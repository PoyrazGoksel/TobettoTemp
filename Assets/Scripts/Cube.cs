using UnityEngine;

public class Cube : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}