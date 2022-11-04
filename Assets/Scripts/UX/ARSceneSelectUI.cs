using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class ARSceneSelectUI : MonoBehaviour
    {
        [SerializeField]
        GameObject m_AllMenu;
        public GameObject allMenu
        {
            get => m_AllMenu;
            set => m_AllMenu = value;
        }

        [SerializeField]
        GameObject m_ImageTrackingMenu;
        public GameObject imageTrackingMenu
        {
            get => m_ImageTrackingMenu;
            set => m_ImageTrackingMenu = value;
        }

        [SerializeField]
        GameObject m_DepthMenu;
        public GameObject depthMenu
        {
            get => m_DepthMenu;
            set => m_DepthMenu = value;
        }

        void Start()
        {
            if(ActiveMenu.currentMenu == MenuType.ImageTracking)
            {
                m_ImageTrackingMenu.SetActive(true);
                m_AllMenu.SetActive(false);
            }
            else if(ActiveMenu.currentMenu == MenuType.Depth)
            {
                m_DepthMenu.SetActive(true);
                m_AllMenu.SetActive(false);
            }
        }

        static void LoadScene(string sceneName)
        {
            LoaderUtility.Initialize();
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        public void ImageTrackableButtonPressed()
        {
            ActiveMenu.currentMenu = MenuType.ImageTracking;
            m_ImageTrackingMenu.SetActive(true);
            m_AllMenu.SetActive(false);
        }

        public void BasicImageTrackingButtonPressed()
        {
            LoadScene("BasicImageTracking");
        }

        public void MultiImagesTrackingButtonPressed()
        {
            LoadScene("ImageTrackingWithMultiplePrefabs");
        }

        public void AnchorsButtonPressed()
        {
            LoadScene("Anchors");
        }

        public void BackButtonPressed()
        {
            ActiveMenu.currentMenu = MenuType.Main;
            m_ImageTrackingMenu.SetActive(false);
            m_DepthMenu.SetActive(false);
            m_AllMenu.SetActive(true);        
        }

        public void DepthMenuButtonPressed()
        {
            ActiveMenu.currentMenu = MenuType.Depth;
            m_DepthMenu.SetActive(true);
            m_AllMenu.SetActive(false);    
        }
        public void DepthImagesButtonPressed()
        {
            LoadScene("DepthImages");
        }

       
    }
}
