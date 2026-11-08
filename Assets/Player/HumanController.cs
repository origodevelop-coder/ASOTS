using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class HumanController : MonoBehaviour
{
    private CharacterController rb;
    private InputAction moveAction;
    private InputAction shiftAction;

    [SerializeField] private InputActionAsset asset;
    [SerializeField] private GameObject cam;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bodyEmpty;
    [SerializeField] private GameObject soul;

    void Awake()
    {
        moveAction = asset.FindAction("WASD");
        shiftAction = asset.FindAction("Shift");
        rb = GetComponent<CharacterController>();

        shiftAction.performed += ctx =>
        {
            Instantiate(bodyEmpty, transform.position,transform.rotation);
            Instantiate(soul, transform.position + new Vector3(0,1.2f,0), transform.rotation);
            Destroy(transform);
        };

        asset.Enable();
    }

    void Update()
    {
        if (transform.gameObject.activeSelf)
        {

            Vector2 input = moveAction.ReadValue<Vector2>();
            Vector3 direction = (input.y * cam.transform.forward + input.x * cam.transform.right);

            direction.Normalize();
            if (!rb.isGrounded)
            {
                direction.y -= Physics.gravity.y / -5;
            }
            else
            {
                direction.y = 0;
            }
            rb.Move(direction * speed * Time.deltaTime);
        }
    }
}
