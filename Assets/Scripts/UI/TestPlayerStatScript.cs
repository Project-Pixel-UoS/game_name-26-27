using UnityEngine;

public class TestPlayerStatScript : MonoBehaviour
{
    [SerializeField]private PlayerStats playerstat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestMaxHealthIncrease()
    {
        playerstat.UpdateMaxHealth(10000);
        Debug.Log("New max health: " + playerstat.GetMaxHealth());
    }

    public void TestMaxDecreaseHealth()
    {
        playerstat.UpdateMaxHealth(-87);
        Debug.Log("New current health: " + playerstat.GetCurrentHealth());
        Debug.Log("New max health: " + playerstat.GetMaxHealth());
    }

    public void TestPlayerDeath()
    {
        playerstat.UpdateCurrentHealth(-999999);
        
    }

    public void TestDecreaseCurrentHealth()
    {
        playerstat.UpdateCurrentHealth(-5);
        Debug.Log("New current health: " + playerstat.GetCurrentHealth());
    }

    public void TestCurrentHealthFallsBelow0()
    {
        playerstat.UpdateCurrentHealth(-9999999999);
        Debug.Log("New current health: " + playerstat.GetCurrentHealth());
    }

    public void TestCurrentHealthExceedsMaximum()
    {
        playerstat.UpdateCurrentHealth(playerstat.GetMaxHealth() + 999);
        Debug.Log("New current health" + playerstat.GetCurrentHealth());
    }

    public void TestDecreaseMoney()
    {
        Debug.Log("Money before increment: " + playerstat.GetCurrentMoney());
        playerstat.UpdateMoney(-10);
        Debug.Log("Money after increment: " + playerstat.GetCurrentMoney());
    }

    public void TestDecreaseDefence()
    {
        Debug.Log("Defence before decrease: " + playerstat.GetCurrentDefence());
        playerstat.UpdateDefence(97);
        Debug.Log("Defence after decrease: " + playerstat.GetCurrentDefence());
    }

    public void TestResetDefence()
    {
        playerstat.ResetDefence();
        Debug.Log("Defence after reset: " + playerstat.GetCurrentDefence());
    }

    public void TestResetEnergy()
    {
        playerstat.ResetCurrentEnergy();
        Debug.Log("Current energy after reset: " + playerstat.GetCurrentEnergy());
    }

    public void TestResetMaxEnergy()
    {
        playerstat.ResetMaxEnergy();
        Debug.Log("Max energy after reset: " + playerstat.GetMaxEnergy());
    }

    public void TestDecreaseCurrentEnergy()
    {
        playerstat.UpdateCurrentEnergy(-1);
        Debug.Log("Current energy after decrease: " + playerstat.GetCurrentEnergy());
    }
}
