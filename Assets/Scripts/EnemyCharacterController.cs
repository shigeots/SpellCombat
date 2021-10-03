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
            
        }

        public void UnsubscribeMethodsToEvents() {
            
        }

        #endregion
        
    }
}
