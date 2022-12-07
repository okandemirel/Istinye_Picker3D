using System;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoBehaviour
    {
        #region Singleton

        public static UISignals Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        #endregion

        public UnityAction<int> onSetNewLevelValue = delegate { };
        public UnityAction<int> onSetStageColor = delegate { };
    }
}