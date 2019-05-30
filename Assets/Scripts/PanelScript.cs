using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public float maxMoveSpeed;
    public float touchSensitivity;
    public float smoothFactor;
    GameObject player;
    RectTransform rectTransform;
    public Vector2 moveVector;
    /// <summary>
    /// This variable is needed for animator smooth move
    /// </summary>
    public Vector2 realMoveVector;
    Vector3 requiredPlayerPosition;

    // Mouse variables
    bool wasMouseInBordersAndPressed;
    Vector2 previousMousePosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        requiredPlayerPosition = player.transform.localPosition;
        wasMouseInBordersAndPressed = false;
    }

    void Update()
    {
        moveVector = Vector2.ClampMagnitude(GetDeltaPosition()
            * touchSensitivity, maxMoveSpeed);
        CountNewRequiredPlayerPosition();
        MovePlayerToPosition();
    }

    private void MovePlayerToPosition()
    {
        Vector2 oldPosition = new Vector2(player.transform.localPosition.x,
            player.transform.localPosition.z);
        player.transform.localPosition = Vector3.Lerp(player.transform.localPosition, requiredPlayerPosition, smoothFactor);
        Vector2 newPosition = new Vector2(player.transform.localPosition.x,
            player.transform.localPosition.z);
        realMoveVector = (newPosition - oldPosition) / Time.deltaTime;
    }

    Vector2 GetDeltaPosition()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform,
            Input.touches[0].position))
            {
                return Input.touches[0].deltaPosition;
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform,
            new Vector2(Input.mousePosition.x, Input.mousePosition.y)))
            {
                if (wasMouseInBordersAndPressed)
                {
                    Vector2 currentMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    Vector2 deltaPosition = currentMousePosition - previousMousePosition;
                    previousMousePosition = currentMousePosition;
                    return deltaPosition;
                }
                wasMouseInBordersAndPressed = true;
                previousMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            else
            {
                wasMouseInBordersAndPressed = false;
            }
        }
        else
        {
            wasMouseInBordersAndPressed = false;
        }
#endif

        return Vector2.zero;
    }


    void CountNewRequiredPlayerPosition()
    {
        requiredPlayerPosition = requiredPlayerPosition + player.transform.forward.normalized * moveVector.y * Time.deltaTime
            + player.transform.right.normalized * moveVector.x * Time.deltaTime;
    }
}

//enum MouseTouchStatus
//{
//    MOUSE_TOUCH_BEGAN,
//    MOUSE_TOUCH_HELD,
//    MOUSE_TOUCH_END
//}
