using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections; // Add this line for IEnumerator
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{
    private bool done;

    [SerializeField] public GameObject CongratsCanvas;

    private PlaneScript planeScript;

    private void Start()
    {
        done = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (!done)
        {
            Debug.Log("Done'ın içinde");                           
            GameObject gameOverCanvas = GameObject.Find("GameOverCanvas");
            if (gameOverCanvas == null)
            {
                StartCoroutine(displayCongratsCanvas());
            }
            

            done = true;
        }
    }

    private IEnumerator displayCongratsCanvas()
    {
        CongratsCanvas.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");
    }


}
