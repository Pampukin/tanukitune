//ゲームのシステム関連に関する処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSystem : MonoBehaviour
{
    public static bool isStart = false;
    private float currentTime = 0;
    private int amari = 0;
    private bool isChanged = false;

    public static bool isHit = false;
    public GameObject Canvas;

    [SerializeField,Tooltip("ゲームの進行度")]
    private float progress = 0;

    public static float pro = 0;

    [SerializeField]
    private GameObject Teleporting;

    [SerializeField]
    private GameObject Player;

    private Vector3 startPlayerPos;
    private Vector3 pPos;

    private void Awake()
    {
        progress = pro;

    }
    private void Start()
    {
        isStart = false;
        isHit = false;
        isStart = false;
        Canvas.SetActive(false);
        Teleporting.SetActive(true);
        pro = 0;
        isChanged = false;
        startPlayerPos = this.Player.transform.position;
        //DontDestroyOnLoad(this.gameObject);

    }
    void Update()
    {

        if (gameSystem.pro > 5)
        {
            gameSystem.pro = 5;

            if (SceneManager.GetActiveScene().name != "ClearScene" && !isChanged)
            {
                FadeManager.Instance.LoadScene("ClearScene", 2.0f);
                isChanged = true;
            }

        }
        else if (gameSystem.pro < 0)
        {
            gameSystem.pro = 0;
        }
        progress = pro;
        
        if (isStart) 
        {
            currentTime += Time.deltaTime;
            Teleporting.SetActive(false);
        }
        
        if((currentTime > 30) && (isStart == true))
        {
            RenderSettings.fogEndDistance = 15;
        }

        if(currentTime > 60)
        {
            RenderSettings.fogEndDistance = 1000;
        }

        if (isHit)
        {
            Canvas.SetActive(true);
            pPos = new Vector3(Player.transform.position.x, -0.1f, Player.transform.position.z);
            Player.transform.position = pPos;

        }
       
    }
}

   