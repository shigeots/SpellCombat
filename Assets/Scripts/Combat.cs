using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {
    
    public class Combat : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Internal properties

        [SerializeField] internal int currentTurn = 0;
        [SerializeField] internal int probabilityToChangeElement = 0;
        [SerializeField] internal int turnToWaitToModifyTheProbability = 0;

        [SerializeField] internal Player player;
        [SerializeField] internal Enemy enemy;
        [SerializeField] internal PlayerBag playerBag;

        [SerializeField] internal ElementalType enemyElementalSpell;
        [SerializeField] internal PlayerAction playerActionOfTheTurn;

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();

            EventObserver.StartCombatPhaseEvent();
        }

        private void Start() {
            EventObserver.StartTurnPhaseEvent();
            EventObserver.ShowProbabilityTurnEvent();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }

        #endregion

        #region Private methods

        /*
        public void StartGamePhase() {
            SetPlayerAndEnemyData();
            
        }

        public void StartTurnPhase() {
            IncreaseTurn();
            DefineProbability();
        }*/

        private void SetPlayerAndEnemyData() {
            player = new Player(120, 80, 10, 15, 10, RandomElementalType());
            enemy = new Enemy(80, 50, 10, 5, 8, RandomElementalType());
        }

        [ContextMenu("IncreaseTurn")]
        private void IncreaseTurn() {
            currentTurn++;
        }

        private void DecreaseTurnToWaitToModifyTheProbability() {
            if(turnToWaitToModifyTheProbability > 0) {
                turnToWaitToModifyTheProbability--;
            }
        }

        private void DefineProbability() {
            probabilityToChangeElement = UnityEngine.Random.Range(1,101);
        }

        private void ChooseTheElementEnemySpell() {
            if(probabilityToChangeElement <= 50) {

                Debug.Log("Debilidad");

                if(player.ElementalType == ElementalType.Fire) {
                    enemyElementalSpell = ElementalType.Water;
                }
                if(player.ElementalType == ElementalType.Water) {
                    enemyElementalSpell = ElementalType.Grass;
                }
                if(player.ElementalType == ElementalType.Grass) {
                    enemyElementalSpell = ElementalType.Fire;
                }
            } else {
                Debug.Log("random");
                enemyElementalSpell = RandomElementalType();
            }

            EventObserver.ShowChangeProbabilityHUDEvent();
        }

        private ElementalType RandomElementalType() {
            Type type = typeof(ElementalType);
            Array values = type.GetEnumValues();
            int index = UnityEngine.Random.Range(0, values.Length);
            return (ElementalType)values.GetValue(index);
        }
        #endregion

        #region Internal methods

        internal void IncreaseTurnToWaitToModifyTheProbability() {
            if(turnToWaitToModifyTheProbability == 0) {
                turnToWaitToModifyTheProbability = 3;
            }
        }

        internal void ChangeTheProbabilityToGreater() {
            if(turnToWaitToModifyTheProbability == 0) {
                probabilityToChangeElement = UnityEngine.Random.Range(probabilityToChangeElement, 101);
            }
        }

        internal void ChangeTheProbabilityToLess() {
            if(turnToWaitToModifyTheProbability == 0) {
                probabilityToChangeElement = UnityEngine.Random.Range(1, probabilityToChangeElement + 1);
            }
        }

        internal void DefinePlayerAction(PlayerAction playerAction) {
            playerActionOfTheTurn = playerAction;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.StartCombatPhaseEvent += SetPlayerAndEnemyData;
            EventObserver.StartTurnPhaseEvent += IncreaseTurn;
            EventObserver.StartTurnPhaseEvent += DefineProbability;
            EventObserver.ShowProbabilityTurnEvent += ChooseTheElementEnemySpell;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.StartCombatPhaseEvent -= SetPlayerAndEnemyData;
            EventObserver.StartTurnPhaseEvent -= IncreaseTurn;
            EventObserver.StartTurnPhaseEvent -= DefineProbability;
            EventObserver.ShowProbabilityTurnEvent -= ChooseTheElementEnemySpell;
        }

        #endregion
    }
}