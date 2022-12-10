using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public KeyCode fireButton;

    public Transform spawn;
    public GameObject arrowObj;
   

    public GameObject arrow;

    float _charge = 80;

    public float chargeMax;
    public float chargeRate;

    //public Vector3 localcentreofmass;
    

    
    [SerializeField] private GameObject ArrowContainer;
    
    void Start()
    {
        

    }
    
   void update()
   {
        if(1<2)
        {
            Debug.Log("Hell");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //popup();
            // arrow.GetComponent<Rigidbody>().useGravity = false;
            // arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);
            // arrow.GetComponent<Rigidbody>().useGravity = true;
            Debug.Log("Hell");
        }
   }
        // if (Input.GetKey(fireButton) && _charge < chargeMax)
        // {
        //     _charge += Time.fixedDeltaTime * chargeRate;
        //     arrow.GetComponent<Rigidbody>().useGravity = false;
        //     arrow.transform.position += new Vector3(0,0,0.0091955f);  

        //     Debug.Log(_charge.ToString());
        // }
        // if (Input.GetKeyUp(fireButton))
        // {  
        //    arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);
        //    //arrow.GetComponent<Rigidbody>().centerOfMass = localcentreofmass;
        //    arrow.GetComponent<Rigidbody>().useGravity = true;
        //    _charge = 0;
        // }
    void popup()
    {
       arrow = Instantiate(arrowObj, spawn.position, transform.rotation * Quaternion.Euler(270, 180, 0)) as GameObject;
       //arrow.transform.parent =  ArrowContainer.transform;
       arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);
    }
}
    
    
    
    
    
    
    //Stuff to do
    // Rotate the transform of bow by 180 degrees in x axis upon a button press
    // Enable moving the bow

    // Make the string of the bow work
    // Make the crosshair of bow , shooting where the crosshair is

    //  Make the arrows instantiate using Object Pooling
    // I can make the bow move after enabling that I can increase the difficulty by adding some objects which will hit 
    // the bow and u can only dodge them.
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // float _charge;

    // public float chargeMax;
    // public float chargeRate;

    // public KeyCode fireButton;

    // public Transform spawn;
    // public Rigidbody arrowObj;
    

    // Rigidbody arrow;

    // // void Start()
    // // {
    // //     arrow = Instantiate(arrowObj, spawn.position, transform.rotation * Quaternion.Euler(270, 180, 0)) as Rigidbody;
    // // }
    // void Update()
    // {
    //     if(Input.GetKey(fireButton) && _charge < chargeMax)
    //     {
    //         _charge += Time.deltaTime * chargeRate;
    //         //arrow = Instantiate(arrowObj, spawn.position, transform.rotation * Quaternion.Euler(270, 180, 0)) as Rigidbody;
    //         // arrow.position += Vector3.back * 2;
    //         Debug.Log(_charge.ToString());
    //     }

    //     if (Input.GetKeyUp(fireButton))
    //     {
    //         arrow = Instantiate(arrowObj, spawn.position, transform.rotation * Quaternion.Euler(270, 180, 0)) as Rigidbody;   
    //         arrow.AddForce(spawn.forward * _charge, ForceMode.Impulse);
    //         _charge = 0;
    //     }
       
    // }
