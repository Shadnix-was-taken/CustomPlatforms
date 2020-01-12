﻿using BS_Utils.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CustomPlatforms {
    public class SpectrogramMaterialManager:MonoBehaviour {
        List<SpectrogramMaterial> spectrogramMaterials;

        private void OnEnable() {
            BSEvents.gameSceneLoaded += UpdateSpectrogramDataProvider;
            UpdateSpectrogramDataProvider();
        }

        private void OnDisable() {
            BSEvents.gameSceneLoaded -= UpdateSpectrogramDataProvider;
        }

        public void UpdateMaterials() {
            if(spectrogramMaterials == null) spectrogramMaterials = new List<SpectrogramMaterial>();

            foreach(SpectrogramMaterial spec in Resources.FindObjectsOfTypeAll(typeof(SpectrogramMaterial))) {
                spectrogramMaterials.Add(spec);
            }
        }

        public void UpdateSpectrogramDataProvider() {
            BasicSpectrogramData[] datas = Resources.FindObjectsOfTypeAll<BasicSpectrogramData>();
            if(datas.Length == 0) return;
            BasicSpectrogramData spectrogramData = datas.FirstOrDefault();
            if(spectrogramData == null) return;
            foreach(SpectrogramMaterial specMat in spectrogramMaterials) {
                specMat.setData(spectrogramData);
            }
        }
    }
}
