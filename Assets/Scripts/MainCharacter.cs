using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    private float horizantalValue;
    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizantalMovementSpeed;
    [SerializeField] private float horizantalLimitValue;

    private float newPositionX;

    void Start()
    {
        
    }

    void Update()
    {
        HandleHorizantalInput();
    }

    private void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizantalMovement();
    }

    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.down * forwardMovementSpeed * Time.fixedDeltaTime);
        // sürekli o yönde hareket edecek
    }
    private void SetHeroHorizantalMovement()
    {
        newPositionX = transform.position.x + horizantalValue * Time.fixedDeltaTime * horizantalMovementSpeed;
        newPositionX = Mathf.Clamp(newPositionX, - horizantalLimitValue, horizantalLimitValue); // It cannot go beyond that range
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }



    private void HandleHorizantalInput()
    {
        if(Input.GetMouseButton(0))
        {
            horizantalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizantalValue = 0;
        }
    }

}
