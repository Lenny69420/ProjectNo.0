
using UnityEngine;
using UnityEngine.Advertisements;

public class AdForScene : MonoBehaviour
{
    static int loadCount = 1;
    void Start()
    {
        if (loadCount % 6 == 0) // Display every 6th time (Transition between scenes is every 3th time for no reason)
        {
            PlayAd();
        }
        loadCount++;
    }
    public void PlayAd()
    {
        if(Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
    }

}
