using Client.Event;
using Client.Event.EventArgs;
using UnityEngine;

namespace Client.Object
{
    public class Base : MonoBehaviour
    {
        public int hp=4;
        private void OnEnable()
        {
            EventCenter.Instance.OnBaseHpChange += HandleBaseHpChange;
            EventCenter.Instance.OnBaseRuined += HandleBaseRuined;
        }

        private void OnDisable()
        {
            EventCenter.Instance.OnBaseHpChange -= HandleBaseHpChange;
            EventCenter.Instance.OnBaseRuined -= HandleBaseRuined;
        }
        

        private int HandleBaseHpChange(BaseHpChangeEventArgs e)
        {
            if (hp <= 1)
            {
                EventCenter.Instance.BaseRuined(e.Base);
            }
            return hp += e.Damage;
        }

        private Base HandleBaseRuined(BaseRuinedEventArgs e)
        {
            Debug.Log("Base ruin");
            return e.Base;
        }
    }
}
