using UnityEngine;

public class Interactable : MonoBehaviour
{
   
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
