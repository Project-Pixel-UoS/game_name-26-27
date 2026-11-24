using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeHealthbar : MonoBehaviour
{

    public Slider healthBar;
    public TMP_Text healthText;
    private EnemyHealth stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = stats.currentHealth + " / " + stats.maxHealth;
        healthBar.value = (float)stats.currentHealth / (float)stats.maxHealth;
    }
}
