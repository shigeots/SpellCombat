using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpellCombat {

    public class RestConfirmHUDController : GeneralCombatHUDController, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Combat _combat;
        [SerializeField] private Canvas _restConfirmHUDCanvas;

        private const string _confirmRestDescription = "Confirm rest.";
        private const string _yesDescription = "Will perform the rest.";
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

        private void ShowRestConfirmHUDCanvas() {
            _restConfirmHUDCanvas.enabled = true;
        }

        private void HideRestConfirmHUDCanvas() {
            _restConfirmHUDCanvas.enabled = false;
        }
        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowRestConfirmHUDEvent += ShowRestConfirmHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowRestConfirmHUDEvent -= ShowRestConfirmHUDCanvas;
        }

        public void ShowConfirmRestDescription() {
            SetDescription(_confirmRestDescription);
        }

        public void ShowYesDescription() {
            SetDescription(_yesDescription);
        }

        public void ShowNoDescription() {
            SetDescription(_noDescription);
        }

        public void OnClickYesButton() {
            _combat.DefinePlayerAction(PlayerAction.Rest);
            HideRestConfirmHUDCanvas();
        }

        public void OnClickNoButton() {
            HideRestConfirmHUDCanvas();
            EventObserver.ShowCombatActionHUDEvent();
        }

        #endregion

    }
}
