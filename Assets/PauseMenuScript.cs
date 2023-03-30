using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public AudioControllerScript acs;
    public Animator anim;
    bool menuShown = false;
    public static bool menuShown_ = false;

    public Slider VSyncSlider;
    int vsync;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("VSYNC") == 1){
            QualitySettings.vSyncCount = 1;
            VSyncSlider.GetComponent<Slider>().value = 1;
        }else{
            QualitySettings.vSyncCount = 0;
            VSyncSlider.GetComponent<Slider>().value = 0;
        }
        vsync = PlayerPrefs.GetInt("VSYNC");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuShown){
            ShowMenu();
        }else if(Input.GetKeyDown(KeyCode.Escape) && menuShown){
            HideMenu();
        }
    }

    public void ShowMenu(){
        //Update sliders to their real value
        VSyncSlider.GetComponent<Slider>().value = vsync;
        AudioControllerScript.masterSlider.GetComponent<Slider>().value = AudioControllerScript.masterVolume;
        AudioControllerScript.sfxSlider.GetComponent<Slider>().value = AudioControllerScript.sfxVolume;
        AudioControllerScript.musicSlider.GetComponent<Slider>().value = AudioControllerScript.musicVolume;

        Time.timeScale = 0f;
        anim.SetBool("ShowMenu",true);
        menuShown = true;
        menuShown_ = true;
    }

    public void HideMenu(){
        Time.timeScale = 1f;
        anim.SetBool("ShowMenu",false);
        menuShown = false;
        menuShown_ = false;
    }

    public void ApplyAudioButton(){
        Debug.Log("APPLIED");
        PlayerPrefs.SetFloat("MASTERVOL", AudioControllerScript.masterVolume);
        PlayerPrefs.SetFloat("SFXVOL", AudioControllerScript.sfxVolume);
        PlayerPrefs.SetFloat("MUSICVOL", AudioControllerScript.musicVolume);
        acs.masterApply();
        acs.sfxApply();
        acs.musicApply();
    }

    public void ApplyVideoButton(){
        vsync = (int)VSyncSlider.GetComponent<Slider>().value;
        QualitySettings.vSyncCount = vsync;
        PlayerPrefs.SetInt("VSYNC",vsync);
    }

    public void VSyncButton(){
        if(VSyncSlider.GetComponent<Slider>().value == 1){
            VSyncSlider.GetComponent<Slider>().value = 0;
        }else{
            VSyncSlider.GetComponent<Slider>().value = 1;
        }
    }

    public void QuitButton(){
        Application.Quit();
    }
}
