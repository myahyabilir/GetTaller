using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bu class'ta karakterin altına konumlandırılmış olan objenin belirli durumlara göre boyutunun değişimi düzenlenmektedir. 
/// </summary>
public class CubeScaleController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private FloatEvent onObstacleCollided;
    [SerializeField] private VoidEvent onCoinCollected;
    [SerializeField] private BoolEvent onGameFinishedSuccessful;

    private void OnEnable() {
        onObstacleCollided.OnEventRaised += DecreaseScale;
        onCoinCollected.OnEventRaised += IncreaseScale;
    }

    private void OnDisable() {
        onObstacleCollided.OnEventRaised -= DecreaseScale;
        onCoinCollected.OnEventRaised -= IncreaseScale;
    }

    /// <summary>
    /// Objenin engellere çarpması halinde belirlenecek boyutu burada ayarlanmaktadır. Eğer küçülme boyutu objenin scale değerini 0'dan aşağı çekecekse objenin y değeri 0.25f'ye sabitlenir ve oyun fail olur.
    /// </summary>
    /// <param name="scaleDescreaser">CubeInteractor class'ından gelen küçülme değeri</param>
    private void DecreaseScale(float scaleDescreaser)
    {
        if(transform.localScale.y - scaleDescreaser <= 0)
        {
            transform.localScale = new Vector3(1,0.25f,1);
            transform.position -= new Vector3(0, 0.25f/2, 0);
            onGameFinishedSuccessful.Raise(false);
        } 
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y - scaleDescreaser, 1); 
            transform.position -= new Vector3(0, scaleDescreaser/2, 0);
        } 
    }

    /// <summary>
    /// Coin toplanması sonucunda objenin y eksenindeki scale'i herhangi bir artış sınırı olmaksızın 0.25f artırılmaktadır.
    /// </summary>
    private void IncreaseScale()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.25f, transform.localScale.z);
        transform.position += new Vector3(0, 0.25f/2, 0);
    }

}
