using Godot;

public abstract partial class State : Node
{
  public virtual void Enter() { }

  public virtual void Exit() { }

  public virtual void Process(double delta) { }

  public virtual void PhysicsProcess(double delta) { }
}