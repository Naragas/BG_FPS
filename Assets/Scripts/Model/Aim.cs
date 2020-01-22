using System;
using UnityEngine;

namespace Geekbrains
{
    public abstract class Aim : MonoBehaviour, ISetDamage, ISelectObj
    {
        public virtual event Action OnPointChange;

        private float _hp = 100;
        private string _status;
        protected bool _isDead;

        public float Hp { get => _hp; protected set => _hp = value; }
        public string Status { get => _status; protected set => _status = value; }

        //todo дописать поглащение урона
        public virtual void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
        }

        public virtual void StatusChange()
        {
            Status = gameObject.name;
        }

        public string GetMessage()
        {
            StatusChange();
            return Status; 
        }
    }
}
