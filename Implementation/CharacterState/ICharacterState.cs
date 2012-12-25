using System;

public interface ICharacterState
{
	void Move();
	void Stop();
	void Crouch();
	void Jump();
	void Sprint();
	void StopSprint();
	void DoneJump();
	void Update(float deltaTime);
}

