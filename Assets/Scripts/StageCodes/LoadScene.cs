using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public string scene;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")) 
		{
			Debug.Log("Colisono con caja");
            SceneManager.LoadScene(scene);
        }
	}
}
