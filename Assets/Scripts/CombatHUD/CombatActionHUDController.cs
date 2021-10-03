using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class CombatActionHUDController : GeneralCombatHUDController , ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _combatActionHUDCanvas;

        private const string _selectTheActionDescription = "Select the action.";
        private const string _spellDescription = "Spell attack to damage the enemy using mana.";
        private const string _itemDescription = "Use item to heal health or/and mana.";
        private const string _guardDescription = "Guard to reduce damage. Block 10 damage. Ignore the elemental buff.";
        private const string _restDescription = "Rest to recover 10 mana.";

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

        private void ShowCombatActionHUDCanvas() {
            _combatActionHUDCanvas.enabled = true;
        }

        private void HideCombatActionHUDCanvas() {
            _combatActionHUDCanvas.enabled = false;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowCombatActionHUDEvent += ShowCombatActionHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowCombatActionHUDEvent -= ShowCombatActionHUDCanvas;
        }

        public void ShowSelectTheActionDescription() {
            SetDescription(_selectTheActionDescription);
        }

        public void ShowSpellDescription() {
            SetDescription(_spellDescription);
        }

        public void ShowItemDescription() {
            SetDescription(_itemDescription);
        }

        public void ShowGuardDescription() {
            SetDescription(_guardDescription);
        }

        public void ShowRestDescription() {
            SetDescription(_restDescription);
        }

        public void OnClickSpellButton() {
            HideCombatActionHUDCanvas();
            EventObserver.ShowSpellOptionHUDEvent();
        }

        public void OnClickItemButton() {
            HideCombatActionHUDCanvas();
            EventObserver.ShowItemOptionHUDEvent();
        }

        public void OnClickGuardButton() {
            HideCombatActionHUDCanvas();
            EventObserver.ShowGuardConfirmHUDEvent();
        }

        public void OnClickRestButton() {
            HideCombatActionHUDCanvas();
            EventObserver.ShowRestConfirmHUDEvent();
        }

        #endregion
    }
}
