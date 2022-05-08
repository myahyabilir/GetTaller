using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Oyun içi UI'ı ayarlayan classtır.
/// </summary>
public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private Image imageToFill;
    [SerializeField] private FloatEvent onProgressChanged;
    
    private void OnEnable() {
        onProgressChanged.OnEventRaised += OnProgressChanged;
    }

    private void OnDisable() {
        onProgressChanged.OnEventRaised -= OnProgressChanged;
    }

    private void OnProgressChanged(float fillAmount) 
    {
        imageToFill.fillAmount = fillAmount;
    }
}
