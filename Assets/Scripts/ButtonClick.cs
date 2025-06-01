using System;
using UnityEditor;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    private Animator ButtonAnimator, ArmRobotAnimator;
    public GameObject ArmRobot;
    private Boolean isReverse = false;

    private void Start()
    {
        ButtonAnimator = GetComponent<Animator>();
        ArmRobotAnimator = ArmRobot.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    ButtonAnimator.ResetTrigger("ButtonClick");
                    ButtonAnimator.SetTrigger("ButtonClick");

                    if (!isReverse)
                    {
                        isReverse = true;
                        ArmRobotAnimator.SetTrigger("Move");
                    }
                    else
                    {
                        isReverse = false;
                        ArmRobotAnimator.ResetTrigger("Move");
                        ArmRobotAnimator.ResetTrigger("MoveReverse");
                        ArmRobotAnimator.SetTrigger("MoveReverse");
                    }

                }
            }
        }
    }
}
