using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public sealed  class SelectionObjMessageUi : MonoBehaviour
	{
		private Text _text;
        private float _hp;
        private float _armore;
		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		public string Text
		{
			set => _text.text = $"{value}";
		}

		public void SetActive(bool value)
		{
			_text.gameObject.SetActive(value);
		}
	}
}