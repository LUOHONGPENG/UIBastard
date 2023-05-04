using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class GameMgr
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction touchPositionAction;
    private InputAction normalAttackAction;
    private InputAction specialAttackAction;
    private InputAction skillReadyAttackAction;


    public Vector2 movementVec;

    private void InitInput()
    {
        playerInput = new PlayerInput();
        moveAction = playerInput.Gameplay.Movement;
        touchPositionAction = playerInput.Gameplay.TouchPosition;
        normalAttackAction = playerInput.Gameplay.NormalAttack;
        specialAttackAction = playerInput.Gameplay.SpecialAttack;
        skillReadyAttackAction = playerInput.Gameplay.SkillReady;
    }

    private void EnableInput()
    {
        playerInput.Enable();
        moveAction.performed += Movement_performed;
        normalAttackAction.performed += Normal_performed;
        specialAttackAction.performed += Special_performed;
        skillReadyAttackAction.performed += SkillReady_performed;
    }
    private void Normal_performed(InputAction.CallbackContext obj)
    {
        Vector2 screenPosition = touchPositionAction.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Vector3 groundPosition;
        if(Physics.Raycast(ray,out RaycastHit hitData,LayerMask.GetMask("Ground"))) 
        {
            groundPosition = hitData.point;
            EventCenter.Instance.EventTrigger("NormalAttack", groundPosition);
        }
    }

    private void Special_performed(InputAction.CallbackContext obj)
    {
        EventCenter.Instance.EventTrigger("SpecialAttack", null);
    }

    private void SkillReady_performed(InputAction.CallbackContext obj)
    {
        EventCenter.Instance.EventTrigger("SkillReady", null);
    }

    private void DisableInput()
    {
        moveAction.performed -= Movement_performed;
        normalAttackAction.performed -= Normal_performed;
        specialAttackAction.performed -= Special_performed;
        skillReadyAttackAction.performed -= SkillReady_performed;
        playerInput.Disable();
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
        Vector2 valueMove = obj.ReadValue<Vector2>();
        movementVec = valueMove;
    }


}
