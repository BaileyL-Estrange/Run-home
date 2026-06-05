using UnityEngine;
using UnityEngine.UI;

public class PCmanagement : MonoBehaviour
{
	private Renderer _renderer;
	public Image PCImage;
	public GameObject crosshair;

	private void Start() 
	{

		_renderer = GetComponent<Renderer>();

	}
	public void showAPP()
	{
		PCImage.gameObject.SetActive(true);
		CursorManagement.SetUI(true);
		crosshair.gameObject.SetActive(false);
	}

	public void hideAPP() 
	{
		PCImage.gameObject.SetActive(false);
		CursorManagement.SetUI(false);
		crosshair.gameObject.SetActive(true);
	}

}
