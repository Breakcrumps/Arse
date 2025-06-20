using System.Collections.Generic;
using Godot;

[GlobalClass]
public partial class StateMachine : Node
{
  [Export] private State? _initialState;

  private readonly Dictionary<string, State> _states = [];
  private State? _currentState;

  public override void _Ready()
  {
    foreach (Node child in GetChildren())
    {
      if (child is not State state)
        continue;
      
      _states.Add(child.Name, state);
    }

    if (_initialState is null)
      return;

    _initialState.Enter();
    _currentState = _initialState;
  }

  public void Process(double delta)
  {
    _currentState?.Process(delta);
  }

  public void PhysicsProcess(double delta)
  {
    _currentState?.PhysicsProcess(delta);
  }

  public void Transition(string nextStateName)
  {
    State newState = _states[nextStateName];

    if (newState is null)
      return;

    _currentState?.Exit();

    newState.Enter();
    _currentState = newState;
  }
}
