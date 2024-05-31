using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmScript : MonoBehaviour
{
    public float leftHeight;
    public float normalHeight;
    void Start()
    {
        leftHeight = transform.localPosition.y;
        normalHeight = transform.localPosition.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, leftHeight + Mathf.Sin(Time.time * 4) * 0.1f, transform.localPosition.z);
    }
}
