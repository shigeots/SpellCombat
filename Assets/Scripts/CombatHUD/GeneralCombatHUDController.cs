using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat
{
    public class GeneralCombatHUDController : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _descriptionText;

        protected void SetDescription(string description) {
            _descriptionText.SetText(description);
        }
    }
}
