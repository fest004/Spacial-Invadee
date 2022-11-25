using UnityEngine;

public class BaseAttack : AttackData 
{
  public Transform firePointLeft;
  public Transform firePointRight;
  private Transform firePoint;


  public GameObject baseAttackBullet;

  ObjectPooler objectPooler;

  void Start() {
    firePoint = firePointRight;
    objectPooler = ObjectPooler.Instance;
  }


  void FixedUpdate() {
      if (Input.GetKey(KeyCode.Space)) {
      firerateTimer += 1;
      if (firerateTimer >= firerate) {
        Shoot();
        firerateTimer = 0;
      }
    }
  }

  void Shoot() 
  {
    firePoint = firePoint == firePointLeft ? firePointRight : firePointLeft;

    /*
    if (firePoint == firePointLeft) {
      firePoint = firePointRight;
    } else {
      firePoint = firePointLeft;
    }
    */
    
    objectPooler.SpawnFromPool("BaseAttackBullet", firePoint.transform.position, firePoint.transform.rotation);
    // Instantiate(baseAttackBullet, firePoint.position, firePoint.rotation);

    /*
    GameObject baseAttackBullet = ObjectPool.SharedInstance.GetPooledObject();
      if (baseAttackBullet != null) {
        baseAttackBullet.transform.position = firePoint.transform.position;
        baseAttackBullet.transform.rotation = firePoint.transform.rotation;
        baseAttackBullet.SetActive(true);
        Debug.Log("Shooty McShootShoot");
      }
    */
  }
}

