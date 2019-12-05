using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState:byte
{
    Idle,
    Walk,
    Jump,
    Change,
    Clear,
}

public class Player : MonoBehaviour
{
    //   {SerializeField]はインスペクターでの編集を可能にする
    [SerializeField] private Vector3 direction;
    [SerializeField] private float moveSpeed = 3.0f;        //! 移動速度
    [SerializeField] private float jampSpeed = 18.0f;        //! ジャンプの高さ
    [SerializeField] private int m_iDamage;                 //! 体力
    [SerializeField] private ActiveLight Playernum;                 //! Playerの番号

    public bool m_bDethFlag;
    private bool m_bInvincible;
    private bool m_bJumpIn;
    private bool m_bIsJump;
    private bool m_bClear = false;
    public bool Clear
    {
        set { m_bClear = value; }
    }

    private float hori;
    

    private bool wallcheck;
    private sbyte walldis = 1;

    private PlayerState State = PlayerState.Idle;
    public int PState
    {
        get { return (int)State; }
    }
    //RaycastHit hit;

    [SerializeField] private Rigidbody rb;          //! このオブジェクトについているもの
    [SerializeField] private CapsuleCollider CapCol;//! このオブジェクトについているTriggerでないもの
    [SerializeField] private Animator animator;

    [SerializeField] private LightManager lightManager;　//! LightManagerについているもの
    [SerializeField] private PlayerHP HP;

    // Start is called before the first frame update
    void Start()
    {
        m_bJumpIn = false;
        m_bIsJump = false;
        m_bDethFlag = false;
        m_bInvincible = false;
        wallcheck = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((CrushPlayer() || m_iDamage >= 3) && !m_bClear)
        {
            m_bDethFlag = true;
        }
        if (m_bDethFlag)
        {
            //ゲームオーバー処理
            //transform.position = new Vector3(0, 0, 0);
            Debug.Log("You Lose");
        }
    }

    public void IsJump()
    {
        PlayerState Next = State;
        RaycastHit hit;
        if (Physics.SphereCast(CapCol.transform.position + CapCol.center,
            CapCol.radius,
            Vector3.down,
            out hit,
            CapCol.height * 0.5f - CapCol.radius + 0.01f,
           Physics.AllLayers))
        {
            //Debug.Log("IsCast" + hit.distance);
            //Debug.Log(CapCol.center);
            //Debug.Log(hit.point);

            //if (m_bIsJump)
            Next = PlayerState.Idle;
            m_bIsJump = false;
        }
        else
        {
            //if (!m_bIsJump)
            //State = PlayerState.Jump;
            m_bIsJump = true;
        }

        if (State != Next)
        {
            State = Next;
            animator.SetInteger("State", (int)State);
        }
    }

    public void UpdateP()
    {

       
        if (!m_bInvincible && !m_bDethFlag && !m_bClear)
        {
            hori = Input.GetAxisRaw("GamePad1_LeftStick_H");

            if (hori < 0)
            {
                //animator.SetBool("WarkFlag", false);
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.AngleAxis(180f, new Vector3(0, 1, 0)), 0.6f);
                if (wallcheck && walldis == 1)
                    hori = 0;
            }
            else if(hori > 0)
            {
               // animator.SetBool("WarkFlag", false);
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.AngleAxis(0f, new Vector3(0, 1, 0)), 0.6f);
                if (wallcheck && walldis == -1)
                    hori = 0;
            }
            if (!m_bIsJump) {
                if (hori == 0)
                    State = PlayerState.Idle;
                else
                    State = PlayerState.Walk;
            }
            

            if (Input.GetButtonDown("GamePad1_buttonB") && !m_bIsJump)
            {
                m_bJumpIn = true;
                State = PlayerState.Jump;
            }

            if (Input.GetButtonDown("GamePad1_buttonX") && !m_bIsJump)
            {
                State = PlayerState.Change;
                lightManager.ChageLight(Playernum);
            }

        }
        else if (m_bClear)
        {
            rb.isKinematic = true;
            State = PlayerState.Clear;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            RaycastHit hit;
            if (Physics.SphereCast(CapCol.transform.position + CapCol.center,
                CapCol.radius,
                Vector3.down,
                out hit,
                10,
                Physics.AllLayers))
            {
                Debug.Log("IsCast" + hit.distance);
                Debug.Log(hit.point);
                Debug.Log(CapCol.height * 0.5f - CapCol.radius+0.01f);
            }
            //damage(1f);
            //m_bClear = true;
        }

        
            animator.SetInteger("State", (int)State);
    }

    public void FixedUpdateP()
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
        if ((hori != 0))
        {
            float x = hori * moveSpeed;
            x = 1000 * (x - rb.velocity.x) * Time.deltaTime;
            // Debug.Log(x);
            rb.AddForce(x, 0, 0);
        }
       // else
         

    }

    private void OnTriggerStay(Collider other)
    {
        if (m_bIsJump)
        {
            if (0 < transform.position.x - other.ClosestPointOnBounds(transform.position).x)
                walldis = 1;
            else
                walldis = -1;

            wallcheck = true;
             // Debug.Log("TriggerEnter");
        }
        else
        {
            wallcheck = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("TriggerExit");
        wallcheck = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (!m_bInvincible)
            {
                damage(1f);
            }
        }
    }
    public void damage(float time)
    {
        rb.AddForce((-transform.right + transform.up)*8,
            ForceMode.Impulse);
        m_iDamage++;
        m_bInvincible = true;
        Invoke("InvincibleEnd", time);
        HP.Off(m_iDamage-1);
    }

    void InvincibleEnd()
    {
        m_bInvincible = false;
    }

    bool CrushPlayer()
    {
        if (lightManager.changelight)
            return false;
        float posplus = CapCol.height * 0.5f - CapCol.radius;
        Vector3 pos = transform.position + CapCol.center;
        Vector3 pos2 = new Vector3(pos.x, pos.y +posplus-0.1f , pos.z);
        pos.y -= posplus+0.1f;
        return Physics.CheckCapsule(pos,pos2,
            CapCol.radius *0.5f, 
            ~LayerMask.GetMask("Player", "Enemy", "Stage","GoalLope"));
    }

    public void ReSpawn(Vector3 pos)
    {
        transform.position = pos;
    }

   /* void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hit.point, CapCol.radius*1.3f);

        //Gizmos.DrawWireSphere(transform.position + CapCol.center, CapCol.radius - 0.1f);
       /* var radius = transform.lossyScale.x * 0.5f;

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
        }*/
    //}

}
