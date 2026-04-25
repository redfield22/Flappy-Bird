using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System.Collections;

public class birdie_final : MonoBehaviour
{
    public Rigidbody2D body;
    public float flapStrength;
    public LogicScript logic;
    public bool birdisalive = true;
    public int Highscore;
    public AudioSource jump_sound;
    public AudioSource dying_sound;
    public SpriteRenderer sprite;
    public Sprite dying_sprite;
    public Sprite power_sprite;
    public GameObject teleportProjectile;
    public Transform shootPoint;

    //teleport stuff
    float teleportCooldown = 3f;
    float lastTeleportTime = -10f;
    public ParticleSystem teleportBurst;
    public Color powerColor = Color.cyan;
    private Color originalColor;
    public float powerDuration = 2f;
    bool powerActive = false;

    void Start()
    {
        // start setups:
        logic = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicScript>();
        birdisalive = true;
        Highscore =  PlayerPrefs.GetInt("HighScore", 0);
        logic.scoreAddition = true;
        originalColor = sprite.color;
    }

    void Update()
    {
        // jumping:
        if (Input.GetKey(KeyCode.Space) && birdisalive) 
        {
            body.linearVelocity = Vector2.up *flapStrength;
            jump_sound.Play();
        }
        //teleport:
        if (Input.GetKeyDown(KeyCode.L) && birdisalive && Time.time > lastTeleportTime + teleportCooldown)
        {
            teleportBurst.Play();   // particle burst

            Teleport();

            lastTeleportTime = Time.time;

            sprite.color = powerColor;
            powerActive = true;

            StartCoroutine(PowerTimer());
        }
        //shoot:
        if(Input.GetKeyDown(KeyCode.E)&& birdisalive)
        {
            shoot();
        }
        // highscore saving:
        if (logic.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            print("yes greater!");
            PlayerPrefs.SetInt("HighScore", logic.score);
            Highscore = PlayerPrefs.GetInt("HighScore", 0);
        }
    }

    // timer
    IEnumerator PowerTimer()
    {
        yield return new WaitForSeconds(powerDuration);

        sprite.color = originalColor;
        powerActive = false;
    }
    // offscreen dying:
    private void OnBecameInvisible()
    {
        die();
    }
    // collision dying:
    private void OnCollisionEnter2D(Collision2D collision)
    {
        die();
        
    }
    //dying method:
    void die()
    {if (!birdisalive) {
            return;
        }
        GetComponent<Animator>().enabled = false;
        sprite.sprite= dying_sprite;
        logic.scoreAddition = false;
        logic.HighScoreText.text = "HighScore = " + PlayerPrefs.GetInt("HighScore", 0);
        logic.gameOver();
        birdisalive = false;
        dying_sound.Play();
    }
    void shoot()
    {
        GameObject proj = Instantiate(teleportProjectile, shootPoint.position, Quaternion.identity);

        proj.GetComponent<TeleportProjectile>().player = this.transform;
    }
    void Teleport()
    {
            GameObject[] pipes = GameObject.FindGameObjectsWithTag("pipe");

            GameObject closestPipe = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject pipe in pipes)
            {
                float distance = pipe.transform.position.x - transform.position.x;

            if (distance > 0 && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPipe = pipe;
                }
            }

            if (closestPipe != null)
            {
            float teleportOffset = 0.4f;

            transform.position = new Vector3(
                transform.position.x + closestDistance + teleportOffset,
                transform.position.y,
                transform.position.z
            );
            
            logic.move_the_world(teleportOffset+closestDistance);

            }
        }
    }


