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

    public AudioClip title;        //タイトル
    public AudioClip rurle;        //ルール
    public AudioClip game;         //ゲーム
    public AudioClip gameover;     //ゲームオーバー
    public AudioClip gameclear;    //ゲームクリア
    public AudioClip jump;         //ジャンプ
    public AudioClip changelight;  //ライトチェンジ
    public AudioClip changeplayer; //プレイヤーチェンジ
    //public AudioClip gameclear;  //
    //public AudioClip gameclear;  //


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
        BGM();
    }

    //=========================================================
    //BGM
    void BGM()
    {
        if (!isBGM)
        {
            switch (sceneName)
            {
                case "test2": audioSource.clip = game; break;
                case "TitleScene":// audioSource.clip = title; break;
                case "RurleScene": audioSource.clip = title; break;
                case "MainScene": audioSource.clip = game; break;
                case "Pause": audioSource.clip = title; break;
                case "GameOver": audioSource.clip = gameover; break;
                case "GameClear": audioSource.clip = gameclear; break;
            }
            Debug.Log(sceneName);
            audioSource.Play();
            isBGM = true;
        }
    }

    //=========================================================
    //SE

    public void jumpSE()
    {
        Debug.Log("jump");
        audioSource.PlayOneShot(jump);
    }
    public void changelightSE()
    {
        Debug.Log("changeLight");
        audioSource.PlayOneShot(jump);
    }
    public void changePlayerSE()
    {
        Debug.Log("changePlayer");
        audioSource.PlayOneShot(jump);
    }
    /*
    void SE()
    {
        switch (sceneName)
        {
            case "test2":
                if (Input.GetButtonDown("GamePad1_buttonB"))
                {
                    Debug.Log("buttonB");
                    audioSource.PlayOneShot(jump);
                }
                if (Input.GetButtonDown("GamePad1_buttonX"))
                {
                    Debug.Log("buttonX");
                    audioSource.PlayOneShot(changelight);
                }
                if (Input.GetButtonDown("GamePad1_button_Start"))
                {
                    Debug.Log("button_Start");
                }
                break;
            case "TitleScene": audioSource.clip = title; break;
            case "RurleScene": audioSource.clip = title; break;
            case "MainScene": audioSource.clip = game; break;
            case "Pause": audioSource.clip = title; break;
            case "GameOver": audioSource.clip = gameover; break;
            case "GameClear": audioSource.clip = gameclear; break;
        }
    }
    */

        /*
    //Playerのscriptの中で
    GameObject soundManager;
    SoundManagerScript soundManagerScript;

    SoundManager=GameObject.Find("SoundManager");
    soundScript=SoundManager.GetComponent<SoundManagerScript>();
        soundScript.jumpSE();
        */
}