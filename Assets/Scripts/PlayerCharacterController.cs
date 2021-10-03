using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class PlayerCharacterController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Animator _playerAnimator;

        [SerializeField] private EnemyCharacterController _enemyCharacterController;
        [SerializeField] private Combat _combat;

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

        [ContextMenu("Idle")]
        private void PlayerAnimmationIdle() {
            _playerAnimator.SetTrigger("Idle");
        }

        [ContextMenu("Attack")]
        private void PlayerAnimmationAttack() {
            _playerAnimator.SetTrigger("Attack");
        }

        private void ExecuteThePlayerAction() {
            if(_combat.playerActionOfTheTurn == PlayerAction.FireSpell) {
                PlayerAnimmationAttack();
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.WaterSpell) {
                PlayerAnimmationAttack();
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.GrassSpell) {
                PlayerAnimmationAttack();
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseHealthPotion) {
                _combat.player.RecoveryHealthAndMana(35, 0);
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseManaPotion) {
                _combat.player.RecoveryHealthAndMana(0, 35);
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.UseMixedPotion) {
                _combat.player.RecoveryHealthAndMana(12, 12);
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.Guard) {
                _combat.player.ChangeTruePlayerOnGuard();
            }
            if(_combat.playerActionOfTheTurn == PlayerAction.Rest) {
                _combat.player.RecoveryHealthAndMana(0, 10);
            }

            EventObserver.UpdatePlayerStatsHUDEvent();
            EventObserver.UpdateEnemyStatsHUDEvent();
        }

        #endregion

        #region Internal methods

        [ContextMenu("TakeDamage")]
        internal void PlayerAnimmationTakeDamage() {
            _playerAnimator.SetTrigger("TakeDamage");
        }

        internal void EnemyCharacterAnimmationTakeDamage() {
            _enemyCharacterController.EnemyAnimmationTakeDamage();
        }
        
        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ExecuteThePlayerActionEvent += ExecuteThePlayerAction;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ExecuteThePlayerActionEvent -= ExecuteThePlayerAction;
        }

        #endregion
    }
}
