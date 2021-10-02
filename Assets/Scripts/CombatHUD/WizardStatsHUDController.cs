using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpellCombat
{
    public class WizardStatsHUDController : MonoBehaviour
    {
        [SerializeField] protected Combat _combat;
        [SerializeField] protected TextMeshProUGUI _healthValueText;
        [SerializeField] protected TextMeshProUGUI _typeValueText;
    }
}
