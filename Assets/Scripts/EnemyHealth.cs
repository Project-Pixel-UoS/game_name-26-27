using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// This script manages enemy health, damage, defence functionality. 
/// HP and DEF stats are also displayed on the enemy.
/// Before any changes are made to HP/DEF, a delay occurs to allow for transition/animation time. 
/// </summary>

/// <remarks>
/// Maintained by: Ayaan H
/// </remarks>
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50;
    [SerializeField, Min(0f)] private float actionDelay = 1f;
    [SerializeField] private TMP_Text statsText;

    private float currentHealth;
    private int defence;
    private bool isDead;

    /// <summary>
    /// Set current health to maximum specified health (can be changed) and displays used UpdateDisplay().
    /// </summary>
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateDisplay();
    }

    /// <summary>
    /// TakeDamage calls the routine which includes a delay.
    /// </summary>
    public void TakeDamage(int amount)
    {
        StartCoroutine(TakeDamageRoutine(amount));
    }

    /// <summary>
    /// This coroutine applies damage to an enemy by first applying damage to defence.
    /// Remaining damage is then dealt directly to the enemy's health.
    /// If the enemy's health is below 0, the enemy is dead, so its game object is deleted.
    /// </summary>
    private IEnumerator TakeDamageRoutine(int amount)
    {
        yield return new WaitForSeconds(actionDelay);
        if (isDead) yield break;

        int absorbed = Mathf.Min(defence, amount);
        defence -= absorbed;
        currentHealth -= amount - absorbed;
        UpdateDisplay();

        if (currentHealth<=0)
        {
            Die();
        }
    }

    /// <summary>
    /// Heal() calls the coroutine for healing which includes its delay. 
    /// </summary>
    public void Heal(int amount)
    {
        StartCoroutine(HealRoutine(amount));
    }

    /// <summary>
    /// This coroutine adds the specified health to the current health of the enemy.
    /// If that exceeds the enemy's original max health, the current health is set to that max health amount.
    /// </summary>
    private IEnumerator HealRoutine(int amount)
    {
        yield return new WaitForSeconds(actionDelay);
        if (isDead) yield break;

        if (currentHealth+amount>=maxHealth)
        {
            currentHealth=maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        UpdateDisplay();
    }

    /// <summary>
    /// AddDefence() calls the defence coroutine.
    /// </summary>
    public void AddDefence(int amount)
    {
        StartCoroutine(AddDefenceRoutine(amount));
    }

    /// <summary>
    /// Defence is added to the enemy and then displayed
    /// </summary>
    private IEnumerator AddDefenceRoutine(int amount)
    {
        yield return new WaitForSeconds(actionDelay);
        if (isDead) yield break;
        defence += amount;
        UpdateDisplay();
    }

    /// <summary>
    /// Called after the change in every function except for Die(). 
    /// Displays the new HP/DEF stats of the enemy.
    /// </summary>
    private void UpdateDisplay()
    {
        statsText.text = "HP: " + currentHealth + "\nDEF: " + defence;
    }

    /// <summary>
    /// Destroys the enemy GameObject. 
    /// </summary>
    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}