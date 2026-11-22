using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private double currentHealth = 100;
    private double maxHealth = 100;
    private int currentEnergy = 3;
    private int maxEnergy = 3;
    private double currentDefence;
    private double currentMoney;
    private List<GameObject> cards = new List<GameObject>();
    [SerializeField]private HUDScript ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCurrentHealth(double heal)
    {
        this.currentHealth += heal;
        if (this.currentHealth > maxHealth)
        {
            this.currentHealth = maxHealth;
        }
        else if (this.currentHealth < 0)
        {
            this.currentHealth = 0;
            PlayerDeath();
        }
    }

    void UpdateMaxHealth(double maxhealthIncrement)
    {
        this.maxHealth += maxhealthIncrement;
    }

    void PlayerDeath()
    {
        Debug.Log("Player Died");
    }

    void SetEnergy()
    {

    }

    void SetDefence()
    {

    }

    void SetMoney(double moneyIncrement)
    {
        this.currentMoney += moneyIncrement;
    }

    void UpDateUI()
    {

    }
}
