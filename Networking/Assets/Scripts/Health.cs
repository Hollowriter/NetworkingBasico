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
    private NetworkStartPosition[] spawnPoints;
    private void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }
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
            Vector3 spawnPoint = Vector3.zero;
            
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
