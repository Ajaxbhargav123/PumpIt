using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerJump : MonoBehaviour {
   
   
    public static PlayerJump instan;

    private Slider Powerrange;
   

    private float PowerThreshold = 10f;
    private float PowerValue = 0f;

    private Rigidbody2D rig;
    private Animator ani;

    private float thresholdx=7f, thresholdy=14f;
    [SerializeField]
    public float forcex=2f, forcey;
    private float DistanceBetweenPlatform;

    private  bool setpow, didjump;

    
    
	void Awake () {
        forcex = 2f;
        Instances();
        Insilization();
       
    }
    void Start()
    {
        forcex = 2f;
    }
	
	void Instances()
    {
        if (instan == null)
        {
            instan = this;
        }
    }
    void Insilization()
    {
       
        Powerrange = GameObject.Find("PowerBar").GetComponent<Slider>();
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        Powerrange.minValue = 0f;
        Powerrange.maxValue = 10f;
        Powerrange.value = PowerValue;
    }
    void setPower()
    {
        if (setpow)
        {
            forcex += thresholdx * Time.deltaTime;
            forcey += thresholdy * Time.deltaTime;
            if (forcex > 6.5f)
            {
                forcex = 6.5f;
            }
            if (forcey > 12.5f)
            {
                forcey = 12.5f;
            }
            PowerValue += PowerThreshold * Time.deltaTime;
            Powerrange.value = PowerValue;
        }
      
    }
   public void Setpower(bool setpow)
    {
        this.setpow = setpow;
        if (!setpow)
        {
            Jump();
        }
      
    }
    void Jump()
    {

        if (forcex < 4 && forcex != 0)
        {
           
            forcex = forcey = 0f;
            PowerValue = 0f;
            Powerrange.value = PowerValue;
        }
        else
        {
           
            rig.velocity = new Vector2(forcex, forcey);
            forcex = forcey = 0f;
            didjump = true;
            ani.SetBool("Jump", didjump);
            PowerValue = 0f;
            Powerrange.value = PowerValue;
           
        }
       

    }
	void Update () {
        setPower();
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (didjump)
        {
            didjump = false;
            ani.SetBool("Jump", didjump);
            if (collision.tag == "platform")
            {

                if (Score.ScoreInst != null)

                    Score.ScoreInst.IncrementScoer();
            }
            if (gamemgr.inst != null)
            {
                gamemgr.inst.CreatePlatformandLerp(collision.transform.position.x);
            }
           
        
        }
        if (collision.tag == "Dead")
        {
            
                gamemgr.inst.Idiot(true);
            gamemgr.inst._backAudio.Stop();
            gamemgr.inst._deadAudio.Play();
           
            if (GameOverMgr.insttan != null)
            {
                GameOverMgr.insttan.ShowPanel();
            }
            Destroy(gameObject);
        }
            
          
        }
    }

