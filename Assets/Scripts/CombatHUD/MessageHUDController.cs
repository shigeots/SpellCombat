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
                _messageText.text = "Damaged enemy with fire spell.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.WaterSpell) {
                _messageText.text = "Damaged enemy with water spell.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.GrassSpell) {
                _messageText.text = "Damaged enemy with grass spell.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseHealthPotion) {
                _messageText.text = "You used the health potion, healed 35 health points.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseManaPotion) {
                _messageText.text = "You used the mana potion, healed 35 mana points.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseMixedPotion) {
                _messageText.text = "You used the mixed potion, healed 12 health and mana.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.Guard) {
                _messageText.text = "You used guard. It will reduce enemy attack damage.";
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.Rest) {
                _messageText.text = "You used rest, healed 10 mana.";
            }
            _messageHUDCanvas.enabled = true;

            InvokeCheckEnemyIsAliveEvent();
            
        }

        private void InvokeCheckEnemyIsAliveEvent() {
            Invoke("CallCheckEnemyIsAliveEvent", 2f);
        }

        private void CallCheckEnemyIsAliveEvent() {
            EventObserver.CheckEnemyIsAliveEvent();
        }

        private void ShowMessageCheckEnemyIsAlive() {

            if(_combat.enemy.Health <= 0) {
                _messageText.text = "You have defeated the enemy.";
                _messageHUDCanvas.enabled = true;
                InvokeWinCombatActionEvent();
            } else {
                
            }
        }

        private void InvokeWinCombatActionEvent() {
            Invoke("CallWinCombatActionEvent", 2f);
        }

        private void CallWinCombatActionEvent() {
            EventObserver.WinCombatActionEvent();
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ChangeWizardElementalTypeEvent += ShowMessageChangeWizardElementalType;
            EventObserver.NoChangeWizardElementalTypeEvent += ShowMessageNoChangeWizardElementalType;
            EventObserver.ShowMessagePlayerActionEvent += ShowMessagePlayerAction;
            EventObserver.CheckEnemyIsAliveEvent += ShowMessageCheckEnemyIsAlive;
            EventObserver.WinCombatActionEvent += InvokeWinCombatActionEvent;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ChangeWizardElementalTypeEvent -= ShowMessageChangeWizardElementalType;
            EventObserver.NoChangeWizardElementalTypeEvent -= ShowMessageNoChangeWizardElementalType;
            EventObserver.ShowMessagePlayerActionEvent -= ShowMessagePlayerAction;
            EventObserver.CheckEnemyIsAliveEvent -= ShowMessageCheckEnemyIsAlive;
            EventObserver.WinCombatActionEvent -= InvokeWinCombatActionEvent;

        }

        #endregion

    }
}
