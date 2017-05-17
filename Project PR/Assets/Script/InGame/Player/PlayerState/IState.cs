using UnityEngine;
using System.Collections;

public interface IState
{
    void StateUpdate();
    void OnTriggerEnter2D(Collider2D col, Collider2D target);
    void OnTriggerExit2D(Collider2D col, Collider2D target);
    void Jump();
    void JumpEnterJudge();
    void SlideEnd();
    void Hit();
}
