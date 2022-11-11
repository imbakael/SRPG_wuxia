using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigCenter {
    public static List<SkillModel> SkillModelList { get; private set; }
    public static List<BuffModel> BuffModelList { get; private set; }

    public static void Initialized() {
        LoadConfig();
    }

    public static void LoadConfig() {
        TextAsset skillText = Resources.Load<TextAsset>("JsonConfigs/skill");
        SkillModelList = JsonConvert.DeserializeObject<List<SkillModel>>(skillText.text);
        TextAsset buffText = Resources.Load<TextAsset>("JsonConfigs/buff");
        BuffModelList = JsonConvert.DeserializeObject<List<BuffModel>>(buffText.text);
        for (int i = 0; i < BuffModelList.Count; i++) {
            BuffModelList[i].Init();
        }
    }

    public static SkillModel GetSkillModel(int skillId) {
        foreach (SkillModel item in SkillModelList) {
            if (item.id == skillId) {
                return item;
            }
        }
        return null;
    }
}
