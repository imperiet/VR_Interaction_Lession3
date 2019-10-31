using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticulatedArm : MonoBehaviour
{
    //References to transforms
    [SerializeField] private Transform link1Transform, link2Transform, headTransform;
    [SerializeField] private Light light;

//Adds a rotation to Link 1 relative to world
    public void RotateLink1(float rotationValue) { link1Transform.Rotate(Vector3.up * rotationValue, Space.World); }
    public void SetLink1Rotation(float rotationValue) { link1Transform.eulerAngles = new Vector3(link1Transform.eulerAngles.x, rotationValue, link1Transform.eulerAngles.z); }


}
