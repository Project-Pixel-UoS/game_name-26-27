using UnityEngine;
using System.Collections;

public abstract class BaseBattleAction
{
    public float actionDelay = 1f;
    public abstract IEnumerator Execute();
}
