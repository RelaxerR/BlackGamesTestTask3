using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] public GameObject _target { get; private set; }

    public static GameController Instance;
    public event Action<Color32> ObjColorChangedEvent;

    private void Awake(){
        Instance = this;
    }

    public void ObjPicked(GameObject obj){
        _target = obj;

        var color = obj.GetComponent<ColorController>()._cubeColor.GetColor();
        ObjColorChangedEvent?.Invoke(color);
    }

    private Color32 GetColor(){
        return _target.GetComponent<ColorController>()._cubeColor.GetColor();
    }

    public void RedColorChanged(int val){
        var color = GetColor();

        var intR = color.r + val;
        byte r = 0;

        if (intR < 0) r = byte.MaxValue;
        else if (intR > 255) r = byte.MinValue;
        else r = System.Convert.ToByte(intR);

        color.r = r;

        ObjColorChangedEvent?.Invoke(color);
    }
    public void GreenColorChanged(float val){
        var color = GetColor();
        color.g = System.Convert.ToByte(val * 255);

        ObjColorChangedEvent?.Invoke(color);
    }
    public void BlueColorChanged(){
        var color = GetColor();
        color.b = System.Convert.ToByte(UnityEngine.Random.Range(byte.MinValue, byte.MaxValue + 1));

        ObjColorChangedEvent?.Invoke(color);
    }
}