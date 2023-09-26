using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor;

public class PlayerController : MonoBehaviour  
{
    [SerializeField]
    float speed;
    int puntuacio = 0;
    [SerializeField]
    TextMeshProUGUI textpuntuacio;
    int totalpickup = 0;
    [SerializeField]
    TextMeshProUGUI textguanyador;


    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        totalpickup = GameObject.FindGameObjectsWithTag("Pickup").Length;
        Debug.Log(totalpickup);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            Application.OpenURL("about:blank");
#else
            Application.Quit();
#endif

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag.Equals("Pickup"))
        {
            
            Debug.Log("+1 punt!");
            puntuacio= puntuacio+1;
            Debug.Log(puntuacio);
            totalpickup= totalpickup-1;
            textpuntuacio.text = puntuacio.ToString();
            Destroy(collision.gameObject);
        }
        if (totalpickup == 0)
        {
            textguanyador.text="Marc flores ets un Guanyador!!!";
            textguanyador.gameObject.SetActive(true);
            
        }
        
    }
}
