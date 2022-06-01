using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private GameObject Tree;
    private Transform trans;
    private Transform treeTrans;
    private Vector3 aim;
    private Rigidbody rb;
    private int MvDecide;
    private float theata = 0;
    private bool ismove = true;
    [SerializeField,Tooltip("向かってくる速度の重み")]
    private float addPower = 1.2f;
    [SerializeField, Tooltip("maxスピード")]
    private float maxSpeed = 0;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        trans = this.gameObject.transform;
        treeTrans = Tree.transform;
        aim = Tree.transform.position - trans.position; //(aim.x, o, aim.z)
        aim.y = 0.3f;
        rb = this.gameObject.GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();
        //rb.AddForce(addPower * aim);

    }

    // Update is called once per frame
    void Update()
    {
        if (Tree)
        {
            transform.LookAt(treeTrans.position);
        }
        
    }

    private void FixedUpdate()
    {
        if (this.rb.velocity.magnitude <= maxSpeed)
        {

            this.aim = (Tree.transform.position - trans.position).normalized; //(aim.x, o, aim.z)

            move1(this.aim);
        }

    }

    //直進
    void move1(Vector3 aim)
    {
        rb.AddForce(addPower * aim);
    }

    //螺旋
    void move2()
    {
        float sinAlpha = aim.z / Mathf.Sqrt(aim.x * aim.x + aim.z * aim.z);
        trans.position = new Vector3(trans.position.x + 0.01f*3*sinAlpha*Mathf.Cos(theata), trans.position.y, trans.position.z+0.01f*3*sinAlpha*Mathf.Sin(theata));
        theata += 0.1f;
    }

    void move3()
    {
        float sinAlpha = aim.z / Mathf.Sqrt(aim.x * aim.x + aim.z * aim.z);
        trans.position = new Vector3(trans.position.x + 0.01f * 10 * sinAlpha , trans.position.y, trans.position.z + 0.01f * 10 * sinAlpha* Mathf.Sin(theata));
        theata += 0.1f;
    }

    //AI 直進
    void chase()
    {
        if (Tree)
        {
            agent.destination = Tree.transform.position;
            //agent.speed = 2f;
        }
    }

    void plusCos(float a, float theat)
    {

        rb.AddForce(transform.right * a * Mathf.Cos(theata));
        theat += theat;
    }

    void wait()
    {
        rb.isKinematic = true;
    }
}
