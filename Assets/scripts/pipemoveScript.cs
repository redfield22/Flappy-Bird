using UnityEngine;

public class pipemoveScript : MonoBehaviour
{
    public float MoveSpeed = 5;
    private int deadZone = -2;
    void Start()
    {
        print(deadZone);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left*MoveSpeed) *Time.deltaTime;
        
        if (transform.position.x < deadZone)
        {
            Debug.Log("pipe deleted");
            Destroy(gameObject);
        }
    }
}
