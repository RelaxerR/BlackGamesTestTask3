using UnityEngine;

public class ColorController : MonoBehaviour
{
    private GameObject MainObj;

    private void Start(){
        MainObj = GameObject.FindWithTag("Player");
        if (this.gameObject.name == "Cube") OnMouseDown();
    }

    public void OnMouseDown(){
        GetGameController().ObjPicked(this.gameObject);
    }
    private GameController GetGameController(){
        return MainObj.GetComponent<GameController>();
    }
}