using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class ChangeProbabilityHUDController : GeneralCombatHUDController {

        private const string _changeProbabilityDescription = "Alter the probability of changing the player's and enemy's mage type.";
        private const string _greaterDescription = "Change the probability to a value greater than the current one.";
        private const string _lessDescription = "Change the probability to a value less than the current one.";
        private const string _noChangeDescription = "Do not change the probability value.";

        public void ShowChangeProbabilityDescription() {
            SetDescription(_changeProbabilityDescription);
        }

        public void ShowGreaterDescription() {
            SetDescription(_greaterDescription);
        }

        public void ShowLessDescription() {
            SetDescription(_lessDescription);
        }

        public void ShowNoChangeDescription() {
            SetDescription(_noChangeDescription);
        }

    }
}
