using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Camera playerCam;

    [SerializeField] private float collectDistance = 10f;

    [SerializeField] private Player player;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CollectCoin();
        }
    }

    void CollectCoin()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, collectDistance))
        {
            if (hit.collider.CompareTag("Coin"))
            {
                player.AddMoney(1);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
