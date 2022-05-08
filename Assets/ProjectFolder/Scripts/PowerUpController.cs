using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    private Button buttonComponent;
    [SerializeField] private GameObject background;
    [SerializeField] private FloatVariable speed;

    private void Start() {
        speed.SetValue(15);
    }
    public void PowerUpUsed()
    {
        StartCoroutine("SpeedUp");
        background.SetActive(false);
        GetComponent<Button>().interactable = false;
        GetComponent<Image>().enabled = false;
    }

    private IEnumerator SpeedUp()
    {
        speed.Increase(speed.GetValue());
        yield return new WaitForSeconds(5f);
        speed.Increase(-(speed.GetValue()/2));
    }


}
