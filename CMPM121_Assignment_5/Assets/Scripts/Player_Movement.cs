using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour //code taken from a tutorial on YouTube, edited to fit the needs of the assignment
{

    private float speed = 20.0f;
    public float gravity = -9.8f;

    float jumpStrength = 2f;

    public int forceConst = 50;

    public Text pointText;
    public Text pointText2;
    private int points = 0;

    //public static bool unlock = false;

    private CharacterController _charCont;
    private Rigidbody _rigidbody;

    // Use this for initialization
    void Start()
    {
        _charCont = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
        pointText.text = "Mushrooms: " + points.ToString();
        pointText2.text = "Mushrooms: " + points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charCont.Move(movement);

        if (points > 49)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    void OnTriggerEnter(Collider other) //collect mushrooms to add to your points
    {
        if (other.tag == "Mushroom")
        {
            points++;
            pointText.text = "Mushrooms: " + points.ToString();
            pointText2.text = "Mushrooms: " + points.ToString();
            ParticleSystem particles = other.GetComponent<Mushrooms>().particles;
            particles.Play();
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<SphereCollider>().enabled = false;
        }
        /*
        if (other.tag == "Key")
        {
            unlock = true;
            Destroy(other.gameObject);
            Debug.Log(unlock);
        }
        */
    }

    void OnCollisionEnter(Collision col) //you die when you are hit by the ball
    {
        if (col.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}