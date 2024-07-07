using Client.Controller.KeyboardInputUtils;
using Unity.Netcode;
using UnityEngine;

namespace Client.Controller
{
    public class PlayerController : NetworkBehaviour
    {
        private Rigidbody2D _rigidbody;

        public void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.freezeRotation = true;
        }


        private void Update()
        {
            if (IsLocalPlayer)
            {
                _rigidbody.velocity = KeySettingManager.Instance.Direction.normalized * 10;
            }
            else
            {
                // Code for non-local player here
            }
        }
    }
}