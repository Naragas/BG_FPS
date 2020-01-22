using UnityEngine;
using System.Collections;

namespace Geekbrains
{
    class Ump : Weapon
    {

        
        [SerializeField] protected float _burstingDelayTime;
        [SerializeField] protected int _burstingBulletCount;
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition < _burstingBulletCount) return;

            StartCoroutine(BurstShot());

            Clip.CountAmmunition -= _burstingBulletCount;
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechergeTime);
        }

        IEnumerator BurstShot()
        {
            for (int i = 0; i < _burstingBulletCount; i++)
            {
                var temAmmunition = Instantiate(ammunitions[0], _barrel.position, _barrel.rotation);//todo Pool object
                temAmmunition.AddForce(_barrel.forward * _force);
                yield return new WaitForSeconds(_burstingDelayTime);
            }
        }
    }
}

