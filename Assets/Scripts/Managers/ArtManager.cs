using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        BEACH,
        SNOW
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByType(ArtType artType)
    {
        foreach (ArtSetup setup in artSetups)
        {
            if (setup.artType == artType)
            {
                return setup;
            }
        }
        return null;
    }
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}
