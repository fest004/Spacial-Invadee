using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{

    // Stats and setters for the gun
    [SerializeField]private Transform firePoint;
    [SerializeField]private float firePower;
    [SerializeField]private float maxChargeTime;
    [SerializeField]private LineRenderer lineRenderer;
    [SerializeField]private float cooldown;

    private bool isCharging = false;
    
    // Slowing down the player when charging the attak
    public Rigidbody2D rb;
    [Range(0.0f, 1f)]
    public float slowedDownVelocity;



    Timer timer; 
    Countdown cooldownCountdown; 


    void Start()
    {
        lineRenderer.enabled = false;
        cooldownCountdown = new Countdown(cooldown);
        timer = new Timer();
    }


    void Update()
    {
        timer.Tick();
        cooldownCountdown.Tick();


        CheckInput();
        SlowPlayer();
    }



    public void CheckInput()
    {
        if ((Input.GetKey(KeyCode.Q) && !isCharging) && cooldownCountdown.TimeEnded()) {
           isCharging = true; 
           timer.ResetTimer();
        } 

        if (Input.GetKeyUp(KeyCode.Q) && isCharging) {
            isCharging = false;
            StartCoroutine(Shoot(timer.GetTime()));
        }
    }

    public void SlowPlayer()
    {
        if (isCharging)
        {
           rb.velocity = rb.velocity * slowedDownVelocity;
        }
    }



    IEnumerator Shoot(float chargeTime)
    {
        if (chargeTime > maxChargeTime) {
            chargeTime = maxChargeTime;
        }
        float damage = firePower * (chargeTime / maxChargeTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
        if (hitInfo) {
            Debug.Log(hitInfo.transform.name);
            Debug.Log("HitInfo");
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        } else {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.up * 100);
        }

        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f);
        lineRenderer.enabled = false;
        cooldownCountdown.Reset();
    }

}
