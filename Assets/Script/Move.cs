using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private List<Joycon> joycons;
    public float sensitivity = 10.0f;
    private Joycon j;

    void Start()
    {
        joycons = JoyconManager.Instance.j;
        if (joycons.Count > 0 && joycons != null)
        {
            j = joycons[0];
        } 
    }

    void Update()
    {
        if (j != null)
        {
            Quaternion orientation = j.GetVector();
            transform.localRotation = orientation;
            Vector3 angles = orientation.eulerAngles;
            float posX = Mathf.DeltaAngle(0, angles.y) * sensitivity * 0.01f;
            float posY = Mathf.DeltaAngle(0, angles.x) * sensitivity * -0.01f;

            transform.position = new Vector3(posX, posY, 0);

            if (j.GetButtonDown(Joycon.Button.DPAD_RIGHT))
            {
                j.Recenter();
            }
        }
    }
}
