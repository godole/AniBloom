using UnityEngine;
using System.Collections;

public interface IState
{
    void StateUpdate();
    void OnCollisionEnter2D(Collision2D col);
    void OnTriggerEnter2D(Collider2D col);
    void GroundCollision(Collider2D col);
    void GroundCollisionExit(Collider2D col);
    void SlideCollision(Collider2D col);
    void SlideCollisionExit(Collider2D col);
    void Jump();
}
