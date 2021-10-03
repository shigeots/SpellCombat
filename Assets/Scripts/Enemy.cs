using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SpellCombat {
    
    [Serializable]
    public class Enemy : Wizard
    {
        #region Contructors

        public Enemy() : base() {
        }
        
        public Enemy (int health, int mana, int fireSpell, int waterSpell, int grassSpell, ElementalType elementalType) 
            : base(health, mana, fireSpell, waterSpell, grassSpell, elementalType) {
        }
        
        #endregion
    }
}