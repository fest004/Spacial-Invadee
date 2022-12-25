using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
  int _maxHealth;
  int _currentHealth;

  int _damage;


  public BaseEnemy(int maxHealth, int currentHealth, int damage, float movementSpeed)
  {
    this._maxHealth = maxHealth;
    this._currentHealth = currentHealth;

    // this. _damage = damage;
  } 

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Player") {
      // .TakeDamage(_damage);
  }

  }
}
