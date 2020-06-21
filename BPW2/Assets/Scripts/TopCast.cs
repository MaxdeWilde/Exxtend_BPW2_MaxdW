using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCast : MonoBehaviour
{

    public bool topCheck = false;

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit2D topCast;
        topCast = Physics2D.BoxCast(transform.position, transform.localScale, 0, Vector2.up, 0.2f, LayerMask.GetMask("Obstacle"));
        if (topCast.collider != null)
        {
            topCheck = true;
        }
        else
        {
            topCheck = false;
        }

    }
}
