using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SpellCombat
{
    [Serializable]
    public class PlayerBag {

        #region Attributes

        [SerializeField] private int _healthPotion;
        [SerializeField] private int _manaPotion;
        [SerializeField] private int _mixedPotion;

        #endregion

        #region Constructors

        public PlayerBag() {
        }

        public PlayerBag(int healthPotion, int manaPotion, int mixedPotion) {
            _healthPotion = healthPotion;
            _manaPotion = manaPotion;
            _mixedPotion = mixedPotion;
        }

        #endregion

        #region Getters and setters

        public int HealthPotion {
            get => _healthPotion;
            set => _healthPotion = value;
        }

        public int ManaPotion {
            get => _manaPotion;
            set => _manaPotion = value;
        }

        public int MixedPotion {
            get => _mixedPotion;
            set => _mixedPotion = value;
        }

        #endregion
    }
}