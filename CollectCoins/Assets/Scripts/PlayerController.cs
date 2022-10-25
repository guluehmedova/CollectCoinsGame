using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    CharacterController charchterController;
    float directionX, directionZ;

    Vector3 movement, moveDirection = Vector3.zero;

    [SerializeField]
    float speed, gravity, jumpHeight;

    [SerializeField]
    GameObject obj;

    public static int numberOfCoins;
    
    void Start()
    {
        speed = 10;
        charchterController = GetComponent<CharacterController>();
        numberOfCoins = 0;
    }

    void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        directionZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(directionX, 0, directionZ);
        //coinsText.text = "Coins: " + numberOfCoins;
        Debug.Log("Coins: " + numberOfCoins);
    }

    private void FixedUpdate()
    {
        var mousePosition = Input.mousePosition;
        var capsuleWorldPosition = Camera.main.WorldToScreenPoint(transform.position);
        var direction = mousePosition - capsuleWorldPosition;

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(-angle, Vector3.up), 10 * Time.fixedDeltaTime);

        movement = moveDirection * speed * Time.fixedDeltaTime;
       
        if (charchterController.isGrounded) { movement.y = 0; }
        else { movement.y -= gravity; }

        charchterController.Move(movement);
    }
}
