using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private int loadTime;

    void Start()
    {
        StartCoroutine(LoadingLevel());
    }

    IEnumerator LoadingLevel()
    {
        yield return new WaitForSeconds(loadTime);
        int index = GlobalVar.Get_level_index();
        if (index == 0)
            SceneManager.LoadScene(3);
        else
            SceneManager.LoadScene(index + 1);
    }
}