using UnityEngine;

public class WorkshopTriggerZone : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Debug.Log("Player in Garage TriggerZone");
           _animator.SetBool("IsPlayerInTriggerZone", true);
           
        }
    }
}
