using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushrooms : MonoBehaviour
{
    public ParticleSystem particles;
    public AnimationCurve myCurve;
    public AnimationCurve curve2;
    float posY;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
        posY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, posY + curve2.Evaluate((Time.time % myCurve.length)), transform.position.z);
        transform.Rotate(new Vector3(15, 0, 45) * Time.deltaTime);
    }
}
