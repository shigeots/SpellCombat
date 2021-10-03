using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpellCombat {

    public class MessageHUDController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Combat _combat;
        [SerializeField] private Canvas _messageHUDCanvas;
        [SerializeField] private TextMeshProUGUI _messageText;

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

        private void ShowMessageChangeWizardElementalType() {
            _messageHUDCanvas.enabled = true;
            _messageText.text = "Wizards' elemental types have been changed.";
            EventObserver.ExecuteThePlayerActionEvent();
        }

        private void ShowMessageNoChangeWizardElementalType() {
            _messageHUDCanvas.enabled = true;
            _messageText.text = "Wizards' elemental types were not changed.";
            EventObserver.ExecuteThePlayerActionEvent();
        }

        private void HideMessageHUDCanvas() {
            _messageHUDCanvas.enabled = false;
        }

        private void ShowMessagePlayerAction() {

            if(_combat.playerActionOfTheTurn == PlayerAction.FireSpell) {
                _messageText.text = "Wizards' elemental types have been changed.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.WaterSpell) {
                _messageText.text = "Wizards' elemental types have been changed.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.GrassSpell) {
                _messageText.text = "Wizards' elemental types have been changed.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseHealthPotion) {
                _messageText.text = "Wizards' elemental types have been changed.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseManaPotion) {
                _messageText.text = "Wizards' elemental types have been changed.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseMixedPotion) {
                _messageText.text = "Wizards' elemental types have been changed.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.Guard) {
                _messageText.text = "Wizards' elemental types have been changed.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.Rest) {
                _messageText.text = "Wizards' elemental types have been changed.";
            }
            _messageHUDCanvas.enabled = true;
            
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ChangeWizardElementalTypeEvent += ShowMessageChangeWizardElementalType;
            EventObserver.NoChangeWizardElementalTypeEvent += ShowMessageNoChangeWizardElementalType;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ChangeWizardElementalTypeEvent -= ShowMessageChangeWizardElementalType;
            EventObserver.NoChangeWizardElementalTypeEvent -= ShowMessageNoChangeWizardElementalType;
        }

        #endregion

    }
}
