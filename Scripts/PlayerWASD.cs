using System.Collections;
using UnityEngine;

public class PlayerWASD : PlayerRunData 
{
    //


    public Rigidbody2D RB;

    // State Paramaters

    // Direction player is moving
    private Vector2 direction;

    //Knowing what direction the player is facing
    bool isFacingRight;
    bool isFacingUp;


    private void Awake() {
        RB =  GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    // Getting key input every frame to get general direction
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            direction = Vector2.up;
        } else if (Input.GetKey(KeyCode.S)) {
            direction = Vector2.down;
            Debug.Log(direction);
        } else if (Input.GetKey(KeyCode.A)) {
            direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.D)) {
            direction = Vector2.right;
            Debug.Log(direction);
        } 

        
    }
    
    // Updates at fixed times to not make physics depend on user FPS
    //
    private void FixedUpdate() 
    {
        //Directon we want to go and wanted speed
        float targetSpeed = direction.x * runMaxSpeed;

        // Get acceleration value based off on if we are turning, 
        // accelerating or trying to stop 
        float accelRate; 

        accelRate = (Mathf.Abs(targetSpeed) > 0.01 ? runAccelAmount : runDeccelAmount);


        float speedDif = targetSpeed - RB.velocity.x;

        float movement = speedDif * accelRate;


        if (direction.sqrMagnitude != 0) {
        RB.AddForce(100 * direction);
        // Debug.Log($"Movement is {movement}");
        }
    }
}
