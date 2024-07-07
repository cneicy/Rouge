using Client.Object;
using UnityEngine;

namespace Client.Controller
{
    public class CameraController : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _playerPositionTemp;
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (PlayerManager.Instance.LocalPlayer)
            {
                _playerPositionTemp = PlayerManager.Instance.LocalPlayer.transform.position;
                _playerPositionTemp.z = -10;
                _camera.transform.position = _playerPositionTemp;
            }
            
        }
    }
}