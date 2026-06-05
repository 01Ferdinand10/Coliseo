using UnityEngine;
using Unity.Cinemachine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    CinemachineConfiner2D confiner;

    [SerializeField] Direction direction;
    [SerializeField] Transform teleportTargetPos;

    enum Direction {  up, down, left, right, Teleport }

    private void Awake()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);

            
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        if(direction == Direction.Teleport)
        {
            player.transform.position = teleportTargetPos.position;
            return;
        }

        Vector3 newPos = player.transform.position;
        switch (direction)
        {
            case Direction.up:
                newPos.y += 2;
                break;

            case Direction.down:
                newPos.y -= 2;
                break;
            
            case Direction.left:
                newPos.x += 2;
                break;

            case Direction.right:
                newPos.x -= 2;
                break;
        }

        player.transform.position = newPos;
    }
}
