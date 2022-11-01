using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigCenter {
    public static List<SkillModel> SkillModelList { get; private set; }

    public static void Initialized() {
        LoadHeroConfig();
    }

    public static void LoadHeroConfig() {
        TextAsset text = Resources.Load<TextAsset>("JsonConfigs/skill");
        SkillModelList = JsonConvert.DeserializeObject<List<SkillModel>>(text.text);
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
