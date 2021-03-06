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

            //EventObserver.StartCombatPhaseEvent();
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

        private void SetPlayerAndEnemyData() {
            player = new Player(100, 80, 11, 15, 10, RandomElementalType(), false);
            enemy = new Enemy(120, 50, 16, 6, 9, RandomElementalType());
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

        private ElementalType RandomElementalTypeWithoutRepeating(ElementalType elementalType) {

            int index = 0; 
            ElementalType randomElementalType;

            Type type = typeof(ElementalType);
            Array values = type.GetEnumValues();
            
            do {
                index = UnityEngine.Random.Range(0, values.Length);
                randomElementalType = (ElementalType)values.GetValue(index);
            }
            while(randomElementalType == elementalType);

            return randomElementalType;
        }

        internal void ChangeWizardElementalType() {
            int randomChance = UnityEngine.Random.Range(0, 101);

            if(randomChance <= probabilityToChangeElement) {
                player.ElementalType = RandomElementalTypeWithoutRepeating(player.ElementalType);
                enemy.ElementalType = RandomElementalTypeWithoutRepeating(enemy.ElementalType);

                EventObserver.UpdatePlayerStatsHUDEvent();
                EventObserver.UpdateEnemyStatsHUDEvent();
                EventObserver.ChangeWizardElementalTypeEvent();
            } else {
                EventObserver.NoChangeWizardElementalTypeEvent();
            }
        }
        #endregion

        #region Internal methods

        internal void IncreaseTurnToWaitToModifyTheProbability() {
            if(turnToWaitToModifyTheProbability == 0) {
                turnToWaitToModifyTheProbability = 2;
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
            //EventObserver.StartCombatPhaseEvent += SetPlayerAndEnemyData;
            EventObserver.StartTurnPhaseEvent += IncreaseTurn;
            EventObserver.StartTurnPhaseEvent += DecreaseTurnToWaitToModifyTheProbability;
            EventObserver.StartTurnPhaseEvent += DefineProbability;
            EventObserver.ShowProbabilityTurnEvent += ChooseTheElementEnemySpell;
            EventObserver.VerifyChangeWizardElementEvent += ChangeWizardElementalType;
        }

        public void UnsubscribeMethodsToEvents() {
            //EventObserver.StartCombatPhaseEvent -= SetPlayerAndEnemyData;
            EventObserver.StartTurnPhaseEvent -= IncreaseTurn;
            EventObserver.StartTurnPhaseEvent -= DecreaseTurnToWaitToModifyTheProbability;
            EventObserver.StartTurnPhaseEvent -= DefineProbability;
            EventObserver.ShowProbabilityTurnEvent -= ChooseTheElementEnemySpell;
            EventObserver.VerifyChangeWizardElementEvent -= ChangeWizardElementalType;
        }

        #endregion
    }
}