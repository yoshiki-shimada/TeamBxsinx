using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Scene
{
    TEST,
    TITLE,
    RURLE,
    GAME,
    GAMEOVER,
    GAMECLEAR
};

public class SoundManager : MonoBehaviour
{
    public GameObject soundManager;

    public AudioClip title;     //タイトル
    public AudioClip rurle;     //ルール
    public AudioClip game;      //ゲーム
    public AudioClip gameover;  //ゲームオーバー
    public AudioClip gameclear; //ゲームクリア
    public bool isBGM;


    private AudioSource audioSource;

    string sceneName;
    // Start is called before the first frame update
    void Awake()
    {

        DontDestroyOnLoad(soundManager);

        sceneName = SceneManager.GetActiveScene().name;//SceneManager.sceneCount;

        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        isBGM = false;
    }

    // Update is called once per frame
    void Update()
    {
        //string beforeScene = sceneName;
        //string activeScene = SceneManager.GetActiveScene().name;//sceneCount;

        //if (beforeScene == activeScene)
        //{
            if (!isBGM)
            {
                switch (sceneName)
                {
                    case "test": audioSource.clip = title; break;
                    case "TitleScene": audioSource.clip = title; break;
                    case "RurleScene": audioSource.clip = title; break;
                    case "MainScene": audioSource.clip = game; break;
                    case "Pause": audioSource.clip = title; break;
                    case "GameOver": audioSource.clip = gameover; break;
                    case "GameClear": audioSource.clip = gameclear; break;
                }
                audioSource.Play();
                isBGM = true;
             /*    Debug.Log("sound" + activeScene);
                if(activeScene=="test")//if (activeScene == (int)Scene.TEST)
                {
                    audioSource.clip = title;
                    audioSource.Play();
                    isBGM = true;
                    beforeScene = activeScene;
                }
             */
            }

        //}
        //else if (sceneName != activeScene) { isBGM = false; audioSource.Stop(); }


    }


    /*
        //=====================================================
        //Title
        public void TitleBGM()
        {
            audioSource.clip = title;
            audioSource.Play();
        }
        //=====================================================
        //Rurle
        public void RurleBGM()
        {
            audioSource.clip = rurle;
            audioSource.Play();
        }
        //=====================================================
        //Game
        public void GameBGM()
        {
            audioSource.clip = game;
            audioSource.Play();
        }
        //=====================================================
        //GameClear
        public void GameClearBGM()
        {
            audioSource.clip = gameclear;
            audioSource.Play();
        }
        //=====================================================
        //GameOver
        public void GameOverBGM()
        {
            audioSource.clip = gameover;
            audioSource.Play();
        }
        //=====================================================
        //test
        public void testBGM()
        {
            audioSource.clip = gameover;
            audioSource.Play();
        }
    */
}