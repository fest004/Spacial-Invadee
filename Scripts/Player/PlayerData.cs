using UnityEngine;
public class PlayerData : MonoBehaviour
{
  protected Rigidbody2D RB;
  

  void Start() 
  {
    RB = GetComponent<Rigidbody2D>();
  }

}

public class PlayerMovement : PlayerData 
{
  #region Player Movement 
  // Manipulable speed numbers
  public float maxSpeed;
  public float acceleration;
  public float decceleration;
  public float velPower;

  // Determening if player is moving or not
  protected int isMoving;
  protected bool isMovingBool;
  protected float targetSpeed;
  // calculate difference between current velocity and desired velocity (high or low)
  protected float speedDif;
  //change acceleration rate depending on whether you are trying to accelerate or not
  protected float accelRate;
  // Direction player is going
  protected float movement;
  protected Vector2 moveInput;

  //Dash variables 
  protected bool canDash = true;
  protected bool isDashing = false;
  public float dashingPower; 
  public float dashingTime;
  public float dashingCooldown;

  #endregion

  //#region Attack

}

public class AttackData : MonoBehaviour 
{
  public float baseDamage;
  public float scaleDamage;
  public float currentDamage;
  public float bulletSpeed;
  public float firerate;
  protected int firerateTimer;
}
