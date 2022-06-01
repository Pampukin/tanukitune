//スタートに関する処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasManager : MonoBehaviour
{
    public Text StartText;
    private int currentTime = 0;
    [SerializeField]
    private int StartTime = 3;

    private float timeByStart;
    // Start is called before the first frame update
    void Start()
    {
        StartText.text = StartTime.ToString();
        timeByStart = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeByStart -= Time.deltaTime;
        if(timeByStart > 0)
        {
            StartText.text = (Mathf.Ceil(timeByStart)).ToString();

        }
        else if (-1< timeByStart && timeByStart < 0)
        {
            StartText.text = "Start";
        }
        else if(timeByStart < -1)
        {
            this.gameObject.SetActive(false);
            gameSystem.isHit = false;
            gameSystem.isStart = true;
        }
    }
}
