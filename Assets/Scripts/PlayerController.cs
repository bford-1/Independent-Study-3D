using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        characterController.Move(move * Time.deltaTime * moveSpeed);
    }
}
