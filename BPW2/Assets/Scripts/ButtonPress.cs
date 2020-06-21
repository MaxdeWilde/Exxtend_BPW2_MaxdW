using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{

    public bool isPressed = false;

    public bool top;
    public bool bot;
    public bool left;
    public bool right;

    void Update()
    {

        if (top)
        {
            RaycastHit2D topPress;
            topPress = Physics2D.BoxCast(transform.position, transform.localScale, 0, Vector2.up, 0.15f, LayerMask.GetMask("Player"));
            if (topPress.collider != null)
            {
                isPressed = true;
            }
            else
            {
                isPressed = false;
            }
        }

        if (bot)
        {
            RaycastHit2D botPress;
            botPress = Physics2D.BoxCast(transform.position, transform.localScale, 0, Vector2.down, 0.15f, LayerMask.GetMask("Player"));
            if (botPress.collider != null)
            {
                isPressed = true;
            }
            else
            {
                isPressed = false;
            }
        }

        if (left)
        {
            RaycastHit2D leftPress;
            leftPress = Physics2D.BoxCast(transform.position, transform.localScale, 0, Vector2.left, 0.15f, LayerMask.GetMask("Player"));
            if (leftPress.collider != null)
            {
                isPressed = true;
            }
            else
            {
                isPressed = false;
            }
        }

        if (right)
        {
            RaycastHit2D rightPress;
            rightPress = Physics2D.BoxCast(transform.position, transform.localScale, 0, Vector2.right, 0.15f, LayerMask.GetMask("Player"));
            if (rightPress.collider != null)
            {
                isPressed = true;
            }
            else
            {
                isPressed = false;
            }
        }



    }





    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        pPressed = true;
    //    }
    //}

    //void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        pPressed = false;
    //    }
    //}

}
