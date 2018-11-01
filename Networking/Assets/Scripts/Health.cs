using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
    public const int maxHealth = 100;
	[SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
	public RectTransform healthBar;
    public void TakeDamage(int amount)
    {
		if(!isServer) // Esto se ejecuta solo si esta en server para que no genere cambios anomalos entre los clientes
		{
			return; // Se utiliza para que todos los valores de la vida tengan el mismo valor por mas que haya lag
		}
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            RpcRespawn();
            Debug.Log("Esta Merto");
        }
        Debug.Log("Health: " + currentHealth);
		// healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            transform.position = Vector3.zero;
        }
    }
}
