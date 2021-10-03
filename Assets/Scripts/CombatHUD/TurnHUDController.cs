using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpellCombat {

    public class TurnHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _turnHUDCanvas;
        [SerializeField] private TextMeshProUGUI _turnText;
        [SerializeField] private Combat _combat;

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

        private void ShowTurnHUDCanvas() {
            _turnText.text = "Turn " + _combat.currentTurn;
            _turnHUDCanvas.enabled = true;

            Invoke("HideTurnHUDCanvas", 2f);
        }

        private void HideTurnHUDCanvas() {
            _turnHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowProbabilityTurnEvent += ShowTurnHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowProbabilityTurnEvent -= ShowTurnHUDCanvas;
        }

        #endregion
    }
}
