using System;

public class CharacterState : ICharacterState
{
	
	#region Fields
	
	MovementState _movementState;
	Attributes _attributes;
	
	#endregion
	
	#region Constructors
	
	public CharacterState(Attributes attributes)
	{
		_attributes = attributes;
		_movementState = new StandingIdle();
	}
	
	#endregion
	
	#region Update Method
	
	// Update is called once per frame
	public void Update (float deltaTime) 
	{
		/* Get current state. */
		string movementState = _movementState.State();
		
		/* If Sprinting, decrease energy. */
		if(movementState == "StandingSprinting")
		{
			/* If not at sprinting speed, then change current speed to be sprint speed. */
			if(_attributes.currentSpeed != _attributes.sprintingSpeed)
			{
				_attributes.currentSpeed = _attributes.sprintingSpeed;
			}
			
			/* Decrease energy by proper amount. */
			_attributes.currentEnergy -= deltaTime * _attributes.sprintCost;
			
			/* If out of energy, stop sprinting. */
			if(_attributes.currentEnergy <= 0)
			{
				Stop();
				_attributes.fatigued = true;
			}
		}
		/* If not moving. */
		else if((movementState == "StandingIdle") || (movementState == "CrouchingIdle"))
		{	
			/* If not at max energy, regenerate energy. */
			if(_attributes.currentEnergy < _attributes.maxEnergy)
			{
				_attributes.currentEnergy += deltaTime * _attributes.idleEnergyRegenRate;
			}
		}
		/* If moving, but not sprinting. */
		else if((movementState == "StandingMoving") || (movementState == "CrouchingMoving"))
		{
			/* Apply walking speed if needed. */
			if((movementState == "StandingMoving") && (_attributes.currentSpeed != _attributes.walkingSpeed))
			{
				_attributes.currentSpeed = _attributes.walkingSpeed;
			}
			/* Apply crouching speed if needed. */
			else if ((movementState == "CrouchingMoving") && (_attributes.currentSpeed != _attributes.crouchingSpeed))
			{
				_attributes.currentSpeed = _attributes.crouchingSpeed;
			}
			/* If not at max energy, regenerate 0.75 of energy regen rate because still moving. */
			if(_attributes.currentEnergy < _attributes.maxEnergy)
			{
				_attributes.currentEnergy += deltaTime * _attributes.movingEnergyRegenRate;
			}
		}
		/* If jumping. */
		else
		{
			
		}
		
		/* If fatigued and now past fatigue threshold, no longer fatigued. */
		if((_attributes.currentEnergy > _attributes.fatigueThreshold) &&(_attributes.fatigued))
		{
			_attributes.fatigued = false;
		}	
		
		/* Clamp the current energy to max energy. */
		if(_attributes.currentEnergy > _attributes.maxEnergy)
		{
			_attributes.currentEnergy = _attributes.maxEnergy;
		}
		
	}
	
	#endregion
	
	#region Other Methods
	
	/* Used to send Move input to state chart. */
	public void Move()
	{
		_movementState.Move(this);
	}
	
	/* Used to send Stop input to state chart. */
	public void Stop()
	{
		_movementState.Stop(this);
	}
	
	/* Used to send Crouch input to state chart. */
	public void Crouch()
	{
		_movementState.Crouch(this);	
	}
	
	/* Used to send Jump input to state chart. */
	public void Jump()
	{
		_movementState.Jump(this);
	}
	
	/* Used to send Sprint input to state chart. */
	public void Sprint()
	{
		/* If not fatigued, sprint. */
		if(!_attributes.fatigued)
		{
			_movementState.Sprint(this);
		}
	}
	
	/* Used to stop the character from sprinting. */
	public void StopSprint()
	{
		/* If sprinting, then stop it. */
		if(_movementState.State() == "StandingSprinting")
		{
			_movementState.Stop(this);
		}
	}
	
	/* Used to alert the state component when the character is done jumping. */
	public void DoneJump()
	{	
		/* If jumping, then complete jump. */
		if(_movementState.State() == "Jumping")
		{
			_movementState.Complete(this);
		}
	}
	
	/* Used to set the state. */
	public void SetMovementState(MovementState state)
	{
		_movementState = state;
	}
	
	#endregion
	
}
