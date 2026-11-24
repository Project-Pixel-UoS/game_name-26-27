using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DamageNumberScript : MonoBehaviour
{

    public TMP_Text damageText;
    public float timeToFade;
    private float opacityReduction;
    private Color currentColor;

    //Sets the text and opacity each time the script is enabled and disabled
    public void displayText(int damageTaken)
    {
        currentColor = damageText.color;
        currentColor.a = 1f;
        damageText.color = currentColor;
        damageText.text = damageTaken.ToString();
        opacityReduction = Time.deltaTime / timeToFade;
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentColor.a >= 0) {
            currentColor.a = damageText.color.a - opacityReduction;
            damageText.color = currentColor;
        }
        else
            this.enabled = false;
    }
    
}
