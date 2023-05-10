using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IFB.Interfaces
{
    public interface IInput
    {
        bool GetActionButtonDown();
        float GetHorizontalButton();
        float GetVerticalButton();

    }
}
