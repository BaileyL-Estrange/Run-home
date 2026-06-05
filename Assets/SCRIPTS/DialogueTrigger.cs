using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	[Header("Visual Cue")]
	[SerializeField] private GameObject visualCue;

	private bool PlayerInRange

	private void Awake()
	{
		playInRange = false;
		visualCue.SetActive(false);
	}

	private void Update()
	{
		if (playerInRange)
		{
			visualCue.SetActive(true);
			if(InputManager.GetInstance().GetInteractPressed())
			{
				Debug.Log(inkJSON.text);
			}
		}
		else
		{
			visualCue.SetActive(false);
		}
	}

	private void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			playerInRange = true;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			playerInRange = false;
		}

	}
}
