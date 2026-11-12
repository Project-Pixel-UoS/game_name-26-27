using UnityEngine;

/// <summary>
/// This class is a ScriptableObject that holds data for a card in the game.
/// </summary>

// The CreateAssetMenu attribute allows you to create instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>
public class CardData : ScriptableObject
{
    public string cardName {get; private set;} //The name of the card
    public string cardDescription {get; private set;} //The description of the card
    public Sprite cardImage {get; private set;} //The image of the card

    public int EnergyCost {get; private set;} //The energy cost of the card

    public CardEffectType effectType; //What the card does (Heal, Attack, Defend a)
    public int effectValue {get; private set;} //Value of the Card's effect (Heal 2 HP, Attack for 5 damage, etc.)

}

public enum CardEffectType
{
    Heal,
    Attack,
    Defend,
    Spirit //Spirit Cards are the cards made to be fused with other cards
}
