using UnityEngine;

public class GrowChaining : MonoBehaviour
{
    [SerializeField] GameObject growingObject1, growingObject2, growingObject3;

    void Start()
    {
        Animate();
    }

    /// <summary>
    /// Animates 3 objects to scale to full scale one after another
    /// </summary>
    private void Animate()
    {
        LTSeq sequence = LeanTween.sequence();
        sequence.append(growingObject1.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEaseOutBack());
        sequence.append(growingObject2.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEaseOutBack());
        sequence.append(growingObject3.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setEaseOutBack());
    }
}
