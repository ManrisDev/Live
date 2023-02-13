using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launch_intro_wait : MonoBehaviour
{
    public int waitTime;
    void Start()
    {
        StartCoroutine(WaitForLevel());
    }

    IEnumerator WaitForLevel()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
