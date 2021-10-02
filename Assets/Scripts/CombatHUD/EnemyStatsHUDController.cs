using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat
{
    public class EnemyStatsHUDController : WizardStatsHUDController
    {

        private void Start() {
            ShowEnemyStatsAllText();
        }

        [ContextMenu("ShowEnemyStats")]
        internal void ShowEnemyStatsAllText() {
            _healthValueText.SetText(_combat.enemy.Health.ToString());
            _typeValueText.SetText(_combat.enemy.ElementalType.ToString());
        }
    }
}
