using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCasts : MonoBehaviour
{

    public Transform BottomArm;

    public bool botRightCheck = false;
    public bool botLeftCheck = false;
    public bool botCheck = false;

    void FixedUpdate()
    {

        RaycastHit2D botRightCast;
        botRightCast = Physics2D.BoxCast(transform.position, new Vector2(1f, 0.4f* BottomArm.transform.localScale.y), 0, Vector2.right, 0.2f, LayerMask.GetMask("Obstacle"));
        if (botRightCast.collider != null)
        {
            botRightCheck = true;
        }
        else
        {
            botRightCheck = false;
        }

        RaycastHit2D botLeftCast;
        botLeftCast = Physics2D.BoxCast(transform.position, new Vector2(1f, 0.4f * BottomArm.transform.localScale.y), 0, Vector2.left, 0.2f, LayerMask.GetMask("Obstacle"));
        if (botLeftCast.collider != null)
        {
            botLeftCheck = true;
        }
        else
        {
            botLeftCheck = false;
        }

        RaycastHit2D botCast;
        botCast = Physics2D.BoxCast(transform.position, new Vector2(1f, 0.4f * BottomArm.transform.localScale.y), 0, Vector2.down, 0.2f, LayerMask.GetMask("Obstacle"));
        if (botCast.collider != null)
        {
            botCheck = true;
        }
        else
        {
            botCheck = false;
        }
    }
}
