using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x020041AC RID: 16812
public class BeRegionTransportDoor : BeRegionBase
{
	// Token: 0x060171AA RID: 94634 RVA: 0x0071657D File Offset: 0x0071497D
	public BeRegionTransportDoor()
	{
		this.mCanRemove = false;
		this.mActive = false;
	}

	// Token: 0x060171AB RID: 94635 RVA: 0x007165AC File Offset: 0x007149AC
	public void Create(ISceneRegionInfoData info, bool isReplace = false, TransportDoorType doorType = TransportDoorType.None)
	{
		base.Create(info, isReplace);
	}

	// Token: 0x060171AC RID: 94636 RVA: 0x007165B6 File Offset: 0x007149B6
	public void SetVisited(bool isVisited)
	{
		this.mIsVisited = isVisited;
	}

	// Token: 0x060171AD RID: 94637 RVA: 0x007165BF File Offset: 0x007149BF
	public bool IsVisited()
	{
		return this.mIsVisited;
	}

	// Token: 0x060171AE RID: 94638 RVA: 0x007165C7 File Offset: 0x007149C7
	public bool IsBoss()
	{
		return this.mIsBoss;
	}

	// Token: 0x060171AF RID: 94639 RVA: 0x007165D0 File Offset: 0x007149D0
	public void SetDoorType(TransportDoorType type)
	{
		this.doorType = type;
		if (this.mTransportDoorData != null)
		{
			ISceneTransportDoorData sceneTransportDoorData = base.regionInfo as ISceneTransportDoorData;
			if (sceneTransportDoorData != null)
			{
				this.regionPos = new VInt3(sceneTransportDoorData.GetRegionInfo().GetEntityInfo().GetPosition());
			}
			this.regionPos += new VInt3(this.mTransportDoorData.GetRegionPos(type));
			this.regionPos.z = 0;
		}
		if (base.regionInfo != null && this.regionPos != VInt3.zero)
		{
			base.regionInfo.SetRegiontype(DRegionInfo.RegionType.Circle);
			base.regionInfo.SetRadius(1.2f);
			ISceneTransportDoorData sceneTransportDoorData2 = base.regionInfo as ISceneTransportDoorData;
			if (sceneTransportDoorData2 != null)
			{
				sceneTransportDoorData2.SetBirthposition(this.regionPos);
			}
		}
	}

	// Token: 0x060171B0 RID: 94640 RVA: 0x007166A4 File Offset: 0x00714AA4
	protected override void _onUpdate(int delta)
	{
		base._onUpdate(delta);
	}

	// Token: 0x060171B1 RID: 94641 RVA: 0x007166AD File Offset: 0x00714AAD
	public override VInt3 GetRegionPos()
	{
		if (this.regionPos != VInt3.zero)
		{
			return this.regionPos;
		}
		return base.GetRegionPos();
	}

	// Token: 0x060171B2 RID: 94642 RVA: 0x007166D4 File Offset: 0x00714AD4
	protected override void _onLoadActorFinish()
	{
		if (null == this.mControlDoorState)
		{
			GameObject entityNode = this.mGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
			if (null != entityNode)
			{
				this.mControlDoorState = entityNode.GetComponentInChildren<ControlDoorState>();
				this._setDoorState(base.active);
			}
		}
		ResTable tableItem = Singleton<TableManager>.instance.GetTableItem<ResTable>(base.resID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			string text = tableItem.ModelPath.Replace(".prefab", string.Empty);
			text += "_extradata";
			this.mTransportDoorData = DungeonUtility.LoadSceneTransportExtraData(text);
		}
		else
		{
			Logger.LogErrorFormat("[TransportDoor] ID {0} 找不到对应模型资源", new object[]
			{
				base.resID
			});
		}
	}

	// Token: 0x060171B3 RID: 94643 RVA: 0x00716795 File Offset: 0x00714B95
	protected override bool _canTriggerIn(BeRegionTarget target)
	{
		return false;
	}

	// Token: 0x060171B4 RID: 94644 RVA: 0x00716798 File Offset: 0x00714B98
	protected override void _tryTriggerIn()
	{
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.mTargetList.Count; i++)
		{
			BeRegionTarget beRegionTarget = this.mTargetList[i];
			if (beRegionTarget != null && beRegionTarget.battlePlayer != null && beRegionTarget.battlePlayer.playerActor != null && !beRegionTarget.battlePlayer.playerActor.IsDead() && beRegionTarget.battlePlayer.netState != BattlePlayer.eNetState.Offline)
			{
				num2++;
				if (beRegionTarget.state == BeRegionState.In && beRegionTarget.isStateChanged)
				{
					num++;
				}
			}
		}
		if (num2 > 0)
		{
			if (num >= num2)
			{
				flag = true;
				flag2 = false;
			}
			else if (num >= 2)
			{
				flag = true;
				flag2 = true;
			}
		}
		if (this.m_triggered && !flag && base.currentBeScene.IsShowTransportDoorCount())
		{
			base.currentBeScene.StopTransportDoorCount(this.timerId);
			this.m_triggered = false;
		}
		if (flag && !flag2 && this.m_triggered && base.currentBeScene.IsShowTransportDoorCount())
		{
			base.currentBeScene.StopTransportDoorCount(this.timerId);
			this.m_triggered = false;
		}
		if (!this.m_triggered && flag)
		{
			if (this.mTriggerRegion != null)
			{
				if (!flag2)
				{
					this.DoTransport();
				}
				else
				{
					base.currentBeScene.StartTransportDoorCount(3, delegate
					{
						this.DoTransport();
					});
					this.timerId = base.currentBeScene.curTransportTimerId;
				}
			}
			this.m_triggered = true;
		}
	}

	// Token: 0x060171B5 RID: 94645 RVA: 0x00716940 File Offset: 0x00714D40
	protected void DoTransport()
	{
		if (this.transported)
		{
			return;
		}
		this.transported = true;
		if (this.mCurrentBeScene == null || this.mCurrentBeScene.mBattle == null || this.mCurrentBeScene.mBattle.dungeonPlayerManager == null)
		{
			Logger.LogError("mCurrentBeScene null reference");
			return;
		}
		List<BattlePlayer> allPlayers = this.mCurrentBeScene.mBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			Logger.LogErrorFormat("players null reference {0}", new object[]
			{
				(this.mCurrentBeScene.mBattle.recordServer == null) ? "none" : this.mCurrentBeScene.mBattle.recordServer.sessionID
			});
			return;
		}
		if (allPlayers.Count > 1)
		{
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				if (battlePlayer != null && battlePlayer.playerActor != null && battlePlayer.playerActor.m_pkGeActor != null && battlePlayer.playerActor.IsDead())
				{
					battlePlayer.playerActor.m_pkGeActor.SetActorVisible(false);
				}
				else if (battlePlayer == null)
				{
					Logger.LogErrorFormat("players {0} null reference {1}", new object[]
					{
						i,
						(this.mCurrentBeScene.mBattle.recordServer == null) ? "none" : this.mCurrentBeScene.mBattle.recordServer.sessionID
					});
				}
				else if (battlePlayer.playerActor == null)
				{
					Logger.LogErrorFormat("players.playerActor {0} {1} {2} null reference {3}", new object[]
					{
						i,
						battlePlayer.GetPlayerName(),
						battlePlayer.GetPlayerServerName(),
						(this.mCurrentBeScene.mBattle.recordServer == null) ? "none" : this.mCurrentBeScene.mBattle.recordServer.sessionID
					});
				}
				else if (battlePlayer.playerActor.m_pkGeActor == null)
				{
					Logger.LogErrorFormat("player.playerActor.m_pkGeActor {0} {1} {2} null reference {3}", new object[]
					{
						i,
						battlePlayer.playerActor.GetName(),
						battlePlayer.playerActor.m_iResID,
						(this.mCurrentBeScene.mBattle.recordServer == null) ? "none" : this.mCurrentBeScene.mBattle.recordServer.sessionID
					});
				}
			}
		}
		if (this.mTriggerRegion == null)
		{
			Logger.LogErrorFormat("mTriggerRegion null reference {0}", new object[]
			{
				(this.mCurrentBeScene.mBattle.recordServer == null) ? "none" : this.mCurrentBeScene.mBattle.recordServer.sessionID
			});
			return;
		}
		if (!this.mTriggerRegion(this.mRegionInfo, this.mTargetList[0]))
		{
			this.transported = false;
			this.m_triggered = false;
			for (int j = 0; j < this.mTargetList.Count; j++)
			{
				BeRegionTarget beRegionTarget = this.mTargetList[j];
				if (beRegionTarget != null)
				{
					beRegionTarget.state = BeRegionState.In;
				}
			}
		}
	}

	// Token: 0x060171B6 RID: 94646 RVA: 0x00716C82 File Offset: 0x00715082
	protected override void _onCreate()
	{
	}

	// Token: 0x060171B7 RID: 94647 RVA: 0x00716C84 File Offset: 0x00715084
	private void _addActiveEffect()
	{
		this._deleteActiveEffect();
		VInt3 position = base.position;
		position.z += VInt.one.i * 3;
		this.mEffect = this.mGeActor.CreateEffect("Effects/Common/Sfx/Jiaodi/Prefab/Eff_toudingjiantou_guo", "Orign", 0f, position.vec3, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
	}

	// Token: 0x060171B8 RID: 94648 RVA: 0x00716CF0 File Offset: 0x007150F0
	private void _deleteActiveEffect()
	{
		if (this.mEffect != null)
		{
			this.mGeActor.DestroyEffect(this.mEffect);
			this.mEffect = null;
		}
	}

	// Token: 0x060171B9 RID: 94649 RVA: 0x00716D18 File Offset: 0x00715118
	private void _setDoorState(bool isActived)
	{
		if (null != this.mControlDoorState)
		{
			if (isActived)
			{
				this._addActiveEffect();
				this.mControlDoorState.OpenDoor(this.doorType);
			}
			else
			{
				this._deleteActiveEffect();
				this.mControlDoorState.CloseDoor();
			}
		}
	}

	// Token: 0x060171BA RID: 94650 RVA: 0x00716D69 File Offset: 0x00715169
	protected override void _loadActivedEffect()
	{
		base._loadActivedEffect();
		this._setDoorState(true);
	}

	// Token: 0x060171BB RID: 94651 RVA: 0x00716D78 File Offset: 0x00715178
	protected override void _unloadActivedEffect()
	{
		base._unloadActivedEffect();
		this._setDoorState(false);
	}

	// Token: 0x060171BC RID: 94652 RVA: 0x00716D88 File Offset: 0x00715188
	public bool CheckInDoorRange(BeActor actor)
	{
		bool result = false;
		for (int i = 0; i < this.mTargetList.Count; i++)
		{
			BeRegionTarget beRegionTarget = this.mTargetList[i];
			if (beRegionTarget != null && !beRegionTarget.battlePlayer.playerActor.IsDead() && beRegionTarget.battlePlayer.netState != BattlePlayer.eNetState.Offline && beRegionTarget.battlePlayer.playerActor == actor && beRegionTarget.state == BeRegionState.In && beRegionTarget.isStateChanged)
			{
				result = true;
			}
		}
		return result;
	}

	// Token: 0x04010A42 RID: 68162
	protected ControlDoorState mControlDoorState;

	// Token: 0x04010A43 RID: 68163
	protected ITransportDoorExtraData mTransportDoorData;

	// Token: 0x04010A44 RID: 68164
	public TransportDoorType doorType = TransportDoorType.None;

	// Token: 0x04010A45 RID: 68165
	private bool m_triggered;

	// Token: 0x04010A46 RID: 68166
	protected bool mIsVisited;

	// Token: 0x04010A47 RID: 68167
	private bool transported;

	// Token: 0x04010A48 RID: 68168
	private int timerId = -1;

	// Token: 0x04010A49 RID: 68169
	public bool isEggDoor;

	// Token: 0x04010A4A RID: 68170
	private VInt3 regionPos = VInt3.zero;

	// Token: 0x04010A4B RID: 68171
	private GeEffectEx mEffect;
}
