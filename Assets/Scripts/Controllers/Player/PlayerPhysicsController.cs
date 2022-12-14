using System;
using Signals;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;

        #endregion

        #endregion


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StageArea"))
            {
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                return;
            }
        }

        public void OnReset()
        {
        }
    }
}