using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class ItemOptionHUDController : GeneralCombatHUDController{

        private const string _selectTheItemDescription = "Select the item.";
        private const string _healthPotionDescription = "Recover 35 health.";
        private const string _manaPotionDescription = "Recover 35 mana.";
        private const string _mixedPotionDescription = "Recover 12 health and mana.";
        private const string _backDescription = "Go back to select the action.";

        public void ShowSelectTheItemDescription() {
            SetDescription(_selectTheItemDescription);
        }

        public void ShowHealthPotionDescription() {
            SetDescription(_healthPotionDescription);
        }

        public void ShowManaPotionDescription() {
            SetDescription(_manaPotionDescription);
        }

        public void ShowMixedPotionDescription() {
            SetDescription(_mixedPotionDescription);
        }

        public void ShowBackDescription() {
            SetDescription(_backDescription);
        }
    }
}
