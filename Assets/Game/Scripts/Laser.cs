using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        float _ran = Random.Range(-7.5f, 7.5f);

        Debug.Log("Collided with: " + other.name);

        EnemyAI enemy = other.GetComponent<EnemyAI>();

        if (enemy != null)
        {
            Destroy(this.gameObject);
        }

    }
}
