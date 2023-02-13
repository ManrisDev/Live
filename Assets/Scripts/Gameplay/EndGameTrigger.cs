using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            FindObjectOfType<GameManager>().EndGame();
    }
}
