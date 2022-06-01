using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setItemNum : MonoBehaviour
{
    private int childNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        childNum = this.gameObject.transform.childCount;
        
        Pop.itemNum = childNum;
    }
}
