using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCasts : MonoBehaviour
{
    public Transform RightArm;

    public bool rightTopCheck = false;
    public bool rightBotCheck = false;
    public bool rightCheck = false;

    void FixedUpdate()
    {

        RaycastHit2D rightCast;
        rightCast = Physics2D.BoxCast(transform.position, new Vector2(0.5f * RightArm.transform.localScale.x, 0.9f), 0, Vector2.right, 0.2f, LayerMask.GetMask("Obstacle"));
        if (rightCast.collider != null)
        {
            rightCheck = true;
        }
        else
        {
            rightCheck = false;
        }

        RaycastHit2D rightTopCast;
        rightTopCast = Physics2D.BoxCast(transform.position, new Vector2(0.5f * RightArm.transform.localScale.x, 0.9f), 0, Vector2.up, 0.2f, LayerMask.GetMask("Obstacle"));
        if (rightTopCast.collider != null)
        {
            rightTopCheck = true;
        }
        else
        {
            rightTopCheck = false;
        }

        RaycastHit2D rightBotCast;
        rightBotCast = Physics2D.BoxCast(transform.position, new Vector2(0.5f * RightArm.transform.localScale.x, 0.9f), 0, Vector2.down, 0.2f, LayerMask.GetMask("Obstacle"));
        if (rightBotCast.collider != null)
        {
            rightBotCheck = true;
        }
        else
        {
            rightBotCheck = false;
        }
    }


}

