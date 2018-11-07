using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Enemy : NetworkBehaviour
{
    void Start ()
    {
		
	}
	
	void Update ()
    {
        /*if (this.gameObject.GetComponent<Health>().GetCurrentHealth() <= 0)
        {
            this.gameObject.SetActive(false);
        }*/
        if (!isLocalPlayer) // Pregunta si es el nuestro
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }*/
	}

    /*[Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletTransform.position,
            bulletTransform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }*/

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
    }
}
