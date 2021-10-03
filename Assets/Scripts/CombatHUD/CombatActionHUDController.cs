using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class CombatActionHUDController : GeneralCombatHUDController {

        private const string _selectTheActionDescription = "Select the action.";
        private const string _spellDescription = "Spell attack to damage the enemy using mana.";
        private const string _itemDescription = "Use item to heal health or/and mana.";
        private const string _guardDescription = "Guard to reduce damage. Block 10 damage. Ignore the elemental buff.";
        private const string _restDescription = "Rest to recover 10 mana.";

        public void ShowSelectTheActionDescription() {
            SetDescription(_selectTheActionDescription);
        }

        public void ShowSpellDescription() {
            SetDescription(_spellDescription);
        }

        public void ShowItemDescription() {
            SetDescription(_itemDescription);
        }

        public void ShowGuardDescription() {
            SetDescription(_guardDescription);
        }

        public void ShowRestDescription() {
            SetDescription(_restDescription);
        }
    }
}
