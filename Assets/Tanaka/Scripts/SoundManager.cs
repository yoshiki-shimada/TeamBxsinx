using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public GameObject soundManager;

    public AudioClip title;     //タイトル
    public AudioClip rurle;     //ルール
    public AudioClip game;      //ゲーム
    public AudioClip gameover;  //ゲームオーバー
    public AudioClip gameclear; //ゲームクリア

    

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(soundManager);

        audioSource = GetComponent<AudioSource>();
    

    }

    // Update is called once per frame
    void Update()
    {
        //タイトルとルールは一緒
        for(int i=0;i< SceneManager.sceneCount; i++)
        {
           //  a[] = SceneManager.GetSceneAt(i);

        }

        audioSource.Stop();
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "TitleScene") {
            Debug.Log(title);
            audioSource.clip = title;
            audioSource.Play();
        }
        else if (sceneName == "RurleScene") {
            audioSource.clip = rurle;
            audioSource.Play();
        }
        else if (sceneName == "MainScene") {
            Debug.Log(game);
            audioSource.clip = game;
            audioSource.Play();
        }
        else if (sceneName == "GameClear") {
            audioSource.clip = gameclear;
            audioSource.Play();
        }
        else if (sceneName == "GameOver") {
            audioSource.clip = gameover;
            audioSource.Play();
        }
        else if (sceneName == "test") {
            Debug.Log(game);
            audioSource.clip = gameover;
            audioSource.Play();
        }
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