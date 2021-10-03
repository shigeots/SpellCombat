using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat
{
    public class ProbabilityChangeHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents  {

        #region Private properties

        [SerializeField] private Combat _combat;
        [SerializeField] private TextMeshProUGUI _probabilityValueText;

        private const string _percentcharacter = "%";

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

        [ContextMenu("ShowProbaility")]
        private void ShowProbabilityText() {
            _probabilityValueText.SetText(_combat.probabilityToChangeElement.ToString() + _percentcharacter);
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowProbabilityTurnEvent += ShowProbabilityText;
            EventObserver.UpdateProbabilityTurnEvent += ShowProbabilityText;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowProbabilityTurnEvent -= ShowProbabilityText;
            EventObserver.UpdateProbabilityTurnEvent -= ShowProbabilityText;
        }

        #endregion
    }
}