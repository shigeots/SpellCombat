using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat
{
    public class ProbabilityChangeHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents  {

        [SerializeField] private Combat _combat;
        [SerializeField] private TextMeshProUGUI _probabilityValueText;

        private const string _percentcharacter = "%";

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowProbailityTurnEvent += ShowProbabilityText;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowProbailityTurnEvent -= ShowProbabilityText;
        }


        [ContextMenu("ShowProbaility")]
        private void ShowProbabilityText() {
            _probabilityValueText.SetText(_combat.probabilityToChangeElement.ToString() + _percentcharacter);
        }
    }
}