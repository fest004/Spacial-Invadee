using UnityEngine;

public class BaseAttack : AttackData 
{
  public Transform firePointLeft;
  public Transform firePointRight;
  private Transform firePoint;
  private float timeLeft;
  private bool canFire;


  public GameObject baseAttackBullet;

  ObjectPooler objectPooler;

  void Start() {
    firePoint = firePointRight;
    objectPooler = ObjectPooler.Instance;
    timeLeft = 0f;
    canFire = true;
  }


  void FixedUpdate() 
  {
    timeLeft -= Time.deltaTime;

    if (timeLeft < 0 && Input.GetKey(KeyCode.Space)) {
      Shoot();
      timeLeft = 20 / roundsPerSecond;
    }

    // if (Input.GetKey(KeyCode.Space )) {
    //   firerateTimer++;
    // }
    // if (firerateTimer >= firerate) {
    //   Shoot();
    //   firerateTimer = 0;
    // }

  }

  void Shoot() 
  {
    firePoint = firePoint == firePointLeft ? firePointRight : firePointLeft;
    objectPooler.SpawnFromPool("BaseAttackBullet", firePoint.transform.position, firePoint.transform.rotation);
  }
}

