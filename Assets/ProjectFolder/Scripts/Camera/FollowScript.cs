using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bu class kameranın takip ettiği boş objenin işlemlerini düzenler.
/// </summary>
public class FollowScript : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform cube;

    [Header("Events")]
    [SerializeField] private FloatEvent onObstacleCollided;
    [SerializeField] private VoidEvent onCoinCollected;
    
    [Header("Variables")]
    [SerializeField] private BoolVariable isGameStarted;
    private float yValue;
     
    
    private void OnEnable() {
        onObstacleCollided.OnEventRaised += DecreaseY;
        onCoinCollected.OnEventRaised += IncreaseY;
    }

    private void OnDisable() {
        onObstacleCollided.OnEventRaised -= DecreaseY;
        onCoinCollected.OnEventRaised -= IncreaseY;
    }

    private void Start() {
        yValue = transform.position.y;
    }

    private void Update() {
        transform.position = new Vector3(transform.position.x, yValue, cube.position.z);
    }

    /// <summary>
    /// Boş objenin y değeri düşürülerek kameranın her engele çarpma sonucu biraz daha aşağıdan bakması sağlanır.
    /// </summary>
    /// <param name="descreaseValue"></param>
    private void DecreaseY(float descreaseValue)
    {
        if(!isGameStarted.GetValue()) return;
        yValue -= descreaseValue;
    }

    /// <summary>
    /// Boş objenin y değeri artırılarak kameranın her coin toplama sonucu biraz daha yukarıdan bakması sağlanır.
    /// </summary>
    private void IncreaseY()
    {
        if(!isGameStarted.GetValue()) return;
        yValue += 0.25f;
    }

}
