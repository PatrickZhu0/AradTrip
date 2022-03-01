using System;
using System.Collections.Generic;
using GameClient;
using Tenmove.Runtime;

// Token: 0x020043C9 RID: 17353
public class Mechanism2139 : BeMechanism
{
	// Token: 0x06018123 RID: 98595 RVA: 0x00779CC2 File Offset: 0x007780C2
	public Mechanism2139(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018124 RID: 98596 RVA: 0x00779CE4 File Offset: 0x007780E4
	public override void OnInit()
	{
		if (this.data.ValueC.Count > 0)
		{
			this.mConcentrationsMinValue = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueC.Count > 1)
		{
			this.mConcentrationsMaxValue = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
		}
		this.mConcentrationsValue = this.mConcentrationsMinValue;
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.mConcentrationsPhase.Add(this.data.ValueB[i].fixInitValue);
			this.mPlayerBuffInfoIDs.Add(this.data.ValueB[i].fixLevelGrow);
		}
		this.mAddBuffUpdateTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mAddBuffUpdateTimeAcc = this.mAddBuffUpdateTime;
		this.mEffectUpdateTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.mEffectUpdateTimeAcc = this.mEffectUpdateTime;
	}

	// Token: 0x06018125 RID: 98597 RVA: 0x00779E44 File Offset: 0x00778244
	public override void OnStart()
	{
		this._ReigstBattleEvent();
		this.SetFogPercentUIActive(true);
		this.SetFogPercentUI();
		this.SetFogPercentEffect();
	}

	// Token: 0x06018126 RID: 98598 RVA: 0x00779E5F File Offset: 0x0077825F
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateAddBuffTime(deltaTime);
		this.UpdateEffectTime(deltaTime);
	}

	// Token: 0x06018127 RID: 98599 RVA: 0x00779E6F File Offset: 0x0077826F
	private void UpdateAddBuffTime(int deltaTime)
	{
		this.mAddBuffUpdateTimeAcc += deltaTime;
		if (this.mAddBuffUpdateTimeAcc >= this.mAddBuffUpdateTime)
		{
			this.mAddBuffUpdateTimeAcc -= this.mAddBuffUpdateTime;
			this.CalcConcentrations();
		}
	}

	// Token: 0x06018128 RID: 98600 RVA: 0x00779EA9 File Offset: 0x007782A9
	private void UpdateEffectTime(int deltaTime)
	{
		this.mEffectUpdateTimeAcc += deltaTime;
		if (this.mEffectUpdateTimeAcc >= this.mEffectUpdateTime)
		{
			this.mEffectUpdateTimeAcc -= this.mEffectUpdateTime;
			this.SetFogPercentUI();
			this.SetFogPercentEffect();
		}
	}

	// Token: 0x06018129 RID: 98601 RVA: 0x00779EEC File Offset: 0x007782EC
	private void CalcConcentrations()
	{
		for (int i = 0; i < this.mConcentrationsPhase.Count; i++)
		{
			if (i + 1 < this.mConcentrationsPhase.Count && this.mConcentrationsValue >= this.mConcentrationsPhase[i] && this.mConcentrationsValue < this.mConcentrationsPhase[i + 1])
			{
				this.TryAddPlayersBuff(i);
				break;
			}
			if (i + 1 == this.mConcentrationsPhase.Count && this.mConcentrationsValue >= this.mConcentrationsPhase[i])
			{
				this.TryAddPlayersBuff(i);
				break;
			}
		}
	}

	// Token: 0x0601812A RID: 98602 RVA: 0x00779F9C File Offset: 0x0077839C
	private void TryAddPlayersBuff(int index)
	{
		if (index < 0 || index >= this.mPlayerBuffInfoIDs.Count)
		{
			return;
		}
		if (base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i] != null && allPlayers[i].playerActor != null && allPlayers[i].playerActor.buffController != null)
				{
					allPlayers[i].playerActor.buffController.TryAddBuff(this.mPlayerBuffInfoIDs[index], null, false, null, 0);
				}
			}
		}
	}

	// Token: 0x0601812B RID: 98603 RVA: 0x0077A079 File Offset: 0x00778479
	private void _ReigstBattleEvent()
	{
		if (base.owner != null)
		{
			this.handleNewA = base.owner.RegisterEventNew(BeEventType.onMechanism2139ValueChange, new BeEvent.BeEventHandleNew.Function(this.OnConcentrationsValueChange));
		}
	}

	// Token: 0x0601812C RID: 98604 RVA: 0x0077A0A8 File Offset: 0x007784A8
	protected void OnConcentrationsValueChange(BeEvent.BeEventParam param)
	{
		int @int = param.m_Int;
		this.mConcentrationsValue += @int;
		this.mConcentrationsValue = (int)IntMath.Clamp((long)this.mConcentrationsValue, (long)this.mConcentrationsMinValue, (long)this.mConcentrationsMaxValue);
	}

	// Token: 0x0601812D RID: 98605 RVA: 0x0077A0EB File Offset: 0x007784EB
	public override void OnFinish()
	{
		this.DestroyFogEffect();
		this.SetFogPercentUIActive(false);
	}

	// Token: 0x0601812E RID: 98606 RVA: 0x0077A0FA File Offset: 0x007784FA
	private void SetFogPercentUIActive(bool _flag)
	{
		if (this.RaidFrame == null)
		{
			this.RaidFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<TeamDungeonBattleFrame>(FrameLayer.Middle, null, string.Empty) as TeamDungeonBattleFrame);
		}
		if (this.RaidFrame != null)
		{
			this.RaidFrame.SetFogActive(_flag);
		}
	}

	// Token: 0x0601812F RID: 98607 RVA: 0x0077A13C File Offset: 0x0077853C
	private void SetFogPercentUI()
	{
		if (this.RaidFrame == null)
		{
			this.RaidFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<TeamDungeonBattleFrame>(FrameLayer.Middle, null, string.Empty) as TeamDungeonBattleFrame);
		}
		if (this.RaidFrame != null)
		{
			this.RaidFrame.SetFogPercent(this.mConcentrationsValue, this.mConcentrationsMaxValue);
			this.RaidFrame.SetFogEffectActive(this.mConcentrationsValue == this.mConcentrationsMaxValue);
		}
	}

	// Token: 0x06018130 RID: 98608 RVA: 0x0077A1AC File Offset: 0x007785AC
	private void SetFogPercentEffect()
	{
		if (base.owner == null || base.owner.CurrentBeScene == null || base.owner.CurrentBeScene.currentGeScene == null)
		{
			return;
		}
		if (this.maskCamera == null)
		{
			this.maskCamera = base.owner.CurrentBeScene.currentGeScene.CreateMaskCameraEffect();
		}
		this.maskCamera.SetGradient((float)this.mConcentrationsValue / (float)this.mConcentrationsMaxValue, 0.5f);
	}

	// Token: 0x06018131 RID: 98609 RVA: 0x0077A235 File Offset: 0x00778635
	private void DestroyFogEffect()
	{
		if (this.maskCamera != null)
		{
			this.maskCamera.SetDestory();
		}
	}

	// Token: 0x04011584 RID: 71044
	protected int mConcentrationsMinValue;

	// Token: 0x04011585 RID: 71045
	protected int mConcentrationsMaxValue;

	// Token: 0x04011586 RID: 71046
	protected int mConcentrationsValue;

	// Token: 0x04011587 RID: 71047
	protected List<int> mConcentrationsPhase = new List<int>();

	// Token: 0x04011588 RID: 71048
	protected List<int> mPlayerBuffInfoIDs = new List<int>();

	// Token: 0x04011589 RID: 71049
	protected int mAddBuffUpdateTime;

	// Token: 0x0401158A RID: 71050
	protected int mAddBuffUpdateTimeAcc;

	// Token: 0x0401158B RID: 71051
	protected int mEffectUpdateTime;

	// Token: 0x0401158C RID: 71052
	protected int mEffectUpdateTimeAcc;

	// Token: 0x0401158D RID: 71053
	private TeamDungeonBattleFrame RaidFrame;

	// Token: 0x0401158E RID: 71054
	private GeMaskCameraEffect maskCamera;
}
