using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelToggle : MonoBehaviour
{
    public UnityEvent OnPanelToggle;
    public Animator animator;
    public void TogglePanel(){
        bool previousValue = animator.GetBool("open");
        animator.SetBool("open",!previousValue);
        OnPanelToggle.Invoke();
    }
}
