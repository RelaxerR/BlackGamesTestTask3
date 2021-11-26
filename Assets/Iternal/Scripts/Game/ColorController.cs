using UnityEngine;
using UnityEngine.UI;
using System;


public class ColorController : MonoBehaviour
{
    public class ObjectColor
    {
        private Color32 _currentColor;
        public GameObject _target { get; private set; }

        public ObjectColor(GameObject obj){
            _target = obj;
            _currentColor = GetColor();
        }

        public Color32 GetColor(){
            try{
                return _target.GetComponent<Image>().color;
            }
            catch (NullReferenceException){
                return _target.GetComponent<MeshRenderer>().materials[0].color;
            }
        }
        public void SetColor(Color32 newColor){
            _currentColor = newColor;

            try{
                _target.GetComponent<Image>().color = _currentColor;
            }
            catch (NullReferenceException){
                _target.GetComponent<MeshRenderer>().materials[0].color = _currentColor;
            }
        }
    }

    public ObjectColor _cubeColor { get; private set; }

    private void Start(){
        _cubeColor = new ObjectColor(this.gameObject);

        GameController.Instance.ObjColorChangedEvent += ColorChanged;
    }
    private void OnDestroy(){
        GameController.Instance.ObjColorChangedEvent -= ColorChanged;
    }

    private void ColorChanged(Color32 color){
        if (GameController.Instance._target == this.gameObject)
            _cubeColor.SetColor(color);
    }

    private void OnMouseDown(){
        GameController.Instance.ObjPicked(this.gameObject);
    }
}