using System;
using UnityEngine;

namespace Geekbrains
{
    public class Enemy : Aim, ISetDamage, ISelectObj
    {
        public override event Action OnPointChange;


        public override void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                Hp = 0;
                if (!TryGetComponent<Rigidbody>(out _))
                {
                    gameObject.AddComponent<Rigidbody>();
                }
                Destroy(gameObject, 10);

                OnPointChange?.Invoke();
                _isDead = true;
            }
            StatusChange();
        }
        public override void StatusChange()
        {
            Status = gameObject.name + " HP " + Hp;
        }
    }
}
