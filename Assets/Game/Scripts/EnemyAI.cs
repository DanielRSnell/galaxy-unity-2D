using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float _speed = 2.0f;

    
    // Start is called before the first frame update
    void Start()
    {

        float _ran = Random.Range(-7.5f, 7.5f);

        transform.position = new Vector3(_ran, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y <= -6)
        {
            float _x = Random.Range(-7.5f, 7.5f);

            transform.position = new Vector3(_x, 6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        float _ran = Random.Range(-7.5f, 7.5f);

        Debug.Log("Collided with: " + other.name);

        Player player = other.GetComponent<Player>();
        
        if ( player != null )
        {
            player._lives -= 1;

            Debug.Log(player._lives);

            // On Collision Respawn

            player.enemiesDestroyed += 1;

            transform.position = new Vector3(_ran, 6, 0);

            // Perm Death Destroy(this.gameObject);
        }

        Laser laser = other.GetComponent<Laser>();

        if (laser != null)
        {
            transform.position = new Vector3(_ran, 6, 0);
        }
        
        }
    }
