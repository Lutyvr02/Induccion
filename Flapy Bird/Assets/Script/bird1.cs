using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;

    public float fuerza = 300;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began
            || Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerza);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}