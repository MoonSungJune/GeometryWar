using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Data/GeoLevel")]
public class GeoData : ScriptableObject
{
    // [SerializeField]
    public string aName = "Geometry";
    public Color thisColor = Color.yellow;
    public int[] SpeedUPCost;
    public float[] SpeedUPEffect;
    public int[] VisionUPCost;
    public float[] VisionUPEffect;



    //public int GetSpeedUpCost(int idx)
    //{
    //    return SpeedUPCost[idx];
    //}

    //public float GetSpeedUpEffect(int idx)
    //{
    //    return SpeedUPEffect[idx];
    //}

    //public float GetVisionUpCost(int idx)
    //{
    //    return SpeedUPEffect[idx];
    //}

    //public float GetSpeedUpEffect(int idx)
    //{
    //    return SpeedUPEffect[idx];
    //}

}
