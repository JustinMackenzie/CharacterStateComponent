using System;

public class Attributes
{
	/* Max energy. */
	public float maxEnergy = 100.0f;
	/* Speed while walking. */
	public float walkingSpeed = 6.0f;
	/* Speed while sprinting. */
	public float sprintingSpeed = 9.0f;
	/* Speed while crouching. */
	public float crouchingSpeed = 3.0f;
	/* Current speed. */
	public float currentSpeed;
	/* Energy cost of sprinting for 1 second. */
	public float sprintCost = 20.0f;
	/* Energy to be regenerated after 1 second of idle time. */
	public float idleEnergyRegenRate = 20.0f;
	/* Energy to be regenerated after 1 second of moving time. */
	public float movingEnergyRegenRate = 15.0f;
	/* The current amount of energy. */
	public float currentEnergy;
	/* The point at which entity is no longer fatigued. */
	public float fatigueThreshold = 20.0f;
	/* Determines if the entity is fatigued. */
	public bool fatigued;
	
	public Attributes ()
	{
		currentSpeed = 0;
		currentEnergy = maxEnergy;
		fatigued = false;
	}
}

