using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum PlayerState
    {
        Movement,
        Shooting,
        Dead
    }

    private StateMachine stateMachine;

    private Dictionary<PlayerState, Istate> dicState = new Dictionary<PlayerState, Istate>();
    
    private void Start()
    {
        
    }

    void CreateStates()
    {
        
    }
}
