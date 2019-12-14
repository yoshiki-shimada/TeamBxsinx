using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// どの方向に進んでいるか
enum SpiderState
{
    WALK,
    ROTATE,
    SHADOW,
}

public class Enemy_Spider : MonoBehaviour
{
    MeshCollider[] col=new MeshCollider[2];
    Rigidbody rb;
    SpiderState EState = SpiderState.WALK;
    SpiderState State = SpiderState.WALK;
    bool flag = false;
    Collider ShadowCol;

    Quaternion quat;
    Vector3 quatPos;

    [SerializeField]
    float[] xRange = new float[2];  // [0]->左 [1]->右   の間を往復

    Vector3 onPlane = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        SpiderInit();
    }
    void SpiderInit()
    {
        col[0] = GetComponent<MeshCollider>();
        col[1] = transform.GetChild(1).GetComponent<MeshCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RaycastHit hit2;
            if (Physics.Raycast(transform.position+transform.up*0.1f,
                -transform.right, //-transform.up, //
                out hit2, 2f))
            {
                //Debug.Log(hit2.distance);
            }
            Debug.Log(EState);
            //Debug.Log(State);           
            //Debug.Log(transform.rotation + "<->" + quat);
        }

        if (EState == SpiderState.SHADOW)
        {
            if (!ShadowCol.enabled)
            {
                rb.isKinematic = false;
                for (int i = 0; i < 2; i++)
                    col[i].isTrigger = false;
                EState = State;
                flag = false;
            }
        }

        if (EState == SpiderState.WALK && !CheckCollide())
        {
            rb.MovePosition(-transform.right * Time.deltaTime + transform.position);

            if (transform.position.x <= xRange[0])
            {
                quat = Quaternion.Euler(0, 180, 0);
                EState = SpiderState.ROTATE;
            }
            else if (transform.position.x >= xRange[1])
            {
                quat = Quaternion.Euler(0, 0, 0);
                EState = SpiderState.ROTATE;
            }
        }
        if (EState==SpiderState.ROTATE)
        {
            if (quatPos != Vector3.zero)
                 rb.MovePosition(quatPos);

            transform.localRotation = 
                Quaternion.Slerp(transform.localRotation, quat, 0.3f);

            if (transform.localRotation.eulerAngles == quat.eulerAngles)
            {
                Debug.Log("RotComplete");
                EState = SpiderState.WALK;
            }
        }

    }

    private bool CheckCollide()
    {
        
        RaycastHit hit;

        if (Physics.Raycast(transform.position + transform.up * 0.65f,
            -transform.right,
            out hit, 0.33f,
            LayerMask.GetMask("Stage")))
        {
            //Debug.Log("Efored" + hit.distance);
            Vector3 normal = hit.normal;
            
           // onPlane = Vector3.ProjectOnPlane(transform.right, normal);
            quat = Quaternion.FromToRotation(Vector3.up, normal);
            
            if (transform.rotation != quat)
            {
                quat.eulerAngles = AngleSet(quat.eulerAngles);
                if (hit.distance >= 0.001f)
                {
                    // Debug.Log(hit.point);
                    //quatPos = hit.point;
                    rb.MovePosition(hit.point);
                }

                EState = SpiderState.ROTATE;
                //Debug.Log("forward");
                return true;
            }
        }

        if(!Physics.Raycast(transform.position+transform.up*0.01f,
            -transform.up,out hit , 0.01f))
            if (Physics.Raycast(transform.position,
                (transform.right) + (-transform.up),
                out hit, 1.5f))
            {
                //Debug.Log(hit.distance);

                Vector3 normal = hit.normal;

               // onPlane = Vector3.ProjectOnPlane(transform.right, normal);
                quat = Quaternion.FromToRotation(Vector3.up, normal);

                if (transform.localRotation != quat)
                {
                    quat.eulerAngles = AngleSet(quat.eulerAngles);

                    if (hit.distance >= 0.001f)
                    {
                        //quatPos =  hit.point;
                        quatPos = Vector3.zero;
                        rb.MovePosition(hit.point);
                    }
                    EState = SpiderState.ROTATE;
                    //Debug.Log("down");
                    return true;
                }
            }
        
        return false;
    }

    Vector3 AngleSet (Vector3 angle)
    {
        if (transform.localRotation.eulerAngles.y < 90 &&
            transform.localRotation.eulerAngles.y > -90)
        {
            return angle;
        }
        else if(transform.localRotation.eulerAngles.y >= 90 ||
            transform.localRotation.eulerAngles.y <= -90)
        {
            //angle.x = angle.x + 180;
            angle.y = 180;
            angle.z *= -1;
            return   angle;
        }
        Debug.Log("Error");
        return Vector3.up;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3( xRange[0],2.5f,transform.position.z),
            new Vector3( xRange[1],2.5f,transform.position.z));
        Gizmos.DrawRay(transform.position, 
            (transform.right) + (-transform.up));
        Gizmos.DrawRay(transform.position + transform.up*0.65f,
            -transform.right);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
            collision.rigidbody.AddForce(
                (-collision.transform.right + collision.transform.up) * 3f,
                ForceMode.VelocityChange);
            collision.transform.GetComponent<Player>().damage(1f);
        }
        else if(collision.transform.tag=="ShadowObject")
        {
            if (!flag)
            {
                ShadowCol = collision.collider;
                State = EState;
                flag = true;
            }
            EState = SpiderState.SHADOW;
            rb.isKinematic = true;
            for (int i = 0; i < 2; i++)
                col[i].isTrigger = true;
            
        }
    }

   /* private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag=="ShadowObject")
        {
            if (!flag)
            {
                State = EState;
                flag = true;
            }
            EState = SpiderState.SHADOW;
            rb.isKinematic = true;
            for (int i = 0; i < 2; i++)
                col[i].isTrigger = true;
            Debug.Log("ShadowEnter");
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        rb.isKinematic = false;
        for (int i = 0; i < 2; i++)
            col[i].isTrigger = false;
        if (flag)
        {
            EState = State;
            flag = false;
        }
        Debug.Log(other.bounds.size);
    }
}
