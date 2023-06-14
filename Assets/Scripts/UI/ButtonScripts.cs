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
        public Button playButton;       // 플레이 버튼
        public Button levelButton;      // 레벨 버튼
        public Button quitButton;       // 나가기 버튼
        public Button confirmButton;    // 확인 버튼
        public InputField levelInput;   // 레벨 입력받는 인풋 필드

        // Start is called before the first frame update
        void Start()
        {
            // 각각의 버튼에 온클릭 리스너 추가하기
            playButton.onClick.AddListener(clickPlay);
            levelButton.onClick.AddListener(clickLevel);
            quitButton.onClick.AddListener(clickQuit);
        }
    
        void clickPlay()
        {
            Debug.Log("PlayButton Pressed");

            // 플레이어 오브젝트 찾기
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Player 스크립트의 food를 100으로 설정
                Player playerScript = player.GetComponent<Player>();
                playerScript.food = 100;
            }
            if(GameManager.instance != null)
            {
                // GameManager 오브젝트의 food포인트와 level을 초기화
                GameManager.instance.playerFoodPoints = 100;
                GameManager.instance.level = 1;
            }

            // MAIN 씬 로드
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        void clickLevel()
        {
            Debug.Log("LevelButton Pressed");
            // 온클릭 이벤트로 팝업창 띄움
        }
        void clickQuit()
        {
            Debug.Log("QuitButton Pressed");
            // 게임 종료
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
        }
        public void clickConfirm()
        {
            Debug.Log("ConfirmButton Pressed");
            // level 버튼을 눌러 팝업이 띄워지고 Confirm을 클릭 했을 때

            // InputField의 값을 문자열로 가져옴
            string inputText = levelInput.text;

            int level;
            bool isNumeric = int.TryParse(inputText, out level);

            // 입력된 값이 0보다 큰 정수인지 확인
            bool isValidLevel = isNumeric && level > 0 && level < 21;

            if (isValidLevel)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    // Player 스크립트의 food를 100으로 설정
                    Player playerScript = player.GetComponent<Player>();
                    playerScript.food = 100;
                }
                if (GameManager.instance != null)
                {
                    // GameManager 오브젝트의 food포인트와 level을 초기화
                    GameManager.instance.playerFoodPoints = 100;
                    GameManager.instance.level = level;
                }

                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
            else
            {
                // 입력 값이 유효하지 않을 때
                Debug.Log("Invalid Level");
            }
        }

    }
}