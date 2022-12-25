using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField]protected Rigidbody2D _rb; 


  [SerializeField]private int _maxHealth; 
  [SerializeField]private int _currentHealth; 

  private Health health;

  void Start() 
  {
    health =  new Health(_maxHealth);
    _currentHealth = health.GetHealth();
  }

  void OnCollisionEnter2D(Collision2D collision) 
  {
    if (collision.collider.tag == "Bullet") {
      DamageObject damageObject = collision.collider.gameObject.GetComponent<DamageObject>();
      Debug.Log(damageObject.GetDamage());
      health.TakeDamage(damageObject.GetDamage());
      _currentHealth = health.GetHealth();
    }
  }


}
