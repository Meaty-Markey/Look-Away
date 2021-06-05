using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] float SpeedOfPull;
    DistanceJoint2D DJ;
    LineRenderer LR;
    bool isHooking;
    void Start()
    {
        LR = GetComponent<LineRenderer>();
        DJ = GetComponent<DistanceJoint2D>();
        isHooking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHooking == true)
        {
            Vector2 MousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LR.enabled = true;
            DJ.enabled = true;
            LR.SetPosition(0, MousePos);
            LR.SetPosition(1, transform.position);
            DJ.connectedAnchor = MousePos;
        }
        else
        {
            LR.enabled = false;
            DJ.enabled = false;
        }
        ClickingMouse();
    }

    private void ClickingMouse()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isHooking = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isHooking = false;
        }
        if ((Input.GetKeyDown(KeyCode.F)))
        {
            DJ.distance =  SpeedOfPull;
        }
    }
}
