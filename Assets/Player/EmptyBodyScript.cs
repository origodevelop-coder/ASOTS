using UnityEngine;

public class EmptyBodyScript : MonoBehaviour
{
    [SerializeField]private GameObject bodyNext;

    public void Spawn(GameObject b)
    {
        bodyNext = b;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(bodyNext, transform.position, Quaternion.identity);
            Destroy(other.transform);
            Destroy(transform);
        }
    }
}
