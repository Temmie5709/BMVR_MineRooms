using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerButton : MonoBehaviour
{
    /*public InputActionReference actingL, actingR;
    public Animator animator;
    // Start is called before the first frame update
    private void OnEnable()
    {
        actingL.action.performed += Switching;
        actingR.action.performed += Switching;
    }
    void Switching(InputAction.CallbackContext context)
    {
        animator.SetTrigger("TriggerButton");
    }*/
    public Animator animator;
    public void Switching()
    {
        animator.SetTrigger("TriggerButton");
    }
}
