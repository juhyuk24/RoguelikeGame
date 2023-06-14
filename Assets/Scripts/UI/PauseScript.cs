using Completed;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Completed
{
    public class PauseScript : MonoBehaviour
    {
        public GameObject popupWindow;  // 팝업 창 오브젝트
        public GameObject retryButton;  // 리트라이 버튼
        public GameObject menuButton;   // 메뉴 버튼
        public GameObject quitButton;   // 나가기 버튼
        public bool isPaused;           // 게임이 멈춰 있는지

        public Player playerScript;

        private void Start()
        {
            //각각의 버튼에 온클릭 리스너 추가하기
            retryButton.GetComponent<Button>().onClick.AddListener(Pop);
            menuButton.GetComponent<Button>().onClick.AddListener(Pop);
            quitButton.GetComponent<Button>().onClick.AddListener(Pop);
            retryButton.GetComponent<Button>().onClick.AddListener(Retry);
            menuButton.GetComponent<Button>().onClick.AddListener(Menu);
            quitButton.GetComponent<Button>().onClick.AddListener(Quit);
        }

        private void Update()
        {
            // 'ESC' 키를 눌렀을 때
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowPopup();
            }
        }

        public void ShowPopup()
        {
            if (popupWindow.activeSelf)
            {
                // 키 입력을 받고 팝업 창 비활성화
                isPaused = false;
                SoundManager.instance.gameObject.SetActive(true);
                popupWindow.SetActive(false);
            }
            else
            {
                // 키 입력을 무시하고 팝업 창 활성화
                isPaused = true;
                SoundManager.instance.gameObject.SetActive(false);
                popupWindow.SetActive(true);
            }
        }

        public void Pop()
        {
            // 버튼이 클릭되었을 때 공통적으로 들어가야 할 부분
            Time.timeScale = 1f;
            popupWindow.SetActive(false);
        }

        public void Retry()
        {
            Debug.Log("RetryButton Pressed");

            // Player오브젝트를 찾아서 food에 level시작됐을 때의 food포인트로 초기화
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Player playerScript = player.GetComponent<Player>();
            playerScript.food = GameManager.instance.playerFoodPoints;

            // MAIN 씬으로 이동
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        public void Menu()
        {
            Debug.Log("MenuButton Pressed");

            // INTRO 씬으로 이동
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        public void Quit()
        {
            Debug.Log("QuitButton Pressed");
            // 게임 종료
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
        }
    }
}
