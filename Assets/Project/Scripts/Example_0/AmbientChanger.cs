﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientChanger : MonoBehaviour
{
    private AmbientComponent m_AmbientComponent;
    [SerializeField]
    private GenericEvent m_hitSurfaceSound;
    private MovementComponent m_movementComponent;
    [SerializeField]
    private SurfaceType m_ambientType;

    void Awake()
    {
        m_AmbientComponent = FindObjectOfType<AmbientComponent>();
        m_movementComponent = FindObjectOfType<MovementComponent>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (m_ambientType == SurfaceType.Wather)
            FmodManager.instance.PlaySoundOneShot(m_hitSurfaceSound.eventPath, collider.transform.position);

        if (collider.CompareTag("Player"))
        {
            m_movementComponent.CheckSurface(m_ambientType);
            m_AmbientComponent.ChangeAmbientParameter((int)m_ambientType, 1);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("adawdadadw");
            m_movementComponent.CheckSurface(m_ambientType);
            m_AmbientComponent.ChangeAmbientParameter((int)m_ambientType, 0);
        }
    }
}