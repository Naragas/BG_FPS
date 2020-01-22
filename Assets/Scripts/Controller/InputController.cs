using UnityEngine;

namespace Geekbrains
{
    public sealed class InputController : BaseController, IExecute
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;
        private KeyCode _changeAmmo = KeyCode.X;
        private int _mouseButton = (int)MouseButton.LeftButton;

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
		
        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch(ServiceLocator.Resolve<Inventory>().FlashLight);
            }
            //todo реализовать выбор оружия по колесику мыши

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectWeapon(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectWeapon(1);
            }
            if (Input.GetKeyDown(_changeAmmo))
            {
                ServiceLocator.Resolve<WeaponController>().ChangeAmmo();
            }

            if (Input.GetMouseButton(_mouseButton))
            {
                if (ServiceLocator.Resolve<WeaponController>().IsActive)
                {
                    ServiceLocator.Resolve<WeaponController>().Fire();
                }
            }

            if (Input.GetKeyDown(_cancel))
            {
                ServiceLocator.Resolve<WeaponController>().Off();
                ServiceLocator.Resolve<FlashLightController>().Off();
            }

            if (Input.GetKeyDown(_reloadClip))
            {
                ServiceLocator.Resolve<WeaponController>().ReloadClip();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                SelectWeapon(ServiceLocator.Resolve<Inventory>().NextWeapon());
                //SelectWeapon(Inventory.NextWeapon());
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                SelectWeapon(ServiceLocator.Resolve<Inventory>().PreviousWeapon());
                //SelectWeapon(Main.Instance.Inventory.PreviousWeapon());
            }
        }


        /// <summary>
        /// Выбор оружия
        /// </summary>
        /// <param name="i">Номер оружия</param>
        private void SelectWeapon(int i)
        {
            ServiceLocator.Resolve<WeaponController>().Off();
            var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; //todo инкапсулировать
            if (tempWeapon != null)
            {
                ServiceLocator.Resolve<Inventory>().SetCurrentWeaponNumber(i);
                ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
            }
        }
    }
}
