using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeHealthbar : MonoBehaviour
{

    public Slider healthBar;
    public TMP_Text healthText;
    public int health;
    public int maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health + " / " + maxHealth;
        healthBar.value = (float)health / (float)maxHealth;
    }
}
