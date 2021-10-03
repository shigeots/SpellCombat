using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat {

    public class EnemyStatsHUDController : WizardStatsHUDController, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void Start() {
            ShowEnemyStatsAllText();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods
        
        private void ShowEnemyStatsAllText() {
            _healthValueText.SetText(_combat.enemy.Health.ToString());
            _typeValueText.SetText(_combat.enemy.ElementalType.ToString());
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.UpdateEnemyStatsHUDEvent += ShowEnemyStatsAllText;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.UpdateEnemyStatsHUDEvent -= ShowEnemyStatsAllText;
        }

        #endregion
    }
}
