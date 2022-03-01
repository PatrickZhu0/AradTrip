using System;
using FBSceneData;

// Token: 0x02004B54 RID: 19284
public class SceneFunctionPrefab : SceneEntityInfo, ISceneFunctionPrefabData
{
	// Token: 0x0601C570 RID: 116080 RVA: 0x0089C592 File Offset: 0x0089A992
	public SceneFunctionPrefab(FBSceneData.FunctionPrefab data) : base(data.Super)
	{
		this.mData = data;
	}

	// Token: 0x0601C571 RID: 116081 RVA: 0x0089C5A7 File Offset: 0x0089A9A7
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x0601C572 RID: 116082 RVA: 0x0089C5AA File Offset: 0x0089A9AA
	public global::FunctionPrefab.FunctionType GetFunctionType()
	{
		return (global::FunctionPrefab.FunctionType)this.mData.EFunctionType;
	}

	// Token: 0x040137F0 RID: 79856
	private FBSceneData.FunctionPrefab mData;
}
