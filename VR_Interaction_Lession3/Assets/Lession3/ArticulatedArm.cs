using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class ArticulatedArm : MonoBehaviour
{
    //References to transforms
    [SerializeField] private Transform link1Transform, link2Transform, headTransform;
    [SerializeField] private Light light;
    [SerializeField] private VRTK_BaseControllable reactor;


    //Adds a rotation to Link 1 relative to world
    public void RotateLink1(float rotationValue) { link1Transform.Rotate(Vector3.up * rotationValue, Space.World); }

    //Sets the rotation of Link1 relative to world
    public void SetLink1Rotation(float rotationValue) { link1Transform.eulerAngles = new Vector3(link1Transform.eulerAngles.x, rotationValue, link1Transform.eulerAngles.z); }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        reactor.ValueChanged += ValueChanged;
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            SetLink1Rotation(e.value);
        }
}
