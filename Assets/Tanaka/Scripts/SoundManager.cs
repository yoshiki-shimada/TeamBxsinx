using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject soundManager;

    [SerializeField] private AudioClip title;         //タイトル
    [SerializeField] private AudioClip rurle;         //ルール
    [SerializeField] private AudioClip game;          //ゲーム
    [SerializeField] private AudioClip gameover;      //ゲームオーバー
    [SerializeField] private AudioClip gameclear;     //ゲームクリア
    [SerializeField] private AudioClip jump;          //ジャンプ
    [SerializeField] private AudioClip changelight;   //ライトチェンジ
    [SerializeField] private AudioClip changeplayer;  //プレイヤーチェンジ
    [SerializeField] private AudioClip popshadow;     //シャドウ
    [SerializeField] private AudioClip damage;        //ダメージ受けてlifeが消える音
    [SerializeField] private AudioClip openpage;      //ページをめくる、紙を動かすとき
    [SerializeField] private AudioClip objscroll;     //centerのobjを動かすとき
    [SerializeField] private AudioClip stringswitch;  //ゴールの紐


    public bool isBGM;

    private AudioSource audioSource;

    string sceneName;


    // Start is called before the first frame update
    void Start()
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
                case "test4": audioSource.clip = game; break;
                case "TitleScene":// audioSource.clip = title; break;
                case "RurleScene": audioSource.clip = title; break;
                case "MainScene": audioSource.clip = game; break;
                case "Pause": audioSource.clip = title; break;
                case "GameOver": audioSource.clip = gameover; break;
                case "GameClear": audioSource.clip = gameclear; break;
            }
            Debug.Log("BGM"+sceneName);
            audioSource.Play();
            isBGM = true;
        }
    }

    //=========================================================
    //SE

    //jump-----------------------------------------------------
    public void jumpSE()
    {
        Debug.Log("jumpSE");
        audioSource.PlayOneShot(jump);
    }

    //changelight----------------------------------------------
    public void changelightSE()
    {
        Debug.Log("changeLightSE");
        audioSource.PlayOneShot(changelight);
    }

    //changeplayer---------------------------------------------
    public void changeplayerSE()
    {
        Debug.Log("changePlayerSE");
        audioSource.PlayOneShot(changeplayer);
    }

    //popshadow---------------------------------------------
    public void popshadowSE()
    {
        Debug.Log("changePlayerSE");
        audioSource.PlayOneShot(popshadow);
    }

    //damage---------------------------------------------
    public void damageSE()
    {
        Debug.Log("changePlayerSE");
        audioSource.PlayOneShot(damage);
    }

    //openpage,紙をめくるとき---------------------------
    public void openpageSE()
    {
        Debug.Log("openpageSE");
        audioSource.PlayOneShot(openpage);
    }

    //openpage,紙をめくるとき---------------------------
    public void objscrollSE()
    {
        Debug.Log("objSE");
        audioSource.PlayOneShot(objscroll);
    }

    //stringswitch,紐を引っ張ったとき---------------------------
    public void stinrgswitchSE()
    {
        Debug.Log("stringswitchSE");
        audioSource.PlayOneShot(stringswitch);
    }
    //---------------------------------------------------------
    /*
    //soundmanager呼び込み-------------------------------------
    GameObject soundManager;
    //void start()で-------------------------------------------
    soundManager = GameObject.Find("SoundManager");
    
    //鳴らしたいところで呼び出し-------------------------------
    soundManager.GetComponent<SoundManager>.jumpSE();         //jump
    soundManager.GetComponent<SoundManager>.changelightSE();  //changelight
    soundManager.GetComponent<SoundManager>.changeplayerSE(); //changeplayer
    soundManager.GetComponent<SoundManager>.damageSE();       //damage
    soundManager.GetComponent<SoundManager>.openpageSE();     //openpage
    soundManager.GetComponent<SoundManager>.objscrollSE();    //centerobj
    if(this.gameobject.transform.y =< 1){                     //stringswitch
    soundManager.GetComponent<SoundManager>.stringswitchSE(); 
    }
    */
    //---------------------------------------------------------
}