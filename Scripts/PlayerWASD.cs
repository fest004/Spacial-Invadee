using UnityEngine;

public class PlayerWASD : MonoBehaviour 
{
  //  Retrieving Rigidbody
  public Rigidbody2D RB;

  // Animator variable
  public Animator animator;

  // CabbagesUpdate


  //  Speed numbers to be manipulated
  public float maxSpeed;
  public float acceleration;
  public float decceleration;
  public float velPower;

  
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


  void Start() {
    RB = GetComponent<Rigidbody2D>();
   // RB.AddForce(1000 * Vector2.left);
  }

  void Update() 
  {
    if (Input.GetKey(KeyCode.W)) {
      moveInput = Vector2.up; 
      isMoving = 1; 
      animator.SetBool("isFacingUp", true);
      animator.SetBool("isIdle", false);
    } else if (Input.GetKey(KeyCode.S)) {
      moveInput = Vector2.down; 
      isMoving = 1;
      animator.SetBool("isFacingUp", false);
      animator.SetBool("isIdle", false);
    } else if (Input.GetKey(KeyCode.A)) {
      moveInput = Vector2.left;    
      isMoving = 1;
      animator.SetBool("isFacingRight", false);
      animator.SetBool("isIdle", false);
    } else if (Input.GetKey(KeyCode.D)) {
      moveInput = Vector2.right;
      isMoving = 1;
      animator.SetBool("isFacingRight", true);
      animator.SetBool("isIdle", false);
    } else {
      isMoving = 0;
      animator.SetBool("isIdle", true);
    }
  }

  void FixedUpdate() 
  {
    // isMoving is either maxSpeed or zero, which will tell us if we are moving 
    // which will tell us wether the player wants to move and in what direction
    targetSpeed = isMoving * maxSpeed;


    // Difference between current velocity or wanted velocity (maxSpeed or 0)
    // speedDif = targetSpeed - 0.5f * (RB.velocity.x + RB.velocity.y); 
    //speedDif = targetSpeed - 0.5f*(Mathf.Abs(RB.velocity.x) + Mathf.Abs(RB.velocity.y));
    speedDif = targetSpeed - Mathf.Sqrt(Mathf.Pow(RB.velocity.x,2) + Mathf.Pow(RB.velocity.y,2))/ (maxSpeed / 5); 



    // If elses targetSpeed to know if it is either 0 
    // or more, and gives it acceleration value
    accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
    
    movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
    Debug.Log($"movement is {movement}");
    Debug.Log($"speedDif is {speedDif}");
    Debug.Log($"moveInput is {moveInput}");
    //Debug.Log(movement);
    
    if (movement > 0) {
      RB.AddForce(movement * moveInput);
    } else {
      RB.AddForce(movement * new Vector2(RB.velocity.x, RB.velocity.y));
    }
  }
}

