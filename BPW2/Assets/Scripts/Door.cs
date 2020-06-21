using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Transform button;
    public bool Vertical;
    public bool Horizontal;
    public float speed;
    public bool pressed;
    public bool prevPressed;
    public bool opening;
    public bool closing;
    public Vector2 startPos;
    public Vector2 endPos;

    void Start()
    {
        startPos = transform.position;
    }


    void FixedUpdate()
    {
        pressed = button.GetComponent<ButtonPress>().isPressed;
        doorBoxCast();

        if (pressed && pressed == !prevPressed)
        {
            StopCoroutine("doorClose");
            StartCoroutine("doorOpen");
            prevPressed = pressed;
        }

        if (!pressed && pressed == !prevPressed)
        {
            StopCoroutine("doorOpen");
            StartCoroutine("doorClose");
            prevPressed = pressed;
        }
    }

    public void doorBoxCast()
    {

        if (Vertical)
        {
            RaycastHit2D doorHit1;
            RaycastHit2D doorHit2;
            doorHit1 = Physics2D.BoxCast(transform.localPosition, transform.localScale, 0, Vector2.up, 0.05f, LayerMask.GetMask("Player"));
            doorHit2 = Physics2D.BoxCast(transform.localPosition, transform.localScale, 0, Vector2.down, 0.05f, LayerMask.GetMask("Player"));

            if (doorHit1.collider != null || doorHit2.collider != null)
            {
                StopCoroutine("doorClose");
                StopCoroutine("doorOpen");
            }
            else
            {
                if (opening)
                {
                    StartCoroutine("doorOpen");
                }
                else if (closing)
                {
                    StartCoroutine("doorClose");
                }
            }
        }
        
        if (Horizontal)
        {
            RaycastHit2D doorHit1;
            RaycastHit2D doorHit2;
            doorHit1 = Physics2D.BoxCast(transform.localPosition, transform.localScale, 0, Vector2.left, 0.05f, LayerMask.GetMask("Player"));
            doorHit2 = Physics2D.BoxCast(transform.localPosition, transform.localScale, 0, Vector2.right, 0.05f, LayerMask.GetMask("Player"));

            if (doorHit1.collider != null || doorHit2.collider != null)
            {
                StopCoroutine("doorClose");
                StopCoroutine("doorOpen");
            }
            else
            {
                if (opening)
                {
                    StartCoroutine("doorOpen");
                }
                else if (closing)
                {
                    StartCoroutine("doorClose");
                }
            }
        }
    }

    IEnumerator doorOpen()
    {
        opening = true;
        closing = false;
        Debug.Log("Opening...");
        while (Vector2.Distance(transform.position, endPos) > 0.05f)
        {
            transform.position = Vector2.Lerp(transform.position, endPos, speed*Time.deltaTime);
            yield return null;
        }
        Debug.Log("Open!");
        opening = false;

    }

    IEnumerator doorClose()
    {
        closing = true;
        opening = false;
        Debug.Log("Closing...");
        while (Vector2.Distance(startPos, transform.position) > 0.05f)
        {
            transform.position = Vector2.Lerp(transform.position, startPos, speed*Time.deltaTime);
            yield return null;
        }
        Debug.Log("Closed!");
        closing = false;

    }
}
