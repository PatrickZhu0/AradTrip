using System;
using System.ComponentModel;

// Token: 0x02004B61 RID: 19297
[Serializable]
public class FunctionPrefab : DEntityInfo, ISceneFunctionPrefabData
{
	// Token: 0x0601C612 RID: 116242 RVA: 0x0089D8A0 File Offset: 0x0089BCA0
	public override void Duplicate(DEntityInfo info)
	{
		if (info != this)
		{
			base.Duplicate(info);
			FunctionPrefab functionPrefab = info as FunctionPrefab;
			this.eFunctionType = functionPrefab.eFunctionType;
		}
	}

	// Token: 0x0601C613 RID: 116243 RVA: 0x0089D8CE File Offset: 0x0089BCCE
	public FunctionPrefab.FunctionType GetFunctionType()
	{
		return this.eFunctionType;
	}

	// Token: 0x0601C614 RID: 116244 RVA: 0x0089D8D6 File Offset: 0x0089BCD6
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x04013843 RID: 79939
	public FunctionPrefab.FunctionType eFunctionType;

	// Token: 0x02004B62 RID: 19298
	public enum FunctionType
	{
		// Token: 0x04013845 RID: 79941
		[Description("随从")]
		FT_FollowPet,
		// Token: 0x04013846 RID: 79942
		[Description("魔法宝贝")]
		FT_FollowPet2,
		// Token: 0x04013847 RID: 79943
		FT_COUNT
	}
}
