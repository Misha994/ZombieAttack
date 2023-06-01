using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] private PlayerController playerController;

    public delegate void Died();
    public Died OnDied;

    int IDamageable.Health
    {
        get { return health; }
    }

    public void ReduceHealth(int point)
    {
        health -= point;

        if (health <= 0)
        {
            playerController.StopMove();
            OnDied?.Invoke();
        }
    }


}
