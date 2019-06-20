using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents2 : MonoBehaviour
{
    #region Events
    public static UnityAction OnTouchpadUp = null;
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;
    #endregion

    #region Anchors
    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_InputSource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActive = true;
    #endregion

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets();
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }

    private void Update()
    {
        if (!m_InputActive)
            return;

        CheckForController();

        CheckInputSource();

        Input();
    }

    

    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTouch))
            controllerCheck = OVRInput.Controller.RTouch;

        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTouch))
            controllerCheck = OVRInput.Controller.LTouch;



        m_Controller = UpdateSource(controllerCheck, m_Controller);

    }

    private void CheckInputSource()
    {
        m_InputSource = UpdateSource(OVRInput.GetActiveController(), m_InputSource);
    }

    private void Input()
    {
        
    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
    {
        if (check == previous)
            return previous;

        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        if (OnControllerSource != null)
            OnControllerSource(check, controllerObject);


        return check;
    }

    private void PlayerFound()
    {
        m_InputActive = true;
    }

    private void PlayerLost()
    {
        m_InputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            { OVRInput.Controller.LTouch, m_LeftAnchor },
            { OVRInput.Controller.RTouch, m_RightAnchor }
        };

        return newSets;
    }


}
