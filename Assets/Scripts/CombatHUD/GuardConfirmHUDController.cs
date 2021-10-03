using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class GuardConfirmHUDController : GeneralCombatHUDController {

        private const string _confirmGuardDescription = "Confirm guard.";
        private const string _yesDescription = "Will perform the guard.";
        private const string _noDescription = "Go back to select the action.";

        public void ShowConfirmGuardDescription() {
            SetDescription(_confirmGuardDescription);
        }

        public void ShowYesDescription() {
            SetDescription(_yesDescription);
        }

        public void ShowNoDescription() {
            SetDescription(_noDescription);
        }
    }
}
