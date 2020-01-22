using UnityEngine;

namespace Geekbrains
{
	public sealed class Inventory : IInitialization
	{
		private Weapon[] _weapons = new Weapon[5];
        public int _currentWeaponNumber;

        public Weapon[] Weapons => _weapons;

		public FlashLightModel FlashLight { get; private set; }

        public void SetCurrentWeaponNumber(int i)
        {
            _currentWeaponNumber = i;
        }
        public void Initialization()
		{
			_weapons = ServiceLocatorMonoBehaviour.GetService<CharacterController>().
				GetComponentsInChildren<Weapon>();

			foreach (var weapon in Weapons)
			{
				weapon.IsVisible = false;
			}

			FlashLight = Object.FindObjectOfType<FlashLightModel>();
			FlashLight.Switch(FlashLightActiveType.Off);
		}

        public int PreviousWeapon()
        {
            _currentWeaponNumber--;
            if (_currentWeaponNumber < 0)
            {
                _currentWeaponNumber = 0;
            }
            return _currentWeaponNumber;
        }
        public int NextWeapon()
        {
            _currentWeaponNumber++;
            if (_currentWeaponNumber > _weapons.Length-1)
            {
                _currentWeaponNumber --;
            }

            return _currentWeaponNumber;
        }

        public void RemoveWeapon(Weapon weapon)
        {
            
        }
	}
}