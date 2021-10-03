using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpellCombat {

    public class SpellOptionHUDController : GeneralCombatHUDController, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Combat _combat;
        [SerializeField] private Canvas _spellOptionHUDCanvas;
        [SerializeField] private TextMeshProUGUI _fireSpellText;
        [SerializeField] private TextMeshProUGUI _waterSpellText;
        [SerializeField] private TextMeshProUGUI _grassSpellText;

        private const string _selectTheSpellDescription = "Select the spell.";
        private const string _fireSpellDescription = "Fire spell. Inflict double damage to the Grass-type Wizard. Mana cost 12.";
        private const string _waterSpellDescription = "Water spell. Inflict double damage to the Fire-type Wizard. Mana cost 12.";
        private const string _grassSpellDescription = "Grass spell. Inflict double damage to the Water-type Wizard. Mana cost 12.";
        private const string _fireSpellDescriptionWhenFireType = "Fire spell. Inflict double damage to the Grass-type Wizard. Mana cost 6.";
        private const string _waterSpellDescriptionWhenWaterType = "Water spell. Inflict double damage to the Fire-type Wizard. Mana cost 6.";
        private const string _grassSpellDescriptionWhenGrassType = "Grass spell. Inflict double damage to the Water-type Wizard. Mana cost 6.";
        private const string _backDescription = "Go back to select the action.";

        #endregion

        #region Main methods

        private void Awake() {
            SubscribeMethodsToEvents();
        }

        private void OnDestroy() {
            UnsubscribeMethodsToEvents();
        }
        
        #endregion

        #region Private methods

        private void ShowSpellOptionHUDCanvas() {
            SetSpellDataInButtonTexts();
            _spellOptionHUDCanvas.enabled = true;
        }
        
        private void HideSpellOptionHUDCanvas() {
            _spellOptionHUDCanvas.enabled = false;
        }

        private void SetSpellDataInButtonTexts() {
            _fireSpellText.text = "Fire spell " + _combat.player.FireSpell;
            _waterSpellText.text = "Water spell " + _combat.player.WaterSpell;
            _grassSpellText.text = "Grass spell " + _combat.player.GrassSpell;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowSpellOptionHUDEvent += ShowSpellOptionHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowSpellOptionHUDEvent -= ShowSpellOptionHUDCanvas;
        }

        public void ShowSelectTheSpellDescription() {
            SetDescription(_selectTheSpellDescription);
        }

        public void ShowFireSpellDescription() {
            if(_combat.player.ElementalType == ElementalType.Fire) {
                SetDescription(_fireSpellDescriptionWhenFireType);
            } else {
                SetDescription(_fireSpellDescription);
            }
        }

        public void ShowWaterSpellDescription() {
            if(_combat.player.ElementalType == ElementalType.Water) {
                SetDescription(_waterSpellDescriptionWhenWaterType);
            } else {
                SetDescription(_waterSpellDescription);
            }
        }

        public void ShowGrassDescription() {
            if(_combat.player.ElementalType == ElementalType.Grass) {
                SetDescription(_grassSpellDescriptionWhenGrassType);
            } else {
                SetDescription(_grassSpellDescription);
            }
        }

        public void ShowBackDescription() {
            SetDescription(_backDescription);
        }

        public void OnClickFireSpellButton() {

            if(_combat.player.ElementalType == ElementalType.Fire && _combat.player.Mana < 6) {
                Debug.Log("No alcanza");
            }
            if(_combat.player.ElementalType != ElementalType.Fire && _combat.player.Mana < 12) {
                Debug.Log("No alcanza");
            }
            if(_combat.player.ElementalType == ElementalType.Fire && _combat.player.Mana >= 6) {
                _combat.DefinePlayerAction(PlayerAction.FireSpell);
                _combat.player.ReduceMana(6);
                EventObserver.UpdatePlayerStatsHUDEvent();
                HideSpellOptionHUDCanvas();
                EventObserver.VerifyChangeWizardElementEvent();
            }
            if(_combat.player.ElementalType != ElementalType.Fire && _combat.player.Mana >= 12) {
                _combat.DefinePlayerAction(PlayerAction.FireSpell);
                _combat.player.ReduceMana(12);
                EventObserver.UpdatePlayerStatsHUDEvent();
                HideSpellOptionHUDCanvas();
                EventObserver.VerifyChangeWizardElementEvent();
            }
        }

        public void OnClickWaterSpellButton() {

            if(_combat.player.ElementalType == ElementalType.Water && _combat.player.Mana < 6) {
                Debug.Log("No alcanza");
            }
            if(_combat.player.ElementalType != ElementalType.Water && _combat.player.Mana < 12) {
                Debug.Log("No alcanza");
            }
            if(_combat.player.ElementalType == ElementalType.Water && _combat.player.Mana >= 6) {
                _combat.DefinePlayerAction(PlayerAction.WaterSpell);
                _combat.player.ReduceMana(6);
                EventObserver.UpdatePlayerStatsHUDEvent();
                HideSpellOptionHUDCanvas();
                EventObserver.VerifyChangeWizardElementEvent();
            }
            if(_combat.player.ElementalType != ElementalType.Water && _combat.player.Mana >= 12) {
                _combat.DefinePlayerAction(PlayerAction.WaterSpell);
                _combat.player.ReduceMana(12);
                EventObserver.UpdatePlayerStatsHUDEvent();
                HideSpellOptionHUDCanvas();
                EventObserver.VerifyChangeWizardElementEvent();
            }
        }

        public void OnClickGrassSpellButton() {
            
            if(_combat.player.ElementalType == ElementalType.Grass && _combat.player.Mana < 6) {
                Debug.Log("No alcanza");
            }
            if(_combat.player.ElementalType != ElementalType.Grass && _combat.player.Mana < 12) {
                Debug.Log("No alcanza");
            }
            if(_combat.player.ElementalType == ElementalType.Grass && _combat.player.Mana >= 6) {
                _combat.DefinePlayerAction(PlayerAction.GrassSpell);
                _combat.player.ReduceMana(6);
                EventObserver.UpdatePlayerStatsHUDEvent();
                HideSpellOptionHUDCanvas();
                EventObserver.VerifyChangeWizardElementEvent();
            }
            if(_combat.player.ElementalType != ElementalType.Grass && _combat.player.Mana >= 12) {
                _combat.DefinePlayerAction(PlayerAction.GrassSpell);
                _combat.player.ReduceMana(12);
                EventObserver.UpdatePlayerStatsHUDEvent();
                HideSpellOptionHUDCanvas();
                EventObserver.VerifyChangeWizardElementEvent();
            }
        }

        public void OnClickBackButton() {
            HideSpellOptionHUDCanvas();
            EventObserver.ShowCombatActionHUDEvent();
        }

        #endregion
    }
}
