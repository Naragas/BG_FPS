namespace Geekbrains
{
	public sealed class Gun : Weapon
	{
        
        private int _grenadeCount = 3;
        //   public AmmunitionType[] AmmunitionTypes = { AmmunitionType.Bullet, AmmunitionType.Grenade };

        public override void ChangeAmmoType()
        {
            //if (AmmunitionTypes.Length == 1) return;
            if (_currentAmmoType == AmmunitionType1)
            {
                _currentAmmoType = AmmunitionType2;
            }
            else if (_currentAmmoType == AmmunitionType2)
            {
                _currentAmmoType = AmmunitionType1;
            }

        }
        public override void Fire()
		{
			if (!_isReady) return;
            if (_currentAmmoType == AmmunitionType.Bullet)
            {
                if (Clip.CountAmmunition <= 0) return;
                var temAmmunition = Instantiate(ammunitions[0], _barrel.position, _barrel.rotation);//todo Pool object
                temAmmunition.AddForce(_barrel.forward * _force);
                Clip.CountAmmunition--;
                _isReady = false;
                Invoke(nameof(ReadyShoot), _rechergeTime);
            }
            if (_currentAmmoType == AmmunitionType.Grenade)
            {
                if(_grenadeCount > 0)
                {
                    var temAmmunition = Instantiate(ammunitions[1], _barrel.position, _barrel.rotation);//todo Pool object
                    temAmmunition.AddForce(_barrel.forward * _force);
                    _grenadeCount--;
                    _isReady = false;
                    Invoke(nameof(ReadyShoot), _grenadeRechergeTime);
                }
            }

        }
	}
}