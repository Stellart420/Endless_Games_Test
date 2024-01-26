using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private float speed;
    private float distanceTraveled;
    private float totalDistance;

    public void Initialize(float _speed, float _distance)
    {
        speed = _speed;
        totalDistance = _distance;
        distanceTraveled = 0f;
    }

    void Update()
    {
        MoveCube(Time.deltaTime);
    }

    void MoveCube(float deltaTime)
    {
        transform.position += Vector3.forward * speed * deltaTime;
        distanceTraveled += speed * deltaTime;

        if (distanceTraveled >= totalDistance)
        {
            ObjectPool.Instance.ReturnCube(gameObject);
        }
    }
}
