using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiClick : MonoBehaviour
{
	public GameObject _CanvasStartMenu;
	
	private void Start()
  {
	 Screen.orientation = ScreenOrientation.LandscapeLeft;
    _CanvasStartMenu.gameObject.SetActive(true);
  }

    public void LoadScene(int level)
    {
		switch (level)
		{
			case 1:
				//Debug.Log("Fight");
				_CanvasStartMenu.gameObject.SetActive(false);
				SceneManager.LoadScene("Fight");
				break;
			case 2:
				break;
			default:
				break;
		}
		
    }
	
}
