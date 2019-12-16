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
    [SerializeField] private AudioClip buttonswitch;  //ゴールの紐


    public bool isBGM;

    private AudioSource[] audioSource;

    string sceneName;

    private void Start()
    {
        Debug.Log("SoundState");
        int soundPlay = FindObjectsOfType<SoundManager>().Length;
        DontDestroyOnLoad(soundManager);
        if (soundPlay > 1){Destroy(gameObject);}
        audioSource = GetComponents<AudioSource>();
        isBGM = false;
    }

    // Start is called before the first frame update
    public void State()
    {
        Debug.Log("SoundState");
        DontDestroyOnLoad(soundManager);

        sceneName = SceneManager.GetActiveScene().name;//SceneManager.sceneCount;

        audioSource = GetComponents<AudioSource>();
        audioSource[0].Stop();
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
                case "TitleScene":// audioSource[0].clip = title; break;
                case "RurleScene": audioSource[0].clip = title; break;
                case "MainScene": audioSource[0].clip = game; break;
                case "Pause": audioSource[0].clip = title; break;
                case "GameOver": audioSource[0].clip = gameover; break;
                case "GameClear": audioSource[0].clip = gameclear; break;
            }
            Debug.Log("BGM"+sceneName);
            audioSource[0].Play();
            isBGM = true;
        }
    }

    //=========================================================
    //SE

    //jump-----------------------------------------------------
    public void jumpSE()
    {
        Debug.Log("jumpSE");
        audioSource[1].PlayOneShot(jump);
    }

    //changelight----------------------------------------------
    public void changelightSE()
    {
        Debug.Log("changeLightSE");
        audioSource[1].PlayOneShot(changelight);
    }

    //changeplayer---------------------------------------------
    public void changeplayerSE()
    {
        Debug.Log("changePlayerSE");
        audioSource[1].PlayOneShot(changeplayer);
    }

    //popshadow---------------------------------------------
    public void popshadowSE()
    {
        Debug.Log("changePlayerSE");
        audioSource[1].PlayOneShot(popshadow);
    }

    //damage---------------------------------------------
    public void damageSE()
    {
        Debug.Log("changePlayerSE");
        audioSource[1].PlayOneShot(damage);
    }

    //openpage,紙をめくるとき---------------------------
    public void openpageSE()
    {
        Debug.Log("openpageSE");
        audioSource[1].PlayOneShot(openpage);
    }

    //openpage,紙をめくるとき---------------------------
    public void objscrollSE()
    {
        Debug.Log("objSE");
        audioSource[1].PlayOneShot(objscroll);
    }

    //stringswitch,紐を引っ張ったとき---------------------------
    public void stinrgswitchSE()
    {
        Debug.Log("stringswitchSE");
        audioSource[1].PlayOneShot(stringswitch);
    }

    //stringswitch,紐を引っ張ったとき---------------------------
    public void buttonswitchSE()
    {
        Debug.Log("buttonswitchSE");
        audioSource[1].PlayOneShot(buttonswitch);
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