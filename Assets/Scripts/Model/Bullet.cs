using UnityEngine;

namespace Geekbrains
{
    public sealed class Bullet : Ammunition
    {
        public AmmunitionType Type = AmmunitionType.Bullet;
        private void OnCollisionEnter(Collision collision)
        {
            // дописать доп урон
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();

            if (tempObj != null)
            {
                tempObj.SetDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
            }

            DestroyAmmunition();
        }
    }
}
