﻿using UnityEngine;

public class SPTC_WG : MonoBehaviour {
    public WorldGeneratorSettings settings;
    void Start() {
        var terrain = WorldGenerator.Generate(settings);
        //Debug.Log(terrain.GetComponent<MiscTerrainData>().SpawnPoints[0].Item1);
    }
}
