using UnityEngine;

public class ProximityHandler : MonoBehaviour
{
    private Material _material;

    public Transform playerLocation;
    private float distanceToGun;



    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        distanceToGun = Vector3.Distance(playerLocation.position, transform.position);
        _material.SetFloat("_Distance", distanceToGun);
        Debug.Log(distanceToGun);
    }
}