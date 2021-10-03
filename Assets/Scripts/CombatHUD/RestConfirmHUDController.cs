using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class RestConfirmHUDController : GeneralCombatHUDController {

        private const string _confirmRestDescription = "Confirm rest.";
        private const string _yesDescription = "Will perform the rest.";
        private const string _noDescription = "Go back to select the action.";

        public void ShowConfirmRestDescription() {
            SetDescription(_confirmRestDescription);
        }

        public void ShowYesDescription() {
            SetDescription(_yesDescription);
        }

        public void ShowNoDescription() {
            SetDescription(_noDescription);
        }

    }
}
