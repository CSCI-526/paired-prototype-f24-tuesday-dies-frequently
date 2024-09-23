using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _target;
    private Rigidbody _rb;

    public float moveSpeed = 0.1f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        SetTarget(GameManager.Instance.Nexus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(!_target)
        {
            SetTarget(GameManager.Instance.Nexus);
        }

        Vector3 dirToTarget = _target.transform.position - _rb.transform.position;
        dirToTarget.y = 0.0f;
        dirToTarget.Normalize();
        _rb.MovePosition(transform.position + dirToTarget * moveSpeed * Time.fixedDeltaTime);

        transform.rotation = UnityEngine.Quaternion.LookRotation(dirToTarget, Vector3.up);
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nexus"))
        {
            collision.gameObject.GetComponent<Nexus>().TakeDamage();
            GetComponent<EnemyHealth>().Die();
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
        }
    }
}
