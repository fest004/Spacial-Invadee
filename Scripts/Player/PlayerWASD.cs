using UnityEngine.Audio;
using UnityEngine;

public class PlayerWASD : PlayerMovement 
{
  // Animator variable
  public Animator animator;

  void Update() 
  {
    #region GET INPUT
    if (Input.GetKey(KeyCode.W)) {
      moveInput.y = 1; 
      isMoving = 1; 
    } 

    if (Input.GetKey(KeyCode.S)) {
      moveInput.y = -1; 
      isMoving = 1;
    } 
    if (Input.GetKey(KeyCode.A)) {
      moveInput.x = -1; 
      isMoving = 1;
    } 
    if (Input.GetKey(KeyCode.D)) {
      moveInput.x = 1; 
      isMoving = 1;
    } 
    #endregion

    #region Check Key Let Go
    if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
      // Debug.Log("y");
      moveInput.y = 0; 
    }

    if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
      // Debug.Log("x");
      moveInput.x = 0; 
    }

    if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
      moveInput.Set(0, 0);
      isMoving = 0;
    }
    #endregion

    animator.SetFloat("Horizontal", moveInput.x);
    animator.SetFloat("Vertical", moveInput.y);
    animator.SetFloat("Speed", moveInput.sqrMagnitude);


    // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)) {
      // FindObjectOfType<AudioManager>().Play("ShipMoving");
    // }

    // if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A)) {
      // FindObjectOfType<AudioManager>().Stop("ShipMoving");
    // }
  }

  void FixedUpdate() 
  {
    #region Calculate speed and applying to RB
    // isMoving is either maxSpeed or zero, which will tell us if we are moving 
    targetSpeed = isMoving * maxSpeed;

    // Difference between current velocity or wanted velocity (maxSpeed or 0)
    speedDif = targetSpeed - Mathf.Sqrt(Mathf.Pow(RB.velocity.x,2) + Mathf.Pow(RB.velocity.y,2))/ (maxSpeed / 8); 


    // If elses targetSpeed to know if it is either 0 or more
    accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
    
    movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
    
    if (movement > 0) {
      RB.AddForce(movement * moveInput); 
    } else {
      RB.AddForce(movement * new Vector2(RB.velocity.x, RB.velocity.y));
    }
    #endregion
  }
}

