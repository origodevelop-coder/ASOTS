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

        shiftAction.performed += Shift;

        asset.Enable();
    }

    private void OnDestroy()
    {
        shiftAction.performed -= Shift;
    }

    private void Shift(InputAction.CallbackContext context)
    {
        Instantiate(bodyEmpty, transform.position, transform.rotation);
        Instantiate(soul, transform.position, transform.rotation);
        Destroy(transform.gameObject);
    }

    void Update()
    {
        if (transform.gameObject != null)
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
