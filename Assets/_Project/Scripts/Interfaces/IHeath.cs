using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IFB.Interfaces
{
    public interface IHeath
    {
        int InitialLife { get; set; }
        void Damage(int damage);

        int CurrentLife();
    }
}