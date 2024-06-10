using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDotSight : MonoBehaviour
{
    public GameObject redDot; // The red dot UI element
    public Transform weapon; // The weapon's transform
    public Camera playerCamera; // The player's camera

    void Update()
    {
        if (redDot != null && weapon != null && playerCamera != null)
        {
            // Align the red dot with the weapon's aim
            Ray ray = new Ray(weapon.position, weapon.forward);
            Plane plane = new Plane(playerCamera.transform.forward, playerCamera.transform.position);

            if (plane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                redDot.transform.position = hitPoint;
            }
        }
    }
}
