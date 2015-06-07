using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
	public HealthScript Player;
	public Transform ForegroundSprite;
	public SpriteRenderer ForegroundRenderer;
	public Color MaxHealthColor = new Color (255 / 255f, 63 / 255f, 63 / 255f);
	public Color MinHealthColor = new Color(63 / 255f, 137 / 255f, 255 / 255f);

	void Update()
	{
		var healthPercent = Player.currentHealth / (float)Player.maxHealth;

		ForegroundSprite.localScale = new Vector3 (healthPercent, 1, 1);
		ForegroundRenderer.color = Color.Lerp (MaxHealthColor, MinHealthColor, healthPercent);
	}
}
