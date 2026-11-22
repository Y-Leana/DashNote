using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform Player;

    void Update()
    {
        if (Player.transform.position.x >= 0)
        {
            transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        }
    }
}
