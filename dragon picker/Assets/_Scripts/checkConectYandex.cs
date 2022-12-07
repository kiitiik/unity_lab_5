using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;

public class checkConectYandex : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
    private TextMeshProUGUI scoreBest;
    
    // Start is called before the first frame update
    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            CheckSDK();
        }
    }

    public void CheckSDK()
    {
       
        if(YandexGame.auth == true)
        {
            Debug.Log("user authorization ok ");
        }
        else
        {
            Debug.Log("user not authorization ");
            YandexGame.AuthDialog();
        }
        GameObject  scoreBO = GameObject.Find("BestScore");
        scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
        scoreBest.text = "Best Score: " + YandexGame.savesData.bestscore.ToString();
        if ((YandexGame.savesData.achivMent)[0] == null & !GameObject.Find("ListAchive") )
        {

        }
        else
        {
            foreach(string value in YandexGame.savesData.achivMent)
            {
                GameObject.Find("ListAchive").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ListAchive").GetComponent<TextMeshProUGUI>().text + value +"\n";
            }
        }
    
    }
}
