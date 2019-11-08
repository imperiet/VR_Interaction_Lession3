using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class CanvasAlphaController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public VRTK_BaseControllable controllable;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        controllable.ValueChanged += OnLeverValueChanged;
    }

    protected virtual void OnLeverValueChanged(object sender, ControllableEventArgs e)
    {
        canvasGroup.alpha = e.value;
        
    }
}
