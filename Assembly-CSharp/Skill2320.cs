using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using ProtoTable;

// Token: 0x020044A2 RID: 17570
public class Skill2320 : BeSkill
{
	// Token: 0x06018716 RID: 100118 RVA: 0x007A02B4 File Offset: 0x0079E6B4
	public Skill2320(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018717 RID: 100119 RVA: 0x007A0350 File Offset: 0x0079E750
	public override void OnInit()
	{
		base.OnInit();
		this.m_UserChaserPro = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		if (this.m_NormalChaserBuffId.Length + this.m_BigChaserBuffId.Length != this.skillData.ValueB.Count)
		{
			Logger.LogError("Skill2320 ValueB Config Error");
		}
		else
		{
			for (int i = 0; i < this.m_NormalChaserBuffId.Length; i++)
			{
				this.m_NormalChaserBuffId[i] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true);
			}
			for (int j = 0; j < this.m_BigChaserBuffId.Length; j++)
			{
				this.m_BigChaserBuffId[j] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[j + this.m_NormalChaserBuffId.Length], base.level, true);
			}
		}
		this.m_DamageRate = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), GlobalLogic.VALUE_1000);
		if (this.m_NormalHurtIdArr.Length + this.m_BigHurtIdArr.Length != this.skillData.ValueD.Count)
		{
			Logger.LogError("Skill2320 ValueD Config Error");
		}
		else
		{
			for (int k = 0; k < this.m_NormalHurtIdArr.Length; k++)
			{
				this.m_NormalHurtIdArr[k] = TableManager.GetValueFromUnionCell(this.skillData.ValueD[k], base.level, true);
			}
			for (int l = 0; l < this.m_BigHurtIdArr.Length; l++)
			{
				this.m_BigHurtIdArr[l] = TableManager.GetValueFromUnionCell(this.skillData.ValueD[l + this.m_NormalHurtIdArr.Length], base.level, true);
			}
		}
		int num = 0;
		while (num < this.skillData.ValueE.Count && num < this.m_CommonBuffInfoId.Length)
		{
			this.m_CommonBuffInfoId[num] = TableManager.GetValueFromUnionCell(this.skillData.ValueE[num], base.level, true);
			num++;
		}
		if (this.skillData.ValueF.Count > 0)
		{
			this.m_EffectBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], base.level, true);
		}
		for (int m = 0; m < this.skillData.ValueG.Count; m++)
		{
			this.m_targetHurtID.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueG[m], base.level, true));
		}
	}

	// Token: 0x06018718 RID: 100120 RVA: 0x007A060A File Offset: 0x0079EA0A
	public override void OnPostInit()
	{
		base.OnPostInit();
		if (BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		this.GetChaserMgr();
		this.RemoveHandle();
		this.RegisterHandle();
		this.CacheChaserHurtTable();
	}

	// Token: 0x06018719 RID: 100121 RVA: 0x007A063C File Offset: 0x0079EA3C
	private void CacheChaserHurtTable()
	{
		for (int i = 0; i < this.m_NormalHurtIdArr.Length; i++)
		{
			this.m_CacheNormalChaserTable[i] = Singleton<TableManager>.instance.GetTableItem<EffectTable>(this.m_NormalHurtIdArr[i], string.Empty, string.Empty);
		}
		for (int j = 0; j < this.m_BigHurtIdArr.Length; j++)
		{
			this.m_CacheBigChaserTable[j] = Singleton<TableManager>.instance.GetTableItem<EffectTable>(this.m_BigHurtIdArr[j], string.Empty, string.Empty);
		}
	}

	// Token: 0x0601871A RID: 100122 RVA: 0x007A06C4 File Offset: 0x0079EAC4
	protected void RegisterHandle()
	{
		if (base.owner == null)
		{
			return;
		}
		this.m_HandleList.Add(base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this.OnSkillStart)));
		this.m_HandleList.Add(base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this.OnSkillFinish)));
		this.m_HandleList.Add(base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.OnSkillFinish)));
		this.m_HandleNewList.Add(base.owner.RegisterEventNew(BeEventType.onReplaceHurtTableDamageData, new BeEvent.BeEventHandleNew.Function(this.ReplaceHurtTableDamageData)));
	}

	// Token: 0x0601871B RID: 100123 RVA: 0x007A0770 File Offset: 0x0079EB70
	private void OnSkillStart(object[] args)
	{
		int num = (int)args[0];
		if (num == 2313 || num == 2309)
		{
			this.GetChaserLevel();
			this.ReduceChaser();
			this.AddBuff();
			this.AddCommonBuff();
			this.m_MixHurtTableList = this.GetChaserMixHurtIdArr();
		}
	}

	// Token: 0x0601871C RID: 100124 RVA: 0x007A07C0 File Offset: 0x0079EBC0
	private void OnSkillFinish(object[] args)
	{
		int num = (int)args[0];
		if (num == 2313 || num == 2309)
		{
			this.RemoveBuff();
		}
	}

	// Token: 0x0601871D RID: 100125 RVA: 0x007A07F4 File Offset: 0x0079EBF4
	private void ReduceChaser()
	{
		this.m_ChaserList.Clear();
		this.GetChaserMgr();
		if (this.mChaserMgr == null)
		{
			return;
		}
		int useChaserCount = this.GetUseChaserCount();
		if (useChaserCount <= 0)
		{
			return;
		}
		this.mChaserMgr.LaunchChaser(useChaserCount, this.m_ChaserList);
		this.mChaserMgr.ReduceChaserCount(this.m_ChaserList.Count);
		this.DestroyChaserEffect();
	}

	// Token: 0x0601871E RID: 100126 RVA: 0x007A085C File Offset: 0x0079EC5C
	private int GetUseChaserCount()
	{
		int result = 0;
		if (this.mChaserMgr == null)
		{
			return result;
		}
		if (this.mChaserMgr.GetChaserCount() <= 0)
		{
			return result;
		}
		if ((int)base.FrameRandom.Range1000() < this.m_UserChaserPro)
		{
			result = base.FrameRandom.InRange(0, Math.Min(3, this.mChaserMgr.GetChaserCount())) + 1;
		}
		return result;
	}

	// Token: 0x0601871F RID: 100127 RVA: 0x007A08C4 File Offset: 0x0079ECC4
	private void AddCommonBuff()
	{
		if (this.m_ChaserList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			int type = (int)this.m_ChaserList[i].type;
			if (type < this.m_CommonBuffInfoId.Length)
			{
				base.owner.buffController.TryAddBuffInfo(this.m_CommonBuffInfoId[type], base.owner, this.m_ChaserLevel);
			}
		}
	}

	// Token: 0x06018720 RID: 100128 RVA: 0x007A0944 File Offset: 0x0079ED44
	private void AddBuff()
	{
		if (this.m_ChaserList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			Mechanism2072.ChaserData chaserData = this.m_ChaserList[i];
			int buffID;
			if (chaserData.sizeType == Mechanism2072.ChaseSizeType.Normal)
			{
				buffID = this.m_NormalChaserBuffId[(int)chaserData.type];
			}
			else
			{
				buffID = this.m_BigChaserBuffId[(int)chaserData.type];
			}
			base.owner.buffController.TryAddBuff(buffID, -1, this.m_ChaserLevel);
		}
		if (this.m_EffectBuffId > 0)
		{
			base.owner.buffController.TryAddBuff(this.m_EffectBuffId, -1, base.level);
		}
	}

	// Token: 0x06018721 RID: 100129 RVA: 0x007A09FC File Offset: 0x0079EDFC
	private void RemoveBuff()
	{
		if (this.m_ChaserList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			Mechanism2072.ChaserData chaserData = this.m_ChaserList[i];
			int buffID;
			if (chaserData.sizeType == Mechanism2072.ChaseSizeType.Normal)
			{
				buffID = this.m_NormalChaserBuffId[(int)chaserData.type];
			}
			else
			{
				buffID = this.m_BigChaserBuffId[(int)chaserData.type];
			}
			base.owner.buffController.RemoveBuff(buffID, 0, 0);
		}
		if (this.m_EffectBuffId > 0)
		{
			base.owner.buffController.RemoveBuff(this.m_EffectBuffId, 0, 0);
		}
	}

	// Token: 0x06018722 RID: 100130 RVA: 0x007A0AA8 File Offset: 0x0079EEA8
	private void GetChaserLevel()
	{
		if (base.owner != null)
		{
			int skillLevel = base.owner.GetSkillLevel(2302);
			if (skillLevel == 0)
			{
				this.m_ChaserLevel = 1;
			}
			else
			{
				this.m_ChaserLevel = skillLevel;
			}
		}
	}

	// Token: 0x06018723 RID: 100131 RVA: 0x007A0AEC File Offset: 0x0079EEEC
	protected void ReplaceHurtTableDamageData(BeEvent.BeEventParam param)
	{
		if (this.m_MixHurtTableList == null || this.m_MixHurtTableList.Length <= 0)
		{
			return;
		}
		int @int = param.m_Int;
		if (!this.m_targetHurtID.Contains(@int))
		{
			return;
		}
		int num = 0;
		VPercent a = VPercent.zero;
		bool flag = BattleMain.IsModePvP(base.battleType);
		for (int i = 0; i < this.m_MixHurtTableList.Length; i++)
		{
			EffectTable effectTable = this.m_MixHurtTableList[i];
			num += TableManager.GetValueFromUnionCell((!flag) ? effectTable.DamageFixedValue : effectTable.DamageFixedValuePVP, this.m_ChaserLevel, true);
			a += TableManager.GetValueFromUnionCell((!flag) ? effectTable.DamageRate : effectTable.DamageRatePVP, this.m_ChaserLevel, true);
		}
		param.m_Int2 += num * this.m_DamageRate;
		VFactor vfactor = a.precent * this.m_DamageRate;
		param.m_Percent += new VPercent(vfactor.single);
	}

	// Token: 0x06018724 RID: 100132 RVA: 0x007A0C0C File Offset: 0x0079F00C
	protected EffectTable[] GetChaserMixHurtIdArr()
	{
		if (this.m_ChaserList == null)
		{
			Logger.LogErrorFormat("力法被动数据为空，请检查", new object[0]);
			return null;
		}
		List<EffectTable> list = ListPool<EffectTable>.Get();
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			Mechanism2072.ChaserData chaserData = this.m_ChaserList[i];
			int type = (int)chaserData.type;
			int sizeType = (int)chaserData.sizeType;
			list.Add((sizeType != 0) ? this.m_CacheBigChaserTable[type] : this.m_CacheNormalChaserTable[type]);
		}
		EffectTable[] result = list.ToArray();
		ListPool<EffectTable>.Release(list);
		return result;
	}

	// Token: 0x06018725 RID: 100133 RVA: 0x007A0CA8 File Offset: 0x0079F0A8
	private void GetChaserMgr()
	{
		if (base.owner == null)
		{
			return;
		}
		if (this.mChaserMgr != null)
		{
			return;
		}
		BeMechanism mechanism = base.owner.GetMechanism(Mechanism2072.ChaserMgrID);
		if (mechanism == null)
		{
			return;
		}
		Mechanism2072 mechanism2 = mechanism as Mechanism2072;
		this.mChaserMgr = mechanism2;
	}

	// Token: 0x06018726 RID: 100134 RVA: 0x007A0CF4 File Offset: 0x0079F0F4
	protected void RemoveHandle()
	{
		for (int i = 0; i < this.m_HandleNewList.Count; i++)
		{
			if (this.m_HandleNewList[i] != null)
			{
				this.m_HandleNewList[i].Remove();
				this.m_HandleNewList[i] = null;
			}
		}
		this.m_HandleNewList.Clear();
		for (int j = 0; j < this.m_HandleList.Count; j++)
		{
			if (this.m_HandleList[j] != null)
			{
				this.m_HandleList[j].Remove();
				this.m_HandleList[j] = null;
			}
		}
		this.m_HandleList.Clear();
	}

	// Token: 0x06018727 RID: 100135 RVA: 0x007A0DB0 File Offset: 0x0079F1B0
	private void DestroyChaserEffect()
	{
		for (int i = 0; i < this.m_ChaserList.Count; i++)
		{
			if (this.m_ChaserList[i].effect != null && base.owner.m_pkGeActor != null)
			{
				base.owner.m_pkGeActor.DestroyEffect(this.m_ChaserList[i].effect);
				this.m_ChaserList[i].effect = null;
			}
		}
	}

	// Token: 0x04011A27 RID: 72231
	private int m_UserChaserPro;

	// Token: 0x04011A28 RID: 72232
	private int[] m_NormalChaserBuffId = new int[5];

	// Token: 0x04011A29 RID: 72233
	private int[] m_BigChaserBuffId = new int[5];

	// Token: 0x04011A2A RID: 72234
	private VFactor m_DamageRate;

	// Token: 0x04011A2B RID: 72235
	private int[] m_NormalHurtIdArr = new int[5];

	// Token: 0x04011A2C RID: 72236
	private int[] m_BigHurtIdArr = new int[5];

	// Token: 0x04011A2D RID: 72237
	private int[] m_CommonBuffInfoId = new int[5];

	// Token: 0x04011A2E RID: 72238
	private int m_EffectBuffId;

	// Token: 0x04011A2F RID: 72239
	private HashSet<int> m_targetHurtID = new HashSet<int>();

	// Token: 0x04011A30 RID: 72240
	private EffectTable[] m_CacheNormalChaserTable = new EffectTable[5];

	// Token: 0x04011A31 RID: 72241
	private EffectTable[] m_CacheBigChaserTable = new EffectTable[5];

	// Token: 0x04011A32 RID: 72242
	private Mechanism2072 mChaserMgr;

	// Token: 0x04011A33 RID: 72243
	private List<Mechanism2072.ChaserData> m_ChaserList = new List<Mechanism2072.ChaserData>();

	// Token: 0x04011A34 RID: 72244
	protected List<BeEventHandle> m_HandleList = new List<BeEventHandle>();

	// Token: 0x04011A35 RID: 72245
	protected List<BeEvent.BeEventHandleNew> m_HandleNewList = new List<BeEvent.BeEventHandleNew>();

	// Token: 0x04011A36 RID: 72246
	protected EffectTable[] m_MixHurtTableList;

	// Token: 0x04011A37 RID: 72247
	private int m_ChaserLevel = 1;
}
