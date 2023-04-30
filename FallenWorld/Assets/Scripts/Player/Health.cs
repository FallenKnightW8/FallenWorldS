using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
	[SerializeField]private Image HpBar;
	[SerializeField] private Image ArmorBar;
	private float fill;
	private float RimeToRestore = 3f;
	private float Cheker;
	public Text CountHP;
	[SerializeField]private GameObject Enemy;

	private Mission countOfdeads;

	[SerializeField]private bool canDie = true;					// Whether or not this health can die

	public float startingHealth = 50.0f;		// The amount of health to start with
	public float maxHealth = 50.0f;			// The maximum amount of health
	public float currentHealth;             // The current ammount of health

	[SerializeField]private float ArmorCount = 0;
	private float StartArmorCount = 25;

	[SerializeField]private bool isPlayer = false;				// Whether or not this health is the player

	public int MoneyForDead = 10;
	public Take Mscore;

	[SerializeField] private FirstPersonCharacter Cursor;
	[SerializeField]private Animator anim;

	private bool dead = false;					// Used to make sure the Die() function isn't called twice
	// Use this for initialization
	void Start() 
	{
		// Initialize the currentHealth variable to the value specified by the user in startingHealth
		currentHealth = startingHealth;
		fill = 1f;
		Mscore = GameObject.Find("PlayerObj").GetComponent<Take>();
		countOfdeads = GameObject.Find("MissionManager").GetComponent<Mission>();
		if (isPlayer && PlayerPrefs.GetInt("ListHasBuyed_2") == 2)
        {
			ArmorCount = StartArmorCount;
			Cheker = StartArmorCount;

		}
	}

	void Update()
	{
		if (currentHealth <= 0 && !dead && canDie)
			Die();
		if (isPlayer == true)
		{
			HpBar.fillAmount = fill;
			fill = (currentHealth/100);
			ArmorBar.fillAmount = ArmorCount / 100;
			CountHP.text = currentHealth.ToString();
		}
	}

	private IEnumerator RestoreArmor()
    {
		yield return new WaitForSeconds(RimeToRestore);
		if (ArmorCount + Cheker > StartArmorCount)
			ArmorCount += StartArmorCount - ArmorCount;
		else
		ArmorCount += Cheker;
		Cheker = 0;
	}
	public void ChangeHealth(float amount)
	{
		// Change the health by the amount specified in the amount variable
		if (ArmorCount > 0)
        {
			ArmorCount += amount;

		}
		else currentHealth += amount;
		StopAllCoroutines();
		Cheker += amount * -1;
		StartCoroutine(RestoreArmor());

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
		if(isPlayer == false) // IF, ELSE IF
		{
			countOfdeads.CountOfComplitM++;
			Mscore.PlayerGM(MoneyForDead);
			Destroy(gameObject);
		}

		if (isPlayer == true)
		{
			if (isPlayer)
			{
				anim.SetBool("IsDead",true);
			}
		}
        else
        {
			if (Enemy != null)Destroy(Enemy);
			Destroy(gameObject);
		}
		// Remove this GameObject from the scene
	}
	public void DeadPlayer()
    {
		Cursor.lockCursor = false;
		Time.timeScale = 0f;
	}
}
