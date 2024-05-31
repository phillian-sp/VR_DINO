using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAddPlane : MonoBehaviour
{
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "Player" && collision.gameObject.name == "body")
        {
            Debug.Log("Player collision detected");
            logic.addScore(1);
        }
    }
}
