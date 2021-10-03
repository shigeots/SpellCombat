using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpellCombat {

    public class ChangeProbabilityHUDController : GeneralCombatHUDController, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Combat _combat;
        [SerializeField] private Canvas _changeProbabilityHUDCanvas;

        private const string _changeProbabilityDescription = "Alter the probability of changing the player's and enemy's mage type.";
        private const string _greaterDescription = "Change the probability to a value greater than the current one.";
        private const string _lessDescription = "Change the probability to a value less than the current one.";
        private const string _noChangeDescription = "Do not change the probability value.";

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

        private void ShowChangeProbabilityHUDCanvas() {
            
            if(_combat.turnToWaitToModifyTheProbability == 0) {
                _changeProbabilityHUDCanvas.enabled = true;
            } else {
                HideChangeProbabilityHUDCanvas();
            }
        }

        private void HideChangeProbabilityHUDCanvas() {
            _changeProbabilityHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowChangeProbabilityHUDEvent += ShowChangeProbabilityHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowChangeProbabilityHUDEvent -= ShowChangeProbabilityHUDCanvas;
        }

        public void ShowChangeProbabilityDescription() {
            SetDescription(_changeProbabilityDescription);
        }

        public void ShowGreaterDescription() {
            SetDescription(_greaterDescription);
        }

        public void ShowLessDescription() {
            SetDescription(_lessDescription);
        }

        public void ShowNoChangeDescription() {
            SetDescription(_noChangeDescription);
        }

        public void OnClickGreaterButton() {
            if(_combat.turnToWaitToModifyTheProbability == 0) {
                _combat.ChangeTheProbabilityToGreater();
                _combat.IncreaseTurnToWaitToModifyTheProbability();
                HideChangeProbabilityHUDCanvas();
                EventObserver.ShowCombatActionHUDEvent();
            }
        }

        public void OnClickLessButton() {
            if(_combat.turnToWaitToModifyTheProbability == 0) {
                _combat.ChangeTheProbabilityToLess();
                _combat.IncreaseTurnToWaitToModifyTheProbability();
                HideChangeProbabilityHUDCanvas();
                EventObserver.ShowCombatActionHUDEvent();
            }
        }

        public void OnClickNoChangeButton() {
            HideChangeProbabilityHUDCanvas();
            EventObserver.ShowCombatActionHUDEvent();
        }

        #endregion

    }
}
