using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<AudioSource>().Stop();
    }
}
