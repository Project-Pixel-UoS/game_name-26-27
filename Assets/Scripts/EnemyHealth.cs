using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50;

    private float currentHealth; 
    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Current health: " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log("Current health: " + currentHealth);

        if (currentHealth<=0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;
        if (currentHealth+amount>=maxHealth)
        {
            currentHealth=maxHealth;
        }
        else 
        {
        currentHealth += amount;
        }
        Debug.Log("Current health: " + currentHealth);
    }

    private void Die()
    {
        isDead = true;
        Debug.Log(gameObject.name + "Enemy has died");
        Destroy(gameObject);
    }
    
}
