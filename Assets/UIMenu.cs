using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class OptionsData
{
    public static float MusicVolume;
    public static float SfxVolume;
}

public class UIMenu : MonoBehaviour
{
    public static bool musicStarted;
    public static AudioSource TheMusic;

    [SerializeField]
    Button Begin, Options, Exit;
    [SerializeField]
    RectTransform Panel, PanelOpt;
    float Startx, Endx;
    bool isOnMain = true; // false if on options menu

    // Audio
    [SerializeField]
    AudioSource Music, SFX;
    [SerializeField] Slider SliderM, SliderS;
    [SerializeField]
    AudioClip[] Sounds;


    // Start is called before the first frame update
    void Start()
    {
        if (!musicStarted)
        {
            TheMusic = Music;

            Music.Play();
            musicStarted = true;
        }

        Startx = Panel.position.x;
        Endx = PanelOpt.position.x;
        DontDestroyOnLoad(TheMusic.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Panel.position = new Vector2(isOnMain ? Mathf.Lerp(Panel.position.x, Startx, .125f) : Mathf.Lerp(Panel.position.x, Endx * -1, .125f), Panel.position.y);
        PanelOpt.position = new Vector2(!isOnMain ? Mathf.Lerp(PanelOpt.position.x, Startx, .125f) : Mathf.Lerp(PanelOpt.position.x, Endx, .125f), PanelOpt.position.y);

        // Audio
        TheMusic.volume = SliderM.value;
        SFX.volume = SliderS.value;

        OptionsData.MusicVolume = SliderM.value;
        OptionsData.SfxVolume = SliderS.value;
    }
    public void BeginFunct()
    {
        SFX.clip = Sounds[1];
        SFX.Play();
        SceneManager.LoadScene("DemoMap");
    }
    public void OptionsFunct()
    {
        SFX.clip = Sounds[0];
        SFX.Play();
        isOnMain = !isOnMain;
    }
    public void ExitFunct()
    {
        SFX.clip = Sounds[0];
        SFX.Play();
        Application.Quit();
    }

    public void CreditsFunct()
    {
        SFX.clip = Sounds[0];
        SFX.Play();
        SceneManager.LoadScene("Credits");
    }
}
