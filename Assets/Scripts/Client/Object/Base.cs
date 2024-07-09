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
        }
        private int HandleBaseHpChange(BaseHpChangeEventArgs e)
        {
            if (hp <= 1)
            {
                HandleBaseDie();
            }
            return hp += e.Damage;
        }

        private void HandleBaseDie()
        {
            Debug.Log("Base ruin");
        }
    }
}
