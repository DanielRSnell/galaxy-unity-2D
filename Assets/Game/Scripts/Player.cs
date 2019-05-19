using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private GameObject _powerupPrefab;

    [SerializeField]
    public bool canTripleShot = false;

    [SerializeField]
    public bool speedBooster = false;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _boost = 2f;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _lastShot = 0.0f;

    [SerializeField]
    public float _lives = 3.0f;

    public int enemiesDestroyed = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Start()
    {
        // Current pos = new pos 
       
        
    }
    

    // Update is called once per frame
    void Update()
    {
        Movement();
        LaserController();
        LifeCounter();
    }

    

    void LifeCounter()
    {
        if (_lives == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void LaserController()
    {
        if (Input.GetKey("space"))
        {
            ActivateLaser();
        }
        else if (Input.GetMouseButton(1))
        {
            ActivateLaser();
        }
    }
    

    void ActivateLaser()
    {
        if (Time.time > _lastShot)
            {
            if (canTripleShot == true)
            {

                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.15f, 0), Quaternion.identity);
               
            }
            _lastShot = Time.time + _fireRate;
        }
        
    }

    void Movement()
    {

        if (Input.GetKeyDown("c"))
        {
            if (_boost + 2 >= 10)
            {
                _boost = 10;
            } else
            {
                _boost += 2;
            }

        }
        else if (Input.GetKeyDown("x"))
        {
            if (_boost - 2 <= 2)
            {
                _boost = 2;
            } else if ( _boost > 10 )
            {
                _boost = _boost;
            }
            else
            {
                _boost -= 2;
            }
        }

        if (speedBooster == true)
        {
            _speed = 10.0f;

        } else if (speedBooster == false)
        {
            _speed = 5;
        }

        float horizontalInput = Input.GetAxis("Horizontal") * _boost;
        float verticalInput = Input.GetAxis("Vertical") * _boost;

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * _speed);
        transform.Translate(Vector3.up * Time.deltaTime * verticalInput * _speed);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -3.9)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, 0);
        }
        else if (transform.position.x > 9.3)
        {
            transform.position = new Vector3(-9.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.3)
        {
            transform.position = new Vector3(9.29f, transform.position.y, 0);
        }
    }

    public void TripleShotPowerupOn()
    {
        canTripleShot = true;

        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    public void SpeedPowerupOn()
    {
        speedBooster = true;

        StartCoroutine(SpeedDownRoutine());
    }

    public IEnumerator SpeedDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speedBooster = false;
    }
}
