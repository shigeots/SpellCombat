using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpellCombat {

    public class LevelCanvasController : MonoBehaviour {

        [SerializeField] private Canvas _mainMenuCanvas;
        [SerializeField] private Canvas _levelCanvas;

        [SerializeField] private GameObject _level1Image;
        [SerializeField] private GameObject _level2Image;
        [SerializeField] private GameObject _level3Image;
        [SerializeField] private GameObject _level4Image;
        [SerializeField] private GameObject _level5Image;

        public void ShowLevel1Image() {
            _level1Image.SetActive(true);
        }

        public void HideLevel1Image() {
            _level1Image.SetActive(false);
        }

        public void ShowLevel2Image() {
            _level2Image.SetActive(true);
        }

        public void HideLevel2Image() {
            _level2Image.SetActive(false);
        }

        public void ShowLevel3Image() {
            _level3Image.SetActive(true);
        }

        public void HideLevel3Image() {
            _level3Image.SetActive(false);
        }
        public void ShowLevel4Image() {
            _level4Image.SetActive(true);
        }

        public void HideLevel4Image() {
            _level4Image.SetActive(false);
        }
        public void ShowLevel5Image() {
            _level5Image.SetActive(true);
        }

        public void HideLevel5Image() {
            _level5Image.SetActive(false);
        }

        public void LoadCombatLevel1Scene() {
            SceneManager.LoadScene("CombatLevel1Scene");
        }

        public void LoadCombatLevel2Scene() {
            SceneManager.LoadScene("CombatLevel2Scene");
        }

        public void LoadCombatLevel3Scene() {
            SceneManager.LoadScene("CombatLevel3Scene");
        }

        public void LoadCombatLevel4Scene() {
            SceneManager.LoadScene("CombatLevel4Scene");
        }

        public void LoadCombatLevel5Scene() {
            SceneManager.LoadScene("CombatLevel5Scene");
        }
    }
}
