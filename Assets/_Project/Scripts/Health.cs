using HermitCrabGameStudio.Onboarding.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IFB
{
    public class Health : MonoBehaviour, IHeath
    {
        public int Initial = 3;

        public int InitialLife { get => Initial; set => Initial = value; }

        public int CurrentLife()
        {
            return Initial;
        }

        public void Damage(int damage)
        {
            if(Initial > 0)
            {
                Initial -= damage;
            }
        }
    }
}