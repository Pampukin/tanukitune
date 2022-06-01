//木の実に関する処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInTree : MonoBehaviour
{
    Rigidbody rb;
    private bool isCatched = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

}
