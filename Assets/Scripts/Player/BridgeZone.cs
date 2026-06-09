using UnityEngine;

public class BridgeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Footsteps player = other.GetComponent<Footsteps>();

        if (player != null)
        {
            player.SetBridgeState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Footsteps player = other.GetComponent<Footsteps>();

        if (player != null)
        {
            player.SetBridgeState(false);
        }
    }
}