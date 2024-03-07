using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawn;
    public float Speed = 20;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Bullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawn.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawn.forward * Speed;
        Destroy(spawnedBullet,5);
    }
}
