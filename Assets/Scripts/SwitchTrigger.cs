using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SwitchTrigger : MonoBehaviour
    {
        [SerializeField] private int switchId;
        [SerializeField] private bool StartToggle;

        private bool currentState;
        private float defaultScale;

        private void Start()
        {
            currentState = StartToggle;
            defaultScale = transform.localScale.x;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            currentState = !currentState;
            EventManager.singletonInstance.OnSwitchTriggerEvent(switchId, currentState);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}