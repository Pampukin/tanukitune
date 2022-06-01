//タヌキの生成に関する処理

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPop : MonoBehaviour
{

    [SerializeField]
    [Tooltip("生成するEnemy")]
    private GameObject createEnemyPrefab;
    [SerializeField]
    [Tooltip("生成するFriend")]
    private GameObject createFriendPrefab;
    [SerializeField,Tooltip("Enemy生成範囲最小")]
    private float minRe;
    [SerializeField, Tooltip("Enemy生成範囲最大")]
    private float maxRe;
    [SerializeField, Tooltip("Friend生成範囲最小")]
    private float minRf;
    [SerializeField, Tooltip("Friend生成範囲最大")]
    private float maxRf;
    [SerializeField, Tooltip("Enemy生成数最大")]
    private int MaxE = 4;
    [SerializeField, Tooltip("Friend生成数最大")]
    private int MaxF = 4;


    // 経過時間
    private float time1;
    private float time2;

    public static int countE = 1;
    public static int countF = 1;

    private Vector3 posE;
    private Vector3 posF;

    [SerializeField]
    private float createTimeEnemy=3f;
    [SerializeField]
    private float createTimeFriend=3f;



    // Start is called before the first frame update
    void Start()
    {
        posE.y = -0.1f;
        posF.y = -0.1f;
        countE = 1;
        countF = 1;

        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSystem.isStart)
        {
            // 前フレームからの時間を加算していく
            time1 = time1 + Time.deltaTime;
            time2 = time2 + Time.deltaTime;

            // 敵がcreateTimeEnemy置きにランダムに生成されるようにする。
            if (time1 > createTimeEnemy)
            {
                if (RandomPop.countE < MaxE)
                {
                    createEnemyPrefab.tag = "Enemy";
                    float randomRe = UnityEngine.Random.Range(minRe, maxRe);
                    float radomXe = UnityEngine.Random.Range(-randomRe, randomRe);
                    posE.x = radomXe;
                    posE.z = PosZ(radomXe, randomRe);
                    //Debug.Log(posE.x * posE.x + posE.z * posE.z);
                    // GameObjectを上記で決まったランダムな場所に生成
                    Instantiate(createEnemyPrefab, posE, createEnemyPrefab.transform.rotation);

                    // 経過時間リセット
                    time1 = 0f;
                    RandomPop.countE++;
                }
            }

            // 味方がcreatTimeFreiend置きにランダムに生成されるようにする。
            if (time2 > createTimeFriend)
            {
                if (RandomPop.countF < MaxF)
                {
                    createFriendPrefab.tag = "Friend";
                    float randomRf = UnityEngine.Random.Range(minRf, maxRf);
                    float radomXf = UnityEngine.Random.Range(-randomRf, randomRf);
                    posF.x = radomXf;
                    posF.z = PosZ(radomXf, randomRf);
                    // GameObjectを上記で決まったランダムな場所に生成
                    Instantiate(createFriendPrefab, posF, createFriendPrefab.transform.rotation);

                    // 経過時間リセット
                    time2 = 0f;
                    RandomPop.countF++;
                }
            }
        }
       
    }

    float PosZ(float x,float r)
    {
        float z = Mathf.Sqrt(r * r - x * x);
        int i = UnityEngine.Random.Range(0, 2);
        if (i == 1)
        {
            return -z;
        }
        else
        {
            return z;
        }
    }
}
