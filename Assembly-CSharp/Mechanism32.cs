using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020043DE RID: 17374
public class Mechanism32 : BeMechanism
{
	// Token: 0x060181B0 RID: 98736 RVA: 0x0077E240 File Offset: 0x0077C640
	public Mechanism32(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060181B1 RID: 98737 RVA: 0x0077E278 File Offset: 0x0077C678
	public override void OnInit()
	{
		this.m_CurrentDamage = 0;
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			this.m_GiantIdArray[i] = valueFromUnionCell;
		}
		this.m_ProtectedEffectId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.m_ProtectHurtTime = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_BaseHurt = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		for (int j = 0; j < this.data.ValueE.Count; j++)
		{
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.data.ValueE[j], this.level, true);
			this.m_HurtCoefficient[j] = valueFromUnionCell2;
		}
	}

	// Token: 0x060181B2 RID: 98738 RVA: 0x0077E39E File Offset: 0x0077C79E
	public override void OnStart()
	{
		this.m_AllGiantDead = false;
	}

	// Token: 0x060181B3 RID: 98739 RVA: 0x0077E3A8 File Offset: 0x0077C7A8
	public override void OnUpdate(int deltaTime)
	{
		if (!this.m_AllGiantDead)
		{
			if (this.CheckGiantAllDead())
			{
				this.m_AllGiantDead = true;
				this.StartDamage();
			}
		}
		else
		{
			if (this.m_ProtectHurtTime >= 0)
			{
				this.m_OnHurtCountDownFlag = true;
				this.m_ProtectHurtTime -= deltaTime;
				if (this.m_Battle != null)
				{
					this.m_Battle.ShowDamageBar(true);
					this.m_Battle.ChangeCountDown(this.m_ProtectHurtTime / 1000);
				}
			}
			else
			{
				this.m_OnHurtCountDownFlag = false;
			}
			if (!this.m_OnHurtCountDownFlag)
			{
				this.SetProtectDead();
			}
		}
	}

	// Token: 0x060181B4 RID: 98740 RVA: 0x0077E44C File Offset: 0x0077C84C
	protected bool CheckGiantAllDead()
	{
		List<BeActor> list = new List<BeActor>();
		for (int i = 0; i < this.m_GiantIdArray.Length; i++)
		{
			base.owner.CurrentBeScene.FindActorById(list, this.m_GiantIdArray[i]);
			if (list.Count > 0 && list[0] != null && !list[0].IsDead())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060181B5 RID: 98741 RVA: 0x0077E4C0 File Offset: 0x0077C8C0
	protected void StartDamage()
	{
		SystemNotifyManager.SysDungeonSkillTip(this.m_TipContent, (float)this.m_ProtectHurtTime / 1000f, false);
		this.m_Battle = (Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle);
		int count = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers().Count;
		int diffID = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().id.diffID;
		int num = 0;
		switch (diffID)
		{
		case 0:
			num = this.m_HurtCoefficient[0];
			break;
		case 1:
			num = this.m_HurtCoefficient[1];
			break;
		case 2:
			num = this.m_HurtCoefficient[2];
			break;
		case 3:
			num = this.m_HurtCoefficient[3];
			break;
		}
		VFactor f = new VFactor((long)num, (long)GlobalLogic.VALUE_1000);
		this.m_MaxHurt = this.m_BaseHurt * count * (diffID + 1) * f;
		this.AddHitNoDamageBuff();
		if (this.m_ProtectActor != null)
		{
			this.m_ProtectHandle = this.m_ProtectActor.RegisterEvent(BeEventType.onHit, delegate(object[] args)
			{
				this.ProtectOnHurt((int)args[0]);
			});
		}
	}

	// Token: 0x060181B6 RID: 98742 RVA: 0x0077E5E4 File Offset: 0x0077C9E4
	protected void AddHitNoDamageBuff()
	{
		List<BeActor> list = new List<BeActor>();
		base.owner.CurrentBeScene.FindActorById(list, this.m_ProtectedEffectId);
		if (list.Count > 0 && list[0] != null)
		{
			this.m_ProtectActor = list[0];
			this.m_ProtectActor.buffController.TryAddBuff(this.m_BeHitNoDamage, null, false, null, 0);
		}
	}

	// Token: 0x060181B7 RID: 98743 RVA: 0x0077E64F File Offset: 0x0077CA4F
	protected void ProtectOnHurt(int value)
	{
		this.m_CurrentDamage += value;
		if (this.m_CurrentDamage >= this.m_MaxHurt)
		{
			this.RefreshDamageBar();
			this.ShowDamageBar(false);
			this.SetBossDead();
		}
		else
		{
			this.RefreshDamageBar();
		}
	}

	// Token: 0x060181B8 RID: 98744 RVA: 0x0077E68E File Offset: 0x0077CA8E
	protected void RefreshDamageBar()
	{
		if (this.m_Battle == null)
		{
			return;
		}
		this.ShowDamageBar(true);
		this.m_Battle.ChangeDamageData((float)this.m_CurrentDamage, (float)this.m_MaxHurt, false);
	}

	// Token: 0x060181B9 RID: 98745 RVA: 0x0077E6BD File Offset: 0x0077CABD
	protected void SetProtectDead()
	{
		if (this.m_ProtectActor != null)
		{
			this.m_ProtectActor.DoDead(false);
			this.ShowDamageBar(false);
		}
	}

	// Token: 0x060181BA RID: 98746 RVA: 0x0077E6DD File Offset: 0x0077CADD
	protected void SetBossDead()
	{
		base.owner.buffController.RemoveBuff(2, 0, 0);
		base.owner.DoHurt(int.MaxValue, null, HitTextType.NORMAL, null, HitTextType.NORMAL, false);
	}

	// Token: 0x060181BB RID: 98747 RVA: 0x0077E707 File Offset: 0x0077CB07
	protected void ShowDamageBar(bool show)
	{
		if (this.m_Battle != null)
		{
			this.m_Battle.ShowDamageBar(show);
		}
	}

	// Token: 0x060181BC RID: 98748 RVA: 0x0077E720 File Offset: 0x0077CB20
	public override void OnFinish()
	{
		if (this.m_ProtectHandle != null)
		{
			this.m_ProtectHandle.Remove();
		}
	}

	// Token: 0x04011613 RID: 71187
	protected int[] m_GiantIdArray = new int[3];

	// Token: 0x04011614 RID: 71188
	protected int m_ProtectedEffectId;

	// Token: 0x04011615 RID: 71189
	protected int m_ProtectHurtTime;

	// Token: 0x04011616 RID: 71190
	protected int m_BaseHurt;

	// Token: 0x04011617 RID: 71191
	protected int[] m_HurtCoefficient = new int[4];

	// Token: 0x04011618 RID: 71192
	protected int m_BeHitNoDamage = 547727;

	// Token: 0x04011619 RID: 71193
	protected int m_MaxHurt;

	// Token: 0x0401161A RID: 71194
	protected int m_CurrentDamage;

	// Token: 0x0401161B RID: 71195
	protected bool m_AllGiantDead;

	// Token: 0x0401161C RID: 71196
	protected BeActor m_ProtectActor;

	// Token: 0x0401161D RID: 71197
	protected bool m_OnHurtCountDownFlag;

	// Token: 0x0401161E RID: 71198
	protected string m_TipContent = "破坏仪式，阻止BOSS破封而出";

	// Token: 0x0401161F RID: 71199
	protected BeEventHandle m_ProtectHandle;

	// Token: 0x04011620 RID: 71200
	private ClientSystemBattle m_Battle;
}
