using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{

    [SerializeField] private float ParalaxMultiplier;
    private Transform CameraTransform;
    private Vector3 PreviousCameraPosition;

    void Start()
    {
        CameraTransform = Camera.main.transform;
        PreviousCameraPosition = CameraTransform.position;

    }
    void LateUpdate()
    {
        float deltax = (CameraTransform.position.x - PreviousCameraPosition.x) * ParalaxMultiplier;
        transform.Translate(new Vector3(deltax, 0, 0));
        PreviousCameraPosition += CameraTransform.position;


    }
}
