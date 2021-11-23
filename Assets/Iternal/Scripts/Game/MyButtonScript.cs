using UnityEngine;
using System.Collections;

public class MyButtonScript : MonoBehaviour
{
    private bool isRacePressed;
    [SerializeField] private int val;

    private void Update(){
        if (isRacePressed) ButtonPressed();
    }
    private void ButtonPressed(){
        UI_Controller.Instance.R_ButtonPressed(val);
    }
    private IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
        isRacePressed = true;
    }

    public void onPointerDownRaceButton()
    {
        StartCoroutine(Wait());
    }
    public void onPointerUpRaceButton()
    {
        isRacePressed = false;
        StopAllCoroutines();
    }
}