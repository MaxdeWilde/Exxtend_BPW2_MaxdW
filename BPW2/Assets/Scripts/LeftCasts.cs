using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCasts : MonoBehaviour
{

    public Transform LeftArm;

    public bool leftTopCheck = false;
    public bool leftBotCheck = false;
    public bool leftCheck = false;

    void FixedUpdate()
    {

        RaycastHit2D leftCast;
        leftCast = Physics2D.BoxCast(transform.position, new Vector2(0.5f * LeftArm.transform.localScale.x, 0.9f), 0, Vector2.left, 0.2f, LayerMask.GetMask("Obstacle"));
        if (leftCast.collider != null)
        {
            leftCheck = true;
        }
        else
        {
            leftCheck = false;
        }

        RaycastHit2D leftTopCast;
        leftTopCast = Physics2D.BoxCast(transform.position, new Vector2(0.5f * LeftArm.transform.localScale.x, 0.9f), 0, Vector2.up, 0.2f, LayerMask.GetMask("Obstacle"));
        if (leftTopCast.collider != null)
        {
            leftTopCheck = true;
        }
        else
        {
            leftTopCheck = false;
        }

        RaycastHit2D leftBotCast;
        leftBotCast = Physics2D.BoxCast(transform.position, new Vector2(0.5f * LeftArm.transform.localScale.x, 0.9f), 0, Vector2.down, 0.2f, LayerMask.GetMask("Obstacle"));
        if (leftBotCast.collider != null)
        {
            leftBotCheck = true;
        }
        else
        {
            leftBotCheck = false;
        }
    }

   
}

