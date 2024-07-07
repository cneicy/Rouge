using TMPro;
using UnityEngine;

namespace Client.Controller.KeyboardInputUtils
{
    /// <summary>
    /// 喜欢我写的屎山吗
    /// </summary>
    public class KeyChanger : MonoBehaviour
    {
        private KeySettingManager _keySettingManager;
        public bool isLeftChanging;
        [SerializeField] private TMP_Text left;
        public bool isRightChanging;
        [SerializeField] private TMP_Text right;
        public bool isAttackChanging;
        [SerializeField] private TMP_Text attack;
        public bool isUpChanging;
        [SerializeField] private TMP_Text up;
        public bool isDownChanging;
        [SerializeField] private TMP_Text down;
        
        private void Start()
        {
            _keySettingManager = GameObject.FindWithTag("KeySettingManager").GetComponent<KeySettingManager>();
            attack.text = _keySettingManager.GetKey("Attack").ToString();
            left.text = _keySettingManager.GetKey("Left").ToString();
            right.text = _keySettingManager.GetKey("Right").ToString();
            up.text = _keySettingManager.GetKey("Up").ToString();
            down.text = _keySettingManager.GetKey("Down").ToString();
        }

        public void EnableAttackChange()
        {
            isAttackChanging = true;
        }
        public void Attack()
        {
            if (isAttackChanging)
            {
                if (Input.anyKeyDown)
                {
                    isAttackChanging = false;
                    KeyCode pressedKeyCode=KeyCode.None;
                    foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (!Input.GetKeyDown(keyCode)) continue;
                        pressedKeyCode = keyCode;
                        break;
                    }

                    attack.text = pressedKeyCode.ToString();
                    _keySettingManager.SetKey("Attack", pressedKeyCode);
                }
            }
        }

        public void EnableLeftChange()
        {
            isLeftChanging = true;
        }
        public void Left()
        {
            if (isLeftChanging)
            {
                if (Input.anyKeyDown)
                {
                    isLeftChanging = false;
                    KeyCode pressedKeyCode=KeyCode.None;
                    foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (!Input.GetKeyDown(keyCode)) continue;
                        pressedKeyCode = keyCode;
                        break;
                    }

                    left.text = pressedKeyCode.ToString();
                    _keySettingManager.SetKey("Left", pressedKeyCode);
                }
            }
        }
        
        public void EnableRightChange()
        {
            isRightChanging = true;
        }
        public void Right()
        {
            if (isRightChanging)
            {
                if (Input.anyKeyDown)
                {
                    isRightChanging = false;
                    KeyCode pressedKeyCode=KeyCode.None;
                    foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (!Input.GetKeyDown(keyCode)) continue;
                        pressedKeyCode = keyCode;
                        break;
                    }

                    right.text = pressedKeyCode.ToString();
                    _keySettingManager.SetKey("Right", pressedKeyCode);
                }
            }
        }
        
        
        public void EnablUpChange()
        {
            isUpChanging = true;
        }
        public void Up()
        {
            if (isUpChanging)
            {
                if (Input.anyKeyDown)
                {
                    isUpChanging = false;
                    KeyCode pressedKeyCode=KeyCode.None;
                    foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (!Input.GetKeyDown(keyCode)) continue;
                        pressedKeyCode = keyCode;
                        break;
                    }

                    up.text = pressedKeyCode.ToString();
                    _keySettingManager.SetKey("Up", pressedKeyCode);
                }
            }
        }
        
        public void EnablDownChange()
        {
            isDownChanging = true;
        }
        public void Down()
        {
            if (isDownChanging)
            {
                if (Input.anyKeyDown)
                {
                    isDownChanging = false;
                    KeyCode pressedKeyCode=KeyCode.None;
                    foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (!Input.GetKeyDown(keyCode)) continue;
                        pressedKeyCode = keyCode;
                        break;
                    }

                    down.text = pressedKeyCode.ToString();
                    _keySettingManager.SetKey("Down", pressedKeyCode);
                }
            }
        }

        private void Update()
        {
            Attack();
            Left();
            Right();
            Up();
            Down();
        }
    }
}