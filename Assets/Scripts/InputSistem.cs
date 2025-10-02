using UnityEngine;

public class InputSistem : MonoBehaviour
{
    //public
    public float movementSpeed = 5;
    public float rotationSpeed = 10;
    public float dashAmount = 2000;
    public float increase = 100;
    public float jumpAmount = 100;
    public bool landing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * dashAmount);
        }

        movementSpeed = movementSpeed + Input.GetAxis("Mouse ScrollWheel") * increase;
        if (movementSpeed > 100) movementSpeed = 100;
        if (movementSpeed < 0) movementSpeed = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpAmount);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            landing = true;
        }
        if (landing && transform.position.y > 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpAmount * -1);
        } 
        else if (landing && transform.position.y <= 0) landing = false;

    }
}
