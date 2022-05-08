using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objenin üzerindeki karakterin hareketleri burada düzenlenmektedir. 
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform topPointOfCube;

    private void LateUpdate() {
        transform.position = topPointOfCube.position;
    }
}
