using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IFB.Interfaces
{
    public interface IMovement
    {
        void Move(Rigidbody2D rigidBody, float speed);
        void MoveJoystick(RectTransform reactJoystick, Rigidbody2D rigidbody, float speed);
    }
}