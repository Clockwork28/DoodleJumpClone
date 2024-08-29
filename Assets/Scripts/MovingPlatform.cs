using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    LevelGenerator levelGenerator;
    [SerializeField] float minSpeed = 0.5f;
    [SerializeField] float maxSpeed = 3f;
    float speed;
    int direction;
    private void Start()
    {
        levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
        direction = Random.Range(0, 2) * 2 - 1;
        speed = Random.Range(minSpeed, maxSpeed);
    }
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            float newX = transform.position.x + speed * direction * Time.deltaTime;
            newX = Mathf.Clamp(newX, -levelGenerator.levelWidth, levelGenerator.levelWidth);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            if (direction > 0 && transform.position.x >= levelGenerator.levelWidth ||
                direction < 0 && transform.position.x <= -levelGenerator.levelWidth)
            {
                direction *= -1;
            }
        }
    }
}
