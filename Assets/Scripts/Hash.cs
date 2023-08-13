using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hash : MonoBehaviour
{
    public int dyingState;
    public int deadBool;
    public int walkState;
    public int speedFloat;
    public int upBool;

    // Start is called before the first frame update
    void Awake()
    {
        dyingState = Animator.StringToHash("BaseLayer.Player_Dead_Day");
        deadBool = Animator.StringToHash("Dead");
        walkState = Animator.StringToHash("Player_Walk_Day");
        speedFloat = Animator.StringToHash("Speed");
        upBool = Animator.StringToHash("Up");
    }
}

