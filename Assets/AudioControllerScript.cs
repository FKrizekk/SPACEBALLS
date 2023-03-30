using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControllerScript : MonoBehaviour
{
    public Slider _masterSlider;
    public Slider _sfxSlider;
    public Slider _musicSlider;


    //Clips
    public AudioClip _shoot;
    public AudioClip _hit;
    public AudioClip _hurt;
    public AudioClip _death;
    public AudioClip _laser;
    public AudioClip _blip;
    public AudioClip _spawn;


    //SOURCES
    public AudioSource _s1;
    public AudioSource _s2;
    public AudioSource _s3;
    public AudioSource _s4;
    public AudioSource _s5;

    //MSOURCES
    public AudioSource _ms1;
    public AudioSource _ms2;
    public AudioSource _ms3;
    public AudioSource _ms4;

//-----------------------------------------------------------

    public static Slider masterSlider;
    public static Slider sfxSlider;
    public static Slider musicSlider;

    //Clips
    public static AudioClip shoot;
    public static AudioClip hit;
    public static AudioClip hurt;
    public static AudioClip death;
    public static AudioClip laser;
    public static AudioClip blip;
    public static AudioClip spawn;

    //SOURCES
    public static AudioSource s1;
    public static AudioSource s2;
    public static AudioSource s3;
    public static AudioSource s4;
    public static AudioSource s5;
    

    //MSOURCES
    public static AudioSource ms1;
    public static AudioSource ms2;
    public static AudioSource ms3;
    public static AudioSource ms4;

    public static float masterVolume = 1f;//0-1
    public static float sfxVolume = 1f;//0-1
    public static float musicVolume = 1f;//0-1

    float tempMaster;
    float tempSfx;
    float tempMusic;
    // Start is called before the first frame update
    void Start()
    {
        masterSlider = _masterSlider;
        sfxSlider = _sfxSlider;
        musicSlider = _musicSlider;

        shoot = _shoot;
        hit = _hit;
        hurt = _hurt;
        death = _death;
        laser = _laser;
        blip = _blip;
        spawn = _spawn;
        
        //SOURCES
        s1 = _s1;
        s2 = _s2;
        s3 = _s3;
        s4 = _s4;
        s5 = _s5;

        //MSOURCES
        ms1 = _ms1;
        ms2 = _ms2;
        ms3 = _ms3;
        ms4 = _ms4;


        //Playerprefs loading
        masterVolume = PlayerPrefs.GetFloat("MASTERVOL");
        sfxVolume = PlayerPrefs.GetFloat("SFXVOL");
        musicVolume = PlayerPrefs.GetFloat("MUSICVOL");
        s1.volume = masterVolume * sfxVolume;
        s2.volume = masterVolume * sfxVolume;
        s3.volume = masterVolume * sfxVolume;
        s4.volume = masterVolume * sfxVolume;
        s5.volume = masterVolume * sfxVolume;
        masterSlider.GetComponent<Slider>().value = masterVolume;
        sfxSlider.GetComponent<Slider>().value = sfxVolume;
        musicSlider.GetComponent<Slider>().value = musicVolume;
    }

    void Update(){

        if(Input.GetKey("t")){
            //StartCoroutine(Jukebox());
        }
    }

    // IEnumerator Jukebox(){
    //     //s5.Play(FeelGood,musicVolume);
    //     // yield return new WaitForSeconds(10);
    //     // source.Play(Song2,musicVolume);
    //     yield return null;
    // }

    public void master(){
        tempMaster = masterSlider.GetComponent<Slider>().value;
    }

    public void masterApply(){
        masterVolume = tempMaster;
        s1.volume = masterVolume * sfxVolume;
        s2.volume = masterVolume * sfxVolume;
        s3.volume = masterVolume * sfxVolume;
        s4.volume = masterVolume * sfxVolume;
        s5.volume = masterVolume * sfxVolume;
    }

    public void sfx(){
        tempSfx = sfxSlider.GetComponent<Slider>().value;
    }

    public void sfxApply(){
        sfxVolume = tempSfx;
        s1.volume = masterVolume * sfxVolume;
        s2.volume = masterVolume * sfxVolume;
        s3.volume = masterVolume * sfxVolume;
        s4.volume = masterVolume * sfxVolume;
        s5.volume = masterVolume * sfxVolume;
    }

    public void music(){
        tempMusic = musicSlider.GetComponent<Slider>().value;
    }

    public void musicApply(){
        musicVolume = tempMusic;
        ms1.volume = masterVolume * musicVolume;
        ms2.volume = masterVolume * musicVolume;
        ms3.volume = masterVolume * musicVolume;
        ms4.volume = masterVolume * musicVolume;
    }

    public static void Play(string clip){
        switch (clip)
        {
            default:
                break;
            case "shoot1":
                s1.PlayOneShot(shoot);
                break;
            case "hit":
                s2.PlayOneShot(hit);
                break;
            case "hurt":
                s3.PlayOneShot(hurt);
                break;
            case "death":
                s4.PlayOneShot(death);
                break;
            case "laser":
                s5.PlayOneShot(laser);
                break;
            case "blip":
                s1.PlayOneShot(blip);
                break;
            case "spawn":
                s2.PlayOneShot(spawn);
                break;
        }
    }
}