using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ARShoot : MonoBehaviour
{
    public GameObject projectile,chargedProjectile;
    public float shotSpeed = 4f;
    public AudioClip shootClip;
    public GameObject player,charageShot;

    public Camera main;

    ARGestureInteractor arGestureInteractor;

    private void Awake()
    {
        charageShot.SetActive(false);
    }
    void OnEnable()
    {
        arGestureInteractor = GetComponent<ARGestureInteractor>();
        arGestureInteractor.tapGestureRecognizer.onGestureStarted += OnTapRecognized;
        arGestureInteractor.dragGestureRecognizer.onGestureStarted += OnDragRecognized;
        
    }

	void Disable()
    {
        arGestureInteractor.tapGestureRecognizer.onGestureStarted -= OnTapRecognized;
        arGestureInteractor.dragGestureRecognizer.onGestureStarted -= OnDragRecognized;
    }

    private void OnDragRecognized(DragGesture obj)
    {
        Debug.Log("DRAG START: " + obj.position);
        obj.onFinished += OnDragComplete;

        charageShot.SetActive(true);
    }

	private void OnDragComplete(DragGesture obj)
	{
        Debug.Log("DRAG END" + obj.position);
        obj.onFinished -= OnDragComplete;

        charageShot.SetActive(false);

        // this conditional (from Vector2Extensions) avoids spawning when tapping a button
        Vector2 mousePos = obj.startPosition;
        if (!mousePos.IsPointOverUIObject())
        {
            // creating a projectile and setting its velocity

            Ray ray = main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(75);

            Vector3 directionWithoutSpread = targetPoint = transform.position;

            GameObject newProjectile = Instantiate(chargedProjectile, transform.position, Quaternion.Euler(90f, 0f, 0f));
            Vector3 shotVelocity = transform.forward.normalized * shotSpeed;
            newProjectile.GetComponent<Rigidbody>().velocity = shotVelocity;


            GetComponent<AudioSource>().PlayOneShot(shootClip);
        }
    }

    public void ChangeProjectile(GameObject newPrefab)
    {
        Debug.Log("ChangeProjectile");
        projectile = newPrefab;        
    }

    public void ChargedProjectile(GameObject newPrefab)
    {
        chargedProjectile = newPrefab;
    }
    

    private void OnTapRecognized(TapGesture obj)
    {
        // this conditional (from Vector2Extensions) avoids spawning when tapping a button
        Vector2 mousePos = obj.startPosition;
        if (!mousePos.IsPointOverUIObject())
        {
            // creating a projectile and setting its velocity

            Ray ray = main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;
            Vector3 targetPoint;
            if(Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(75);

            Vector3 directionWithoutSpread = targetPoint = transform.position;

            GameObject newProjectile = Instantiate(projectile,transform.position, Quaternion.Euler(90f, 0f, 0f));
            Vector3 shotVelocity = transform.forward.normalized * shotSpeed;
            newProjectile.GetComponent<Rigidbody>().velocity = shotVelocity;
            

            GetComponent<AudioSource>().PlayOneShot(shootClip);
        }
    }
}
