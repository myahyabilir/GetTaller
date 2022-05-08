using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bu class'ta karakterin altına yerleştirilmiş objenin yoldaki engeller ve ögeler ile etkileşiminden ortaya çıkacak durumlar düzenlenmiştir.
/// </summary>
public class CubeInteractor : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private IntEvent onScoreGained;
    [SerializeField] private BoolEvent onGameFinishedSuccessful;
    [SerializeField] private FloatEvent onObstacleCollided;
    [SerializeField] private VoidEvent onCoinCollected;
    [SerializeField] private VoidEvent onFinishLineReached;

    [Header ("Layer Masks")]
    [SerializeField] private LayerMask coinLayer;
    [SerializeField] private LayerMask smallObstacleLayer;
    [SerializeField] private LayerMask bigObstacleLayer;
    [SerializeField] private LayerMask finishObjectLayer;
    [SerializeField] private LayerMask finishLineLayer;

    [Header("Pooler")]
    [SerializeField] private PoolController pooler;

    private void OnTriggerEnter(Collider other) {
        if((1 << other.gameObject.layer & finishObjectLayer) != 0)
        {
            onGameFinishedSuccessful.Raise(true);
        }

        if((1 << other.gameObject.layer & coinLayer) != 0)
        {
            onCoinCollected.Raise();
            onScoreGained.Raise(25);

            pooler.SpawnFromPool("Star", transform.position + Vector3.up*2, Quaternion.identity);
            other.gameObject.SetActive(false);
            
        }

        if((1 << other.gameObject.layer & smallObstacleLayer) != 0)
        {
            onScoreGained.Raise(-25);
            onObstacleCollided.Raise(0.25f);

            pooler.SpawnFromPool("Lightning", other.transform.position + Vector3.up, Quaternion.identity);
            other.gameObject.SetActive(false);
            
        }

        if((1 << other.gameObject.layer & bigObstacleLayer) != 0)
        {
            onScoreGained.Raise(-50);
            onObstacleCollided.Raise(0.5f);

            pooler.SpawnFromPool("Lightning", other.transform.position + Vector3.up, Quaternion.identity);
            other.gameObject.SetActive(false);
            
        }

        if((1 << other.gameObject.layer & finishLineLayer) != 0)
        {
            onFinishLineReached.Raise();
            for(int i = -4; i < 4; i++){
                pooler.SpawnFromPool("Firework", new Vector3(i, 1, 210), Quaternion.identity);
            }
                       
        }
    }


}
