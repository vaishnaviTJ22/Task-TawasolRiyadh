using UnityEngine;
using System;

[Serializable]
public struct PlayerState
{
    public float timestamp;
    public Vector3 position;
    public Vector3 velocity;
    public Quaternion rotation;
    public bool isJumping;
    public bool isGrounded;

    public PlayerState(float time, Vector3 pos, Vector3 vel, Quaternion rot, bool jumping, bool grounded)
    {
        timestamp = time;
        position = pos;
        velocity = vel;
        rotation = rot;
        isJumping = jumping;
        isGrounded = grounded;
    }
}
