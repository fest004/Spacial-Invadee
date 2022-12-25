using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
  [SerializeField]private int _damage;


  public DamageObject(int damage)
  {
    this._damage = damage;
  }

  public int GetDamage()
  {
    return _damage;
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Player") {
      Destroy(gameObject);
    }
  }
}
