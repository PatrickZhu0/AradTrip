using System;
using UnityEngine;

// Token: 0x02000142 RID: 322
[ExecuteInEditMode]
public class GameObjectSettingSerialize : MonoBehaviour
{
	// Token: 0x06000969 RID: 2409 RVA: 0x00031798 File Offset: 0x0002FB98
	private void Awake()
	{
		if (this.lightmapIndex != -1)
		{
			Renderer component = base.gameObject.GetComponent<Renderer>();
			component.lightmapIndex = this.lightmapIndex;
			component.lightmapScaleOffset = this.lightmapScaleOffset;
		}
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x000317D8 File Offset: 0x0002FBD8
	public void SnapSetting()
	{
		Renderer component = base.gameObject.GetComponent<Renderer>();
		if (component.lightmapIndex == -1)
		{
			Object.DestroyImmediate(this);
		}
		else
		{
			this.lightmapIndex = component.lightmapIndex;
			this.lightmapScaleOffset = component.lightmapScaleOffset;
		}
	}

	// Token: 0x04000710 RID: 1808
	public int lightmapIndex = -1;

	// Token: 0x04000711 RID: 1809
	public Vector4 lightmapScaleOffset;
}
