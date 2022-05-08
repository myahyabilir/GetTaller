using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralUIManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private BoolEvent onGameFinishedSuccesful;

    [Header("UI Elements")]
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject levelCompledtePanel;
    [SerializeField] private GameObject levelFailedPanel;
    [SerializeField] private GameObject mainPanel;

    [Header("Variables")]
    private bool isCoroutinePlayed = false;
    [SerializeField] private BoolVariable isGameStarted;


    private void OnEnable() {
        onGameFinishedSuccesful.OnEventRaised += AdjustUI;
    }

    private void OnDisable() {
        onGameFinishedSuccesful.OnEventRaised -= AdjustUI;

    }
    private void AdjustUI(bool isSuccesful)
    {
        if(isSuccesful)
        {
            hudPanel.SetActive(false);
            levelCompledtePanel.SetActive(true);
        }
        else
        {
            hudPanel.SetActive(false);
            levelFailedPanel.SetActive(true);
        }
    }

    public void StartHUD()
    {
        hudPanel.SetActive(true);
        mainPanel.SetActive(false);
        levelFailedPanel.SetActive(false);
        levelCompledtePanel.SetActive(false);
    }


    public void StartGame()
    {
        if(!isCoroutinePlayed)
            StartCoroutine("WaitAndStart");
    }

    private IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(0.3f);
        isGameStarted.SetValue(true);
        isCoroutinePlayed = true;
    }
}
