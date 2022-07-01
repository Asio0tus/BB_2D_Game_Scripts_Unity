using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Bonus bonusPrefab;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform bonusBackground;


    private void Update()
    {
        Move();
    }

    public void PickupBonus()
    {
        Destroy(gameObject);
    }

    public void Spawn(Vector3 position)
    {
        Bonus bonus = Instantiate(bonusPrefab, position, Quaternion.identity);
    }

    public void Move()
    {
        transform.position += new Vector3(0, -fallSpeed * Time.deltaTime, 0);
        bonusBackground.Rotate(0, 0, rotationSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        Cart cart = collision.transform.root.GetComponent<Cart>();
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();
       
        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                fallSpeed = 0;
            }
        }
        if (cart != null)
        {
            PickupBonus();
        }
    }
}
