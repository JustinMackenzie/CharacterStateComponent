using System;
using UnityEngine;
	
public class StandingIdle : MovementState
{
	
	#region Constructors
	
	public StandingIdle ()
	{
		
	}
	
	#endregion
	
	#region Movement State Methods
	
	/* A move is performed. */
	public void Move(CharacterState context)
	{
		context.SetMovementState(new StandingMoving());
	}
	
	/* Movement is stopped. */
	public void Stop(CharacterState context)
	{
		return;
	}
	
	/* A crouch is performed. */
	public void Crouch(CharacterState context)
	{
		context.SetMovementState(new CrouchingIdle());
	}
	
	/* A jump is performed. */
	public void Jump(CharacterState context)
	{
		context.SetMovementState(new Jumping());
	}
	
	/* A sprint is performed. */
	public void Sprint(CharacterState context)
	{
		return;
	}
	
	/* The current state is complete. */
	public void Complete(CharacterState context)
	{
		return;
	}
	
	/* Returns the currect state. */
	public string State()
	{
		return GetType().ToString();
	}
	
	#endregion

}

