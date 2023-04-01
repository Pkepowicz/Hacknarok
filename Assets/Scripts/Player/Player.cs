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

    private List<GameObject> drg;  // list of all dragon GameObjects

    [SerializeField]
    private float speed = 400f;

    [SerializeField] private float minimalSpeedCoefficient = 0.4f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        drg = GameObject.FindGameObjectsWithTag("Dragon").ToList();
        
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

        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        float distanceToPoint = (mouseWorldPosition-transform.position).magnitude;
        float coefficient = (distanceToPoint / Screen.width) * 5;
        coefficient = Mathf.Clamp(coefficient, 0.4f, 1f);

        transform.position = Vector3.MoveTowards(transform.position, mouseWorldPosition, speed * Time.deltaTime * coefficient);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        pos.z = 1;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }

    public void ActivateDragon(int number)
    {
        drg[number].SetActive(true);
        StartCoroutine(dragons[number].Shoot());
        Debug.Log("dragon " + number + " activated!");
    }

    public void DeactivateAllDragons()
    {
        for(int i = 0; i < drg.Count; i++)
        {
            StopCoroutine(dragons[i].Shoot());
            drg[i].SetActive(false);
        }
    }
    
    public void ActivateAllDragons()
    {
        foreach (GameObject dragon in drg)
        {
            dragon.SetActive(true);
        }
    }
    
}
