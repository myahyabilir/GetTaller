using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Sahne işlemlerinin hallediğildiği class.
/// </summary>
public class SceneMenagement : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private IntEvent onScoreGained;
    [SerializeField] private BoolEvent onGameFinishedSuccesful;

    [Header("Variables")]
    [SerializeField] private IntVariable score;    
    [SerializeField] private BoolVariable isGameStarted;

    private void OnEnable() {
        onGameFinishedSuccesful.OnEventRaised += IsGameStartedChanger;
    }

    private void OnDisable() {
        onGameFinishedSuccesful.OnEventRaised -= IsGameStartedChanger;
    }

    private void IsGameStartedChanger(bool isTrue)
    {
        isGameStarted.SetValue(false);
    }

    public void GoNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1) SceneManager.LoadScene(0);
        else SceneManager.LoadScene(1);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
