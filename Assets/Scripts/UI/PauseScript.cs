using Completed;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Completed
{
    public class PauseScript : MonoBehaviour
    {
        public GameObject popupWindow;  // �˾� â ������Ʈ
        public GameObject retryButton;  // ��Ʈ���� ��ư
        public GameObject menuButton;   // �޴� ��ư
        public GameObject quitButton;   // ������ ��ư
        public bool isPaused;           // ������ ���� �ִ���

        public Player playerScript;

        private void Start()
        {
            //������ ��ư�� ��Ŭ�� ������ �߰��ϱ�
            retryButton.GetComponent<Button>().onClick.AddListener(Pop);
            menuButton.GetComponent<Button>().onClick.AddListener(Pop);
            quitButton.GetComponent<Button>().onClick.AddListener(Pop);
            retryButton.GetComponent<Button>().onClick.AddListener(Retry);
            menuButton.GetComponent<Button>().onClick.AddListener(Menu);
            quitButton.GetComponent<Button>().onClick.AddListener(Quit);
        }

        private void Update()
        {
            // 'ESC' Ű�� ������ ��
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowPopup();
            }
        }

        public void ShowPopup()
        {
            if (popupWindow.activeSelf)
            {
                // Ű �Է��� �ް� �˾� â ��Ȱ��ȭ
                isPaused = false;
                SoundManager.instance.gameObject.SetActive(true);
                popupWindow.SetActive(false);
            }
            else
            {
                // Ű �Է��� �����ϰ� �˾� â Ȱ��ȭ
                isPaused = true;
                SoundManager.instance.gameObject.SetActive(false);
                popupWindow.SetActive(true);
            }
        }

        public void Pop()
        {
            // ��ư�� Ŭ���Ǿ��� �� ���������� ���� �� �κ�
            Time.timeScale = 1f;
            popupWindow.SetActive(false);
        }

        public void Retry()
        {
            Debug.Log("RetryButton Pressed");

            // Player������Ʈ�� ã�Ƽ� food�� level���۵��� ���� food����Ʈ�� �ʱ�ȭ
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Player playerScript = player.GetComponent<Player>();
            playerScript.food = GameManager.instance.playerFoodPoints;

            // MAIN ������ �̵�
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        public void Menu()
        {
            Debug.Log("MenuButton Pressed");

            // INTRO ������ �̵�
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        public void Quit()
        {
            Debug.Log("QuitButton Pressed");
            // ���� ����
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
        }
    }
}
