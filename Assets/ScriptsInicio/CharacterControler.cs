using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float MovHOrizontal;
    public float JumForce;
    public float VelocidadDez;
    public float JumpTime;
    public float Timer;
    public float DivMovAir;
    public float TiempoAnima = 0;

    public Rigidbody2D Rigidbody;

    public Vector2 Vector2;

    public bool InAirControl, InGround;
    public bool Ataco = false;

    public Animator PlayerMueve;

    void Start()
    {

    }

    void Update()
    {

        if (InGround)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                Rigidbody.velocity = new Vector2(-VelocidadDez, Rigidbody.velocity.y);
                PlayerMueve.SetBool("Camina", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                Rigidbody.velocity = new Vector2(0, Rigidbody.velocity.y);
                PlayerMueve.SetBool("Camina", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                Rigidbody.velocity = new Vector2(VelocidadDez, Rigidbody.velocity.y);
                PlayerMueve.SetBool("Camina", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                Rigidbody.velocity = new Vector2(0, Rigidbody.velocity.y);
                PlayerMueve.SetBool("Camina", false);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                Rigidbody.velocity = new Vector2(-VelocidadDez /DivMovAir, Rigidbody.velocity.y);
                PlayerMueve.SetBool("Camina", false);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                Rigidbody.velocity = new Vector2(0, Rigidbody.velocity.y);
                PlayerMueve.SetBool("Camina", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                Rigidbody.velocity = new Vector2(VelocidadDez / DivMovAir, Rigidbody.velocity.y);
                PlayerMueve.SetBool("Camina", false);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                Rigidbody.velocity = new Vector2(0, Rigidbody.velocity.y);
                PlayerMueve.SetBool("Camina", false);
            }
        }

        if (Input.GetButton("Jump"))
            {

                if (InGround)
                {
                    InGround = false;
                    InAirControl = true;
                }

                if (InAirControl)
                {
                    PlayerMueve.SetBool("Salta", true);
                    Timer += Time.deltaTime;
                    if (Timer < JumpTime)
                    {
                        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumForce);
                    }

                    if (Timer >= JumpTime)
                    {
                        InAirControl = false;
                        Timer = 0;
                    }
                }
            }
            else
            {
                InAirControl = false;
                Timer = 0;
            }

        if (Input.GetKey(KeyCode.L))
        {
            Ataco = true;
        }
        else
        {
            Ataco = false;
        }

        if (Ataco == true)
        {
            TiempoAnima += Time.fixedDeltaTime;
            PlayerMueve.SetBool("Ataque", true);

        }
        else {
            PlayerMueve.SetBool("Ataque", false);
            Ataco = false;
        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            PlayerMueve.SetBool("Salta", false);
            InGround = true;
            Timer = 0;
    
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        InGround = false;
    }

}
