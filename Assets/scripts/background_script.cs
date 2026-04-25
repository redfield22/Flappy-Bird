using UnityEngine;

public class background_script : MonoBehaviour
{
    public SpriteRenderer bg1;
    public SpriteRenderer bg2;
    public SpriteRenderer bg3;
    public float speed = .3f;

    public float resetPosition = 0;
    public float startPosition = 0.853f;

    void Update()
    {
        bg1.transform.Translate(Vector3.left * speed * Time.deltaTime);
        bg2.transform.Translate(Vector3.left * speed * Time.deltaTime);
        bg3.transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (bg1.transform.position.x <= -2.4 )
        {
            Vector3 pos = bg1.transform.position;
            pos.x = 3.40f;
            bg1.transform.position = pos;
            
        }
        if (bg2.transform.position.x <= -2.4)
        {
            Vector3 pos = bg2.transform.position;
            pos.x = 3.40f;
            bg2.transform.position = pos;

        }
        if (bg3.transform.position.x <= -1.6)
        {
            Vector3 pos = bg3.transform.position;
            pos.x = 3.40f;
            bg3.transform.position = pos;

        }
    }
}