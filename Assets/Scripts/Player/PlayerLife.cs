using System;
using UnityEngine;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private HearthConfig life;
    [SerializeField] private HearthConfig middle;
    [SerializeField] private HearthConfig death;

    private HearthConfig currentState;

    void Start()
    {
        currentState = life;
        currentState.gameObject.SetActive(true);
    }

    public void ReceiveDamage()
    {
        currentState.gameObject.SetActive(false);

        HearthState nextState = currentState.getState().Next();

        currentState = GetConfig(nextState);
        currentState.gameObject.SetActive(true);
    }
    
    public HearthConfig GetCurrentState()=> currentState;
    private HearthConfig GetConfig(HearthState state)
    {
        return state switch
        {
            HearthState.Life => life,
            HearthState.Middle => middle,
            HearthState.Death => death,
            _ => life
        };
    }
}