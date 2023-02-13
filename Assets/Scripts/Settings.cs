using UnityEngine;

public class Settings : MonoBehaviour
{
   [SerializeField] private GameObject settingsPanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsOff();
        }
    }

    public void SettingsOn()
    {
        settingsPanel.SetActive(true);
        FindObjectOfType<PauseMenu>().HidePausePanel(true);
    }

    public void SettingsOff()
    {
        settingsPanel.SetActive(false);
        FindObjectOfType<PauseMenu>().HidePausePanel(false);
    }
}
