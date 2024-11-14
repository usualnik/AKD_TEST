using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
   [SerializeField] private GameObject player;
   [SerializeField] private Transform pickUpTransform;
   [SerializeField] private float pickUpRange = 5f; 
   
   
    private GameObject _heldObj; 
    private Rigidbody _heldObjRb;
    private Camera _camera;
    
   
    private int _layerNumber; 

   
    void Start()
    {
        _layerNumber = LayerMask.NameToLayer("HoldObjects");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (_heldObj == null) 
            {
                Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
                Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
                
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, pickUpRange))
                {
                   
                    if (hit.transform.CompareTag("Pickable"))
                    {
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
        }
        
        if (_heldObj != null) 
        {
            MoveObject();
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               DropObject();
            }
        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            _heldObj = pickUpObj;
            _heldObjRb = pickUpObj.GetComponent<Rigidbody>(); 
            _heldObjRb.isKinematic = true;
            _heldObjRb.transform.parent = pickUpTransform.transform; 
            _heldObj.layer = _layerNumber; 
           
            Physics.IgnoreCollision(_heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
    void DropObject()
    {
        Physics.IgnoreCollision(_heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        _heldObj.layer = 0; 
        _heldObjRb.isKinematic = false;
        _heldObj.transform.parent = null; 
        _heldObj = null; 
    }
    void MoveObject()
    {
       _heldObj.transform.position = pickUpTransform.transform.position;
    }
}
