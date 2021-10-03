using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SpellCombat
{
    [Serializable]
    public class Player : Wizard, IFireSpellAttack {

        #region Contructors

        public Player() : base() {
        }
        
        public Player (int health, int mana, int fireSpell, int waterSpell, int grassSpell, ElementalType elementalType) 
            : base(health, mana, fireSpell, waterSpell, grassSpell, elementalType) {
        }
        
        #endregion

        #region Internal methods

        internal void ReduceMana(int mana) {
            Mana -= mana;
        }

        #endregion

        #region Public methods

        public int FireSpellAttack() {
            return 1;
        }

        #endregion
    }
}
