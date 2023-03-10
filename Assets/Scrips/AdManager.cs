using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4951867"); // Android only
        ShowBanner();
    }
    public void PlayAd()
    {
        if(Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
    }

    public void ShowBanner()
    {
        if(Advertisement.IsReady("banner"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("banner");
        }else 
        {
            StartCoroutine (RepeatShowBanner());
        }
    }
    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }
}
