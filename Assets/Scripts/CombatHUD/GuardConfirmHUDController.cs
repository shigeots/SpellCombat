using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpellCombat {

    public class GuardConfirmHUDController : GeneralCombatHUDController, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Combat _combat;
        [SerializeField] private Canvas _guardConfirmHUDCanvas;

        private const string _confirmGuardDescription = "Confirm guard.";
        private const string _yesDescription = "Will perform the guard.";
        private const string _noDescription = "Go back to select the action.";

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

        private void ShowGuardConfirmHUDCanvas() {
            _guardConfirmHUDCanvas.enabled = true;
        }

        private void HideGuardConfirmHUDCanvas() {
            _guardConfirmHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowGuardConfirmHUDEvent += ShowGuardConfirmHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowGuardConfirmHUDEvent -= ShowGuardConfirmHUDCanvas;
        }

        public void ShowConfirmGuardDescription() {
            SetDescription(_confirmGuardDescription);
        }

        public void ShowYesDescription() {
            SetDescription(_yesDescription);
        }

        public void ShowNoDescription() {
            SetDescription(_noDescription);
        }

        public void OnClickYesButton() {
            _combat.DefinePlayerAction(PlayerAction.Guard);
            HideGuardConfirmHUDCanvas();
        }

        public void OnClickNoButton() {
            HideGuardConfirmHUDCanvas();
            EventObserver.ShowCombatActionHUDEvent();
        }

        #endregion
    }
}
