using System;
using Battle;
using GameClient;

// Token: 0x020043F5 RID: 17397
public class Mechanism54 : BeMechanism
{
	// Token: 0x06018256 RID: 98902 RVA: 0x00782A64 File Offset: 0x00780E64
	public Mechanism54(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018257 RID: 98903 RVA: 0x00782AD0 File Offset: 0x00780ED0
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
				if (valueFromUnionCell != 0)
				{
					this.m_PveAttriBuffInfoArray[i] = valueFromUnionCell;
				}
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			for (int j = 0; j < this.data.ValueB.Count; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
				if (valueFromUnionCell2 != 0)
				{
					this.m_PvpAttriBuffInfoArray[j] = valueFromUnionCell2;
				}
			}
		}
		if (this.data.ValueC.Count > 0)
		{
			for (int k = 0; k < this.data.ValueC.Count; k++)
			{
				int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true);
				if (valueFromUnionCell3 != 0)
				{
					this.m_PveAttriBuffArray[k] = valueFromUnionCell3;
				}
			}
		}
		if (this.data.ValueD.Count > 0)
		{
			for (int l = 0; l < this.data.ValueD.Count; l++)
			{
				int valueFromUnionCell4 = TableManager.GetValueFromUnionCell(this.data.ValueD[l], this.level, true);
				if (valueFromUnionCell4 != 0)
				{
					this.m_PvpAttriBuffArray[l] = valueFromUnionCell4;
				}
			}
		}
		this.m_TopEffectPath[0] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_guang_zi";
		this.m_TopEffectPath[1] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_huo_zi";
		this.m_TopEffectPath[2] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_bing_zi";
		this.m_TopEffectPath[3] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_an_zi";
		this.m_BodyEffectPath[0] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_buff_guang";
		this.m_BodyEffectPath[1] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_buff_huo";
		this.m_BodyEffectPath[2] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_buff_bing";
		this.m_BodyEffectPath[3] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_buff_an";
		this.m_BodyBuffEffectPath[0] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_guang";
		this.m_BodyBuffEffectPath[1] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_huo";
		this.m_BodyBuffEffectPath[2] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_bing";
		this.m_BodyBuffEffectPath[3] = "Effects/Hero_Yuansu/Yuansudianran/Prefab/Eff_yuansudianran_an";
	}

	// Token: 0x06018258 RID: 98904 RVA: 0x00782D30 File Offset: 0x00781130
	public override void OnStart()
	{
		this.RemoveHandle();
		this.CreateBodyEffect();
		this.m_SkillCastHandle = base.owner.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
		{
			int skillID = (int)args[0];
			BeSkill skill = base.owner.GetSkill(skillID);
			int skillAttri = skill.skillData.SkillAttri;
			if (skillAttri != 0 && skillAttri != this.m_LastSkillAttri)
			{
				int num = skillAttri - 1;
				this.SetTopEffect(num);
				base.owner.TriggerEventNew(BeEventType.onMishuMagicAttrChange, default(EventParam));
				int buffInfoID = (!BattleMain.IsModePvP(base.battleType)) ? this.m_PveAttriBuffInfoArray[num] : this.m_PvpAttriBuffInfoArray[num];
				BuffInfoData info = new BuffInfoData(buffInfoID, this.level, 0);
				base.owner.buffController.TryAddBuff(info, null, false, default(VRate), null);
				this.m_LastSkillAttri = skill.skillData.SkillAttri;
			}
		});
		this.m_BuffStartHandle = base.owner.RegisterEvent(BeEventType.onBuffStart, delegate(object[] args)
		{
			int buffId = (int)args[0];
			int buffIndex = this.GetBuffIndex(buffId);
			if (buffIndex != -1)
			{
				this.ChangeEffect(this.m_BodyEffectPath[buffIndex], this.m_BodyBuffEffectPath[buffIndex]);
			}
		});
		this.m_BuffRefreshHandle = base.owner.RegisterEvent(BeEventType.onBuffRefresh, delegate(object[] args)
		{
			int buffId = (int)args[0];
			int buffIndex = this.GetBuffIndex(buffId);
			if (buffIndex != -1)
			{
				this.ChangeEffect(this.m_BodyEffectPath[buffIndex], this.m_BodyBuffEffectPath[buffIndex]);
			}
		});
		this.m_BuffFinishHandle = base.owner.RegisterEvent(BeEventType.onBuffFinish, delegate(object[] args)
		{
			int buffId = (int)args[0];
			int buffIndex = this.GetBuffIndex(buffId);
			if (buffIndex != -1)
			{
				this.ChangeEffect(this.m_BodyBuffEffectPath[buffIndex], this.m_BodyEffectPath[buffIndex]);
			}
		});
	}

	// Token: 0x06018259 RID: 98905 RVA: 0x00782DD0 File Offset: 0x007811D0
	protected void SetTopEffect(int index)
	{
		if (this.m_LastEffect != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.m_LastEffect);
		}
		GeEffectEx lastEffect = this.CreateEffect(this.m_TopEffectPath[index]);
		this.m_LastEffect = lastEffect;
	}

	// Token: 0x0601825A RID: 98906 RVA: 0x00782E14 File Offset: 0x00781214
	protected GeEffectEx CreateEffect(string path)
	{
		GeEffectEx geEffectEx = null;
		if (base.owner.m_pkGeActor != null)
		{
			geEffectEx = base.owner.m_pkGeActor.CreateEffect(path, null, 9999999f, new Vec3(0f, 0f, 0f), 1f, 1f, true, base.owner.GetFace(), EffectTimeType.BUFF, false);
			if (geEffectEx != null)
			{
				GeUtility.AttachTo(geEffectEx.GetRootNode(), base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root), false);
			}
		}
		return geEffectEx;
	}

	// Token: 0x0601825B RID: 98907 RVA: 0x00782E9C File Offset: 0x0078129C
	protected void CreateBodyEffect()
	{
		if (base.owner.m_pkGeActor == null)
		{
			return;
		}
		for (int i = 0; i < this.m_BodyEffectPath.Length; i++)
		{
			this.CreateEffect(this.m_BodyEffectPath[i]);
		}
	}

	// Token: 0x0601825C RID: 98908 RVA: 0x00782EE4 File Offset: 0x007812E4
	protected void ChangeEffect(string orignPath, string replacePath)
	{
		GeEffectEx effectByName = base.owner.m_pkGeActor.GetEffectManager().GetEffectByName(orignPath);
		if (effectByName != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(effectByName);
		}
		GeEffectEx effectByName2 = base.owner.m_pkGeActor.GetEffectManager().GetEffectByName(replacePath);
		if (effectByName2 != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(effectByName2);
		}
		this.CreateEffect(replacePath);
	}

	// Token: 0x0601825D RID: 98909 RVA: 0x00782F5C File Offset: 0x0078135C
	protected int GetBuffIndex(int buffId)
	{
		int result = -1;
		for (int i = 0; i < this.m_PveAttriBuffArray.Length; i++)
		{
			if (this.m_PveAttriBuffArray[i] == buffId)
			{
				result = i;
			}
		}
		for (int j = 0; j < this.m_PvpAttriBuffArray.Length; j++)
		{
			if (this.m_PvpAttriBuffArray[j] == buffId)
			{
				result = j;
			}
		}
		return result;
	}

	// Token: 0x0601825E RID: 98910 RVA: 0x00782FC0 File Offset: 0x007813C0
	protected void DestroyEffect(string path)
	{
		GeEffectEx effectByName = base.owner.m_pkGeActor.GetEffectManager().GetEffectByName(path);
		if (effectByName != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(effectByName);
		}
	}

	// Token: 0x0601825F RID: 98911 RVA: 0x00782FFD File Offset: 0x007813FD
	public override void OnFinish()
	{
		this.RemoveHandle();
		this.RemoveEffect();
	}

	// Token: 0x06018260 RID: 98912 RVA: 0x0078300C File Offset: 0x0078140C
	protected void RemoveHandle()
	{
		if (this.m_SkillCastHandle != null)
		{
			this.m_SkillCastHandle.Remove();
			this.m_SkillCastHandle = null;
		}
		if (this.m_BuffStartHandle != null)
		{
			this.m_BuffStartHandle.Remove();
			this.m_BuffStartHandle = null;
		}
		if (this.m_BuffRefreshHandle != null)
		{
			this.m_BuffRefreshHandle.Remove();
		}
		if (this.m_BuffFinishHandle != null)
		{
			this.m_BuffFinishHandle.Remove();
			this.m_BuffFinishHandle = null;
		}
	}

	// Token: 0x06018261 RID: 98913 RVA: 0x00783088 File Offset: 0x00781488
	protected void RemoveEffect()
	{
		this.m_LastSkillAttri = 0;
		if (this.m_LastEffect != null)
		{
			base.owner.m_pkGeActor.DestroyEffect(this.m_LastEffect);
			this.m_LastEffect = null;
		}
		for (int i = 0; i < this.m_TopEffectPath.Length; i++)
		{
			this.DestroyEffect(this.m_TopEffectPath[i]);
		}
		for (int j = 0; j < this.m_BodyEffectPath.Length; j++)
		{
			this.DestroyEffect(this.m_BodyEffectPath[j]);
		}
		for (int k = 0; k < this.m_BodyBuffEffectPath.Length; k++)
		{
			this.DestroyEffect(this.m_BodyBuffEffectPath[k]);
		}
	}

	// Token: 0x040116B1 RID: 71345
	protected int[] m_PveAttriBuffInfoArray = new int[4];

	// Token: 0x040116B2 RID: 71346
	protected int[] m_PvpAttriBuffInfoArray = new int[4];

	// Token: 0x040116B3 RID: 71347
	protected int[] m_PveAttriBuffArray = new int[4];

	// Token: 0x040116B4 RID: 71348
	protected int[] m_PvpAttriBuffArray = new int[4];

	// Token: 0x040116B5 RID: 71349
	protected int m_LastSkillAttri;

	// Token: 0x040116B6 RID: 71350
	protected BeEventHandle m_SkillCastHandle;

	// Token: 0x040116B7 RID: 71351
	protected string[] m_TopEffectPath = new string[4];

	// Token: 0x040116B8 RID: 71352
	protected string[] m_BodyEffectPath = new string[4];

	// Token: 0x040116B9 RID: 71353
	protected string[] m_BodyBuffEffectPath = new string[4];

	// Token: 0x040116BA RID: 71354
	protected GeEffectEx m_LastEffect;

	// Token: 0x040116BB RID: 71355
	protected BeEventHandle m_BuffStartHandle;

	// Token: 0x040116BC RID: 71356
	protected BeEventHandle m_BuffFinishHandle;

	// Token: 0x040116BD RID: 71357
	protected BeEventHandle m_BuffRefreshHandle;
}
