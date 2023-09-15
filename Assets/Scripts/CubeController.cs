using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CharacterStackController characterStackController;

    private Vector3 direction = Vector3.back;

    public bool isStack = false;

    private RaycastHit hit;

    public bool isLastBlock;

    // direction

    void Start()
    {
        isLastBlock = false;
        characterStackController = GameObject.FindObjectOfType<CharacterStackController>();
       
    }

   

    void FixedUpdate()
    {
        SetCubeBoxcast();
    }
    /*
    private void SetCubeRaycast()
    {
        if(Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if(!isStack)
            {
                Debug.Log("In a collision");
                isStack = true;
                characterStackController.AddNewBlock(gameObject);
            }

            if(hit.transform.name == "Cube")
            {
                characterStackController.RemoveBlock(gameObject);
            }

        }
    }
    */
    private void SetCubeBoxcast()
    {
        
        Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f); 

        if (Physics.BoxCast(transform.position, halfExtents, direction, out hit, Quaternion.identity, 1f))
        {
           
            if (!isStack)
            {
                
                isStack = true;
                characterStackController.AddNewBlock(gameObject);
                SetDirection();
            }
            
            if (hit.transform.name == "Cube" || hit.transform.name == "CubeToCollectCreated")
            {
                
                characterStackController.RemoveBlock(gameObject);
            }
        }
    }

    public void SetDirection()
    {
        direction = Vector3.forward;
    }

}
