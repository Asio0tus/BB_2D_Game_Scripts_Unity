using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
            
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float rotationSpeed;

    
    
    private void Update()
    {
        Move();
    }

    public void PickupCoin()
    {               
        Destroy(gameObject);
    }

    public void Spawn(Vector3 position)
    {
        Coin coin = Instantiate(coinPrefab, position, Quaternion.identity);        
    }

    public void Move()
    {        
        transform.position += new Vector3(0, -fallSpeed * Time.deltaTime, 0);
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();
        Cart cart = collision.transform.root.GetComponent<Cart>();

        if (levelEdge != null)
        {
            if(levelEdge.Type == EdgeType.Bottom)
            {
                fallSpeed = 0;
            }
        }

        if(cart != null)
        {
            PickupCoin();
        }
    }
}
