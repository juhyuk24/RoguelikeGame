using Completed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Completed
{
    public class ButtonScripts : MonoBehaviour
    {
        public Button playButton;       // �÷��� ��ư
        public Button levelButton;      // ���� ��ư
        public Button quitButton;       // ������ ��ư
        public Button confirmButton;    // Ȯ�� ��ư
        public InputField levelInput;   // ���� �Է¹޴� ��ǲ �ʵ�

        // Start is called before the first frame update
        void Start()
        {
            // ������ ��ư�� ��Ŭ�� ������ �߰��ϱ�
            playButton.onClick.AddListener(clickPlay);
            levelButton.onClick.AddListener(clickLevel);
            quitButton.onClick.AddListener(clickQuit);
        }
    
        void clickPlay()
        {
            Debug.Log("PlayButton Pressed");

            // �÷��̾� ������Ʈ ã��
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Player ��ũ��Ʈ�� food�� 100���� ����
                Player playerScript = player.GetComponent<Player>();
                playerScript.food = 100;
            }
            if(GameManager.instance != null)
            {
                // GameManager ������Ʈ�� food����Ʈ�� level�� �ʱ�ȭ
                GameManager.instance.playerFoodPoints = 100;
                GameManager.instance.level = 1;
            }

            // MAIN �� �ε�
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        void clickLevel()
        {
            Debug.Log("LevelButton Pressed");
            // ��Ŭ�� �̺�Ʈ�� �˾�â ���
        }
        void clickQuit()
        {
            Debug.Log("QuitButton Pressed");
            // ���� ����
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
        }
        public void clickConfirm()
        {
            Debug.Log("ConfirmButton Pressed");
            // level ��ư�� ���� �˾��� ������� Confirm�� Ŭ�� ���� ��

            // InputField�� ���� ���ڿ��� ������
            string inputText = levelInput.text;

            int level;
            bool isNumeric = int.TryParse(inputText, out level);

            // �Էµ� ���� 0���� ū �������� Ȯ��
            bool isValidLevel = isNumeric && level > 0 && level < 21;

            if (isValidLevel)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    // Player ��ũ��Ʈ�� food�� 100���� ����
                    Player playerScript = player.GetComponent<Player>();
                    playerScript.food = 100;
                }
                if (GameManager.instance != null)
                {
                    // GameManager ������Ʈ�� food����Ʈ�� level�� �ʱ�ȭ
                    GameManager.instance.playerFoodPoints = 100;
                    GameManager.instance.level = level;
                }

                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
            else
            {
                // �Է� ���� ��ȿ���� ���� ��
                Debug.Log("Invalid Level");
            }
        }

    }
}