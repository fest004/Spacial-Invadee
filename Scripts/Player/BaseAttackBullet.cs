using UnityEngine;

public class BaseAttackBullet : AttackData, InterfacePooledObject
{
  public Rigidbody2D bulletRB;


  public void OnObjectSpawn() 
  {
    bulletRB.velocity = transform.up * bulletSpeed;
  }

  void OnTriggerEnter2D(Collider2D hitInfo) 
  {
    if (hitInfo.tag == "hitableObject")
    {
    gameObject.SetActive(false);
    // Destroy(gameObject);
    Debug.LogWarning(hitInfo.tag);
    } else {
    Debug.LogWarning(hitInfo.tag);
    }
    // Debug.LogWarning(hitInfo.tag);
    // gameObject.SetActive(false);

  }
}
