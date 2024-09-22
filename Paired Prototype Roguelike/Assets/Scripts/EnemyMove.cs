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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 dirToTarget = _target.transform.position - _rb.transform.position;
        dirToTarget.Normalize();
        _rb.MovePosition(transform.position + dirToTarget * moveSpeed * Time.fixedDeltaTime);

        transform.rotation = UnityEngine.Quaternion.LookRotation(dirToTarget, Vector3.up);
    }
}
