using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpellCombat {

    public class LoseScreenController : MonoBehaviour, ISubscribeMethodsToEvents, IUnsubscribeMethodsToEvents {

        #region Private properties

        [SerializeField] private Canvas _loseScreenCanvas;

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

        private void ShowLoseScreenCanvas() {
            _loseScreenCanvas.enabled = true;
        }

        #endregion

        #region Public methods

        public void SubscribeMethodsToEvents() {
            EventObserver.LoseCombatActionEvent += ShowLoseScreenCanvas;
        }

        public void UnsubscribeMethodsToEvents() {
            EventObserver.LoseCombatActionEvent -= ShowLoseScreenCanvas;
        }

        public void LoadMenuScene() {
            SceneManager.LoadScene("MenuScene");
        }

        #endregion
    }
}
