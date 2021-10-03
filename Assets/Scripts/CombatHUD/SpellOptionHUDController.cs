using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class SpellOptionHUDController : GeneralCombatHUDController {

        private const string _selectTheSpellDescription = "Select the spell.";
        private const string _fireSpellDescription = "Fire spell. Inflict double damage to the Grass-type Mage. Mana cost 12.";
        private const string _waterSpellDescription = "Water spell. Inflict double damage to the Fire-type Mage. Mana cost 12.";
        private const string _grassSpellDescription = "Grass spell. Inflict double damage to the Water-type Mage. Mana cost 12.";
        private const string _backDescription = "Go back to select the action.";

        public void ShowSelectTheSpellDescription() {
            SetDescription(_selectTheSpellDescription);
        }

        public void ShowFireSpellDescription() {
            SetDescription(_fireSpellDescription);
        }

        public void ShowWaterSpellDescription() {
            SetDescription(_waterSpellDescription);
        }

        public void ShowGrassDescription() {
            SetDescription(_grassSpellDescription);
        }

        public void ShowBackDescription() {
            SetDescription(_backDescription);
        }
    }
}
