using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Bu class skor sayacını ayarlamaktadır.
/// </summary>
public class CounterController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private IntEvent onScoreGained;
    [SerializeField] private BoolEvent onGameFinishedSuccesful;

    [Header("UI Elements")]
    [SerializeField] private Text scoreTextInHUD;
    [SerializeField] private Text levelTextHUD;
    [SerializeField] private Text scoreTextInMain;
    [SerializeField] private Text levelTextInMain;
    [SerializeField] private Text scoreTextInComplete;
    [SerializeField] private Text levelTextInComplete;
    [SerializeField] private Text coinCollected;

    [Header("Variables")]
    [SerializeField] private IntVariable score;
    private int sceneIndex;
    private int scoreFromPrefs;
    private int levelFromPrefs;


    private void OnEnable() {
        onScoreGained.OnEventRaised += UpdateScoreUI;
        onGameFinishedSuccesful.OnEventRaised += UpdateLevelInPrefs;
    }

    private void OnDisable() {
        onScoreGained.OnEventRaised -= UpdateScoreUI;
        onGameFinishedSuccesful.OnEventRaised -= UpdateLevelInPrefs;

    }
    void Start()
    {   
        score.SetValue(0);

        scoreFromPrefs = PlayerPrefs.GetInt("Score", 0);
        levelFromPrefs = PlayerPrefs.GetInt("Level", 1);

        scoreTextInMain.text = scoreFromPrefs.ToString();
        scoreTextInHUD.text = scoreFromPrefs.ToString();

        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        levelTextInMain.text = "Level "+(levelFromPrefs).ToString();
        levelTextHUD.text = levelFromPrefs.ToString();
        levelTextInComplete.text = "Level "+(levelFromPrefs).ToString();
    }

    /// <summary>
    /// OnScoreGained raise edildiğinde çalışır ve score global integerını günceller
    /// </summary>
    /// <param name="scoreGained"></param>
    private void UpdateScoreUI(int scoreGained)
    {
        
        if((scoreFromPrefs+score.GetValue()) - scoreGained > 0 || scoreGained > 0)
        {
            scoreTextInMain.text = (scoreFromPrefs+score.Increase(scoreGained)).ToString();
            scoreTextInHUD.text = (scoreFromPrefs+score.GetValue()).ToString();
            scoreTextInComplete.text = (scoreFromPrefs+score.GetValue()).ToString();

            PlayerPrefs.SetInt("Score", scoreFromPrefs+score.GetValue());

            coinCollected.text = "You collected "+ score.GetValue();  
        }
        else
        {
            Debug.Log((scoreFromPrefs+score.GetValue()));
            PlayerPrefs.SetInt("Score", 0);
            score.SetValue(0);

            scoreTextInMain.text = "0";
            scoreTextInHUD.text = "0";
            scoreTextInComplete.text = "0";
        }
    }

    private void UpdateLevelInPrefs(bool isSuccesful)
    {
        if(isSuccesful) PlayerPrefs.SetInt("Level", levelFromPrefs+1);
        else PlayerPrefs.SetInt("Level", levelFromPrefs);
    }

}
