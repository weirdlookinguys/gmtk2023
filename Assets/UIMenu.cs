using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
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
        Startx = Panel.position.x;
        Endx = PanelOpt.position.x;
        DontDestroyOnLoad(Music.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Panel.position = new Vector2(isOnMain ? Mathf.Lerp(Panel.position.x, Startx, .125f) : Mathf.Lerp(Panel.position.x, Endx * -1, .125f), Panel.position.y);
        PanelOpt.position = new Vector2(!isOnMain ? Mathf.Lerp(PanelOpt.position.x, Startx, .125f) : Mathf.Lerp(PanelOpt.position.x, Endx, .125f), PanelOpt.position.y);

        // Audio
        Music.volume = SliderM.value;
        SFX.volume = SliderS.value;
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
