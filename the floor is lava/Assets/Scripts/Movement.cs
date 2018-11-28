using UnityEngine;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{

    [SerializeField] private float m_moveSpeed = 2;    //serialized variables fields
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private float m_jumpForce = 4;
    [SerializeField] private Animator m_animator; //ref to animator
    [SerializeField] private Rigidbody m_rigidBody;//ref to rigidbody

   

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;   //read only scale thresh holds for movement blend tree animations
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool m_wasGrounded; //was the player grounded
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();

    private void OnCollisionEnter(Collision collision)
    {
        
                m_isGrounded = true;
            
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
            m_isGrounded = true;
           
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
        m_isGrounded = false; 
    }

    void Update()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        PlayerMovement();
        m_wasGrounded = m_isGrounded;
    }

    private void PlayerMovement()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool walk = Input.GetKey(KeyCode.LeftShift); //shift key to walk slowly

        if (v < 0)
        {
            if (walk) { //if holding shift key down
                v *= m_backwardsWalkScale;
            }
            else {
                v *= m_backwardRunScale;
            }
        }
        else if (walk)
        {
            v *= m_walkScale;
        }
                                //interpolate to find value between 2 numbers by 100%
        m_currentV = Mathf.Lerp(m_currentV, v, m_interpolation * Time.deltaTime);//current velocity equal to 
        m_currentH = Mathf.Lerp(m_currentH, h, m_interpolation * Time.deltaTime);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        m_animator.SetFloat("MoveSpeed", m_currentV);

        JumpingAndLanding();
    }

    

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval; //allow jumping when cool down

        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse); //let us jump
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land"); //set land animation to play
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump"); //set jump animation to play
        }
    }
}
