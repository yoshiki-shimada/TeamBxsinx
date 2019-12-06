using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject soundManager;

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
    private void BGM()
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

    //jump-----------------------------------------------------
    public void jumpSE()
    {
        Debug.Log("jump");
        audioSource.PlayOneShot(jump);
    }

    //changelight----------------------------------------------
    public void changelightSE()
    {
        Debug.Log("changeLight");
        audioSource.PlayOneShot(changelight);
    }

    //changeplayer---------------------------------------------
    public void changeplayerSE()
    {
        Debug.Log("changePlayer");
        audioSource.PlayOneShot(changeplayer);
    }









    //---------------------------------------------------------
    /*
    //triggerとなるscriptに書くPlayerのscriptの中で
    GameObject soundManager;

    soundManager = GameObject.Find("SoundManager");
    soundManager.GetComponent<SoundManager>.jumpSE();
    soundManager.GetComponent<SoundManager>.changelightSE();
    soundManager.GetComponent<SoundManager>.changeplayerSE();
    */
    //---------------------------------------------------------
}