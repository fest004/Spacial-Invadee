using UnityEngine;

public class PlayerWASD : MonoBehaviour 
{
  //  Retrieving Rigidbody
  public Rigidbody2D RB;

  //  Speed numbers to be manipulated
  public float maxSpeed;
  public float acceleration;
  public float decceleration;
  
  // Determening if player is moving or not
  int isMoving;
  float targetSpeed;
  // calculate difference between current velocity and desired velocity (high or low)
  float speedDif;
  //change acceleration rate depending on whether you are trying to accelerate or not
  float accelRate;
  // Direction player is going
  float movement;
  private Vector2 moveInput;
  //Applies acceleration, raises to set power so acceleration increases with  higher speeds

  //Spritestate 
  private bool isFacingRight;
  private bool isFacingUp;
  private bool isIdling;

  void Start() {
    RB = GetComponent<Rigidbody2D>();
  }

  void Update() 
  {
    if (Input.GetKey(KeyCode.W)) {
      moveInput = Vector2.up; 
      isMoving = 1; 
    } else if (Input.GetKey(KeyCode.S)) {
      moveInput = Vector2.down;
      isMoving = 1;
    } else if (Input.GetKey(KeyCode.A)) {
      moveInput = Vector2.left;
      isMoving = 1;
    } else if (Input.GetKey(KeyCode.D)) {
      moveInput = Vector2.right;
      isMoving = 1;
    } else {
      isMoving = 0;
    }
  }

  void FixedUpdate() 
  {
    // moveInput is either a negative value, a positive value or zero
    // which will tell us wether the player wants to move and in what direction
    targetSpeed = isMoving * maxSpeed;
    Debug.Log($"Target speed is {targetSpeed}");
    // Difference between current velocity or wanted velocity (maxSpeed or 0)
    speedDif = targetSpeed - RB.velocity.x;
    Debug.Log($"SpeedDif is {speedDif}");
    // If elses targetSpeed to know if it is either 0 
    // or more, and gives it acceleration value
    accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
    
    movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, 0.5f) * Mathf.Sign(speedDif);
    //Debug.Log(movement);
    

    RB.AddForce(movement * moveInput);
  }
}

