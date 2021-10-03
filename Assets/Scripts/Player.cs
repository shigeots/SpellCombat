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

        internal override void TakeDamage(int damage, ElementalType damageElementalType) {
            if(_playerOnGuard == true) {
                Health -= (damage - 10);
                return;
            }
            if(damageElementalType == ElementalType.Fire && ElementalType == ElementalType.Grass) {
                Health -= (damage * 2);
                return;
            }
            if(damageElementalType == ElementalType.Water && ElementalType == ElementalType.Fire) {
                Health -= (damage * 2);
                return;
            }
            if(damageElementalType == ElementalType.Grass && ElementalType == ElementalType.Water) {
                Health -= (damage * 2);
                return;
            }

            Health -= damage;
            return;
        }

        #endregion

        #region Public methods

        public int FireSpellAttack() {
            return 1;
        }

        #endregion
    }
}
