using IFB.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IFB
{

    public class KeyboardInput : IInput
    {
        public bool GetActionButtonDown()
        {
            if(GetHorizontalButton() != 0 || GetVerticalButton() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public float GetHorizontalButton()
        {
            return Input.GetAxis("Horizontal");
        }

        public float GetVerticalButton()
        {
            return Input.GetAxis("Vertical");
        }
    }
}
