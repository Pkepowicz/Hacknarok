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
        transform.Translate(Vector2.right * vertical * verticalSpeed * Time.deltaTime);

    }
}
