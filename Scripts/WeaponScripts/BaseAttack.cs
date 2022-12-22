using UnityEngine;

public class BaseAttack : AttackData 
{
  public Transform firePointLeft;
  public Transform firePointRight;
  private Transform firePoint;

  public float baseDamage;
  public float scaleDamage;
  public float currentDamage;
  public float firerate;
  protected int firerateTimer;

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

    objectPooler.SpawnFromPool("BaseAttackBullet", firePoint.transform.position, firePoint.transform.rotation);
  }
}

