using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunControler))]
[RequireComponent(typeof(PlayerController))]
public class Player : LivingEntity {

    public float playerSpeed;

    private Camera viewCamera;
    private PlayerController playerController;
    private GunControler gunController;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        playerController = GetComponent<PlayerController>();
        gunController = GetComponent<GunControler>();
        viewCamera = Camera.main;
	}
	
	
	void Update ()
    {
        //movement Input
        Vector3 moveInput = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
        Vector3 moveVelocity = moveInput.normalized * playerSpeed;
        playerController.Move(moveVelocity);

        //look Input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 intersection = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, intersection, Color.magenta);
            playerController.LookAt(intersection);
        }

        //weapon Input
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}
