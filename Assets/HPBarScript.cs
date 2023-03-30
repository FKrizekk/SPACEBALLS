using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarScript : MonoBehaviour
{
    public Image HPBar;
    public GameObject HPDisplayObject;
    public TextMeshProUGUI HPDisplay;

    // Time taken for the transition.
    public float duration = 1f;

    public float startTime;

    public void Move(PlayerScript player){
        startTime = Time.time;
        StartCoroutine(Moving(player));
    }

    void Start(){
        HPDisplay = HPDisplayObject.GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        HPDisplay.text = ((int)(HPBar.fillAmount*500)).ToString();
    }

    IEnumerator Moving(PlayerScript player)
    {
        while (HPBar.fillAmount != player.health/500)
        {
            float t = (Time.time - startTime) / duration;
            HPBar.fillAmount = Mathf.SmoothStep(HPBar.fillAmount, player.health/500, t);

            yield return null; //return null so it doesnt freeze unity
        }
    }
}