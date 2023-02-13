using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Settings settings;

    [SerializeField] private Animator pauseAnimator;

    private bool settingsIn = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !settingsIn)
        {
            Continue();
        }
    }

    public void Continue()
    {
        gameManager.Continue();
    }

    public void Settings()
    {
        settings.SettingsOn();
    }

    public void Quit()
    {
        gameManager.MainMenu();
    }

    public void HidePausePanel(bool state)
    {
        settingsIn = state;
        pauseAnimator.SetBool("settings", state);
    }    
}