using UnityEngine;

public class PickupChecker : MonoBehaviour
{


    [SerializeField] private GameObject _winPanel;

    private int objectcount = 0;

    private void OnTriggerEnter(Collider collision)
    {

       

        if (collision.gameObject.tag == "Pickable") { 
            objectcount ++;
            Debug.Log(objectcount);
            if (objectcount == 4) {
                _winPanel.SetActive(true);
            }
        }
    }

    
}
