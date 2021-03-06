using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float planeSpeed;
    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject bullet;

    private bool canShoot = true;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlaneMovement();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canShoot)
            {
                StartCoroutine(Shoot ());
            }
        }
    }
    void PlaneMovement() 
    {
        float xAxis = Input.GetAxisRaw("Horizontal") * planeSpeed;
        float yAxis = Input.GetAxisRaw("Vertical") * planeSpeed;
        myBody.velocity = new Vector2(xAxis, yAxis);
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        Vector3 temp = transform.position;
        temp.y += 0.6f;
        Instantiate(bullet,temp, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
