using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress1 : MonoBehaviour
{
    public int dvide;
    public GameObject Prefabs;
    private Vector3 pos;
    private float r = 0;
    private float radi=0;//生成半径
    public Transform parentTran;

    // Start is called before the first frame update
    void Start()
    {
        pos.y = 0;
        radi = Progress.rad;
        create();

    }

    void create()
    {
        for (int i = 0; i < dvide; i++)
        {
            pos.x = radi*Mathf.Sin(r) + 7;
            pos.z = radi*Mathf.Cos(r) + 2;
            GameObject go = Instantiate(Prefabs, pos, Quaternion.identity);
            go.transform.SetParent(parentTran);
            r = r + (2*Mathf.PI / dvide);
        }
    }
}
