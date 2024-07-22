using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Vector3 nextPoint;
    public LayerMask groundLayer;
    public float m_Speed;

    // Update is called once per frame
    void Update()
    {
        nextPoint = transform.position + JoystickControl.direct * Time.deltaTime * m_Speed;
        if (CheckGround(nextPoint) && JoystickControl.direct.magnitude > 0f)
        {
            transform.position = nextPoint;
            transform.forward = JoystickControl.direct;
            ChangeAnim("run");
        }
        else
        {
            ChangeAnim("idle");
        }
    }

    //check if can move to nextPoint (position)
    private bool CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;
        return Physics.Raycast(nextPoint + Vector3.up * 2, Vector3.down, out hit, 3f, groundLayer);
    }
}
