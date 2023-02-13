using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            FindObjectOfType<GameManager>().LevelComplete();
    }
}
