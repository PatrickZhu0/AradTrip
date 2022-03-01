using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x02004374 RID: 17268
public class Mechanism2060 : BeMechanism
{
	// Token: 0x06017EC6 RID: 97990 RVA: 0x00767F76 File Offset: 0x00766376
	public Mechanism2060(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017EC7 RID: 97991 RVA: 0x00767F80 File Offset: 0x00766380
	public override void OnInit()
	{
		this.mKillSummonMaxNum = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mMonsterBID = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.mSkillBuffID = TableManager.GetValueFromUnionCell(this.data.ValueA[2], this.level, true);
		this.mMonsterID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.showHitCount = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mRemoveBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.clearEntityResID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.clearMonsterTag = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this.m_onDeadFlag = (TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true) == 1);
	}

	// Token: 0x06017EC8 RID: 97992 RVA: 0x00768104 File Offset: 0x00766504
	private void _onCreateMonster(object[] args)
	{
		if (this.m_monsterDeadHandles == null)
		{
			this.m_monsterDeadHandles = new List<BeEventHandle>();
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor != null && beActor.GetEntityData() != null && beActor.GetEntityData().MonsterIDEqual(this.mMonsterID))
		{
			this.m_monsterDeadHandles.Add(beActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this._onMonsterDead)));
		}
	}

	// Token: 0x06017EC9 RID: 97993 RVA: 0x00768178 File Offset: 0x00766578
	private void _onMonsterDead(object[] args)
	{
		if (args.Length < 3)
		{
			return;
		}
		if (!(args[2] is BeActor))
		{
			return;
		}
		this.killNum++;
		if (this.killNum >= this.mKillSummonMaxNum && !this.triggerEventFlag)
		{
			BeUtility.CancelCurrentSkill(base.owner);
			BeUtility.ForceMonsterUseSkill(this.mMonsterBID, this.mSkillBuffID, base.owner);
			this.ClearEntity(this.clearEntityResID);
			if (this.clearMonsterTag == 0)
			{
				BeUtility.DoMonsterDeadById(this.mMonsterID, base.owner);
			}
			base.owner.buffController.RemoveBuffByBuffInfoID(this.mRemoveBuffInfoID);
			this.ClearEventHandle();
			this.triggerEventFlag = true;
		}
		if (!this.triggerEventFlag && this.killNum < this.mKillSummonMaxNum)
		{
			this.SetKillInfoText();
		}
	}

	// Token: 0x06017ECA RID: 97994 RVA: 0x00768258 File Offset: 0x00766658
	public override void OnStart()
	{
		this.Reset();
		this.SetKillInfoText();
		if (base.owner != null)
		{
			if (this.m_onDeadFlag)
			{
				this.m_createMonsterHandle = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onCreateMonster, new BeEventHandle.Del(this._onCreateMonster));
			}
			else
			{
				this.mKillEventHandle = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onMonsterDead, delegate(object[] args)
				{
					BeActor beActor = args[0] as BeActor;
					if (beActor != null && beActor.GetEntityData().MonsterIDEqual(this.mMonsterID))
					{
						this.killNum++;
						if (this.killNum >= this.mKillSummonMaxNum && !this.triggerEventFlag)
						{
							BeUtility.CancelCurrentSkill(base.owner);
							BeUtility.ForceMonsterUseSkill(this.mMonsterBID, this.mSkillBuffID, base.owner);
							this.ClearEntity(this.clearEntityResID);
							if (this.clearMonsterTag == 0)
							{
								BeUtility.DoMonsterDeadById(this.mMonsterID, base.owner);
							}
							base.owner.buffController.RemoveBuffByBuffInfoID(this.mRemoveBuffInfoID);
							this.ClearEventHandle();
							this.triggerEventFlag = true;
						}
						if (!this.triggerEventFlag && this.killNum < this.mKillSummonMaxNum)
						{
							this.SetKillInfoText();
						}
					}
				});
			}
		}
	}

	// Token: 0x06017ECB RID: 97995 RVA: 0x007682D2 File Offset: 0x007666D2
	public override void OnFinish()
	{
		this.Reset();
		this.ClearKillInfoText();
	}

	// Token: 0x06017ECC RID: 97996 RVA: 0x007682E0 File Offset: 0x007666E0
	private void Reset()
	{
		this.killNum = 0;
		this.triggerEventFlag = false;
		this.ClearEventHandle();
	}

	// Token: 0x06017ECD RID: 97997 RVA: 0x007682F8 File Offset: 0x007666F8
	private void ClearEventHandle()
	{
		if (this.mKillEventHandle != null)
		{
			this.mKillEventHandle.Remove();
			this.mKillEventHandle = null;
		}
		if (this.m_createMonsterHandle != null)
		{
			this.m_createMonsterHandle.Remove();
			this.m_createMonsterHandle = null;
		}
		if (this.m_monsterDeadHandles != null)
		{
			for (int i = 0; i < this.m_monsterDeadHandles.Count; i++)
			{
				this.m_monsterDeadHandles[i].Remove();
			}
			this.m_monsterDeadHandles.Clear();
		}
	}

	// Token: 0x06017ECE RID: 97998 RVA: 0x00768384 File Offset: 0x00766784
	private void SetKillInfoText()
	{
		if (this.RaidFrame == null)
		{
			this.RaidFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<TeamDungeonBattleFrame>(FrameLayer.Middle, null, string.Empty) as TeamDungeonBattleFrame);
		}
		if (this.RaidFrame != null)
		{
			this.RaidFrame.SetNoTimeLimitKillNum(this.killNum, this.mKillSummonMaxNum);
		}
	}

	// Token: 0x06017ECF RID: 97999 RVA: 0x007683DA File Offset: 0x007667DA
	private void ClearKillInfoText()
	{
		if (this.RaidFrame != null)
		{
			this.RaidFrame.Close(false);
		}
	}

	// Token: 0x06017ED0 RID: 98000 RVA: 0x007683F4 File Offset: 0x007667F4
	private void ClearEntity(int resID)
	{
		if (base.owner != null)
		{
			List<BeEntity> list = ListPool<BeEntity>.Get();
			base.owner.CurrentBeScene.GetEntitysByResId(list, resID);
			for (int i = 0; i < list.Count; i++)
			{
				BeProjectile beProjectile = list[i] as BeProjectile;
				if (beProjectile != null && !beProjectile.IsDead())
				{
					beProjectile.DoDie();
				}
			}
			ListPool<BeEntity>.Release(list);
		}
	}

	// Token: 0x0401138C RID: 70540
	private int mKillSummonMaxNum;

	// Token: 0x0401138D RID: 70541
	private int mMonsterBID;

	// Token: 0x0401138E RID: 70542
	private int mSkillBuffID;

	// Token: 0x0401138F RID: 70543
	private int mMonsterID;

	// Token: 0x04011390 RID: 70544
	private int killNum;

	// Token: 0x04011391 RID: 70545
	private BeEventHandle mKillEventHandle;

	// Token: 0x04011392 RID: 70546
	private int showHitCount;

	// Token: 0x04011393 RID: 70547
	private int mRemoveBuffInfoID;

	// Token: 0x04011394 RID: 70548
	private bool triggerEventFlag;

	// Token: 0x04011395 RID: 70549
	private int clearEntityResID;

	// Token: 0x04011396 RID: 70550
	private int clearMonsterTag;

	// Token: 0x04011397 RID: 70551
	private bool m_onDeadFlag;

	// Token: 0x04011398 RID: 70552
	private BeEventHandle m_createMonsterHandle;

	// Token: 0x04011399 RID: 70553
	private List<BeEventHandle> m_monsterDeadHandles;

	// Token: 0x0401139A RID: 70554
	private TeamDungeonBattleFrame RaidFrame;
}
