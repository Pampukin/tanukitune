//アイテムの生成に関する処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pop : MonoBehaviour
{

    public GameObject[] Prefabs;
    GameObject[] obj;
    public GameObject Items;
    [SerializeField, Tooltip("生成時間")]
    private float popTime;
    [SerializeField, Tooltip("最大生成アイテム数")]
    private int popItem;
    private float time;
    private int number;

    public static int itemNum; //最大生成個数

    private Vector3 genPos;
    private float posX, posZ;

    private bool isSet = false;

    void Start()
    {
        isSet = false;
        time = popTime;
        //現在の時刻でシード値を初期化
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }

    void Update()
    {
        if (gameSystem.isStart)
        {
            time -= Time.deltaTime;
            posX = UnityEngine.Random.Range(6f, 8f);

            posZ = UnityEngine.Random.Range(0.8f, 3f);
            while(6.8<posX && posX < 7.3)
            {
                posX = UnityEngine.Random.Range(6f, 8f);
                
            }
            while(1.7<posZ && posZ<2.3)
            {
                posZ = UnityEngine.Random.Range(0.8f, 3f);
            }
            genPos = new Vector3(posX, 1.95f, posZ);

            if (time <= 0.0f && itemNum < popItem)
            {

                time = popTime;
                //
                number = UnityEngine.Random.Range(0, 6);
                if(number<=2){
                    number = 1;
                }else{
                    number = 0;
                }

                GameObject ins =
                Instantiate(Prefabs[number], genPos, Quaternion.identity);

                if (!isSet)
                {
                    ins.transform.SetParent(Items.transform);
                }
                

            }
        }
        



    }
}

