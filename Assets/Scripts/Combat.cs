using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {
    
    public class Combat : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Internal properties
        [SerializeField] internal int currentTurn = 0;
        [SerializeField] internal int probabilityToChangeElement = 0;
        [SerializeField] internal int _turnToWaitToModifyTheProbability = 0;

        [SerializeField] internal Player player;
        [SerializeField] internal Enemy enemy;
        [SerializeField] internal PlayerBag playerBag;
        #endregion

        #region Main methods
        private void Awake() {
            SubscribeMethodsToEvents();

            EventObserver.StartCombatPhaseEvent();
        }

        private void Start() {
            EventObserver.StartTurnPhaseEvent();
            EventObserver.ShowProbailityTurnEvent();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        public void SubscribeMethodsToEvents() {
            EventObserver.StartCombatPhaseEvent += SetPlayerAndEnemyData;
            EventObserver.StartTurnPhaseEvent += IncreaseTurn;
            EventObserver.StartTurnPhaseEvent += DefineProbability;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.StartCombatPhaseEvent -= SetPlayerAndEnemyData;
            EventObserver.StartTurnPhaseEvent -= IncreaseTurn;
            EventObserver.StartTurnPhaseEvent -= DefineProbability;
        }

        private void SetPlayerAndEnemyData() {
            player = new Player(120, 80, 10, 15, 10, ElementalType.Water);
            enemy = new Enemy(80, 50, 10, 5, 8, ElementalType.Fire);
        }

        [ContextMenu("IncreaseTurn")]
        private void IncreaseTurn() {
            currentTurn++;
        }

        private void DecreaseTurnToWaitToModifyTheProbability() {
            if(_turnToWaitToModifyTheProbability > 0) {
                _turnToWaitToModifyTheProbability--;
            }
        }

        private void IncreaseTurnToWaitToModifyTheProbability() {
            if(_turnToWaitToModifyTheProbability == 0) {
                _turnToWaitToModifyTheProbability = 3;
            }
        }

        [ContextMenu("DefineProbability")]
        private void DefineProbability() {
            probabilityToChangeElement = UnityEngine.Random.Range(1,101);
        }

        [ContextMenu("Major")]
        private void ChangeTheProbabilityToMajor() {
            if(_turnToWaitToModifyTheProbability == 0) {
                probabilityToChangeElement = UnityEngine.Random.Range(probabilityToChangeElement, 101);
            }
        }

        [ContextMenu("Minor")]
        private void ChangeTheProbabilityToMinor() {
            if(_turnToWaitToModifyTheProbability == 0) {
                probabilityToChangeElement = UnityEngine.Random.Range(1, probabilityToChangeElement + 1);
            }
        }
        #endregion
    }
}