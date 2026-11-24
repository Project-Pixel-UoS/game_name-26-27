using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents the UI in the game
/// </summary>
/// <remarks>
/// Maintained by: Alvin Michael Bijo
/// </remarks>
public class HUDScript : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    public Image healthBar;
    private int energy;
    [SerializeField] private GameObject fuseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Method to pause the game when clicking the pause button
    /// </summary>
    public void PauseButtonClicked()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Method to fuse two cards when the button is clicked
    /// </summary>
    public void FuseButtonClicked()
    {
        fuseMenu.SetActive(true);
    }

    /// <summary>
    /// Method to return from the fuse menu when the back button is clicked.
    /// Places all moved cards back into the hand and sets the fuse menu to inactive.
    /// </summary>
    public void BackButtonClicked()
    {

        List<Transform> children = new List<Transform>();

        foreach (Transform child in fuseMenu.transform.Find("BattleCardSlot").transform)
        {
            children.Add(child);
        }

        foreach (Transform child in fuseMenu.transform.Find("SpiritCardSlot").transform)
        {
            children.Add(child);
        }

        
        foreach (Transform child in children)
        {
            GameObject childObject = child.gameObject;
            if (childObject.CompareTag("Card"))
            {
                childObject.transform.SetParent(GameObject.Find("Content").transform);
                RectTransform cardRectTransform = childObject.GetComponent<RectTransform>();
                cardRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                cardRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                cardRectTransform.pivot = new Vector2(0.5f, 0.5f);

                cardRectTransform.anchoredPosition = Vector2.zero;
                cardRectTransform.localScale = Vector3.one;
            }
        }

        fuseMenu.SetActive(false);
    }
}
