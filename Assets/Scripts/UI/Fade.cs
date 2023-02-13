using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] private GameObject fadePanel;
    private void Start()
    {
        StartCoroutine(FadeOff());
    }
    IEnumerator FadeOff()
    {
        yield return new WaitForSeconds(2.5f);
        fadePanel.SetActive(false);
    }
}
