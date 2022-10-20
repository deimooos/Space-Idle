using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets
{
    /// <summary>
    /// How to add a new Panel:
    /// - First add your new type into the PanelType enum
    /// - Add PanelTypeHolder.cs to your new Panel
    /// - Change the type of your panel GameObject in the Inspector
    /// - Now add here into the methods like MenuPanel() if when your panel should be activated
    /// - Now you can access your panel
    /// </summary>
    public enum PanelType { menu, game, win, lose, level, coins, settings }

    public class Manager : MonoBehaviour
    {
        public static Manager manager;

        private void Awake()
        {
            manager = this;
        }

        private void Start()
        {
            InitGameScenePanels();
        }

        #region Panels

        public List<PanelTypeHolder> allPanels;

        private void InitGameScenePanels()
        {
            manager.DisableAll();
            manager.MenuPanel();
        }

        public void Activate(PanelType panelType, bool activate = true)
        {
            foreach (var panel in allPanels)
            {
                if (panel.panelType == panelType)
                {
                    panel.gameObject.SetActive(activate);
                    return;
                }
            }

            Debug.LogWarning("SA: Panel not found: " + panelType.ToString());
        }

        public void DisableAll()
        {
            Activate(PanelType.menu, false);
            Activate(PanelType.game, false);
            Activate(PanelType.win, false);
            Activate(PanelType.lose, false);
            Activate(PanelType.coins, false);
            Activate(PanelType.settings, false);
            Activate(PanelType.level, false);
        }

        public void MenuPanel()
        {
            DisableAll();
            Activate(PanelType.menu);
            Activate(PanelType.level);
            Activate(PanelType.coins);
        }

        public void GamePanel()
        {
            Activate(PanelType.menu, false);
            Activate(PanelType.game);
        }

        public void WinPanel()
        {
            Activate(PanelType.game, false);
            Activate(PanelType.level, false);
            Activate(PanelType.win, true);
        }

        public void LosePanel()
        {
            Activate(PanelType.game, false);
            Activate(PanelType.level, false);
            Activate(PanelType.lose, true);
        }

        public void SettingsPanel()
        {
            DisableAll();
            Activate(PanelType.settings, true);
        }
        #endregion

        public void NextScene()
        {
            SA.ReloadScene();
        }

        public void StartGame()
        {
            SA.StartGame();
        }

        public void ReloadScene()
        {
            SA.ReloadScene();
        }
    }
}
