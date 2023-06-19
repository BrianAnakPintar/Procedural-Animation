using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    public float speed;
    private Vector3 movementVect;
    
    
    Vector3 rot = Vector3.zero;
    public float rotSpeed = 120f;
    
    
    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxisRaw("Horizontal");
        float vMovement = Input.GetAxisRaw("Vertical");
        movementVect = vMovement * speed * transform.TransformDirection(Vector3.forward);
        
        gameObject.transform.eulerAngles = rot;

        rot.y += rotSpeed * hMovement * Time.deltaTime;

        controller.Move(speed * Time.deltaTime * movementVect);
    }

    public Vector3 getMovementVector()
    {
        return movementVect;
    }
}
