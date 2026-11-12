using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
///
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

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Current health: " + currentHealth);
        UpdateDisplay();
    }

    /// <summary>
    ///
    /// </summary>
    public void TakeDamage(int amount)
    {
        StartCoroutine(TakeDamageRoutine(amount));
    }

    /// <summary>
    ///
    /// </summary>
    private IEnumerator TakeDamageRoutine(int amount)
    {
        yield return new WaitForSeconds(actionDelay);
        if (isDead) yield break;

        int absorbed = Mathf.Min(defence, amount);
        defence -= absorbed;
        currentHealth -= amount - absorbed;
        Debug.Log("Current health: " + currentHealth + " Defence: " + defence);
        UpdateDisplay();

        if (currentHealth<=0)
        {
            Die();
        }
    }

    /// <summary>
    ///
    /// </summary>
    public void Heal(int amount)
    {
        StartCoroutine(HealRoutine(amount));
    }

    /// <summary>
    ///
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
        Debug.Log("Current health: " + currentHealth);
        UpdateDisplay();
    }

    /// <summary>
    ///
    /// </summary>
    public void AddDefence(int amount)
    {
        StartCoroutine(AddDefenceRoutine(amount));
    }

    /// <summary>
    ///
    /// </summary>
    private IEnumerator AddDefenceRoutine(int amount)
    {
        yield return new WaitForSeconds(actionDelay);
        if (isDead) yield break;

        defence += amount;
        Debug.Log("Defence: " + defence);
        UpdateDisplay();
    }

    /// <summary>
    ///
    /// </summary>
    private void UpdateDisplay()
    {
        statsText.text = "HP: " + currentHealth + "\nDEF: " + defence;
    }

    /// <summary>
    ///
    /// </summary>
    private void Die()
    {
        isDead = true;
        Debug.Log(gameObject.name + " Enemy has died");
        Destroy(gameObject);
    }
}