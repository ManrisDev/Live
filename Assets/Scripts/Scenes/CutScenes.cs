using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutScenes : MonoBehaviour
{
    public int actualCutScene;
    public Sprite[] cutScenes;
    public Image MainCutScene;
    public bool isLastCutScene = false;

    void Start()
    {
        MainCutScene.sprite = cutScenes[0];
    }
    public void NextSlide()
    {
        actualCutScene += 1;
        if (actualCutScene >= cutScenes.Length)
        {
            if (isLastCutScene == true)
            {
                FindObjectOfType<GameManager>().LoadCredits();
            }
            else
            {
                GlobalVar.Set_level_index(3);
                SceneManager.LoadScene("Loading");
            }
        }
        MainCutScene.sprite = cutScenes[actualCutScene];
    }
}
