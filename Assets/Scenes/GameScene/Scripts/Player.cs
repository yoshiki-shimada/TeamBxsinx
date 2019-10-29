using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //   {SerializeField]はインスペクターでの編集を可能にする
    [SerializeField] private Vector3 direction;
    [SerializeField] private float moveSpeed = 2.0f;        //! 移動速度
    [SerializeField] private float jampSpeed = 9.0f;        //! ジャンプの高さ
    [SerializeField] private int m_iDamage;                 //! 体力
    public bool m_bDethFlag;
    private bool m_bJumpIn = false;
    private bool m_bIsJump = false;

    //! 左スティックInput Axisの名前
    //[SerializeField]
    //private string m_LeftHorizontalName, m_LeftVerticalName;
    
    private float hori;
    //RaycastHit hit;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider CapCol;


    [SerializeField] private GameObject light;

    // Start is called before the first frame update
    void Start()
    {

        m_bDethFlag = false;
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
                CapCol.height*0.8f  ,//- CapCol.radius + 0.1f,
               Physics.AllLayers))
            {
                Debug.Log("IsCast"+hit.distance);
                if (hit.distance<=CapCol.height*0.8)
                {
                    m_bIsJump = false;
                }
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
        if ( hori != 0)
        {
            /*  direction = Vector3.zero;
              if (LeftVertical < -0.5f)
                  direction.x -= 2;
              if (LeftVertical > 0.5f)
                  direction.x += 2;*/
            float x= hori * moveSpeed;
            x = 1000 * (x - rb.velocity.x) * Time.deltaTime;
            Debug.Log(x);
            rb.AddForce(x,0,0);
        }

    }

   /* void OnDrawGizmos()
    {

        var radius = transform.lossyScale.x * 0.5f;

        var isHit = Physics.SphereCast(transform.position, radius, transform.forward * 10, out hit);
        if (isHit)
        {
            Gizmos.DrawRay(transform.position, -transform.up * hit.distance);
            Gizmos.DrawWireSphere(transform.position + -transform.up * (hit.distance), radius);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 100);
        }
    }*/

}
