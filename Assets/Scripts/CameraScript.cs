using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform characterTransform;
    private Vector3 offset;
    private Vector3 updatedPosition;
    [SerializeField] private float lerpValue;

    void Start()
    {
        offset = transform.position - characterTransform.position;
    }

    void LateUpdate()
    {
        CameraSmoothFollow();       
    }


    private void CameraSmoothFollow()
    {
        updatedPosition = Vector3.Lerp(transform.position, new Vector3(0f, characterTransform.position.y, characterTransform.position.z) + offset, lerpValue * Time.deltaTime);
        transform.position = updatedPosition;
    }


}
