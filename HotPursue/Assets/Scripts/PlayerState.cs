using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Idle, RunR, RunL}
public class PlayerState : MonoBehaviour
{
    private State state;
    private Animator anim;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(State newState)
    {
        anim.SetBool("idle", false);
        anim.SetBool("run", false);

        switch (newState)
        {
            case State.Idle:
                state = State.Idle;
                anim.SetBool("idle", true);
                break;
            case State.RunR:
                state = State.RunR;
                sr.flipX = false;
                anim.SetBool("run", true);
                break;
            case State.RunL:
                state = State.RunL;
                sr.flipX = true;
                anim.SetBool("run", true);
                break;
            default:
                break;
        }
    }

    public State GetState() { return state; }
}
