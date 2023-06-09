using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Serialization;
using static System.Math;

public class Player : MonoBehaviour
{
    [SerializeField]
    private List<Dragon>dragons; // list of all dragon scripts
    [SerializeField]
    private List<GameObject> drg;  // list of all dragon GameObjects

    private Vector3 mouseWorldPosition = new Vector3(0, -3, 0);

    [SerializeField]
    private float speed = 400f;

    [SerializeField] private float minimalSpeedCoefficient = 0.4f;

    [SerializeField] private Dragon currentDragon;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -3, 0);
        foreach (GameObject dragon in drg)
        {
            dragons.Add(dragon.GetComponent<Dragon>());
        }
        DeactivateAllDragons();
        ActivateDragon(0);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        }
        float distanceToPoint = (mouseWorldPosition-transform.position).magnitude;
        float coefficient = (distanceToPoint / Screen.width) * 5;
        coefficient = Mathf.Clamp(coefficient, 0.4f, 1f);

        transform.position = Vector3.MoveTowards(transform.position, mouseWorldPosition, speed * Time.deltaTime * coefficient);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.3f, 0.9f);
        pos.z = 1;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }

    public void ActivateDragon(int number)
    {
        drg[number].SetActive(true);
        currentDragon = dragons[number];
        dragons[number].StartShootCoroutine();
        Debug.Log("dragon " + number + " activated!");
    }

    public void DeactivateAllDragons()
    {
        Debug.Log("deactivaed all dragons");
        for(int i = 0; i < dragons.Count; i++)
        {
            dragons[i].StopShootCoroutine();
            drg[i].SetActive(false);
            Debug.Log("Deactivated" + i + " dragon");
            
        }
    }

    public void AddXp(int xp)
    {
        currentDragon.AddXp(xp);
    }
    
}
