using System;

// Token: 0x02004496 RID: 17558
public class Skill2208 : BeSkill
{
	// Token: 0x06018686 RID: 99974 RVA: 0x0079C691 File Offset: 0x0079AA91
	public Skill2208(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018687 RID: 99975 RVA: 0x0079C6D0 File Offset: 0x0079AAD0
	public override void OnInit()
	{
		this.m_AutoTimeAcc = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.m_CreateNumMax = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		if (this.skillData.ValueC.Count > 1)
		{
			this.m_ClickTimeAcc = (BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true));
		}
		else
		{
			this.m_ClickTimeAcc = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		}
		this.m_CanManual = (TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true) != 0);
		if (this.skillData.ValueE.Count > 1)
		{
			this.m_RayEntityId = (BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.skillData.ValueE[1], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true));
		}
		if (this.skillData.ValueF.Count > 1)
		{
			this.m_RayChargeEntityId = (BattleMain.IsModePvP(base.battleType) ? TableManager.GetValueFromUnionCell(this.skillData.ValueF[1], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], base.level, true));
		}
	}

	// Token: 0x06018688 RID: 99976 RVA: 0x0079C8BD File Offset: 0x0079ACBD
	public override void OnStart()
	{
		base.OnStart();
		this.InitData();
	}

	// Token: 0x06018689 RID: 99977 RVA: 0x0079C8CC File Offset: 0x0079ACCC
	public override void OnUpdate(int iDeltime)
	{
		if (this.m_CreateRayFlag && this.m_CurrCreateNum < this.m_CreateNumMax)
		{
			if (this.m_CurrAutoTimeAcc > 0)
			{
				if (!this.m_ShowSpeelBar)
				{
					this.m_ShowSpeelBar = true;
					if (base.owner.isLocalActor)
					{
						base.owner.StartSpellBar(eDungeonCharactorBar.RayDrop, this.m_AutoTimeAcc, true, string.Empty, false);
					}
				}
				this.m_CurrAutoTimeAcc -= iDeltime;
			}
			else
			{
				this.CreateRayEntity();
			}
			if (this.m_CanManual)
			{
				if (this.m_CurrClickTimeAcc > 0)
				{
					this.m_CurrClickTimeAcc -= iDeltime;
				}
				else
				{
					this.m_CurrClickTimeAcc = 0;
				}
			}
		}
	}

	// Token: 0x0601868A RID: 99978 RVA: 0x0079C987 File Offset: 0x0079AD87
	public override void OnReleaseJoystick()
	{
		if (this.m_CreateRayFlag && this.m_CanManual && this.m_CurrCreateNum < this.m_CreateNumMax && this.m_CurrClickTimeAcc == 0)
		{
			this.CreateRayEntity();
		}
	}

	// Token: 0x0601868B RID: 99979 RVA: 0x0079C9C1 File Offset: 0x0079ADC1
	public override void OnCancel()
	{
		this.End();
	}

	// Token: 0x0601868C RID: 99980 RVA: 0x0079C9C9 File Offset: 0x0079ADC9
	public override void OnFinish()
	{
		this.End();
	}

	// Token: 0x0601868D RID: 99981 RVA: 0x0079C9D1 File Offset: 0x0079ADD1
	protected void End()
	{
		this.m_CreateRayFlag = false;
		this.canRemoveJoystick = true;
		base.StartCoolDown();
		base.SetInnerState(BeSkill.InnerState.LAUNCH);
		this.skillButtonState = BeSkill.SkillState.NORMAL;
	}

	// Token: 0x0601868E RID: 99982 RVA: 0x0079C9F5 File Offset: 0x0079ADF5
	protected void InitData()
	{
		this.m_ShowSpeelBar = false;
		this.m_CreateRayFlag = true;
		this.canRemoveJoystick = false;
		this.m_CurrCreateNum = 0;
		this.m_CurrAutoTimeAcc = this.m_AutoTimeAcc;
		this.m_CurrClickTimeAcc = this.m_ClickTimeAcc;
	}

	// Token: 0x0601868F RID: 99983 RVA: 0x0079CA2C File Offset: 0x0079AE2C
	protected void CreateRayEntity()
	{
		this.m_CurrAutoTimeAcc = this.m_AutoTimeAcc;
		this.m_CurrClickTimeAcc = this.m_ClickTimeAcc;
		this.m_CurrCreateNum++;
		if (base.owner.HasAction("Tianlei_04"))
		{
			base.owner.PlayAction("Tianlei_04", 1f);
		}
		int entityID = (!this.charged) ? this.m_RayEntityId : this.m_RayChargeEntityId;
		VInt3 effectPos = this.effectPos;
		base.owner.AddEntity(entityID, effectPos, base.level, 0);
		if (this.m_CurrCreateNum == this.m_CreateNumMax)
		{
			if (base.owner.isLocalActor)
			{
				base.owner.StopSpellBar(eDungeonCharactorBar.RayDrop, true);
			}
			base.owner.Locomote(new BeStateData(0, 0), true);
			base.Cancel();
			if (base.owner.buffController.HasBuffByID(1) != null)
			{
				base.owner.buffController.RemoveBuff(1, 0, 0);
			}
		}
		else
		{
			this.m_ShowSpeelBar = false;
		}
	}

	// Token: 0x040119D2 RID: 72146
	protected int m_AutoTimeAcc = 2000;

	// Token: 0x040119D3 RID: 72147
	protected int m_CreateNumMax = 5;

	// Token: 0x040119D4 RID: 72148
	protected int m_ClickTimeAcc = 500;

	// Token: 0x040119D5 RID: 72149
	protected int m_RayEntityId = 60300;

	// Token: 0x040119D6 RID: 72150
	protected int m_RayChargeEntityId = 60301;

	// Token: 0x040119D7 RID: 72151
	protected int m_CurrAutoTimeAcc;

	// Token: 0x040119D8 RID: 72152
	protected int m_CurrCreateNum;

	// Token: 0x040119D9 RID: 72153
	protected bool m_CreateRayFlag;

	// Token: 0x040119DA RID: 72154
	protected int m_CurrClickTimeAcc;

	// Token: 0x040119DB RID: 72155
	protected bool m_CanManual;

	// Token: 0x040119DC RID: 72156
	protected bool m_ShowSpeelBar;
}
