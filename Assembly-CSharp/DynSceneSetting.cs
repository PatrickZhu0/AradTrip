using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004B79 RID: 19321
public class DynSceneSetting : ScriptableObject
{
	// Token: 0x0601C6B4 RID: 116404 RVA: 0x0089E860 File Offset: 0x0089CC60
	public void Apply()
	{
		List<LightmapData> list = new List<LightmapData>();
		if (this.lightmaps != null)
		{
			for (int i = 0; i < this.lightmaps.Length; i++)
			{
				list.Add(new LightmapData
				{
					lightmapDir = this.lightmaps[i].lightmapNear,
					lightmapColor = this.lightmaps[i].lightmapFar
				});
			}
		}
		LightmapSettings.lightmaps = list.ToArray();
		LightmapSettings.lightmapsMode = this.lightmapsMode;
		LightmapSettings.lightProbes = this.lightProbes;
	}

	// Token: 0x040138CB RID: 80075
	public DynLightmapData[] lightmaps = new DynLightmapData[0];

	// Token: 0x040138CC RID: 80076
	public LightmapsMode lightmapsMode;

	// Token: 0x040138CD RID: 80077
	public LightProbes lightProbes;

	// Token: 0x040138CE RID: 80078
	public DRenderSettings renderSetting = new DRenderSettings();
}
