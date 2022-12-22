using UnityEngine;

public class Health 
{
    float _maxHealth;
    float _currentHealth;


    public Health(float maxHealth)
    {
        this._maxHealth = maxHealth;
        this._currentHealth = maxHealth;
    }

    

    public void TakeDamage(float damageTaken)
    {
        _currentHealth -= damageTaken;

        if (_currentHealth <= 0){
            Die();
        }
    }

    public void Die()
    {
        // Die
        Debug.Log("Die");
    }
}
