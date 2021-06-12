using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	GameObject mainMenu, creditosMenu;
	public Camera camera;
	public TextMeshPro[] flechasDeBotones = new TextMeshPro[3];
	public int botonSeleccionado;
	private float pressedSpaceTime;
	private bool credits = false;

	void Start()
	{
		mainMenu = this.gameObject;
		//creditosMenu = GameObject.Find("CreditosMenu");
		//creditosMenu.SetActive(false);
		flechasDeBotones[0] = GameObject.Find("Start").transform.GetChild(0).GetComponent<TextMeshPro>();
		flechasDeBotones[1] = GameObject.Find("Options").transform.GetChild(0).GetComponent<TextMeshPro>();
		flechasDeBotones[2] = GameObject.Find("Quit").transform.GetChild(0).GetComponent<TextMeshPro>();
		for(int i=0; i <= 2; i++)
		{
			flechasDeBotones[i].GetComponent<MeshRenderer>().enabled = false;
		}
		botonSeleccionado = 0;

		actualizaBoton();
		//StartCoroutine(ManageOptions());
	}

	private void Update()
	{
		if(!credits)
		{
			if (Input.GetKey("down") && Time.time - pressedSpaceTime > 0.2f)
			{
				botonSeleccionado++;
				if (botonSeleccionado == 3) botonSeleccionado = 0;
				pressedSpaceTime = Time.time;
				actualizaBoton();
				SoundSystemScript.PlaySound("Sound_button");
			}
			if (Input.GetKey("up") && Time.time - pressedSpaceTime > 0.2f)
			{
				botonSeleccionado--;
				if (botonSeleccionado == -1) botonSeleccionado = 2;
				pressedSpaceTime = Time.time;
				actualizaBoton();
				SoundSystemScript.PlaySound("Sound_button");
			}

			if (Input.GetKey("c") || Input.GetKey("space") || Input.GetKey(KeyCode.Return))
			{
				switch (botonSeleccionado)
				{
					case 0:
						Jugar();
						break;
					case 1:
						Opciones();
						break;
					case 2:
						Salir();
						break;
					default:
						print("Error de seleccion de boton\n");
						break;
				}
			}
		}
	}

	public void actualizaBoton()
	{
		for (int i = 0; i <= 2; i++)
		{
			if (i == botonSeleccionado) flechasDeBotones[i].GetComponent<MeshRenderer>().enabled = true;
			else if (flechasDeBotones[i].enabled == true) flechasDeBotones[i].GetComponent<MeshRenderer>().enabled = false;
		}
	}

	public void Jugar()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Opciones()
	{
		StartCoroutine(creditos());
	}

	public void Salir()
	{
		Application.Quit();
	}

	IEnumerator creditos()
	{
		credits = true;
		camera.transform.position = new Vector3(6f, 1.477005f, -20f);
		yield return new WaitForSeconds(5f);
		camera.transform.position = new Vector3(2.043019f, 1.477005f, -20f);
		credits = false;
	}
}
