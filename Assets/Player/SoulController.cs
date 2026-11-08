using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class SoulController : MonoBehaviour
{
    private Rigidbody rb;
    private InputAction shiftAction;
    private InputAction moveAction;

    [SerializeField] private InputActionAsset asset;
    [SerializeField] private GameObject cam;
    [SerializeField] private float speed;

    void Awake()
    {
        moveAction = asset.FindAction("WASD");
        shiftAction = asset.FindAction("Shift");
        rb = GetComponent<Rigidbody>();

        asset.Enable();
    }

    void Update()
    {
        if (transform.gameObject.activeSelf)
        {

                Vector2 input = moveAction.ReadValue<Vector2>();
                Vector3 direction = (input.y * cam.transform.forward + input.x * cam.transform.right) * speed * Time.deltaTime;

                rb.linearVelocity = direction;
        }
    }
}
