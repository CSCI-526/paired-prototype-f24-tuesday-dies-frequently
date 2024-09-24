using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : Building
{   
    private float timeSinceLastShot = 0.0f;
    [SerializeField] float fireRate = 5.0f;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gunBarrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(placed)
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        timeSinceLastShot += Time.fixedDeltaTime;
    }

    private void Shoot()
    {
        if ((timeSinceLastShot > 1 / fireRate) && projectile && gunBarrel)
        {
            var bullet = Instantiate(projectile, gunBarrel.transform.position, gunBarrel.transform.rotation);
            timeSinceLastShot = 0;
        }
    }
}
