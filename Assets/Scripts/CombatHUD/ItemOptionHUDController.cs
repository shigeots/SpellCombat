using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpellCombat {

    public class ItemOptionHUDController : GeneralCombatHUDController, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Combat _combat;
        [SerializeField] private Canvas _itemOptionHUDCanvas;
        [SerializeField] private TextMeshProUGUI _healthPotionText;
        [SerializeField] private TextMeshProUGUI _manaPotionText;
        [SerializeField] private TextMeshProUGUI _mixedPotionText;
        [SerializeField] private Button _healthPotionButton;
        [SerializeField] private Button _manaPotionButton;
        [SerializeField] private Button _mixedPotionButton;

        private const string _selectTheItemDescription = "Select the item.";
        private const string _healthPotionDescription = "Recover 35 health.";
        private const string _manaPotionDescription = "Recover 35 mana.";
        private const string _mixedPotionDescription = "Recover 12 health and mana.";
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

        private void ShowItemOptionHUDCanvas() {
            SetPotionDataInButtonTexts();
            _itemOptionHUDCanvas.enabled = true;
        }
        
        private void HideItemOptionHUDCanvas() {
            _itemOptionHUDCanvas.enabled = false;
        }

        private void SetPotionDataInButtonTexts() {
            _healthPotionText.text = "Health potion x" + _combat.playerBag.HealthPotion;
            _manaPotionText.text = "Mana potion x" + _combat.playerBag.ManaPotion;
            _mixedPotionText.text = "Mixed potion x" + _combat.playerBag.MixedPotion;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.ShowItemOptionHUDEvent += ShowItemOptionHUDCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.ShowItemOptionHUDEvent -= ShowItemOptionHUDCanvas;
        }

        public void ShowSelectTheItemDescription() {
            SetDescription(_selectTheItemDescription);
        }

        public void ShowHealthPotionDescription() {
            SetDescription(_healthPotionDescription);
        }

        public void ShowManaPotionDescription() {
            SetDescription(_manaPotionDescription);
        }

        public void ShowMixedPotionDescription() {
            SetDescription(_mixedPotionDescription);
        }

        public void ShowBackDescription() {
            SetDescription(_backDescription);
        }

        public void OnClickHealthPotionButton() {
            if(_combat.playerBag.HealthPotion > 0) {
                _combat.DefinePlayerAction(PlayerAction.UseHealthPotion);
                _combat.playerBag.ReduceHealthPotion();
                HideItemOptionHUDCanvas();
            } else {
                Debug.Log("No hay pocion");
            }
            
        }

        public void OnClickManaPotionButton() {
            if(_combat.playerBag.ManaPotion > 0) {
                _combat.DefinePlayerAction(PlayerAction.UseManaPotion);
                _combat.playerBag.ReduceManaPotion();
                HideItemOptionHUDCanvas();
            } else {
                Debug.Log("No hay pocion");
            }
        }

        public void OnClickMixedPotionButton() {
            if(_combat.playerBag.MixedPotion > 0) {
                _combat.DefinePlayerAction(PlayerAction.UseMixedPotion);
                _combat.playerBag.ReduceMixedPotion();
                HideItemOptionHUDCanvas();
            } else {
                Debug.Log("No hay pocion");
            }
        }

        public void OnClickBackButton() {
            HideItemOptionHUDCanvas();
            EventObserver.ShowCombatActionHUDEvent();
        }

        #endregion
    }
}
