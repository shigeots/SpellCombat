using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SpellCombat
{
    [Serializable]
    public class Player : Wizard, IFireSpellAttack {

        #region Atributes

        [SerializeField] private bool _playerOnGuard;

        #endregion

        #region Contructors

        public Player() : base() {
        }
        
        public Player (int health, int mana, int fireSpell, int waterSpell, int grassSpell, ElementalType elementalType, bool playerOnGuard) 
            : base(health, mana, fireSpell, waterSpell, grassSpell, elementalType) {
                _playerOnGuard = playerOnGuard;
        }
        
        #endregion

        #region Internal methods

        internal void ReduceMana(int mana) {
            Mana -= mana;
        }

        internal void RecoveryHealthAndMana(int healthToRecover, int manaToRecover) {
            Health += healthToRecover;
            Mana += manaToRecover;
        }

        internal void ChangeTruePlayerOnGuard() {
            _playerOnGuard = true;
        }

        #endregion

        #region Public methods

        public int FireSpellAttack() {
            return 1;
        }

        #endregion
    }
}
