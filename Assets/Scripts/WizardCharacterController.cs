using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class WizardCharacterController : MonoBehaviour {

        [SerializeField] private Animator _characterAnimator;

        [SerializeField] private WizardCharacterController _oponentWizardCharacterController;

        [ContextMenu("Idle")]
        internal void CharacterAnimmationIdle() {
            _characterAnimator.SetTrigger("Idle");
        }

        [ContextMenu("Attack")]
        internal void CharacterAnimmationAttack() {
            _characterAnimator.SetTrigger("Attack");
        }

        [ContextMenu("TakeDamage")]
        internal void CharacterAnimmationTakeDamage() {
            _characterAnimator.SetTrigger("TakeDamage");
        }

        internal void OponentCharacterAnimmationTakeDamage() {
            _oponentWizardCharacterController.CharacterAnimmationTakeDamage();
        }
    }
}
