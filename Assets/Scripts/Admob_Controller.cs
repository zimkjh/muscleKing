using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
public class Admob_Controller : MonoBehaviour
{

    RewardBasedVideoAd m_AD_RewardVideo;

#if UNITY_ANDROID
    // AdMob 에서 발급된 AppID
    string m_App_Id = "ca-app-pub-8642591281586798~7925257757";
    // AdMob 에서 각 광고단위로 발급된 UnitID 중 리워드광고 ID
    string m_Ad_UnitId_Reward = "ca-app-pub-8642591281586798/9277373039";
#endif
    void Start()
    {
        AD_Initialize();
    }
    void AD_Initialize()
    {
        // 앱ID 로 초기화
        MobileAds.Initialize(m_App_Id);

        // 리워드광고를 받을 수 있게 준비
        m_AD_RewardVideo = RewardBasedVideoAd.Instance;
        AD_Request();
    }
    public void AD_Request()
    {
        // 광고 요청 조건 자료구조 생성
        AdRequest t_Request = new AdRequest.Builder().Build();

        // 리워드광고에 대한 광고 정보 요청
        m_AD_RewardVideo.LoadAd(t_Request, m_Ad_UnitId_Reward);
    }

    public void Show_RewardVideo()
    {
        // 광고 준비(로드) 상태 확인
        if (m_AD_RewardVideo.IsLoaded())
        {
            // 준비된 광고 표시(노출)
            m_AD_RewardVideo.Show();
        }
    }
}
