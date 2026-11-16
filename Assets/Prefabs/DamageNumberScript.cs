using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DamageNumberScript : MonoBehaviour
{

    public TMP_Text damageText;
    public float timeToFade;
    public int damageTaken;
    public float opacityReduction;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damageText.text = damageTaken.ToString();
        opacityReduction = Time.deltaTime / timeToFade;
    }

    // Update is called once per frame
    void Update()
    {
        FadeOut();
    }
    public IEnumerator FadeOut()
    {
        Color currentColor = damageText.color;
        currentColor.a = damageText.color.a - opacityReduction;
        damageText.color = currentColor;
        return null;
    }
}
