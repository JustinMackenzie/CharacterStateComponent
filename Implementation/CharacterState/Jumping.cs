using System;

public class Jumping : MovementState
{
	
	#region Constructors
	
	public Jumping ()
	{
		
	}
	
	#endregion
	
	#region Movement State Methods
	
	/* A move is performed. */
	public void Move(CharacterState context)
	{
		return;
	}
	
	/* Movement is stopped. */
	public void Stop(CharacterState context)
	{
		return;
	}
	
	/* A crouch is performed. */
	public void Crouch(CharacterState context)
	{
		return;
	}
	
	/* A jump is performed. */
	public void Jump(CharacterState context)
	{
		return;
	}
	
	/* A sprint is performed. */
	public void Sprint(CharacterState context)
	{
		return;
	}
	
	/* The current state is complete. */
	public void Complete(CharacterState context)
	{
		context.SetMovementState(new StandingMoving());
	}
	
	/* Returns the current state. */
	public string State()
	{
		return GetType().ToString();
	}
	
	#endregion
}

