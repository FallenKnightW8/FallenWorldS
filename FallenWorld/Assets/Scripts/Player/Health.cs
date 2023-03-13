/// <summary>
/// Health.cs
/// Author: MutantGopher
/// This is a sample health script.  If you use a different script for health,
/// make sure that it is called "Health".  If it is not, you may need to edit code
/// referencing the Health component from other scripts
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
	public Image HpBar;
	public float fill;
	public Text CountHP;

	public GameObject DeadC;

	public bool canDie = true;					// Whether or not this health can die

	public float startingHealth = 50.0f;		// The amount of health to start with
	public float maxHealth = 50.0f;			// The maximum amount of health
	public float currentHealth;				// The current ammount of health

	public GameObject deadReplacement;			// The prefab to instantiate when this GameObject dies

	public bool isPlayer = false;				// Whether or not this health is the player

	public int MoneyForDead;
	public Take Mscore;

	[SerializeField]private GameObject deathCam;					// The camera to activate when the player dies

	private bool dead = false;					// Used to make sure the Die() function isn't called twice
	// Use this for initialization
	void Start()
	{
		// Initialize the currentHealth variable to the value specified by the user in startingHealth
		currentHealth = startingHealth;
		fill = 1f;
		Mscore = GameObject.Find("PlayerObj").GetComponent<Take>();
	}

	void Update()
	{
			if (currentHealth <= 0 && !dead && canDie)
				Die();
			if (isPlayer == true)
			{
				HpBar.fillAmount = fill;
				fill = (currentHealth/100);
				CountHP.text = currentHealth.ToString();
		}
	}

	public void ChangeHealth(float amount)
	{
		// Change the health by the amount specified in the amount variable
		currentHealth += amount;

		// If the health runs out, then Die.
		if (currentHealth <= 0 && !dead && canDie)
			Die();

		// Make sure that the health never exceeds the maximum health
		else if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	}

	public void Die()
	{
		// This GameObject is officially dead.  This is used to make sure the Die() function isn't called again
		dead = true;
		if(isPlayer == false)
		{
		Mscore.PlayerGM(MoneyForDead);
		Destroy(gameObject);
		}

		if (isPlayer == true)
		{
			if (isPlayer && deathCam != null)
				Time.timeScale = 0f;
				DeadC.SetActive(true);
				deathCam.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
		}
		// Remove this GameObject from the scene
		Destroy(gameObject);
	}
}
