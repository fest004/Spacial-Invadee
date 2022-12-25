using UnityEngine;

public class Health 
{
    private int _maxHealth; 
    private int _currentHealth;


    public Health(int maxHealth)
    {
        this._maxHealth = maxHealth;
        this._currentHealth = maxHealth;
    }

    public int GetHealth()
    {
        return this._currentHealth;
    }

    public void Heal(int HealAmount)
    {
        _currentHealth += HealAmount;
        if (_currentHealth > _maxHealth) {
            _currentHealth = _maxHealth;
        }
    }

    public void TakeDamage(int damageTaken)
    {
        _currentHealth -= damageTaken;
        Debug.Log(_currentHealth);

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
