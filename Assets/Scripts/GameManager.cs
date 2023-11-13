
using Cars;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Race
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private StartScript m_startScript;
        [SerializeField] private TimerComponent m_timer;
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private GameObject m_panel;
        [SerializeField] private ScrolComponent m_scrolComponent;
        private void Start()//отчет на старте
        {
            m_startScript.StartCountdown();
        }

        public void StartRace() //старт заезда
        {
            m_timer.StartCountRaceTime(); 
        }

        public void PlayerInputOn(bool input) //возможность отключать инпут игрока
        {
            m_playerController.OnPlayerInput(input);
        }
        
        public void EndRace() // завершение заезда
        {
            PlayerInputOn(false);
            m_panel.SetActive(true);
        }
        
        public void ShowLeaderBoard() //показывает лидерборд
        {
            m_scrolComponent.Initialization();
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
        

        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPrefs() //чистит префсы
        {
            PlayerPrefs.DeleteAll();
        }
            
    }
}