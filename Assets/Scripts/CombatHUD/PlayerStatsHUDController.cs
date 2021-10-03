using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat {

    public class PlayerStatsHUDController : WizardStatsHUDController, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {
        
        #region Private properties

        [SerializeField] private TextMeshProUGUI _manaValueText;

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void Start() {
            ShowPlayerStatsAllText();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        private void ShowPlayerStatsAllText() {
            _healthValueText.SetText(_combat.player.Health.ToString());
            _manaValueText.SetText(_combat.player.Mana.ToString());
            _typeValueText.SetText(_combat.player.ElementalType.ToString());
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.UpdatePlayerStatsHUDEvent += ShowPlayerStatsAllText;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.UpdatePlayerStatsHUDEvent -= ShowPlayerStatsAllText;
        }

        #endregion
    }
}
