using System;
using UnityEngine;

namespace Geekbrains
{
    public class ArmoredEnemy : Aim, ISetDamage, ISelectObj
    {
        public override event Action OnPointChange;

        
        private float _armor = 50;
        
       
        public float Armor { get => _armor; private set => _armor = value; }

        public override void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Armor > 0)
            {
                if (Armor > info.Damage)
                {
                    Armor -= info.Damage;
                    return;
                }
                else
                {
                    Hp -= (info.Damage - Armor);
                    Armor = 0;
                }

            }else if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                Hp = 0;
                if (!GetComponent<Rigidbody>())
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
            Status = gameObject.name + " HP " + Hp + " Armor " + Armor;
        }

    }
}
