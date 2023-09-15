using TMPro; // Import the TextMeshPro namespace
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
using System.Collections; // Add this line for IEnumerator


public class PlaneScript : MonoBehaviour
{
    private CharacterStackController characterStackController;

    public GameObject cubeToCollectPrefab;

    private bool done = false;
    

    [SerializeField] public GameObject gameOverCanvas;

    public bool panelActivated = false;



    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == "PlusTwoPlane")
        {
            plusTwoFunction(other);
        }
        else if(gameObject.name == "MinusThreePlane")
        {
            StartCoroutine(minusThreeFunction(other));

        }
    }


    private void plusTwoFunction(Collider other)
    {
        if (other.name == "MainCube" || other.name == "CubeToCollect")
        {
            GameObject characterStackObject = GameObject.Find("MainCube");
            characterStackController = characterStackObject.GetComponent<CharacterStackController>();

            for (int i = 0; i < 2; i++)
            {
                GameObject newCube = Instantiate(cubeToCollectPrefab);
                newCube.name = "CubeToCollectCreated";
                newCube.GetComponent<CubeController>().isStack = true;
                characterStackController.AddNewBlock(newCube);
                newCube.GetComponent<CubeController>().SetDirection();
            }
        }
    }

    private IEnumerator minusThreeFunction(Collider other)
    {
        if ((other.name == "MainCube" || other.name == "CubeToCollect" || other.name == "CubeToCollectCreated") && !done)
        {
            GameObject characterStackObject = GameObject.Find("MainCube");
            characterStackController = characterStackObject.GetComponent<CharacterStackController>();

            if (characterStackController.blockList.Count >= 3)
            {
                
                for (int i = 0; i < 3; i++)
                {
                    characterStackController.RemoveBlock(characterStackController.blockList[characterStackController.blockList.Count - 1]);
                }
            }
            else
            {
                if(!panelActivated)
                {
                    if (gameOverCanvas != null)
                    {
                        gameOverCanvas.SetActive(true);
                    }

                    yield return new WaitForSeconds(3.0f);

                    // Restart the scene after 3 seconds
                    SceneManager.LoadScene("SampleScene"); // Replace with the actual scene name
                    panelActivated = true;
                }
            }
            done = true;
        }
    }




}
