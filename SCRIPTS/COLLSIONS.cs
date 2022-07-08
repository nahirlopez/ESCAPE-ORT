using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLLSIONS : MonoBehaviour
{

    public GameObject PUERTA;
    public GameObject LLAVE;
    bool llave;
    public float speedgiro;
    public float speedZ;
    public float JumpForce;
    Rigidbody rb;
    int hasJump;
    // Start is called before the first frame update
    void Start()
    {
        llave = false;
        rb = GetComponent<Rigidbody>();
        hasJump = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))

        {
            transform.Translate(0, 0, speedZ);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speedZ);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, speedgiro, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -speedgiro, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && hasJump > 0)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            hasJump--;
        }
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "llave")
        {
            llave = true;
            LLAVE.SetActive(false);
            
        }
        if (col.gameObject.name == "puerta" && llave)
        {
            PUERTA.SetActive(false);
        }
    }
}
