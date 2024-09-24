using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected int exp_value = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            other.GetComponent<PlayerLevels>().add_exp(exp_value);
            Destroy(gameObject);
            
        }
    }
}
