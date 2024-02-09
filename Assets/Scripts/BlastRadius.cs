using UnityEngine;

public class BlastRadius : MonoBehaviour
{
    public float destroyDelay = 3f;

    public void InitiateBlast()
    {
        Destroy(gameObject, destroyDelay);
    }
}
