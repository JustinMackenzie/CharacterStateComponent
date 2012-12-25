using System;
	
public class CrouchingMoving : MovementState
{
	
	#region Constructors
	
	public CrouchingMoving ()
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
		context.SetMovementState(new CrouchingIdle());
	}
	
	/* A crouch is performed. */
	public void Crouch(CharacterState context)
	{
		context.SetMovementState(new StandingMoving());
	}
	
	/* A jump is performed. */
	public void Jump(CharacterState context)
	{
		context.SetMovementState(new Jumping());
	}
	
	/* A sprint is performed. */
	public void Sprint(CharacterState context)
	{
		context.SetMovementState(new StandingSprinting());
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

