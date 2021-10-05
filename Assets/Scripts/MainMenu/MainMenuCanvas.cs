using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellCombat {

    public class MainMenuCanvas : MonoBehaviour {
        
        [SerializeField] private Canvas _mainMenuCanvas;
        [SerializeField] private Canvas _instructionCanvas;
        [SerializeField] private Canvas _levelCanvas;

        public void ShowMainMenuCanvas() {
            _mainMenuCanvas.enabled = true;
        }

        public void HideMainMenuCanvas() {
            _mainMenuCanvas.enabled = false;
        }

        public void ShowLevelCanvas() {
            _levelCanvas.enabled = true;
        }

        public void HideLevelCanvas() {
            _levelCanvas.enabled = false;
        }

        public void ShowInsctructionCanvas() {
            _instructionCanvas.enabled = true;
        }

        public void HideInsctructionCanvas() {
            _instructionCanvas.enabled = false;
        }

        public void QuitGame() {
            Application.Quit();
        }
    }
}
