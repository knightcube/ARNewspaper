using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SceneController : MonoBehaviour
{
    public VideoPlayer manikarnikaVideoPlayer;
    public VideoPlayer accidentalVideoPlayer;
    public VideoPlayer thackerayVideoPlayer;
    public VideoPlayer gajendraVideoPlayer;
    public VideoPlayer sorabhVideoPlayer;
    public GameObject manikarnikaBtn;
    public GameObject accidentalBtn;
    public GameObject thackerayBtn;
    public GameObject gajendraBtn;
    public GameObject sorabhBtn;


    // Start is called before the first frame update
    void Start()
    {
        manikarnikaVideoPlayer.playOnAwake = false;
        accidentalVideoPlayer.playOnAwake = false;
        thackerayVideoPlayer.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
        gajendraBtn.transform.Rotate(Vector3.right * Time.deltaTime * 10);
        sorabhBtn.transform.Rotate(Vector3.right * Time.deltaTime * 10);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.transform.name == "manikarnika_btn")
                {
                    Debug.Log("Manikarnika button");
                    accidentalVideoPlayer.Stop();
                    thackerayVideoPlayer.Stop();
                    playVideo(manikarnikaVideoPlayer);
                    changeUI(manikarnikaBtn);
                  
                }
                else if(hit.transform.name == "acc_pm_btn")
                {
                    Debug.Log("Accidental Prime Minister button");
                    manikarnikaVideoPlayer.Stop();
                    thackerayVideoPlayer.Stop();
                    playVideo(accidentalVideoPlayer);
                    changeUI(accidentalBtn);
                   
                }
                else if (hit.transform.name == "thackeray_btn")
                {
                    Debug.Log("Thackeray button");
                    manikarnikaVideoPlayer.Stop();
                    accidentalVideoPlayer.Stop();
                    playVideo(thackerayVideoPlayer);
                    changeUI(thackerayBtn);

                }
                else if(hit.transform.name == "GajendraSphere")
                { 
                    
                    playVideo(gajendraVideoPlayer);
                }
                else if (hit.transform.name == "SorabhSphere")
                {
                    
                    playVideo(sorabhVideoPlayer);
                }
            }

        }
        
    }

    private void changeUI(GameObject button)
    {
        if(button.GetComponent<Renderer>().material.color == Color.red)
        {
            button.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            button.GetComponent<Renderer>().material.color = Color.red;
        }
        
     
    }

    private void playVideo(VideoPlayer videoPlayer)
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
            //accidentalBtn.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
