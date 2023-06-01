using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public abstract void SetPlayerPosition(Transform position);
}
