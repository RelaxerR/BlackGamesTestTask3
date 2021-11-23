using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller Instance { get; private set; }
    public event Action<int> RedColorChangedEvent;
    public event Action<float> GreenColorChangedEvent;
    public event Action BlueColorChangedEvent;

    [SerializeField] private Text R_ValueText;
    [SerializeField] private Text G_ValueText;
    [SerializeField] private Text B_ValueText;
    [SerializeField] private Slider G_Slider;

    private void Awake(){
        Instance = this;
    }

    public void SetColor(GameObject obj, Color32 color){
        if (CheckImageComponent(obj)) obj.GetComponent<Image>().color = color;
        else obj.GetComponent<MeshRenderer>().materials[0].color = color;

        SetVal(R_ValueText, color.r);
        SetVal(G_ValueText, color.g, G_Slider);
        SetVal(B_ValueText, color.b);
    }
    private void SetVal(Text txt, byte val, bool slider = false){
        txt.text = val.ToString();
        if (slider) G_Slider.value = (float) val / 255;
    }
    public static Color32 GetColor(GameObject obj){
        if (CheckImageComponent(obj)) return obj.GetComponent<Image>().color;
        else return obj.GetComponent<MeshRenderer>().materials[0].color;
    }
    private static bool CheckImageComponent(GameObject obj){
        if (obj.GetComponent<Image>()) return true;
        else return false;
    }

    public void R_ButtonPressed(int val){
        RedColorChangedEvent?.Invoke(val);
    }
    public void G_SliderValueChanged(){
        var val = G_Slider.value;
        GreenColorChangedEvent?.Invoke(val);
    }
    public void B_ButtonPressed(){
        BlueColorChangedEvent?.Invoke();
    }
}