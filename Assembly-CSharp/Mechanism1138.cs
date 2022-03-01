using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020042BC RID: 17084
public class Mechanism1138 : BeMechanism
{
	// Token: 0x06017A33 RID: 96819 RVA: 0x0074850D File Offset: 0x0074690D
	public Mechanism1138(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A34 RID: 96820 RVA: 0x00748530 File Offset: 0x00746930
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.m_skillID.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Length; j++)
		{
			this.m_iResID.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
		this.m_hurtID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.m_hurtData = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(this.m_hurtID, string.Empty, string.Empty);
	}

	// Token: 0x06017A35 RID: 96821 RVA: 0x00748621 File Offset: 0x00746A21
	public override void OnFinish()
	{
		if (this.m_grabbedHandle != null)
		{
			this.m_grabbedHandle.Remove();
			this.m_grabbedHandle = null;
		}
		if (this._handleNewB != null)
		{
			this._handleNewB.Remove();
			this._handleNewB = null;
		}
	}

	// Token: 0x06017A36 RID: 96822 RVA: 0x00748660 File Offset: 0x00746A60
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this.onCastSkill));
		this.handleB = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.onCastFinishSkill));
		this.handleC = base.owner.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this.onSkillCancel));
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this.onHurtEntity));
		this.handleD = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, new BeEventHandle.Del(this.onAfterGenBullet));
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.OnJudgeGrab, new BeEvent.BeEventHandleNew.Function(this.onSelfGrabbed));
		this._handleNewB = base.owner.RegisterEventNew(BeEventType.OnSelfJudgeGrab, new BeEvent.BeEventHandleNew.Function(this.onGrabTarget));
	}

	// Token: 0x06017A37 RID: 96823 RVA: 0x0074874C File Offset: 0x00746B4C
	private void onSelfGrabbed(BeEvent.BeEventParam param)
	{
		BeActor beActor = param.m_Obj as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (base.owner.GetCamp() == beActor.GetCamp())
		{
			param.m_Bool = false;
		}
	}

	// Token: 0x06017A38 RID: 96824 RVA: 0x0074878C File Offset: 0x00746B8C
	private void onGrabTarget(BeEvent.BeEventParam param)
	{
		BeActor beActor = param.m_Obj as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (base.owner.GetCamp() == beActor.GetCamp())
		{
			param.m_Bool = false;
		}
	}

	// Token: 0x06017A39 RID: 96825 RVA: 0x007487CC File Offset: 0x00746BCC
	private void onAfterGenBullet(object[] args)
	{
		BeProjectile beProjectile = args[0] as BeProjectile;
		if (beProjectile != null && this.m_iResID.Contains(beProjectile.m_iResID))
		{
			beProjectile.SetCanAttackEnemyAndFriend(true);
		}
	}

	// Token: 0x06017A3A RID: 96826 RVA: 0x00748808 File Offset: 0x00746C08
	private void onCastSkill(object[] args)
	{
		int item = (int)args[0];
		if (this.m_skillID.Contains(item))
		{
			base.owner.stateController.SetAbilityEnable(BeAbilityType.ATTACK_FRIEND_ENEMY_2, false);
		}
	}

	// Token: 0x06017A3B RID: 96827 RVA: 0x00748844 File Offset: 0x00746C44
	private void onSkillCancel(object[] args)
	{
		int item = (int)args[0];
		if (this.m_skillID.Contains(item))
		{
			base.owner.stateController.SetAbilityEnable(BeAbilityType.ATTACK_FRIEND_ENEMY_2, true);
		}
	}

	// Token: 0x06017A3C RID: 96828 RVA: 0x00748880 File Offset: 0x00746C80
	private void onCastFinishSkill(object[] args)
	{
		int item = (int)args[0];
		if (this.m_skillID.Contains(item))
		{
			base.owner.stateController.SetAbilityEnable(BeAbilityType.ATTACK_FRIEND_ENEMY_2, true);
		}
	}

	// Token: 0x06017A3D RID: 96829 RVA: 0x007488BC File Offset: 0x00746CBC
	private void onHurtEntity(BeEvent.BeEventParam param)
	{
		EffectTable effectTable = param.m_Obj3 as EffectTable;
		BeEntity beEntity = param.m_Obj2 as BeEntity;
		if (effectTable == null || beEntity == null || beEntity.m_iCamp != base.owner.m_iCamp)
		{
			return;
		}
		if (this.m_skillID.Contains(effectTable.SkillID) && this.m_hurtData != null)
		{
			param.m_Int = this.m_hurtID;
			param.m_Obj3 = this.m_hurtData;
		}
	}

	// Token: 0x04010FC2 RID: 69570
	private List<int> m_skillID = new List<int>();

	// Token: 0x04010FC3 RID: 69571
	private List<int> m_iResID = new List<int>();

	// Token: 0x04010FC4 RID: 69572
	private int m_hurtID;

	// Token: 0x04010FC5 RID: 69573
	private EffectTable m_hurtData;

	// Token: 0x04010FC6 RID: 69574
	private BeEventHandle m_grabbedHandle;

	// Token: 0x04010FC7 RID: 69575
	private BeEvent.BeEventHandleNew _handleNewB;
}
