using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBarScript : MonoBehaviour
{
    public Image HPBar;
    public Text HPDisplay;

    // Time taken for the transition.
    public float duration = 1f;

    public float startTime;

    public void Move(EnemyScript enemy){
        startTime = Time.time;
        StartCoroutine(Moving(enemy));
    }

    public void UpdateHPText(EnemyScript enemy){
        HPDisplay.text = ((int)(HPBar.fillAmount*enemy.health)).ToString();
    }

    IEnumerator Moving(EnemyScript enemy)
    {
        while (HPBar.fillAmount != enemy.health/200)
        {
            float t = (Time.time - startTime) / duration;
            HPBar.fillAmount = Mathf.SmoothStep(HPBar.fillAmount, enemy.health/enemy.healthMAX, t);

            yield return null; //return null so it doesnt freeze unity
        }
    }
}