using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        FindObjectOfType<GameManager>().LoadLastCutScene();
    }
}