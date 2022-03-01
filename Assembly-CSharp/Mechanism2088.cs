using System;
using GameClient;
using ProtoTable;

// Token: 0x02004393 RID: 17299
public class Mechanism2088 : BeMechanism
{
	// Token: 0x06017FBB RID: 98235 RVA: 0x0076E95D File Offset: 0x0076CD5D
	public Mechanism2088(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017FBC RID: 98236 RVA: 0x0076E97C File Offset: 0x0076CD7C
	public override void OnInit()
	{
		this.m_HurtId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_TimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_MaxHitNum = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_AddDamagePercent = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06017FBD RID: 98237 RVA: 0x0076EA33 File Offset: 0x0076CE33
	public void InitData(int[] hurtIdArr, BeActor actor)
	{
		this.m_HurtIdArr = hurtIdArr;
		this.m_Attacker = actor;
		this.InitRegister();
		this.GetChaserLevel();
	}

	// Token: 0x06017FBE RID: 98238 RVA: 0x0076EA4F File Offset: 0x0076CE4F
	public override void OnStart()
	{
		base.OnStart();
		base.InitTimeAcc(this.m_TimeAcc);
	}

	// Token: 0x06017FBF RID: 98239 RVA: 0x0076EA64 File Offset: 0x0076CE64
	private void GetChaserLevel()
	{
		if (this.m_Attacker != null)
		{
			int skillLevel = this.m_Attacker.GetSkillLevel(2302);
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

	// Token: 0x06017FC0 RID: 98240 RVA: 0x0076EAA6 File Offset: 0x0076CEA6
	public override void OnUpdateTimeAcc()
	{
		base.OnUpdateTimeAcc();
		if (this.m_CurHitNum >= this.m_MaxHitNum)
		{
			base.Finish();
		}
		else
		{
			this.DoAttack();
			this.m_CurHitNum++;
		}
	}

	// Token: 0x06017FC1 RID: 98241 RVA: 0x0076EADE File Offset: 0x0076CEDE
	protected void InitRegister()
	{
		if (this.m_Attacker == null)
		{
			return;
		}
		this.handleNewA = this.m_Attacker.RegisterEventNew(BeEventType.onReplaceHurtTableDamageData, new BeEvent.BeEventHandleNew.Function(this.ReplaceHurtTableDamageData));
	}

	// Token: 0x06017FC2 RID: 98242 RVA: 0x0076EB0B File Offset: 0x0076CF0B
	protected void DoAttack()
	{
		if (this.m_Attacker == null)
		{
			return;
		}
		this.m_Attacker.DoAttackTo(base.owner, this.m_HurtId, true, false);
	}

	// Token: 0x06017FC3 RID: 98243 RVA: 0x0076EB34 File Offset: 0x0076CF34
	protected void ReplaceHurtTableDamageData(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		if (@int != this.m_HurtId)
		{
			return;
		}
		if (this.m_HurtIdArr == null)
		{
			return;
		}
		int num = 0;
		VPercent a = VPercent.zero;
		bool flag = BattleMain.IsModePvP(base.battleType);
		for (int i = 0; i < this.m_HurtIdArr.Length; i++)
		{
			EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(this.m_HurtIdArr[i], string.Empty, string.Empty);
			num += TableManager.GetValueFromUnionCell((!flag) ? tableItem.DamageFixedValue : tableItem.DamageFixedValuePVP, this.m_ChaserLevel, true);
			a += TableManager.GetValueFromUnionCell((!flag) ? tableItem.DamageRate : tableItem.DamageRatePVP, this.m_ChaserLevel, true);
		}
		param.m_Int2 = num * this.m_AddDamagePercent;
		param.m_Percent = new VPercent((a.precent * this.m_AddDamagePercent).single);
	}

	// Token: 0x04011456 RID: 70742
	protected int m_HurtId;

	// Token: 0x04011457 RID: 70743
	protected int m_TimeAcc;

	// Token: 0x04011458 RID: 70744
	protected int m_MaxHitNum;

	// Token: 0x04011459 RID: 70745
	protected VFactor m_AddDamagePercent = VFactor.zero;

	// Token: 0x0401145A RID: 70746
	protected int m_CurHitNum;

	// Token: 0x0401145B RID: 70747
	protected int[] m_HurtIdArr;

	// Token: 0x0401145C RID: 70748
	protected BeActor m_Attacker;

	// Token: 0x0401145D RID: 70749
	private int m_ChaserLevel = 1;

	// Token: 0x0401145E RID: 70750
	protected BeEvent.BeEventHandleNew m_ReplaceHurtDataHandle;
}
