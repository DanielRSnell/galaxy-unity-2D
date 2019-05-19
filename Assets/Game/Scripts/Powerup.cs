using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int powerupID;
    
    // 0 = TS, 1 = Speed, 2 = Shields

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y < -9)
        {
            Destroy(this.gameObject, 1);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        Player player = other.GetComponent<Player>();

        Debug.Log("Something");

        if (player != null) {

            if (powerupID == 0)
            {
                player.TripleShotPowerupOn();
            }
            else if (powerupID == 1)
            {
                player.SpeedPowerupOn();
            }
            else if (powerupID == 2)
            {
                // Shield
            }
        }

        Destroy(this.gameObject);
    }
}
