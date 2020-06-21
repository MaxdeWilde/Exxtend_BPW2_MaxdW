using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform Body;
    public Transform RightArm;
    public Transform LeftArm;
    public Transform BottomArm;

    public bool retracting = false;

    public bool rightCheck = false;
    public bool leftCheck = false;    
    public bool topCheck = false;

    public bool BRCheck = false;
    public bool BLCheck = false;
    public bool BCheck = false;
    public bool LTCheck = false;
    public bool LBCheck = false;
    public bool RTCheck = false;
    public bool RBCheck = false;
    

    void FixedUpdate()
    {
        topCheck = GetComponentInChildren<TopCast>().topCheck;
        leftCheck = GetComponentInChildren<LeftCasts>().leftCheck;
        rightCheck = GetComponentInChildren<RightCasts>().rightCheck;
        BRCheck = GetComponentInChildren<BottomCasts>().botRightCheck;
        BLCheck = GetComponentInChildren<BottomCasts>().botLeftCheck;
        BCheck = GetComponentInChildren<BottomCasts>().botCheck;
        LTCheck = GetComponentInChildren<LeftCasts>().leftTopCheck;
        LBCheck = GetComponentInChildren<LeftCasts>().leftBotCheck;
        RTCheck = GetComponentInChildren<RightCasts>().rightTopCheck;
        RBCheck = GetComponentInChildren<RightCasts>().rightBotCheck;

        //Boxcasts();

        //Debug.Log("L: " + leftCheck + " R: " + rightCheck + " T: " + topCheck);
        //Debug.Log("B: " + BCheck + " BR: " + BRCheck + " BL: " + BLCheck + " RT: " + RTCheck + " RB: " + RBCheck + " LT: " + LTCheck + " LB: " + LBCheck);

        if (LeftArm.transform.localScale.x < 1f)
        {
            LeftArm.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (RightArm.transform.localScale.x < 1f)
        {
            RightArm.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (BottomArm.transform.localScale.y < 1.1f)
        {
            BottomArm.transform.localScale = new Vector3(1f, 1.1f, 1f);
        }


        if (Input.GetKey(KeyCode.D))
        {
            if (LeftArm.transform.localScale.x > 1f)
            {
                LeftArm.transform.localScale -= new Vector3(0.2f, 0f, 0f);
            }
            else
            {
                if ((!BLCheck || !rightCheck) && (!rightCheck || !leftCheck))
                {
                    RightArm.transform.localScale += new Vector3(0.2f, 0f, 0f);
                }
                
            }
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            if (RightArm.transform.localScale.x > 1f)
            {
                RightArm.transform.localScale -= new Vector3(0.2f, 0f, 0f);
            }
            else
            {
                if ((!BRCheck || !leftCheck) && (!rightCheck || !leftCheck))
                {
                    LeftArm.transform.localScale += new Vector3(0.2f, 0f, 0f);
                }
            }
        }


        if (Input.GetKey(KeyCode.S) && (!topCheck && !LTCheck && !RTCheck))
        {
            BottomArm.transform.localScale += new Vector3(0f, 0.2f, 0f);
        }

        if (Input.GetKey(KeyCode.W) && BottomArm.transform.localScale.y > 1.1f)
        {
            BottomArm.transform.localScale -= new Vector3(0f, 0.2f, 0f);
        }

        if (Input.GetKey(KeyCode.Space) && !retracting && (RightArm.transform.localScale.x > 1.1 || LeftArm.transform.localScale.x > 1.1 || BottomArm.transform.localScale.y > 1.2))
        {
            //StopCoroutine("Retract");
            StartCoroutine("Retract");
        }

    }


    IEnumerator Retract()
    {
        retracting = true;

        while (RightArm.transform.localScale.x > 1f)
        {
            RightArm.transform.localScale -= new Vector3(0.4f, 0f, 0f);
            yield return null;
        }

        while (LeftArm.transform.localScale.x > 1f)
        {
            LeftArm.transform.localScale -= new Vector3(0.4f, 0f, 0f);
            yield return null;
        }

        while (BottomArm.transform.localScale.y > 1.1f)
        {
            BottomArm.transform.localScale -= new Vector3(0f, 0.6f, 0f);
            yield return null;
        }

        retracting = false;

    }

    //void Boxcasts()
    //{
    //    Vector2 lrBoxSize = new Vector2(0.5f, 0.9f);
    //    Vector2 topBoxSize = new Vector2(1f, 0.68f);
        //Vector2 botBoxSize = new Vector2(1f, 0.4f);

        //RaycastHit2D rightCast;
        //rightCast = Physics2D.BoxCast(Body.transform.position + new Vector3(0.2f, 0, 0), lrBoxSize, 0, Vector2.right, ((0.5f*RightArm.transform.localScale.x)-0.32f), LayerMask.GetMask("Obstacle"));
        //if (rightCast.collider != null)
        //{
        //    rightCheck = true;
        //}
        //else
        //{
        //    rightCheck = false;
        //}

        //RaycastHit2D leftCast;
        //leftCast = Physics2D.BoxCast(Body.transform.position - new Vector3(0.2f, 0, 0), lrBoxSize, 0, Vector2.left, ((0.5f * LeftArm.transform.localScale.x)-0.32f), LayerMask.GetMask("Obstacle"));
        //if (leftCast.collider != null)
        //{
        //    leftCheck = true;
        //}
        //else
        //{
        //    leftCheck = false;
        //}

        

      

    //}

    //void OnCollisionEnter(Collision coll)
    //{
    //    if (coll.gameObject.tag == "Obstacle")
    //    {
    //        //if (topCheck)
    //        //{
    //            Debug.Log("AAAAAA");
    //            BottomArm.transform.localScale -= new Vector3(0f, 0.1f, 0f);
    //        //}
                
    //    }
    //}

}
