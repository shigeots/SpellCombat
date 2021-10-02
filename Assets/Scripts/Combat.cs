using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {
    
    public class Combat : MonoBehaviour {

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
            player = new Player(120, 80, 10, 15, 10, ElementalType.Water);
            enemy = new Enemy(80, 50, 10, 5, 8, ElementalType.Fire);
            IncreaseTurn();
            DefineProbability();
        }
        #endregion

        #region Private methods
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