using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is the script that manages the player stats and their deck of cards.
/// The currentMoney the user has should be saved even after the user exits 
/// the game which has not yet been implemented
/// </summary>
/// <remarks>
/// Maintained by: Alvin Michael Bijo
/// </remarks>
public class PlayerStats : MonoBehaviour
{
    public double currentHealth = 100;
    public double GetCurrentHealth() {  return currentHealth; }
    private double maxHealth = 100;
    public double GetMaxHealth() { return maxHealth; }
    private int currentEnergy = 3;
    public int GetCurrentEnergy() { return currentEnergy; }
    private int maxEnergy = 3;
    public int GetMaxEnergy() { return currentEnergy; }
    private double currentDefence = 0;
    public double GetCurrentDefence() {  return currentDefence; }
    private double currentMoney = 1000;
    public double GetCurrentMoney() { return currentMoney; }
    [SerializeField]private List<GameObject> cards = new List<GameObject>();
    [SerializeField]private GameObject ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Method to update the current health and ensure it doesnt exceed the Max
    /// Health or fall below zero, if the health falls below 0, a Game over screen 
    /// is displayed. 
    /// </summary>
    /// <param name="healthAdd"> The amount of health to be added to the player. 
    /// (Use negqtive values to decrease the health)<param>
    public void UpdateCurrentHealth(double healthAdd)
    {
        this.currentHealth += healthAdd;
        if (this.currentHealth > maxHealth)
        {
            this.currentHealth = maxHealth;
        }
        else if (this.currentHealth < 0)
        {
            this.currentHealth = 0;
            PlayerDeath();
        }
        UpDateUI();
    }

    /// <summary>
    /// Method to increase or decrease the maximum health of the user and calls 
    /// the UpdateCurrentHealth to make sure the currentHealth doesnt exceed the 
    /// maximum health
    /// </summary>
    /// <param name="maxhealthIncrement">Specifies the amount of health to be added to the max health.
    /// (Use negative values to decrease health by specified value)</param>
    public void UpdateMaxHealth(double maxhealthIncrement)
    {
        double maxhealthBefore = this.GetMaxHealth();
        this.maxHealth += maxhealthIncrement;
        double maxhealthAfter = this.GetMaxHealth();
        UpdateCurrentHealth((maxhealthAfter - maxhealthBefore));
        UpDateUI();
    }

    /// <summary>
    /// Method to log the player died and display the Game Over scene
    /// After loading the Game Over scene, the Game time is paused.
    /// </summary>
    void PlayerDeath()
    {
        Debug.Log("Player Died");
        SceneTransition.instance.TransitionScene("Game Over");
        // Time.timeScale = 0f; Commented out because the scene transition system will not work if time is paused

    }

    /// <summary>
    /// Method to increase or decrease the current energy the player has.
    /// If the current energy exceeds the max energy, the current energy is set to 
    /// the max energy.(Use negative values to decrease energy)
    /// Make sure to call the HasEnergy() function to check if the user has enough energy to spend
    /// </summary>
    /// <param name="energyIncrement">Specifies the amount of energy to be added. </param>
    public void UpdateCurrentEnergy(int energyIncrement)
    {
        this.currentEnergy += energyIncrement;
        if (this.currentEnergy > maxEnergy)
        {
            this.currentEnergy = maxEnergy;
        }
        else if (this.currentEnergy < 0)
        {
            this.currentEnergy = 0;
        }
        UpDateUI();
    }

    /// <summary>
    /// Method to check if the user has energy to spend
    /// </summary>
    /// <param name="energyCost"> Specifies the energy cost of the action </param>
    /// <returns> True if the user has energy to spend and false if they don't </returns>
    public bool HasEnergy(int energyCost)
    {
        if ((this.currentEnergy -= energyCost) < 0)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Method to add to Max energy.
    /// (Use negative values to decrease Max energy)
    /// </summary>
    /// <param name="maxEnergyIncrement">Specifes the amount of energy to be added to the player's </param>
    public void UpdateMaxEnergy(int maxEnergyIncrement)
    {
        this.maxEnergy += maxEnergyIncrement;
        if (this.maxEnergy < 0)
        {
            this.maxEnergy = 0;
        }
        UpDateUI();
    }

    /// <summary>
    /// Method to reset the current energy to default (3)
    /// </summary>
    public void ResetCurrentEnergy()
    {
        this.currentEnergy = 3;
        UpDateUI();
    }

    /// <summary>
    /// Method to reset Max energy to default (3)
    /// </summary>
    public void ResetMaxEnergy()
    {
        this.maxEnergy = 3;
        UpdateCurrentEnergy(this.currentEnergy);
    }

    /// <summary>
    /// Method to add defence to the user.
    /// (Use negative values to decrease the defence)
    /// </summary>
    /// <param name="defenceChange"> Specifies the value to be added to player's defence</param>
    public void UpdateDefence(double defenceChange)
    {
        this.currentDefence += defenceChange;
        if (this.currentDefence < 0)
        {
            this.currentDefence = 0;
        }
        UpDateUI();
    }

    /// <summary>
    /// Method to reset the player's defence to default (0)
    /// </summary>
    public void ResetDefence()
    {
        this.currentDefence = 0;
    }

    /// <summary>
    /// Method to add value to the player's money.
    /// (Use negative values to decrease player's money)
    /// Make sure to call the HasMoney() method to check if the user 
    /// has enough money before deducting the money
    /// </summary>
    /// <param name="moneyIncrement">TSpecifies the value to be added to the player's money</param>
    public void UpdateMoney(double moneyIncrement)
    {
        this.currentMoney += moneyIncrement;
        if (this.currentMoney < 0)
        {
            currentMoney = 0;
        }
        UpDateUI();
    }

    /// <summary>
    /// Method to check if the user has enough money to buy stuff
    /// </summary>
    /// <param name="cost">Specifies the cost of the item the user wishes to purchase</param>
    /// <returns>True if the user has enough money to buy the item and false if they don't</returns>
    public bool HasMoney(double cost)
    {
        this.currentMoney -= cost;
        if(this.currentMoney < 0)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Method to add a new card to the list of card prefabs
    /// </summary>
    /// <param name="newCard">Specfies the new card prefab to be added to the player's list of cards</param>
    public void AddNewCard(GameObject newCard)
    {
        cards.Add(newCard);
    }

    /// <summary>
    /// Code to Update UI goes here, This function is called whenever user stats change
    /// </summary>
    void UpDateUI()
    {
         // The methods to set Player stats in the UI is missing in the HUD script
         // After adding the methods to set the elements in the UI, you can use 
         // the UI refernence variable (ui) to change each element of the UI according
         // to the Instance variables in this script
    }
}
