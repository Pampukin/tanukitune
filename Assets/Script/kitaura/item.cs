using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    private Transform myTrans;
    private Transform othTrans;
    private Vector3 target;
    private bool aimAssist = false;
    private Rigidbody rb;
    [SerializeField]
    private float mag = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.gameObject.transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        if (this.gameObject.transform.parent != null)
        {

            if (this.gameObject.transform.parent.tag == "Player")
            {
                this.rb.useGravity = true;
                this.rb.constraints = RigidbodyConstraints.None;
            }

        }
   
    }

    private void FixedUpdate()
    {

        if (aimAssist && this.gameObject.transform.parent== null)
        {
            rb.AddForce(mag * target);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "mag")
        { 
            GameObject o = other.gameObject;
            this.othTrans = o.transform;
            target = (othTrans.parent.position - myTrans.position).normalized;
            aimAssist = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "mag")
        {
            aimAssist = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy(this.gameObject, 1.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(this.gameObject.transform.parent == null)
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Friend")
            {
                Destroy(this.gameObject, 0.075f);

            }
        }

    }

    
}
