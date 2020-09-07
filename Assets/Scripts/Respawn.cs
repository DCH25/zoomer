using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{   
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other) 
    {
        Physics.SyncTransforms();
        player.transform.position = spawnPoint.transform.position;
    }
}
