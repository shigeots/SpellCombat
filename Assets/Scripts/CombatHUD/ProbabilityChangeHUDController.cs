using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat
{
    public class ProbabilityChangeHUDController : MonoBehaviour {

        [SerializeField] private Combat _combat;
        [SerializeField] private TextMeshProUGUI _probabilityValueText;

        private const string _percentcharacter = "%";

        private void Start() {
            ShowProbabilityText();
        }

        [ContextMenu("ShowProbaility")]
        internal void ShowProbabilityText() {
            _probabilityValueText.SetText(_combat.probabilityToChangeElement.ToString() + _percentcharacter);
        }
    }
}