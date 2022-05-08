using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Bu class karakterin aşağısına konumlanmış objenin hareketini sağlamaktadır. 
/// </summary>
public class CubeMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private BoolVariable isGameStarted;
    [SerializeField] private FloatVariable movementSpeed;
    [SerializeField] private FloatVariable dragSpeed;
    private Vector3 position;

    [Header("Events")]
    [SerializeField] private Vector2Event onDrag;
    [SerializeField] private FloatEvent onProgressChanged;

    [Header("Tranforms")]
    [SerializeField] private Transform floor;

    private void OnEnable() {
        onDrag.OnEventRaised += DragCube;
    }

    private void OnDisable() {
        onDrag.OnEventRaised -= DragCube;
    }

    private void Start() {
        isGameStarted.SetValue(false);
    }

    private void Update() {
        if(!isGameStarted.GetValue()) return;
        GoForward();

        //Aşağıdaki işlem objenin x değerini clamplemektedir. İşlemin gerçekleştirmenin en optimize şeklinin bu olmadığının bilincindeyim. 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, transform.position.z);

        onProgressChanged.Raise(transform.position.z / floor.localScale.z);
        
    }


    /// <summary>
    /// Objenin x yönündeki hareketi belirlenmektedir. Kullanıcı parmağını kaldırana kadar bu fonksiyon çalışmaktadır.
    /// </summary>
    /// <param name="movement">InputController'daki Vector2 eventinden gelen parametre</param>
    private void DragCube(Vector2 movement){
        if(!isGameStarted.GetValue()) return;
        position.x = movement.x;
        transform.Translate(position * Time.deltaTime * dragSpeed.GetValue());    
    }

    /// <summary>
    /// Objenin ileri yönlü hareketi sağlanır
    /// </summary>
    private void GoForward()
    {
        transform.Translate(new Vector3(0, 0, 1f) * Time.deltaTime * movementSpeed.GetValue());
    }
}
