using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStackController : MonoBehaviour
{
    public List<GameObject>blockList = new List<GameObject>();

    private GameObject lastCube;

    private int collectedBlocks = 0;

    private CubeController cubeController;

    private bool isLastBlock;

    private PlaneScript planeScript;

    private bool hasCollided = false; // Flag to track whether a collision has occurred

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves another cube and blockList.Count is 1
        if (collision.gameObject.name == "Cube" && blockList.Count == 1 && !hasCollided)
        {
            hasCollided = true; // Set the flag to prevent multiple calls

            GameObject planeObject = GameObject.Find("MinusThreePlane");
            planeScript = planeObject.GetComponent<PlaneScript>();

            if (!planeScript.panelActivated)
            {
                if (planeScript.gameOverCanvas != null)
                {
                    planeScript.gameOverCanvas.SetActive(true);
                }

                StartCoroutine(RestartSceneAfterDelay());
                planeScript.panelActivated = true;
            }
        }
    }

    private IEnumerator RestartSceneAfterDelay()
    {
        yield return new WaitForSeconds(3.0f);

        // Restart the scene after 3 seconds
        SceneManager.LoadScene("SampleScene"); // Replace with the actual scene name
    }

    void Start()
    {
        isLastBlock = true;
        UpdateLastCube();

    }

    public void AddNewBlock(GameObject block)
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);    
        block.transform.position = new Vector3(lastCube.transform.position.x, lastCube.transform.position.y -2f, lastCube.transform.position.z);
        block.transform.SetParent(transform);
        blockList.Add(block);
        collectedBlocks++;
        UpdateLastCube();
        
    }

   
    public void RemoveBlock(GameObject block)
    {
        
        block.transform.parent = null;
        blockList.Remove(block);
        collectedBlocks--;
        UpdateLastCube();
    }



    
    private void UpdateLastCube()
    {
        /*
        if(blockList.Count == 2) 
        {
            cubeController = blockList[blockList.Count - 1].GetComponent<CubeController>(); // 1. element
            cubeController.isLastBlock = true;
            isLastBlock= false;

        }
        else if(blockList.Count == 1)
        {
            isLastBlock = true;
        }
        else
        {
            cubeController = blockList[blockList.Count - 1].GetComponent<CubeController>();
            cubeController.isLastBlock = true;
            cubeController = blockList[blockList.Count - 2].GetComponent<CubeController>();
            cubeController.isLastBlock = false;
        }
        */
        lastCube = blockList[blockList.Count - 1];
    }
}
