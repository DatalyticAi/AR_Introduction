using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
#if UNITY_IOS
using UnityEngine.XR.ARKit;
#endif
using UnityEngine.XR.Management;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class CheckAvailableFeatures : MonoBehaviour
    {
        
        [SerializeField]
        Button m_ImageTracking;
        public Button imageTracking
        {
            get => m_ImageTracking;
            set => m_ImageTracking = value;
        }

        [SerializeField]
        Button m_Anchors;
        public Button anchors
        {
            get => m_Anchors;
            set => m_Anchors = value;
        }

        [SerializeField]
        Button m_Depth;
        public Button depth
        {
            get => m_Depth;
            set => m_Depth = value;
        }

        void Start()
        {
            
            var imageDescriptors = new List<XRImageTrackingSubsystemDescriptor>();
            SubsystemManager.GetSubsystemDescriptors(imageDescriptors);

            var anchorDescriptors = new List<XRAnchorSubsystemDescriptor>();
            SubsystemManager.GetSubsystemDescriptors(anchorDescriptors);

            var depthDescriptors = new List<XRDepthSubsystemDescriptor>();
            SubsystemManager.GetSubsystemDescriptors(depthDescriptors);

            var occlusionDescriptors = new List<XROcclusionSubsystemDescriptor>();
            SubsystemManager.GetSubsystemDescriptors(occlusionDescriptors);

            if(occlusionDescriptors.Count > 0)
            {
                foreach(var occlusionDescriptor in occlusionDescriptors)
                {
                    if (occlusionDescriptor.environmentDepthImageSupported != Supported.Unsupported ||
                        occlusionDescriptor.humanSegmentationDepthImageSupported != Supported.Unsupported ||
                        occlusionDescriptor.humanSegmentationStencilImageSupported != Supported.Unsupported)
                    {
                        m_Depth.interactable = true;
                    }
                }
            }

           if(imageDescriptors.Count > 0)
            {
                m_ImageTracking.interactable = true;
            }
 
            if(anchorDescriptors.Count > 0)
            {
                m_Anchors.interactable = true;
            }
            
        }

    }
}
