using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02004375 RID: 17269
public class Mechanism2061 : BeMechanism
{
	// Token: 0x06017ED2 RID: 98002 RVA: 0x00768557 File Offset: 0x00766957
	public Mechanism2061(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017ED3 RID: 98003 RVA: 0x00768578 File Offset: 0x00766978
	public override void OnInit()
	{
		this.m_InfoTextString = this.data.StringValueA[0];
		this.mSummonMaxNum = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mMonsterAID = TableManager.GetValueFromUnionCell(this.data.ValueA[1], this.level, true);
		this.mSkillBuffID = TableManager.GetValueFromUnionCell(this.data.ValueA[2], this.level, true);
		this.mMonsterID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.showMonsterInfo = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mRemoveBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.clearEntityResID = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.clearMonsterTag = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
	}

	// Token: 0x06017ED4 RID: 98004 RVA: 0x007686DC File Offset: 0x00766ADC
	public override void OnStart()
	{
		this.Reset();
		if (base.owner != null)
		{
			this.mSummonEventHandle = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && beActor.GetEntityData().MonsterIDEqual(this.mMonsterID))
				{
					this.mSummonNum++;
					if (this.mSummonNum >= this.mSummonMaxNum && !this.triggerEventFlag)
					{
						this.ShowHeadDialog(string.Empty, true);
						BeUtility.CancelCurrentSkill(base.owner);
						BeUtility.ForceMonsterUseSkill(this.mMonsterAID, this.mSkillBuffID, base.owner);
						this.ClearEntity(this.clearEntityResID);
						if (this.clearMonsterTag == 0)
						{
							BeUtility.DoMonsterDeadById(this.mMonsterID, base.owner);
						}
						base.owner.buffController.RemoveBuffByBuffInfoID(this.mRemoveBuffInfoID);
						this.ClearEventHandle();
						this.triggerEventFlag = true;
					}
					if (!this.triggerEventFlag && this.mSummonNum < this.mSummonMaxNum)
					{
						this.ShowHeadDialog(string.Format(this.m_InfoTextString, this.mSummonMaxNum - this.mSummonNum), false);
					}
				}
			});
			this.mKillEventHandle = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onMonsterDead, delegate(object[] args)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && beActor.GetEntityData().MonsterIDEqual(this.mMonsterID))
				{
					this.mSummonNum--;
				}
			});
		}
	}

	// Token: 0x06017ED5 RID: 98005 RVA: 0x0076873C File Offset: 0x00766B3C
	public override void OnFinish()
	{
		this.Reset();
	}

	// Token: 0x06017ED6 RID: 98006 RVA: 0x00768744 File Offset: 0x00766B44
	private void Reset()
	{
		this.mSummonNum = 0;
		this.triggerEventFlag = false;
		this.ClearEventHandle();
		this.ShowHeadDialog(string.Empty, true);
	}

	// Token: 0x06017ED7 RID: 98007 RVA: 0x00768766 File Offset: 0x00766B66
	private void ClearEventHandle()
	{
		if (this.mSummonEventHandle != null)
		{
			this.mSummonEventHandle.Remove();
			this.mSummonEventHandle = null;
		}
		if (this.mKillEventHandle != null)
		{
			this.mKillEventHandle.Remove();
			this.mKillEventHandle = null;
		}
	}

	// Token: 0x06017ED8 RID: 98008 RVA: 0x007687A4 File Offset: 0x00766BA4
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

	// Token: 0x06017ED9 RID: 98009 RVA: 0x0076881A File Offset: 0x00766C1A
	private void ShowHeadDialog(string text, bool hide = false)
	{
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.ShowHeadDialog(text, hide, false, false, false, 3.5f, false);
		}
	}

	// Token: 0x0401139B RID: 70555
	private string m_MonsterInfoPath = "UIFlatten/Prefabs/BattleUI/DungeonMonsterInfo";

	// Token: 0x0401139C RID: 70556
	private string m_InfoTextString = string.Empty;

	// Token: 0x0401139D RID: 70557
	private GameObject m_MonsterInfoPrefab;

	// Token: 0x0401139E RID: 70558
	private Text m_InfoText;

	// Token: 0x0401139F RID: 70559
	private int mSummonMaxNum;

	// Token: 0x040113A0 RID: 70560
	private int mMonsterAID;

	// Token: 0x040113A1 RID: 70561
	private int mSkillBuffID;

	// Token: 0x040113A2 RID: 70562
	private int mMonsterID;

	// Token: 0x040113A3 RID: 70563
	private int mSummonNum;

	// Token: 0x040113A4 RID: 70564
	private bool triggerEventFlag;

	// Token: 0x040113A5 RID: 70565
	private BeEventHandle mSummonEventHandle;

	// Token: 0x040113A6 RID: 70566
	private BeEventHandle mKillEventHandle;

	// Token: 0x040113A7 RID: 70567
	private int showMonsterInfo;

	// Token: 0x040113A8 RID: 70568
	private int mRemoveBuffInfoID;

	// Token: 0x040113A9 RID: 70569
	private int clearEntityResID;

	// Token: 0x040113AA RID: 70570
	private int clearMonsterTag;
}
