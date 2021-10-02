using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat {

    public class PlayerStatsHUDController : WizardStatsHUDController {
        
        [SerializeField] private TextMeshProUGUI _manaValueText;

        private void Start() {
            ShowPlayerStatsAllText();
        }

        [ContextMenu("ShowPlayerStats")]
        internal void ShowPlayerStatsAllText() {
            _healthValueText.SetText(_combat.player.Health.ToString());
            _manaValueText.SetText(_combat.player.Mana.ToString());
            _typeValueText.SetText(_combat.player.ElementalType.ToString());
        }
    }
}
