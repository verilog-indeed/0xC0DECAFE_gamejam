using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlatformRotateController : MonoBehaviour
    {
        [SerializeField] private int switchId;

        void Start()
        {
            EventManager.singletonInstance.SwitchTriggerEnter += RotateOnSwitchTrigger;
        }

        private void RotateOnSwitchTrigger(int triggerId, bool switchState)
        {
            if (switchId == triggerId)
            {
                if (switchState) {
                    transform.Rotate(Vector3.forward, -50f);
                }
                else
                {
                    transform.Rotate(Vector3.forward, 50f);

                }
            }
        }
    }
}