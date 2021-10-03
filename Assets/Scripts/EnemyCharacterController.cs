using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class EnemyCharacterController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Animator _enemyAnimator;

        [SerializeField] private PlayerCharacterController _playerCharacterController;
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

        #region private methods

        [ContextMenu("Idle")]
        private void EnemyAnimmationIdle() {
            _enemyAnimator.SetTrigger("Idle");
        }

        [ContextMenu("Attack")]
        private void EnemyAnimmationAttack() {
            _enemyAnimator.SetTrigger("Attack");
        }

        private void ExecuteTheEnemyAction() {
            if(_combat.enemyElementalSpell == ElementalType.Fire) {
                EnemyAnimmationAttack();
                _combat.player.TakeDamage(_combat.enemy.FireSpell, ElementalType.Fire);
            }
            if(_combat.enemyElementalSpell == ElementalType.Water) {
                EnemyAnimmationAttack();
                _combat.player.TakeDamage(_combat.enemy.WaterSpell, ElementalType.Water);
            }
            if(_combat.enemyElementalSpell == ElementalType.Grass) {
                EnemyAnimmationAttack();
                _combat.player.TakeDamage(_combat.enemy.GrassSpell, ElementalType.Grass);
            }

            EventObserver.UpdatePlayerStatsHUDEvent();

            InvokeShowMessageEnemyActionEvent();
        }

        private void InvokeShowMessageEnemyActionEvent() {
            Invoke("CallShowMessageEnemyActionEvent", 3f);
        }

        private void CallShowMessageEnemyActionEvent() {
            EventObserver.ShowMessageEnemyActionEvent();
        }

        #endregion

        #region Internal methods

        [ContextMenu("TakeDamage")]
        internal void EnemyAnimmationTakeDamage() {
            _enemyAnimator.SetTrigger("TakeDamage");
        }

        internal void PlayerCharacterAnimmationTakeDamage() {
            _playerCharacterController.PlayerAnimmationTakeDamage();
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ExecuteTheEnemyActionEvent += ExecuteTheEnemyAction;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ExecuteTheEnemyActionEvent -= ExecuteTheEnemyAction;
        }

        #endregion
        
    }
}
