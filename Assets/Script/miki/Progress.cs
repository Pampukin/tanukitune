using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public float progress = 0;
    [SerializeField,Tooltip("生成半径")]
    private float radi  = 24;
    public static float rad;
    public GameObject progress1;
    public GameObject progress2;
    public GameObject progress3;
    public GameObject progress4;
    public GameObject progress5;
    public Transform parentTran;

    GameObject[] array = new GameObject[5];


    private void Awake()
    {
        rad = radi;
    }


    // Start is called before the first frame update
    void Start()
    {
        array[0] = progress1;
        array[1] = progress2;
        array[2] = progress3;
        array[3] = progress4;
        array[4] = progress5;

        for (int i = 0; i < 5; i++)
        {
            GameObject g = array[i];
            g.transform.SetParent(parentTran);
        }
    }

    // Update is called once per frame
    void Update()
    {
        progress = gameSystem.pro;
        if (progress < 0)
        {
            progress = 0;
        }
        else if (progress == 0)
        {
            progress1.SetActive(false);
            progress2.SetActive(false);
            progress3.SetActive(false);
            progress4.SetActive(false);
            progress5.SetActive(false);
        }
        else if (progress == 1)
        {
            progress1.SetActive(true);
            progress2.SetActive(false);
            progress3.SetActive(false);
            progress4.SetActive(false);
            progress5.SetActive(false);
        }
        else if (progress == 2)
        {
            progress1.SetActive(false);
            progress2.SetActive(true);
            progress3.SetActive(false);
            progress4.SetActive(false);
            progress5.SetActive(false);
        }
        else if (progress == 3)
        {
            progress1.SetActive(false);
            progress2.SetActive(false);
            progress3.SetActive(true);
            progress4.SetActive(false);
            progress5.SetActive(false);
        }
        else if (progress == 4)
        {
            progress1.SetActive(false);
            progress2.SetActive(false);
            progress3.SetActive(false);
            progress4.SetActive(true);
            progress5.SetActive(false);
        }
        else if (progress == 5)
        {
            progress1.SetActive(false);
            progress2.SetActive(false);
            progress3.SetActive(false);
            progress4.SetActive(false);
            progress5.SetActive(true);
        }
        else
        {

            progress = 5;
        }

    }
}
