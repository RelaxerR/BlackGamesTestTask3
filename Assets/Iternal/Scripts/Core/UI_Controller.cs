using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private Text R_ValueText;
    [SerializeField] private Text G_ValueText;
    [SerializeField] private Text B_ValueText;
    [SerializeField] private Slider G_Slider;

    private void Start(){
        GameController.Instance.ObjColorChangedEvent += UpdateUI;
    }
    private void OnDestroy(){
        GameController.Instance.ObjColorChangedEvent -= UpdateUI;
    }

    private void UpdateUI(Color32 color){
        R_ValueText.text = color.r.ToString();
        G_ValueText.text = color.g.ToString();
        B_ValueText.text = color.b.ToString();
        G_Slider.value = (float) Convert.ToInt32(color.g) / 255;
    }

    public void R_ButtonPressed(int val){
        GameController.Instance.RedColorChanged(val);
    }
    public void G_SliderValueChanged(){
        var val = G_Slider.value;
        GameController.Instance.GreenColorChanged(val);
    }
    public void B_ButtonPressed(){
        GameController.Instance.BlueColorChanged();
    }
}