using UnityEngine;
using UnityEngine.SceneManagement;

public class Mole : Entity
{
    [SerializeField] private GameObject mole;
    [SerializeField] private GameObject moth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<Hero>().Take_Damage(2);
        mole.SetActive(false);
        moth.SetActive(true);

        if (SceneManager.GetActiveScene().name == "Level_2")
        {
            FindObjectOfType<Pugovka>().MovePug();
        }
    }
}
