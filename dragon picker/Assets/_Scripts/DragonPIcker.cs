using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;

public class DragonPIcker : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent +=GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -=GetLoadSave;
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;
    public TextMeshProUGUI scoreGT;
    private TextMeshProUGUI playerName;
    // Start is called before the first frame update
    void Start()
    {
        if (YandexGame.SDKEnabled == true )
        {
            GetLoadSave();
        }
        shieldList = new List<GameObject>();
        for (int i=1;i <= numEnergyShield;i++){
        GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
        tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
        tShieldGo.transform.localScale = new Vector3(1*i,1*i,1*i);
        shieldList.Add(tShieldGo);
        }
    }
    public List<GameObject> shieldList;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DraggonEggDestroyed()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Draggon egg");
        foreach (GameObject tGO in tDragonEggArray)
        {
            Destroy (tGO);
        }
        int shieldIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);
        if (shieldList.Count == 0)
        {
            GameObject  scoreGO = GameObject.Find("Score");
            scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
            string[] achivList;
            achivList = YandexGame.savesData.achivMent;
            achivList[0] = "Береги щиты !";
            UserSave(int.Parse(scoreGT.text),YandexGame.savesData.bestscore,achivList);
            YandexGame.NewLeaderboardScores("TOPPlayerScore",int.Parse(scoreGT.text));
            SceneManager.LoadScene("_0Scene");
            GetLoadSave();
        }
    }

    public void GetLoadSave()
    {
        Debug.Log(YandexGame.savesData.score);
        GameObject  playerNamePrefabGUI = GameObject.Find("Name");
        playerName = playerNamePrefabGUI.GetComponent<TextMeshProUGUI>();
        playerName.text = YandexGame.playerName;
    }

    public void UserSave(int currentScore,int currentBestScore,string[] currentAchiv)
    {
        YandexGame.savesData.score = currentScore ;
        if (currentScore > currentBestScore)
        {
            YandexGame.savesData.bestscore = currentScore; 
        }
        YandexGame.savesData.achivMent = currentAchiv;
        YandexGame.SaveProgress();
        SceneManager.LoadScene("_0Scene");
    }
}