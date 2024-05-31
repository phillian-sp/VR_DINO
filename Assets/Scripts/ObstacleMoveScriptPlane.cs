using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveScriptPlane : MonoBehaviour
{
    public float speed = 10.0f;
    public float deadZone = -10.0f;
    // [SerializeField] private float speedIncrement = 1f;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("PlayerMove").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isAlive){
            Destroy(gameObject);
        }
        transform.position += Vector3.back * speed * Time.deltaTime;

        if (transform.position.z < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
