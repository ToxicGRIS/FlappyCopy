using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	#region Properties

	

	#endregion
	public void StartGame()
	{
		SceneManager.LoadScene("Gameplay");
	}

	public void Exit()
	{
		Application.Quit();
	}
}
