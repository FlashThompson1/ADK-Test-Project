using UnityEngine;

public class PickingObjects : MonoBehaviour
{
    [SerializeField]private float pickupRange = 3f;        
    [SerializeField] private Transform holdPosition;         
    [SerializeField] private LayerMask pickableLayer;       

    private GameObject pickedObject;       
    private Rigidbody objectRb;            

   private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (pickedObject == null)
            {
                TryPickupObject();         
            }
        }

       
        if (Input.GetMouseButtonUp(0) && pickedObject != null)
        {
            ReleaseObject();               
        }

       
        if (pickedObject != null)
        {
            HoldObject();
        }
    }

    private void TryPickupObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit, pickupRange, pickableLayer))
        {
            pickedObject = hit.collider.gameObject;
            objectRb = pickedObject.GetComponent<Rigidbody>();

            if (objectRb != null)
            {
                objectRb.isKinematic = true;  
            }
        }
    }

    private void HoldObject()
    {
        pickedObject.transform.position = holdPosition.position;  
    }

    private void ReleaseObject()
    {
        if (objectRb != null)
        {
            objectRb.isKinematic = false;  
        }

        pickedObject = null;
        objectRb = null;
    }
}
