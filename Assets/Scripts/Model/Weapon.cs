using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
	public abstract class Weapon : BaseObjectScene
	{
		private int _maxCountAmmunition = 40;
		private int _minCountAmmunition = 20;
		private int _countClip = 5;
        public Ammunition[] ammunitions;
        public Clip Clip;
        protected AmmunitionType _currentAmmoType;


        public AmmunitionType AmmunitionType1 = AmmunitionType.Bullet;
        public AmmunitionType AmmunitionType2 = AmmunitionType.Grenade;
        
        [SerializeField] protected Transform _barrel;
		[SerializeField] protected float _force = 999;
		[SerializeField] protected float _rechergeTime = 0.2f;
        [SerializeField] protected float _grenadeRechergeTime = 2.0f;
        private Queue<Clip> _clips = new Queue<Clip>();

		protected bool _isReady = true;

		private void Start()
		{
            _currentAmmoType = AmmunitionType1;
			for (var i = 0; i <= _countClip; i++)
			{
				AddClip(new Clip { CountAmmunition = Random.Range(_minCountAmmunition, _maxCountAmmunition) });
			}
			
			ReloadClip();
		}

        public virtual void ChangeAmmoType()
        {

        }
		public abstract void Fire();

		protected void ReadyShoot()
		{
			_isReady = true;
		}

		protected void AddClip(Clip clip)
		{
			_clips.Enqueue(clip);
		}

		public void ReloadClip()
		{
			if (CountClip <= 0) return;
			Clip = _clips.Dequeue();
		}

		public int CountClip => _clips.Count;
	}
}