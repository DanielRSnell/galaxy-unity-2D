using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);

        Destroy(this.gameObject, 1f);
    }
}