using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private List<Dragon>dragons;

    [SerializeField]
    private float horizontalSpeed;
    
    [SerializeField]
    private float verticalSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] drg = GameObject.FindGameObjectsWithTag("Dragon");
        
        foreach (GameObject dragon in drg)
        {
            dragons.Add(dragon.GetComponent<Dragon>());
        }
        
        /*foreach (Dragon dragon in dragons)
        {
            Debug.Log(dragon.dragonType);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * horizontalSpeed * Time.deltaTime);
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * vertical * verticalSpeed * Time.deltaTime);
        
        // restrict player movement to game screen with 100 pixel border
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
        

    }
            
        
        
        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
        

    
}
