using System;
using FBSceneData;

// Token: 0x02004B55 RID: 19285
public class SceneTransferInfo : SceneEntityInfo
{
	// Token: 0x0601C573 RID: 116083 RVA: 0x0089C5B8 File Offset: 0x0089A9B8
	public SceneTransferInfo(FBSceneData.DTransferInfo data) : base(data.Super)
	{
		this.mData = data;
	}

	// Token: 0x040137F1 RID: 79857
	private FBSceneData.DTransferInfo mData;
}
