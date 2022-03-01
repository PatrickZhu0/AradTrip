using System;

// Token: 0x02004497 RID: 17559
public class Skill2210 : BeSkill
{
	// Token: 0x06018690 RID: 99984 RVA: 0x0079CB3F File Offset: 0x0079AF3F
	public Skill2210(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018691 RID: 99985 RVA: 0x0079CB70 File Offset: 0x0079AF70
	public override void OnInit()
	{
		if (this.skillData.ValueA.Count > 0)
		{
			for (int i = 0; i < this.skillData.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
				this.m_MonsterIdArray[i] = valueFromUnionCell;
			}
		}
		if (this.skillData.ValueB.Count > 0)
		{
			for (int j = 0; j < this.skillData.ValueB.Count; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.skillData.ValueB[j], base.level, true);
				this.m_CanBoomTime[j] = valueFromUnionCell2;
			}
		}
		if (this.skillData.ValueC.Count > 0)
		{
			for (int k = 0; k < this.skillData.ValueC.Count; k++)
			{
				int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.skillData.ValueC[k], base.level, true);
				this.m_BoomEntityId[k] = valueFromUnionCell3;
			}
		}
	}

	// Token: 0x06018692 RID: 99986 RVA: 0x0079CCA0 File Offset: 0x0079B0A0
	public override void OnStart()
	{
		if (this.GetBlackHoleMonsterId() != 0)
		{
			this.m_CanBoom = false;
			this.m_BlackHoleMonster = null;
			this.RemoveHandle();
			if (base.button != null)
			{
				base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
			}
			this.m_MonsterBirthHandle = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				BeActor beActor = (BeActor)args[0];
				if (beActor.GetEntityData().MonsterIDEqual(this.GetBlackHoleMonsterId()))
				{
					this.m_BlackHoleMonster = beActor;
					if (this.m_BlackHoleMonster == null)
					{
						this.skillButtonState = BeSkill.SkillState.NORMAL;
					}
					else
					{
						int ms = (!BattleMain.IsModePvP(base.battleType)) ? this.m_CanBoomTime[0] : this.m_CanBoomTime[1];
						this.m_DelayCall.SetRemove(true);
						this.m_DelayCall = this.m_BlackHoleMonster.delayCaller.DelayCall(ms, delegate
						{
							this.m_CanBoom = true;
							if (base.button != null)
							{
								base.button.AddEffect(ETCButton.eEffectType.onContinue, false);
							}
						}, 0, 0, false);
						this.m_MonsterDeadHandle = this.m_BlackHoleMonster.RegisterEvent(BeEventType.onDead, delegate(object[] arg)
						{
							this.skillButtonState = BeSkill.SkillState.NORMAL;
							if (this.m_BlackHoleMonster != null)
							{
								VInt3 position = this.m_BlackHoleMonster.GetPosition();
								this.CreateBoomEntity(position);
							}
							if (base.button != null)
							{
								base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
							}
						});
					}
				}
			});
			this.m_PassDoorHandle = base.owner.RegisterEvent(BeEventType.onStartPassDoor, delegate(object[] args)
			{
				this.ClearDeadHandle();
			});
			this.m_EnterNextLayerHandle = base.owner.RegisterEvent(BeEventType.onDeadTowerEnterNextLayer, delegate(object[] args)
			{
				this.ClearDeadHandle();
			});
		}
	}

	// Token: 0x06018693 RID: 99987 RVA: 0x0079CD48 File Offset: 0x0079B148
	protected void ClearDeadHandle()
	{
		this.skillButtonState = BeSkill.SkillState.NORMAL;
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
		if (this.m_MonsterDeadHandle != null)
		{
			this.m_MonsterDeadHandle.Remove();
			this.m_MonsterDeadHandle = null;
		}
		this.m_DelayCall.SetRemove(true);
	}

	// Token: 0x06018694 RID: 99988 RVA: 0x0079CDA3 File Offset: 0x0079B1A3
	public override void OnClickAgain()
	{
		if (this.GetBlackHoleMonsterId() != 0)
		{
			this.SetBlackHoleDead();
		}
	}

	// Token: 0x06018695 RID: 99989 RVA: 0x0079CDB6 File Offset: 0x0079B1B6
	public override void OnCancel()
	{
		this.End();
	}

	// Token: 0x06018696 RID: 99990 RVA: 0x0079CDBE File Offset: 0x0079B1BE
	public override void OnFinish()
	{
		this.End();
	}

	// Token: 0x06018697 RID: 99991 RVA: 0x0079CDC6 File Offset: 0x0079B1C6
	protected void End()
	{
		if (this.m_BlackHoleMonster == null)
		{
			this.skillButtonState = BeSkill.SkillState.NORMAL;
		}
	}

	// Token: 0x06018698 RID: 99992 RVA: 0x0079CDDA File Offset: 0x0079B1DA
	protected void SetBlackHoleDead()
	{
		if (!this.m_CanBoom)
		{
			return;
		}
		if (this.m_BlackHoleMonster != null)
		{
			this.m_BlackHoleMonster.DoDead(false);
		}
	}

	// Token: 0x06018699 RID: 99993 RVA: 0x0079CDFF File Offset: 0x0079B1FF
	protected void CreateBoomEntity(VInt3 pos)
	{
		base.owner.AddEntity(this.GetBoomEntityId(), pos, 1, 0);
	}

	// Token: 0x0601869A RID: 99994 RVA: 0x0079CE18 File Offset: 0x0079B218
	protected int GetBoomEntityId()
	{
		return (!this.charged) ? this.m_BoomEntityId[0] : this.m_BoomEntityId[1];
	}

	// Token: 0x0601869B RID: 99995 RVA: 0x0079CE48 File Offset: 0x0079B248
	protected int GetBlackHoleMonsterId()
	{
		int result;
		if (BattleMain.IsModePvP(base.battleType))
		{
			result = ((!this.charged) ? this.m_MonsterIdArray[2] : this.m_MonsterIdArray[3]);
		}
		else
		{
			result = ((!this.charged) ? this.m_MonsterIdArray[0] : this.m_MonsterIdArray[1]);
		}
		return result;
	}

	// Token: 0x0601869C RID: 99996 RVA: 0x0079CEB0 File Offset: 0x0079B2B0
	protected void RemoveHandle()
	{
		if (this.m_MonsterBirthHandle != null)
		{
			this.m_MonsterBirthHandle.Remove();
			this.m_MonsterBirthHandle = null;
		}
		if (this.m_MonsterDeadHandle != null)
		{
			this.m_MonsterDeadHandle.Remove();
			this.m_MonsterDeadHandle = null;
		}
		if (this.m_PassDoorHandle != null)
		{
			this.m_PassDoorHandle.Remove();
			this.m_PassDoorHandle = null;
		}
		if (this.m_EnterNextLayerHandle != null)
		{
			this.m_EnterNextLayerHandle.Remove();
			this.m_EnterNextLayerHandle = null;
		}
	}

	// Token: 0x040119DD RID: 72157
	protected int[] m_MonsterIdArray = new int[4];

	// Token: 0x040119DE RID: 72158
	protected int[] m_CanBoomTime = new int[2];

	// Token: 0x040119DF RID: 72159
	protected int[] m_BoomEntityId = new int[2];

	// Token: 0x040119E0 RID: 72160
	protected bool m_CanBoom;

	// Token: 0x040119E1 RID: 72161
	protected BeEventHandle m_MonsterBirthHandle;

	// Token: 0x040119E2 RID: 72162
	protected BeEventHandle m_MonsterDeadHandle;

	// Token: 0x040119E3 RID: 72163
	protected BeEventHandle m_PassDoorHandle;

	// Token: 0x040119E4 RID: 72164
	protected BeEventHandle m_EnterNextLayerHandle;

	// Token: 0x040119E5 RID: 72165
	protected BeActor m_BlackHoleMonster;

	// Token: 0x040119E6 RID: 72166
	protected DelayCallUnitHandle m_DelayCall;
}
