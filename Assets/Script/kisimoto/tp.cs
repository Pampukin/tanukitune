using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp : MonoBehaviour
{
    private Vector3 dre;
    [SerializeField,Tooltip("本体")]
    private GameObject Parent;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //ゲームの開始合図
            gameSystem.isHit = true;
            //teleport本体
            Parent.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //ゲームの開始合図
            gameSystem.isHit = true;
            Parent.SetActive(false);
        }
    }
}
