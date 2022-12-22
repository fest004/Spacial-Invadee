using UnityEngine.Audio;
using System.Collections;
using UnityEngine;

public class PlayerWASD : PlayerMovement 
{
  // Animator variable
  public Animator animator;

  // [SerializeField] private TrailRenderer trailDash;

  //DASH 
  protected bool canDash = true;
  private bool isDashing = false;
  public float dashSleepTime;
  private Vector2 dashRefilling;
  private bool isDashAttacking;
  private float LastPressedDashTime;
  public float dashEndTime;
  public float dashEndSpeed;
  public float dashRefillTime;
  public float dashSpeed; 
  public float dashingTime;

  void Update() 
  {
    if (isDashing)
    {
      return;
    }

    if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && isMoving > 0.01f)
    {
      isDashing = true;
      StartCoroutine(Dash());
    }

    GetInput();
    CheckKeyLetGo();
    SetAnimationVariables();
  }









  void FixedUpdate() 
  {
    moveInput = Vector2.ClampMagnitude(moveInput, 1);

    if (isDashing)
    {
      return;
    }

    ApplyForceToPlayer();
  }

  private void GetInput()
  {
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

  }


  private void CheckKeyLetGo()
  {
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
  }
  
  private void ApplyForceToPlayer()
  {
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
  }

  private IEnumerator Dash()
  {
    Sleep(dashSleepTime);
    
    float startTime = Time.time;

    while (Time.time - startTime <= dashingTime) 
    {
      RB.velocity = moveInput.normalized * dashSpeed;

      yield return null;
    }

    startTime = Time.time;

    RB.velocity = dashEndSpeed * moveInput.normalized;

    while (Time.time - startTime <= dashEndTime) {
      yield return null;
    }

    isDashing = false;
    yield return new WaitForSeconds(dashRefillTime);
    canDash = true;

  }


  private IEnumerator DashRefill() 
  {
    yield return new WaitForSeconds(dashRefillTime);
    canDash = true;
  }

  private void SetAnimationVariables()
  {
    animator.SetFloat("Horizontal", moveInput.x);
    animator.SetFloat("Vertical", moveInput.y);
    animator.SetFloat("Speed", moveInput.sqrMagnitude);
  }

  private void Sleep(float duration)
    {
		StartCoroutine(nameof(PerformSleep), duration);
    }

	private IEnumerator PerformSleep(float duration)
    {
		Time.timeScale = 0;
		yield return new WaitForSecondsRealtime(duration); //Must be Realtime since timeScale with be 0 
		Time.timeScale = 1;
	}

}
