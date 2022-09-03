using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlatformRecedeController : MonoBehaviour
    {

        [SerializeField] private int switchId;

        private float defaultScale; 
        void Start()
        {
            EventManager.singletonInstance.SwitchTriggerEnter += RotateOnSwitchTrigger;
            defaultScale = transform.localScale.x;
        }

        private void RotateOnSwitchTrigger(int triggerId, bool switchState)
        {
            if (switchId == triggerId)
            {
                if (switchState)
                {
                    transform.localScale = new Vector2(0.0f, transform.localScale.y) ;
                }
                else
                {
                    transform.localScale = new Vector2(defaultScale, transform.localScale.y);

                }
            }
        }
    }
}