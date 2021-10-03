using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SpellCombat
{
    [Serializable]
    public class Wizard {

        #region Attributes

        [SerializeField] private int _health;
        [SerializeField] private int _mana;
        [SerializeField] private int _fireSpell;
        [SerializeField] private int _waterSpell;
        [SerializeField] private int _grassSpell;
        [SerializeField] private ElementalType _elementalType;

        #endregion

        #region Contructors

        public Wizard () {
        }

        public Wizard (int health, int mana, int fireSpell, int waterSpell, int grassSpell, ElementalType elementalType) {
            _health = health;
            _mana = mana;
            _fireSpell = fireSpell;
            _waterSpell = waterSpell;
            _grassSpell = grassSpell;
            _elementalType = elementalType;
        }

        #endregion

        #region Getters and setters

        public int Health {
            get => _health;
            set => _health = value;
        }

        public int Mana {
            get => _mana;
            set => _mana = value;
        }

        public int FireSpell {
            get => _fireSpell;
            set => _fireSpell = value;
        }

        public int WaterSpell {
            get => _waterSpell;
            set => _waterSpell = value;
        }

        public int GrassSpell {
            get => _grassSpell;
            set => _grassSpell = value;
        }

        public ElementalType ElementalType {
            get => _elementalType;
            set => _elementalType = value;
        }

        #endregion

        #region Protected methods

        internal void TakeDamage(int damage, ElementalType damageElementalType) {
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
    }
}