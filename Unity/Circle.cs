using UnityEngine;

// Self rotating circle in Unity
// You can attach to the gameobject in the scene
// The center position, speed and radius
// can be adjusted in the inspector

public class Circle : MonoBehaviour
{
    public Vector3 center;
    public float speed = 5f;
    public float radius = 3f;

    private float _timeElapsed;

    void Update()
    {
        _timeElapsed += Time.deltaTime * speed;
        var direction = new Vector3(Mathf.Cos(_timeElapsed), Mathf.Sin(_timeElapsed)) * radius;
        var dir = Vector3.ClampMagnitude(direction, radius);
        var newPos = center + dir;
        this.transform.position = newPos;
    }
}
