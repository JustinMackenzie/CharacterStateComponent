using System;

public interface MovementState
{
	void Move(CharacterState context);
	void Stop(CharacterState context);
	void Crouch(CharacterState context);
	void Jump(CharacterState context);
	void Sprint(CharacterState context);
	void Complete(CharacterState context);
	string State();
}

