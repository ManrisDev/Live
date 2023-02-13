using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private int firstPlayInt;
    public Slider musicSlider;
    private float musicFloat;
    public AudioSource[] musicAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            musicFloat = 0.25f;
            musicSlider.value = musicFloat;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }

        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
    }

    private void OnApplicationFocus(bool infocus)
    {
        if (!infocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        for (int i = 0; i < musicAudio.Length; i++)
        {
            musicAudio[i].volume = musicSlider.value;
        }
        
    }
}
