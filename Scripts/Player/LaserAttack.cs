using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : AttackData
{

    public Transform firePoint;
    public float maxFirePower;
    private float firePower = 0;    

    public GameObject LaserAttackRay;

    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
       if (Input.GetKey(KeyCode.Q) && firePower < maxFirePower) {
           firePower++;
           if (firePower >= maxFirePower) {
               Shoot(firePower);
                firePower = 0;
           }
       }
       
    }

    void Shoot(float firePower) 
    {
        
    }
}
