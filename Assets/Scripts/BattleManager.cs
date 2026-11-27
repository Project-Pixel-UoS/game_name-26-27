using UnityEngine;

/// <summary>
/// This is the script that will be used to manage the battle system. 
/// It's main responsibility will be to manage the battle flow. 
/// It'll do this by executing BattleActions objects.
/// A BattleAction is a class that will be used for all the actions that can happen in a battle,
/// like attacking, defending, healing, etc. By calling the Execute() method of a BattleAction, the action will be executed and the battle flow will continue.
/// This script manages the order of these BattleActions, as well as their timings, and other important battle data.
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>
public class BattleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
