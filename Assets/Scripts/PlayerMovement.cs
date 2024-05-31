using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
    public float jumpHeight = 4;

    public LogicScript logic;
    public LeftArmScript leftArm;
    public RightArmScript rightArm;

    private bool isGrounded = true;
    private bool isCrouching = false;
    public bool isAlive = true;
    private bool isQuickFall = false;

    private float crouchHeight = 0.75f;
    private float standHeight = 1.45f;
    private float crouchSpeed = 10.0f;
    private float threshold = 0.005f;

    private float leftRightSpeed = 5.0f;
    public float leftRightLimit = 1.3f;
    private float xPosition = 0;

    private float yVelocity = 0.0f;
    private float gravity = -9.81f;

    [SerializeField] private AudioClip[] jumpSound;
    [SerializeField] private AudioClip[] fallSound;
    [SerializeField] private AudioClip[] gameOverSound;
    [SerializeField] private AudioClip[] crouchSound;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        leftArm = GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LeftArmScript>();
        rightArm = GameObject.FindGameObjectWithTag("RightArm").GetComponent<RightArmScript>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("player collision detected with " + collision.gameObject.tag);
        if (!isAlive) {
            return;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            SoundFXManager.instance.PlayRandomSoundFXClip(gameOverSound, transform, 1f);
            isAlive = false;
            logic.gameOver();
        }
    }

    void Update() {

        // Check if the player is touching the ground
        if (transform.position.y < 0) {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            yVelocity = 0;
            isGrounded = true;
            isQuickFall = false;
            SoundFXManager.instance.PlayRandomSoundFXClip(fallSound, transform, 1f);
        }

        // Apply gravity to the player if the player is not grounded
        if (!isGrounded) {
            yVelocity += gravity * Time.deltaTime;
            transform.position += Vector3.up * yVelocity * Time.deltaTime;
        }

        if (!isAlive) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                logic.restartGame();
            }
            return;
        }

        // Jumping
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded) {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2f * gravity);
            yVelocity = jumpForce;
            isGrounded = false;
            SoundFXManager.instance.PlayRandomSoundFXClip(jumpSound, transform, 1f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            xPosition = Mathf.Max(xPosition - leftRightLimit, -leftRightLimit);
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            xPosition = Mathf.Min(xPosition + leftRightLimit, leftRightLimit);
        }

        if (Mathf.Abs(transform.position.x - xPosition) < threshold) {
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        } else {
            float interpolation = Mathf.Lerp(transform.position.x, xPosition, Time.deltaTime * leftRightSpeed);
            transform.position = new Vector3(interpolation, transform.position.y, transform.position.z);
        }

        if (!isGrounded && Input.GetKeyDown(KeyCode.DownArrow) && !isQuickFall) {
            yVelocity -= 10;
            isQuickFall = true;
        }
        if (!isGrounded) {
            return;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            // crouch interpolation to 0.5 using Mathf.Lerp
            float currentHeight = transform.localScale.y;
            if (currentHeight <= crouchHeight + threshold) {
                transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
                leftArm.leftHeight = leftArm.normalHeight / 2;
                rightArm.rightHeight = rightArm.normalHeight / 2;
            } else {
                float interpolationHeight = Mathf.Lerp(currentHeight, crouchHeight, Time.deltaTime * crouchSpeed);
                transform.localScale = new Vector3(transform.localScale.x, interpolationHeight, transform.localScale.z);
                leftArm.leftHeight = leftArm.normalHeight * (interpolationHeight / standHeight);
                rightArm.rightHeight = rightArm.normalHeight * (interpolationHeight / standHeight);
                if (!isCrouching) {
                    SoundFXManager.instance.PlayRandomSoundFXClip(fallSound, transform, 1f);
                }
            }
            isCrouching = true;
        } else {
            float currentHeight = transform.localScale.y;
            if (currentHeight >= standHeight - threshold) {
                transform.localScale = new Vector3(transform.localScale.x, standHeight, transform.localScale.z);
                 leftArm.leftHeight = leftArm.normalHeight;
                rightArm.rightHeight = rightArm.normalHeight;
            } else {
                float interpolationHeight = Mathf.Lerp(currentHeight, standHeight, Time.deltaTime * crouchSpeed);
                transform.localScale = new Vector3(transform.localScale.x, interpolationHeight, transform.localScale.z);
                leftArm.leftHeight = leftArm.normalHeight * (interpolationHeight / standHeight);
                rightArm.rightHeight = rightArm.normalHeight * (interpolationHeight / standHeight);
                if (isCrouching) {
                    SoundFXManager.instance.PlayRandomSoundFXClip(crouchSound, transform, 1f);
                }
            }
            isCrouching = false;
        }
    }
}
