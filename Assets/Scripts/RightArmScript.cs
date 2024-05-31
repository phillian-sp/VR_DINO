using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmScript : MonoBehaviour
{
    public float rightHeight;
    public float normalHeight;
    void Start()
    {
        rightHeight = transform.localPosition.y;
        normalHeight = transform.localPosition.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, rightHeight - Mathf.Sin(Time.time * 4) * 0.1f, transform.localPosition.z);
    }
}
