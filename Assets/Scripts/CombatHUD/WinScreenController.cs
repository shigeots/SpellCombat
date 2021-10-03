using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class WinScreenController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _winScreenCanvas;

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowWinScreenCanvas() {
            _winScreenCanvas.enabled = true;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.WinCombatActionEvent += ShowWinScreenCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.WinCombatActionEvent -= ShowWinScreenCanvas;
        }

        #endregion
    }
}
