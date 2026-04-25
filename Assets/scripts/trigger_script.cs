using UnityEngine;

public class trigger_script : MonoBehaviour
{
    public LogicScript logic;
    

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicScript>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addscore(0);
            
            
        }
    }
}
