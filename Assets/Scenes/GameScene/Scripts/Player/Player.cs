using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //   {SerializeField]はインスペクターでの編集を可能にする
    [SerializeField] private Vector3 direction;
    [SerializeField] private float moveSpeed = 3.0f;        //! 移動速度
    [SerializeField] private float jampSpeed = 18.0f;        //! ジャンプの高さ
    [SerializeField] private int m_iDamage;                 //! 体力
    public bool m_bDethFlag;
    private bool m_bJumpIn;
    private bool m_bIsJump;

    //! 左スティックInput Axisの名前
    //[SerializeField]
    //private string m_LeftHorizontalName, m_LeftVerticalName;
    
    private float hori;
    private bool wallcheck;

    //RaycastHit hit;

    [SerializeField] private Rigidbody rb;          //! このオブジェクトについているもの
    [SerializeField] private CapsuleCollider CapCol;//! このオブジェクトについているもの


    [SerializeField] private LightManager lightManager;　//! LightManagerについているもの

    // Start is called before the first frame update
    void Start()
    {
        m_bJumpIn = false;
        m_bIsJump = false;
        m_bDethFlag = false;
        wallcheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxisRaw("GamePad1_LeftStick_H");

        if (m_bIsJump)
        {
            RaycastHit hit;
            if (Physics.SphereCast(this.transform.position,
                CapCol.radius * 0.5f,
                Vector3.down,
                out hit,
                1,//CapCol.height*0.5f - (CapCol.radius*0.5f) + 0.11f,
               Physics.AllLayers))
            {
                Debug.Log("IsCast"+hit.distance);
                Debug.Log(hit.point);
                /*  if (hit.distance<=CapCol.height*0.8)
                  {*/
                m_bIsJump = false;
                //}
            }
           // else { Debug.Log("castFailed"); }
        }

        if (Input.GetButtonDown("GamePad1_buttonB") && !m_bIsJump)
        {
            m_bJumpIn = true;
            // rb.velocity = new Vector3(0, jampSpeed, 0);
        }

        if (Input.GetButtonDown("GamePad1_buttonX") && !m_bIsJump)
        {
            lightManager.ChageLight();
        }

    }

    void FixedUpdate()
    {
        if (m_bJumpIn)
        {
            m_bJumpIn = false;
            if (!m_bIsJump)
            {
                m_bIsJump = true;
                rb.AddForce(Vector3.up * jampSpeed, ForceMode.Impulse);
            }
        }
        // Playerの移動
        if ( (hori != 0) && !wallcheck)
        {
            /*  direction = Vector3.zero;
              if (LeftVertical < -0.5f)
                  direction.x -= 2;
              if (LeftVertical > 0.5f)
                  direction.x += 2;*/
            float x= hori * moveSpeed;
            x = 1000 * (x - rb.velocity.x) * Time.deltaTime;
            // Debug.Log(x);
            rb.AddForce(x,0,0);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (m_bIsJump)
        {
            wallcheck = true;
            //  Debug.Log("TriggerEnter");
        }
        else
        {
            wallcheck = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
      //  Debug.Log("TriggerExit");
        wallcheck = false;
    }
     /*void OnDrawGizmos()
     {

         var radius = transform.lossyScale.x * 0.5f;

         var isHit = Physics.SphereCast(transform.position, radius, 
             new Vector3(0, (CapCol.height * 0.5f - CapCol.radius) + 0.3f,0), out hit);
         if (isHit)
         {
             Gizmos.DrawRay(transform.position, -transform.up * hit.distance);
             Gizmos.DrawWireSphere(transform.position + -transform.up * (hit.distance), radius);
         }
         else
         {
             Gizmos.DrawRay(transform.position, -transform.forward * 100);
         }
     }*/

}
