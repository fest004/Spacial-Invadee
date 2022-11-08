using UnityEngine;

public class PlayerRunData : MonoBehaviour 
{
	[Header("Run")]
	public float runMaxSpeed;   //Target speed we want the player to reach.
	public float runAcceleration;   //Time (approx.) time we want it to take for the player to accelerate from 0 to the runMaxSpeed.
	[HideInInspector] public float runAccelAmount;    //The actual force (multiplied with speedDiff) applied to the player.
	public float runDecceleration;    //Time (approx.) we want it to take for the player to accelerate from runMaxSpeed to 0.
	[HideInInspector] public float runDeccelAmount; //Actual force (multiplied with speedDiff) applied to the player .
	[Space(10)]
	public bool doConserveMomentum;


    private void OnValidate()
    {
		//Calculate are run acceleration & deceleration forces using formula: amount = ((1 / Time.fixedDeltaTime) * acceleration) / runMaxSpeed
		runAccelAmount = (10 * runAcceleration) / runMaxSpeed;
		runDeccelAmount = (10 * runDecceleration) / runMaxSpeed;

		#region Variable Ranges
		runAcceleration = Mathf.Clamp(runAcceleration, 0.01f, runMaxSpeed);
		runDecceleration = Mathf.Clamp(runDecceleration, 0.01f, runMaxSpeed);
		#endregion
	}
}
