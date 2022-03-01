using System;
using System.ComponentModel;
using ProtoTable;

// Token: 0x02004B64 RID: 19300
[Serializable]
public class DMonsterInfo : DEntityInfo, ISceneMonsterInfoData
{
	// Token: 0x0601C61C RID: 116252 RVA: 0x0089D98C File Offset: 0x0089BD8C
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DMonsterInfo dmonsterInfo = info as DMonsterInfo;
		if (dmonsterInfo != null)
		{
			this.swapType = dmonsterInfo.swapType;
			this.faceType = dmonsterInfo.faceType;
			this.swapNum = dmonsterInfo.swapNum;
			this.swapDelay = dmonsterInfo.swapDelay;
			this.monsterID = dmonsterInfo.monsterID;
			this.monsterLevel = dmonsterInfo.monsterLevel;
			this.monsterTypeID = dmonsterInfo.monsterTypeID;
			this.monsterDiffcute = dmonsterInfo.monsterDiffcute;
		}
	}

	// Token: 0x0601C61D RID: 116253 RVA: 0x0089DA10 File Offset: 0x0089BE10
	public override string GetModelPathByResID()
	{
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(this.resid, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return string.Empty;
		}
		return tableItem2.ModelPath;
	}

	// Token: 0x170027D9 RID: 10201
	// (get) Token: 0x0601C61E RID: 116254 RVA: 0x0089DA71 File Offset: 0x0089BE71
	// (set) Token: 0x0601C61F RID: 116255 RVA: 0x0089DA79 File Offset: 0x0089BE79
	public int monID
	{
		get
		{
			return this.monsterID;
		}
		set
		{
			if (this.monsterID != value && value > 0)
			{
				this.monsterID = value;
				this._encodeID();
			}
		}
	}

	// Token: 0x170027DA RID: 10202
	// (get) Token: 0x0601C620 RID: 116256 RVA: 0x0089DA9B File Offset: 0x0089BE9B
	// (set) Token: 0x0601C621 RID: 116257 RVA: 0x0089DAA3 File Offset: 0x0089BEA3
	public int monLevel
	{
		get
		{
			return this.monsterLevel;
		}
		set
		{
			if (this.monsterLevel != value && value >= 0)
			{
				this.monsterLevel = value;
				this._encodeID();
			}
		}
	}

	// Token: 0x170027DB RID: 10203
	// (get) Token: 0x0601C622 RID: 116258 RVA: 0x0089DAC5 File Offset: 0x0089BEC5
	// (set) Token: 0x0601C623 RID: 116259 RVA: 0x0089DACD File Offset: 0x0089BECD
	public int monTypeID
	{
		get
		{
			return this.monsterTypeID;
		}
		set
		{
			if (this.monsterTypeID != value && value > 0)
			{
				this.monsterTypeID = value;
				this._encodeID();
			}
		}
	}

	// Token: 0x170027DC RID: 10204
	// (get) Token: 0x0601C624 RID: 116260 RVA: 0x0089DAEF File Offset: 0x0089BEEF
	// (set) Token: 0x0601C625 RID: 116261 RVA: 0x0089DAF7 File Offset: 0x0089BEF7
	public int monDiffcute
	{
		get
		{
			return this.monsterDiffcute;
		}
		set
		{
			if (this.monsterDiffcute != value && value > 0)
			{
				this.monsterDiffcute = value;
				this._encodeID();
			}
		}
	}

	// Token: 0x0601C626 RID: 116262 RVA: 0x0089DB19 File Offset: 0x0089BF19
	public void SetID(int id)
	{
		this.resid = id;
		this._decodeID();
	}

	// Token: 0x0601C627 RID: 116263 RVA: 0x0089DB28 File Offset: 0x0089BF28
	private void _decodeID()
	{
		int num = this.resid;
		this.monsterDiffcute = num % 10;
		num /= 10;
		this.monsterTypeID = num % 10;
		num /= 10;
		this.monsterLevel = num % 100;
		num /= 100;
		this.monsterID = num;
	}

	// Token: 0x0601C628 RID: 116264 RVA: 0x0089DB70 File Offset: 0x0089BF70
	private void _encodeID()
	{
		this.resid = this.monsterID;
		this.resid *= 100;
		this.resid += this.monsterLevel % 100;
		this.resid *= 10;
		this.resid += this.monsterTypeID % 10;
		this.resid *= 10;
		this.resid += this.monsterDiffcute % 10;
	}

	// Token: 0x0601C629 RID: 116265 RVA: 0x0089DBF8 File Offset: 0x0089BFF8
	public DMonsterInfo.MonsterSwapType GetSwapType()
	{
		return this.swapType;
	}

	// Token: 0x0601C62A RID: 116266 RVA: 0x0089DC00 File Offset: 0x0089C000
	public DMonsterInfo.FaceType GetFaceType()
	{
		return this.faceType;
	}

	// Token: 0x0601C62B RID: 116267 RVA: 0x0089DC08 File Offset: 0x0089C008
	public int GetSwapNum()
	{
		return this.swapNum;
	}

	// Token: 0x0601C62C RID: 116268 RVA: 0x0089DC10 File Offset: 0x0089C010
	public int GetSwapDelay()
	{
		return this.swapDelay;
	}

	// Token: 0x0601C62D RID: 116269 RVA: 0x0089DC18 File Offset: 0x0089C018
	public int GetFlushGroupID()
	{
		return this.flushGroupID;
	}

	// Token: 0x0601C62E RID: 116270 RVA: 0x0089DC20 File Offset: 0x0089C020
	public DMonsterInfo.FlowRegionType GetFlowRegionType()
	{
		return this.flowRegionType;
	}

	// Token: 0x0601C62F RID: 116271 RVA: 0x0089DC28 File Offset: 0x0089C028
	public ISceneRegionInfoData GetRegionInfo()
	{
		return this.regionInfo;
	}

	// Token: 0x0601C630 RID: 116272 RVA: 0x0089DC30 File Offset: 0x0089C030
	public ISceneDestructibleInfoData GetDestructInfo()
	{
		return this.destructInfo;
	}

	// Token: 0x0601C631 RID: 116273 RVA: 0x0089DC38 File Offset: 0x0089C038
	public void SetMonsterID(int id)
	{
		this.SetID(id);
	}

	// Token: 0x0601C632 RID: 116274 RVA: 0x0089DC41 File Offset: 0x0089C041
	public int GetMonsterID()
	{
		return this.monID;
	}

	// Token: 0x0601C633 RID: 116275 RVA: 0x0089DC49 File Offset: 0x0089C049
	public int GetMonsterLevel()
	{
		return this.monLevel;
	}

	// Token: 0x0601C634 RID: 116276 RVA: 0x0089DC51 File Offset: 0x0089C051
	public int GetMonsterTypeID()
	{
		return this.monTypeID;
	}

	// Token: 0x0601C635 RID: 116277 RVA: 0x0089DC59 File Offset: 0x0089C059
	public int GetMonsterDiffcute()
	{
		return this.monDiffcute;
	}

	// Token: 0x0601C636 RID: 116278 RVA: 0x0089DC61 File Offset: 0x0089C061
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x0401384B RID: 79947
	public DMonsterInfo.MonsterSwapType swapType;

	// Token: 0x0401384C RID: 79948
	public DMonsterInfo.FaceType faceType;

	// Token: 0x0401384D RID: 79949
	public int swapNum;

	// Token: 0x0401384E RID: 79950
	public int swapDelay;

	// Token: 0x0401384F RID: 79951
	public int flushGroupID;

	// Token: 0x04013850 RID: 79952
	public DMonsterInfo.FlowRegionType flowRegionType;

	// Token: 0x04013851 RID: 79953
	public DRegionInfo regionInfo = new DRegionInfo();

	// Token: 0x04013852 RID: 79954
	public DDestructibleInfo destructInfo = new DDestructibleInfo();

	// Token: 0x04013853 RID: 79955
	private const int kDiffculte = 10;

	// Token: 0x04013854 RID: 79956
	private const int kTypeID = 10;

	// Token: 0x04013855 RID: 79957
	private const int kLevel = 100;

	// Token: 0x04013856 RID: 79958
	private const int kID = 1000;

	// Token: 0x04013857 RID: 79959
	private int monsterID;

	// Token: 0x04013858 RID: 79960
	private int monsterLevel;

	// Token: 0x04013859 RID: 79961
	private int monsterTypeID;

	// Token: 0x0401385A RID: 79962
	private int monsterDiffcute;

	// Token: 0x02004B65 RID: 19301
	public enum MonsterSwapType
	{
		// Token: 0x0401385C RID: 79964
		[Description("点刷怪")]
		POINT_SWAP,
		// Token: 0x0401385D RID: 79965
		[Description("圆形刷怪")]
		CIRCLE_SWAP,
		// Token: 0x0401385E RID: 79966
		[Description("矩形刷怪")]
		RECT_SWAP
	}

	// Token: 0x02004B66 RID: 19302
	public enum FaceType
	{
		// Token: 0x04013860 RID: 79968
		[Description("右朝向")]
		Right,
		// Token: 0x04013861 RID: 79969
		[Description("左朝向")]
		Left,
		// Token: 0x04013862 RID: 79970
		[Description("随机朝向")]
		Random
	}

	// Token: 0x02004B67 RID: 19303
	public enum FlowRegionType
	{
		// Token: 0x04013864 RID: 79972
		[Description("无")]
		None,
		// Token: 0x04013865 RID: 79973
		[Description("区域跟随")]
		Region,
		// Token: 0x04013866 RID: 79974
		[Description("可破坏物->怪物")]
		Destruct
	}
}
