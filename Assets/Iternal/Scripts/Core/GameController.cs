using UnityEngine;

public class GameController : MonoBehaviour
{
    // private static class Clr : Color32{
    //     public static Color32 ChangeColor(GameObject target, byte r){
    //         var color = UI_Controller.GetColor(target);
    //         color.r += r;
    //         return color;
    //     }
    //     public static Color32 ChangeColor(GameObject target, byte g){
    //         var color = UI_Controller.GetColor(target);
    //         color.g += g;
    //         return color;
    //     }
    //     public static Color32 ChangeColor(GameObject target, byte b){
    //         var color = UI_Controller.GetColor(target);
    //         color.b = b;
    //         return color;
    //     }
    // }

    private GameObject _target;

    private void Start(){
        UI_Controller.Instance.RedColorChangedEvent += RedColorChanged;
        UI_Controller.Instance.GreenColorChangedEvent += GreenColorChanged;
        UI_Controller.Instance.BlueColorChangedEvent += BlueColorChanged;
    }
    private void OnDestroy(){
        UI_Controller.Instance.RedColorChangedEvent -= RedColorChanged;
        UI_Controller.Instance.GreenColorChangedEvent -= GreenColorChanged;
        UI_Controller.Instance.BlueColorChangedEvent -= BlueColorChanged;
    }

    public void ObjPicked(GameObject obj){
        _target = obj;
        var color = UI_Controller.GetColor(obj);
        UI_Controller.Instance.SetColor(obj, color);
    }

    private void RedColorChanged(int val){
        var color = UI_Controller.GetColor(_target);

        var intR = color.r + val;
        byte r = 0;

        if (intR < 0) r = byte.MaxValue;
        else if (intR > 255) r = byte.MinValue;
        else r = System.Convert.ToByte(intR);

        color.r = r;

        UI_Controller.Instance.SetColor(_target, color);
    }
    private void GreenColorChanged(float val){
        var color = UI_Controller.GetColor(_target);
        color.g = System.Convert.ToByte(val * 255);

        UI_Controller.Instance.SetColor(_target, color);
    }
    private void BlueColorChanged(){
        var color = UI_Controller.GetColor(_target);
        color.b = System.Convert.ToByte(Random.Range(byte.MinValue, byte.MaxValue + 1));

        UI_Controller.Instance.SetColor(_target, color);
    }
}