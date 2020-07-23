using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : MonoBehaviour
{
    static public CharacterController cont;
    public float speed;
    public float rotSpeed;
    public float gravityForce;
    static public bool jumpLanding;
    static public Vector3 vertical;
    public Vector3 jumpVerticalSpeed;
    private Vector3 resultMove, resultRot;

    private void Start()
    {
        cont = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float z = Input.GetAxisRaw("Vertical");
        float y = Input.GetAxisRaw("Horizontal");
        if (cont.isGrounded == true) resultMove = transform.forward * -z;
        if (cont.isGrounded == true) resultRot = new Vector3(0, y, 0);
        if (SpiderAnimation.death == false) cont.Move(((resultMove * speed) + vertical) * Time.deltaTime);
        if (SpiderAnimation.death == false) cont.transform.Rotate(resultRot * rotSpeed * Time.deltaTime);

        if (cont.isGrounded) vertical = new Vector3(0, -1, 0);
        if (!cont.isGrounded) vertical += -Vector3.up * gravityForce;
        if (cont.isGrounded == true && Input.GetKeyDown(KeyCode.Space) && SpiderAnimation.move == true)
        {
            Invoke("WaitBeforeJump", 0.6f);
        }
    }
    /// <summary>
    /// Задержка для проигрывания анимации отталкивания от поверхности
    /// </summary>
    public void WaitBeforeJump()
    {
        vertical += jumpVerticalSpeed;
        Invoke("WaitForLanding", 0.1f);
    }
    /// <summary>
    /// Решает "баг" перескока через анимацию InAir благодаря небольшой задержки
    /// </summary>
    public void WaitForLanding()
    {
        jumpLanding = true;
    }
}
