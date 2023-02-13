using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject settingsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Loading");
    }

    public void Settings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
   
}
