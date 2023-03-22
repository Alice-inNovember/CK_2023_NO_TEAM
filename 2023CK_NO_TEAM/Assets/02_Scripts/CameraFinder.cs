using UnityEngine;

namespace _02_Scripts
{
    public class CameraFinder : MonoBehaviour
    {
        private Canvas _canvas;
        private GameObject _camera;

        private void Start()
        {
            _canvas = this.GetComponent<Canvas>();
            _camera = GameObject.Find("Camera");
            _canvas.worldCamera = _camera.GetComponent<Camera>();
        }
    }
}
