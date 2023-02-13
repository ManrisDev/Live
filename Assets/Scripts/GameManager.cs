using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject diePanel;
    [SerializeField] private GameObject livesPanel;

    [Header("Animators")]
    [SerializeField] private Animator livesAnimator;
    [SerializeField] private Animator dialogueAnimator;

    [Header("Player")]
    [SerializeField] private Hero movement;

    private bool pause = false;

    public void Start()
    {
        GlobalVar.Set_level_index(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            Pause();
        }
    }

    public void Restart()
    {
        GlobalVar.Set_level_index(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("Loading");
    }

    public void MainMenu()
    {
        //Level_1 build index
        GlobalVar.Set_level_index(3);
        SceneManager.LoadScene("Menu");
    }

    public void LevelComplete()
    {
        SceneManager.LoadScene("Loading");
    }

    public void EndGame()
    {
        livesPanel.SetActive(false);
        diePanel.SetActive(true);
        GlobalVar.Set_level_index(0);
        FindObjectOfType<Hero>().Die();
    }

    public void LoadLastCutScene()
    {
        SceneManager.LoadScene("LastCutScene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Pause()
    {
        pause = true; 
        pausePanel.SetActive(true);
        movement.enabled = false;
        dialogueAnimator.SetBool("pause", true);
        livesAnimator.SetBool("pause", true);
    }

    public void Continue()
    {
        pause = false; 
        pausePanel.SetActive(false);
        movement.enabled = true;
        dialogueAnimator.SetBool("pause", false);
        livesAnimator.SetBool("pause", false);
    }
}