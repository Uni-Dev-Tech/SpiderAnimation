using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimation : MonoBehaviour
{
    private Animator animator;
    static public bool fly = false;
    static public bool move;
    private bool count = true;
    static public bool death = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Alive", true);
    }
    private void Update()
    {
        if (animator != null)
        {
            float forward = Input.GetAxis("Vertical");
            float right = Input.GetAxis("Horizontal");
            animator.SetFloat("Forward", forward);
            animator.SetFloat("Right", right);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack");
            }
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                animator.SetTrigger("AttackDistance");
            }
            if(Input.GetKeyDown(KeyCode.Space) && move == true)
            {
                animator.SetTrigger("startJump");
            }
            if (CharCont.jumpLanding == true)
            {
                if (CharCont.vertical.y < -50) animator.SetBool("Alive", false);
                if (CharCont.cont.isGrounded == true)
                {
                    animator.SetTrigger("finishJump");
                    CharCont.jumpLanding = false;
                    count = true;
                }
            }
            if (CharCont.cont.isGrounded == false && count == true)
            {
                count = false;
                animator.SetTrigger("fall");
                Invoke("WaitForLanding", 0.1f);
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Move") == true) move = true;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Move") == false) move = false;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death") == true) death = true;
        }
    }
    public void WaitForLanding()
    {
        CharCont.jumpLanding = true;
    }
}
