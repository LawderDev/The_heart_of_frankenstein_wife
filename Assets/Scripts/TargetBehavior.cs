using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        // Find the target GameObject by name or tag
        GameObject targetObject = GameObject.FindWithTag("TargetObject");
        target = targetObject.transform;

    }

    private void Update()
    {
        // You can add code to make the target perform actions here
    }
}
