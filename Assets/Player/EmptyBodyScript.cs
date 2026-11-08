using UnityEngine;

public class EmptyBodyScript : MonoBehaviour
{
    [SerializeField]private GameObject bodyNext;

    private void Start()
    {
        Invoke("IncludeCollider", 5f);
    }

    private void IncludeCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    public void Spawn(GameObject b)
    {
        bodyNext = b;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(bodyNext, transform.position, Quaternion.identity);
            Destroy(other.transform.gameObject);
            Destroy(transform.gameObject);
        }
    }
}
