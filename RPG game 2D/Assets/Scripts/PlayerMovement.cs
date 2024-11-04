using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.5f;

    public SpriteRenderer spriteRenderer;
    public Animator PlayerAnim;
    public string ParameterName;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, moveY, 0);
        transform.position += movement * speed * Time.deltaTime;

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
             PlayerAnim.SetBool(ParameterName, true);
        }
        else
        {
             PlayerAnim.SetBool(ParameterName, false);
        }
        if(Input.GetAxis("Horizontal") >= 0 )
        {
             spriteRenderer.flipX = false;
        }
         if(Input.GetAxis("Horizontal") <= 0 )
        {
             spriteRenderer.flipX = true;
        }

    }
}
