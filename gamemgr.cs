using UnityEngine;
using System.Collections;

public class gamemgr : MonoBehaviour {

    public static gamemgr inst;
    private float PlatformCount;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    public GameObject yes;

    [SerializeField]
    public GameObject awesome;

    [SerializeField]
    public GameObject idiot;

    [SerializeField]
    private GameObject Hardplatform;

    [SerializeField]
    public AudioSource _jumpAudio;

    [SerializeField]
    public AudioSource _backAudio;

    [SerializeField]
    public AudioSource _deadAudio;

    private float minx = -2.5f, miny = -4.7f, maxx = 2.5f, maxy = -3.7f;

    private bool lerpcam;
    private float lerptime=1.5f;
    private float lerpx;

   
    void Awake () {
        Initilize();
        CreatePlatform();
        _backAudio.Play();
    }
    void Initilize()
    {
        if (inst == null)
        {
            inst = this;
        }
    }
	void CreatePlatform()
    {
        AdsManeger.Instant.ShowBanner();
        AdsManeger.Instant.ShowIntrestial();
        Vector3 temp = new Vector3(Random.Range(minx, minx + 1.5f), Random.Range(miny, maxy),0);
        Instantiate(platform,temp,Quaternion.identity);
        temp.y += 2f;
        Instantiate(player, temp, Quaternion.identity);

        temp = new Vector3(Random.Range(maxx, maxx - 1.5f), Random.Range(miny, maxy), 0);
        Instantiate(platform, temp, Quaternion.identity);
    }
    void createNewPlatform()
    {
        PlatformCount = Random.Range(1, 5);
        if (PlatformCount <= 2)
        {
            float camX = Camera.main.transform.position.x;
            float newcamX = (maxx * 2.5f) + camX;
            Instantiate(platform, new Vector3(Random.Range(newcamX, newcamX - 1f), Random.Range(miny, maxy - 1.4f)), Quaternion.identity);
        
        }
        else
        {
            float camX = Camera.main.transform.position.x;
            float newcamX = (maxx * 2.4f) + camX;
            Instantiate(Hardplatform, new Vector3(Random.Range(newcamX, newcamX - 1f), Random.Range(miny, maxy - 1.4f)), Quaternion.identity);
        }
        


    }
    void LerpCam()
    {
        float X = Camera.main.transform.position.x;
        X = Mathf.Lerp(X, lerpx, lerptime * Time.deltaTime);
        Camera.main.transform.position = new Vector3(X, Camera.main.transform.position.y, Camera.main.transform.position.z);
        if (Camera.main.transform.position.x >= (lerpx - 0.07f))
        {
            lerpcam = false;
           
           
        }
    }
    public void CreatePlatformandLerp(float lerpPos)
    {
        createNewPlatform();
        lerpx = lerpPos + maxx;
        lerpcam = true;
       
    }
    public void Yes(bool active)
    {
        yes.SetActive(active);
        Destroy(yes, 2f);
    }

    public void Awesome(bool active)
    {
        awesome.SetActive(active);
        Destroy(awesome, 2f);
    }

    public void Idiot(bool active)
    {
        idiot.SetActive(active);
        Destroy(idiot, 2f);
    }
    void Update () {
        
        if (lerpcam)
            LerpCam();
	}
 
}