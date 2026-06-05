using UnityEngine;
using Unity.Cinemachine;

public class Transition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pos;
    
        
    void Start()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    public void Teletransportar()
    {
        confiner.BoundingShape2D = mapBoundry;
        confiner.InvalidateBoundingShapeCache();
        UpdatePlayerPosititon();
    }

    private void UpdatePlayerPosititon()
    {
        player.transform.position = pos.transform.position;
    }
}
