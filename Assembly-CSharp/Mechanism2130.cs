using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using UnityEngine;

// Token: 0x020043BF RID: 17343
public class Mechanism2130 : BeMechanism
{
	// Token: 0x060180DD RID: 98525 RVA: 0x007783A2 File Offset: 0x007767A2
	public Mechanism2130(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180DE RID: 98526 RVA: 0x007783AC File Offset: 0x007767AC
	public override void OnInit()
	{
		this.m_gameTime = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
		if (this.data.ValueB.Count > 0)
		{
			this.m_skillIDs = new int[this.data.ValueB.Count];
			for (int i = 0; i < this.m_skillIDs.Length; i++)
			{
				this.m_skillIDs[i] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			}
		}
	}

	// Token: 0x060180DF RID: 98527 RVA: 0x0077845C File Offset: 0x0077685C
	public override void OnStart()
	{
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onRaceGameEnd, new BeEvent.BeEventHandleNew.Function(this._onRaceGameEnd));
		this.m_frame = (Singleton<ClientSystemManager>.instance.OpenFrame<RaceGameFrame>(FrameLayer.Middle, null, string.Empty) as RaceGameFrame);
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindBoss(list);
		if (list.Count > 0)
		{
			this.m_boss = list[0];
			if (this.m_boss != null)
			{
				this.m_boss.RegisterEvent(BeEventType.onCastSkill, new BeEventHandle.Del(this._onBossSpellStart));
				this.m_boss.RegisterEvent(BeEventType.onSkillCancel, new BeEventHandle.Del(this._onBossSpellBreak));
				this.m_boss.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this._onBossSpellEnd));
			}
		}
		ListPool<BeActor>.Release(list);
		if (this.m_frame != null)
		{
			this.m_frame.Start(this.m_gameTime);
		}
	}

	// Token: 0x060180E0 RID: 98528 RVA: 0x00778555 File Offset: 0x00776955
	private bool _isSpeedUpSkill(int skillID)
	{
		return this.m_skillIDs != null && Array.IndexOf<int>(this.m_skillIDs, skillID) != -1;
	}

	// Token: 0x060180E1 RID: 98529 RVA: 0x00778578 File Offset: 0x00776978
	private void _onBossSpellStart(object[] args)
	{
		int skillID = (int)args[0];
		if (this.m_frame != null && this._isSpeedUpSkill(skillID))
		{
			this.m_frame.OnSpeedUpStart();
		}
	}

	// Token: 0x060180E2 RID: 98530 RVA: 0x007785B0 File Offset: 0x007769B0
	private void _onBossSpellBreak(object[] args)
	{
		int skillID = (int)args[0];
		if (this.m_frame != null && this._isSpeedUpSkill(skillID))
		{
			this.m_frame.OnSpeedUpEnd();
		}
	}

	// Token: 0x060180E3 RID: 98531 RVA: 0x007785E8 File Offset: 0x007769E8
	private void _onBossSpellEnd(object[] args)
	{
		int skillID = (int)args[0];
		if (this.m_frame != null && this._isSpeedUpSkill(skillID))
		{
			this.m_frame.OnSpeedUpEnd();
		}
	}

	// Token: 0x060180E4 RID: 98532 RVA: 0x00778620 File Offset: 0x00776A20
	private void _onRaceGameEnd(BeEvent.BeEventParam param)
	{
		if (this.m_frame != null)
		{
			if (param.m_Int == 1)
			{
				this.m_frame.UpdateSelf(1f);
			}
			else
			{
				this.m_frame.UpdateBoss(1f);
			}
			this.m_frame.Stop();
		}
	}

	// Token: 0x060180E5 RID: 98533 RVA: 0x00778674 File Offset: 0x00776A74
	private void _updateObjectPercent()
	{
		if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return;
		}
		int num = int.MinValue;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor playerActor = allPlayers[i].playerActor;
			if (num < playerActor.GetPosition().x)
			{
				num = playerActor.GetPosition().x;
			}
		}
		float num2 = Mathf.Abs((float)(base.owner.CurrentBeScene.logicXSize.y - base.owner.CurrentBeScene.logicXSize.x));
		float num3 = (float)(num - base.owner.CurrentBeScene.logicXSize.x) / num2;
		if (this.m_frame != null && num3 > 0f)
		{
			this.m_frame.UpdateSelf(num3);
		}
		if (this.m_boss == null)
		{
			return;
		}
		num3 = (float)(this.m_boss.GetPosition().x - base.owner.CurrentBeScene.logicXSize.x) / num2;
		if (this.m_frame != null && num3 > 0f)
		{
			this.m_frame.UpdateBoss(num3);
		}
	}

	// Token: 0x060180E6 RID: 98534 RVA: 0x007787E7 File Offset: 0x00776BE7
	public override void OnUpdateGraphic(int deltaTime)
	{
		base.OnUpdateGraphic(deltaTime);
		if (this.m_frame != null)
		{
			this.m_frame.UpdateRoot((float)deltaTime / 1000f);
			this._updateObjectPercent();
		}
	}

	// Token: 0x0401155A RID: 71002
	private float m_gameTime;

	// Token: 0x0401155B RID: 71003
	private RaceGameFrame m_frame;

	// Token: 0x0401155C RID: 71004
	private BeActor m_boss;

	// Token: 0x0401155D RID: 71005
	private int[] m_skillIDs;
}
