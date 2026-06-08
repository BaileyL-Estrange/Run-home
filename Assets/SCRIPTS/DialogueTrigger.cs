using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
	[Header("Visual Cue")]
	[SerializeField] private GameObject visualCue;

	[Header("Ink JSON")]
	[SerializeField] private TextAsset inkJSON;

	private bool playerInRange;

	private void Awake()
	{
		playerInRange = false;
		visualCue.SetActive(false);
	}

	private void Update()
	{
		if (playerInRange && !DialogueScript.GetInstance().dialogueIsPlaying)
		{
			visualCue.SetActive(true);
			if(Input.GetKeyDown(KeyCode.E))
			{
				DialogueScript.GetInstance().EnterDialogueMode(inkJSON);
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
