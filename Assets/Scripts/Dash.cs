using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 moveDirection;

    
    public float dashCooldown = 5f;
    public float dashDistance = 115f;
    public float dashTime = 1.5f;
    
    private bool isDashing = false;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing)
            return;

        // Check for right-click input
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            StartCoroutine(DDash());
        }
        ////(Input.GetButtonDown("Fire2")) //Right mouse button
        ///        {
        ///            currentDashTime = 0;
        //}
        ///        if (Time.time - lastDashTime > dashCooldown)
        /// {
        ///      Debug.Log("RUN");

        ///   lastDashTime = Time.time;
        ///         moveDirection = transform.forward * dashDistance;
        ///currentDashTime += dashStoppingSpeed;
        ///moveDirection += Vector3.forward * dashSpeed;

        ///   dashTime = 0;
    }
    IEnumerator DDash()
    {
        
        isDashing = true;

        Vector3 dashDirection = transform.forward; // You can modify this based on your game's design

        float elapsedTime = 0f;

        while (elapsedTime < dashTime)
        {
            
            
            transform.Translate(dashDirection * dashDistance * Time.deltaTime / dashTime, Space.World);
            elapsedTime += Time.deltaTime;
            yield return null;
            
        }
    //a
        isDashing = false;
    }

}