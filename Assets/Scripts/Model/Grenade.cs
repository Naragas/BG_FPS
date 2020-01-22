using UnityEngine;

namespace Geekbrains
{
    public sealed class Grenade : Ammunition
    {
        [SerializeField] private float _explosiveRange = 1f;
        public AmmunitionType Type = AmmunitionType.Grenade;

        private void OnCollisionEnter(Collision collision)
        {

            Vector3 center = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            Collider[] objs = Physics.OverlapSphere(center, _explosiveRange);

            foreach (var obj in objs)
            {
                var tempObj = obj.gameObject.GetComponent<ISetDamage>();

                if (tempObj != null)
                {
                    tempObj.SetDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
                }
            }

            DestroyAmmunition();
        }       

    }
}
