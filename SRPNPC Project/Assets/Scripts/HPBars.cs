using UnityEngine;
using UnityEngine.UI;

public class HPBars : MonoBehaviour
{
	private Slider slider;

	private void Start()
	{
		slider = GetComponentInChildren<Slider>();
		GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
	}

	private void HandleHPPctChanged(float pct)
	{
		slider.value = pct;
	}
}
