using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// This script acts as a single point for all other scripts to get
// the current input from. It uses Unity's new Input System and
// functions should be mapped to their corresponding controls
// using a PlayerInput component with Unity Events.

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private MainControls myMainControls;
    private Camera mainCamera;

    private void Awake()
    {

        mainCamera = Camera.main;
        myMainControls = new MainControls();
        myMainControls.Enable();
        
    }

    public void DetectObject(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Debug.Log("We clicked!");
        Ray myRay = mainCamera.ScreenPointToRay(myMainControls.Player.Point.ReadValue<Vector2>());
        RaycastHit2D[] hits2DAll = Physics2D.GetRayIntersectionAll(myRay);

        for (int i = 0; i < hits2DAll.Length; i++)
        {
            if (hits2DAll[i].collider != null)
            {
                if (hits2DAll[i].collider.tag == "Player")
                {
                    Debug.Log("We hit player!");
                    break;    
                }
            }
        }
    }
}