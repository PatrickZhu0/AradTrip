using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020041C3 RID: 16835
public class BeStatesGraph
{
	// Token: 0x06017364 RID: 95076 RVA: 0x00701828 File Offset: 0x006FFC28
	public static int SGStatesID(ref BeStates pkState)
	{
		return pkState.iStateID;
	}

	// Token: 0x06017365 RID: 95077 RVA: 0x00701831 File Offset: 0x006FFC31
	public static void SGAddEventHandler2States(BeStates pkState, BeEventsHandler evenhandler)
	{
		pkState.OnEventHandler.Add(evenhandler);
	}

	// Token: 0x06017366 RID: 95078 RVA: 0x0070183F File Offset: 0x006FFC3F
	public static void SGAddTimeLineHandler2States(BeStates pkState, BeTimeLineHandler timelines)
	{
		pkState.OnTimeLineHandler.Add(timelines);
	}

	// Token: 0x06017367 RID: 95079 RVA: 0x0070184D File Offset: 0x006FFC4D
	public void Reset()
	{
		this.m_iGraphState = BeStatesPhase.SSTATESGRAPH_NONE;
		this.m_uiCurrentTimeSinceStart = 0U;
		this.m_uiCurrentStatesTime = 0U;
		this.m_iCurrentStatesIndex = 0;
		this.m_uiTimeSinceStart = 0U;
		this.m_vStateStack.Clear();
	}

	// Token: 0x06017368 RID: 95080 RVA: 0x0070187D File Offset: 0x006FFC7D
	public virtual bool Start(int iStartState = 0)
	{
		if (this.m_iGraphState == BeStatesPhase.SSTATESGRAPH_RUN)
		{
			return false;
		}
		if (this.SwitchStates(new BeStateData(iStartState, 0)))
		{
			this.m_iGraphState = BeStatesPhase.SSTATESGRAPH_RUN;
			return true;
		}
		return false;
	}

	// Token: 0x06017369 RID: 95081 RVA: 0x007018A9 File Offset: 0x006FFCA9
	public virtual void Stop()
	{
		this.m_iGraphState = BeStatesPhase.SSTATESGRAPH_STOP;
	}

	// Token: 0x0601736A RID: 95082 RVA: 0x007018B2 File Offset: 0x006FFCB2
	public BeStatesPhase GetGraphState()
	{
		return this.m_iGraphState;
	}

	// Token: 0x0601736B RID: 95083 RVA: 0x007018BC File Offset: 0x006FFCBC
	public int GetCurrentState()
	{
		BeStates currentStateData = this.GetCurrentStateData();
		return currentStateData.iStateID;
	}

	// Token: 0x0601736C RID: 95084 RVA: 0x007018D6 File Offset: 0x006FFCD6
	public BeStates GetCurrentStateData()
	{
		return this._getCurrentStateData();
	}

	// Token: 0x0601736D RID: 95085 RVA: 0x007018DE File Offset: 0x006FFCDE
	public uint GetCurrentStatesTime()
	{
		return this.m_uiCurrentStatesTime;
	}

	// Token: 0x0601736E RID: 95086 RVA: 0x007018E6 File Offset: 0x006FFCE6
	public uint GetCurrentTimeSinceStart()
	{
		return this.m_uiCurrentTimeSinceStart;
	}

	// Token: 0x0601736F RID: 95087 RVA: 0x007018EE File Offset: 0x006FFCEE
	public virtual void InitStatesGraph()
	{
	}

	// Token: 0x06017370 RID: 95088 RVA: 0x007018F0 File Offset: 0x006FFCF0
	public virtual void UpdateStates(int iDeltaTime)
	{
		if (this.GetGraphState() != BeStatesPhase.SSTATESGRAPH_RUN)
		{
			return;
		}
		if (iDeltaTime < 0)
		{
			iDeltaTime = 0;
		}
		this.m_uiCurrentStatesTime += (uint)iDeltaTime;
		this.m_uiCurrentTimeSinceStart += (uint)iDeltaTime;
		this.m_uiTimeSinceStart += (uint)iDeltaTime;
		BeStates currentStateData = this.GetCurrentStateData();
		if (currentStateData.OnTick != null)
		{
			currentStateData.OnTick(currentStateData, iDeltaTime);
		}
		if (currentStateData.uiTimeOut != -1 && (ulong)this.m_uiCurrentStatesTime >= (ulong)((long)currentStateData.uiTimeOut))
		{
			if (currentStateData.OnTimeOut != null)
			{
				currentStateData.OnTimeOut(currentStateData);
			}
			else
			{
				this.LocomoteState();
			}
		}
	}

	// Token: 0x06017371 RID: 95089 RVA: 0x007019A0 File Offset: 0x006FFDA0
	public void ResetCurrentStateTime()
	{
		BeStates currentStateData = this.GetCurrentStateData();
		if (currentStateData.uiTimeOut != -1)
		{
			this.m_uiCurrentStatesTime = 0U;
		}
	}

	// Token: 0x06017372 RID: 95090 RVA: 0x007019C8 File Offset: 0x006FFDC8
	public virtual bool SwitchStates(BeStateData s)
	{
		BeStateData beStateData = s;
		for (int i = 0; i < this.m_vkStates.Count; i++)
		{
			BeStates beStates = this.m_vkStates[i];
			if (beStates.iStateID == beStateData._State)
			{
				BeStates currentStateData = this.GetCurrentStateData();
				if (currentStateData != null && currentStateData.OnLeave != null)
				{
					currentStateData.OnLeave(currentStateData, beStateData._State);
				}
				this.m_lastState = currentStateData.iStateID;
				int num = i;
				currentStateData.uiTimeOut = -1;
				beStates.uiTimeOut = -1;
				this.m_iCurrentStatesIndex = i;
				this.m_uiCurrentStatesTime = 0U;
				this.m_uiCurrentTimeSinceStart = 0U;
				this.m_pkEntity.ClearState();
				this.m_pkEntity.TriggerEvent(BeEventType.onStateChange, new object[]
				{
					beStates.iStateID
				});
				if (this.m_pkEntity.IsProcessRecord())
				{
					VInt3 position = this.m_pkEntity.GetPosition();
					string text = string.Empty;
					if (this.m_pkEntity.GetEntityData() != null)
					{
						text = string.Format("hp:{0} mp:{1}", this.m_pkEntity.GetEntityData().GetHP(), this.m_pkEntity.GetEntityData().GetMP());
					}
					if (this.m_pkEntity.GetRecordServer().IsProcessRecord())
					{
						this.m_pkEntity.GetRecordServer().Mark(142055427U, new int[]
						{
							this.m_pkEntity.m_iID,
							position.x,
							position.y,
							position.z,
							this.m_pkEntity.moveXSpeed.i,
							this.m_pkEntity.moveYSpeed.i,
							this.m_pkEntity.moveZSpeed.i,
							(!this.m_pkEntity.GetFace()) ? 0 : 1,
							beStateData._timeout,
							(!beStateData.isForceSwitch) ? 0 : 1,
							this.m_pkEntity.forceX.i,
							this.m_pkEntity.forceY.i,
							this.m_pkEntity.GetAllStatTag(),
							(this.m_pkEntity.attribute == null) ? 0 : this.m_pkEntity.attribute.GetHP(),
							(this.m_pkEntity.attribute == null) ? 0 : this.m_pkEntity.attribute.GetMP()
						}, new string[]
						{
							BeStatesGraph.ActionNames[beStates.iStateID],
							this.m_pkEntity.GetName()
						});
					}
				}
				beStates.kExTags = new SeFlag(beStateData._ExTag);
				beStates.isForceSwitch = beStateData.isForceSwitch;
				if (beStates.OnEnter != null)
				{
					beStates.OnEnter(beStates);
				}
				if (beStateData._timeout > 0 && num == this.m_iCurrentStatesIndex)
				{
					this.SetCurrentStatesTimeout(beStateData._timeout, beStateData._timeoutForce);
				}
				this.m_pkEntity.TriggerEventNew(BeEventType.onStateChangeEnd, new EventParam
				{
					m_Int = beStates.iStateID
				});
				break;
			}
		}
		return true;
	}

	// Token: 0x06017373 RID: 95091 RVA: 0x00701D28 File Offset: 0x00700128
	public virtual void FireEvents2CurrentStates(int iEvents)
	{
		BeStates currentStateData = this.GetCurrentStateData();
		for (int i = 0; i < currentStateData.OnEventHandler.Count; i++)
		{
			BeEventsHandler beEventsHandler = currentStateData.OnEventHandler[i];
			if (beEventsHandler.iEvents == iEvents)
			{
				if (beEventsHandler.onEvent != null)
				{
					beEventsHandler.onEvent(currentStateData);
				}
				return;
			}
		}
	}

	// Token: 0x06017374 RID: 95092 RVA: 0x00701D8C File Offset: 0x0070018C
	public virtual void AddStates2Graph(BeStates rkStates)
	{
		rkStates.pkGraph = this;
		this.m_vkStates.Add(rkStates);
	}

	// Token: 0x06017375 RID: 95093 RVA: 0x00701DA1 File Offset: 0x007001A1
	public virtual void Locomote(BeStateData rkStateData, bool bForce = false)
	{
	}

	// Token: 0x06017376 RID: 95094 RVA: 0x00701DA4 File Offset: 0x007001A4
	public void SetCurrentStatesTimeout(int uiTimes2Out, bool force = false)
	{
		if (uiTimes2Out == -1)
		{
			uiTimes2Out = int.MaxValue;
		}
		BeStates currentStateData = this.GetCurrentStateData();
		if (currentStateData != null)
		{
			bool flag = true;
			if (force)
			{
				currentStateData.uiTimeOut = uiTimes2Out;
				return;
			}
			BDEntityActionInfo cpkCurEntityActionInfo = this.m_pkEntity.m_cpkCurEntityActionInfo;
			if (cpkCurEntityActionInfo != null && cpkCurEntityActionInfo.skillTotalTime > 0)
			{
				int[] array = new int[]
				{
					cpkCurEntityActionInfo.skillTotalTime,
					GlobalLogic.VALUE_1000
				};
				this.m_pkEntity.TriggerEvent(BeEventType.onChangeSkillTime, new object[]
				{
					cpkCurEntityActionInfo.skillID,
					array
				});
				currentStateData.uiTimeOut = array[0] * VFactor.NewVFactor(array[1], GlobalLogic.VALUE_1000);
				flag = false;
			}
			if (flag || force)
			{
				currentStateData.uiTimeOut = uiTimes2Out;
			}
		}
	}

	// Token: 0x06017377 RID: 95095 RVA: 0x00701E68 File Offset: 0x00700268
	public bool CurrentStateHasTag(int iTag)
	{
		BeStates currentStateData = this.GetCurrentStateData();
		return currentStateData != null && currentStateData.kTags.HasFlag(iTag);
	}

	// Token: 0x06017378 RID: 95096 RVA: 0x00701E90 File Offset: 0x00700290
	public void SetCurrentStateTag(int iTag, bool bSet = true)
	{
		BeStates currentStateData = this.GetCurrentStateData();
		if (currentStateData != null)
		{
			if (bSet)
			{
				currentStateData.kTags.SetFlag(iTag, null);
			}
			else
			{
				currentStateData.kTags.ClearFlag(iTag);
			}
		}
	}

	// Token: 0x06017379 RID: 95097 RVA: 0x00701ED0 File Offset: 0x007002D0
	public void ResetCurrentStateTag()
	{
		BeStates currentStateData = this.GetCurrentStateData();
		if (currentStateData != null)
		{
			currentStateData.kTags.Clear();
		}
	}

	// Token: 0x0601737A RID: 95098 RVA: 0x00701EF8 File Offset: 0x007002F8
	public void ResetStateTag(int iStat)
	{
		for (int i = 0; i < this.m_vkStates.Count; i++)
		{
			if (this.m_vkStates[i].iStateID == iStat)
			{
				this.m_vkStates[i].kTags.Clear();
			}
		}
	}

	// Token: 0x0601737B RID: 95099 RVA: 0x00701F50 File Offset: 0x00700350
	public bool CurrentStateHasExTag(int iTag)
	{
		BeStates currentStateData = this.GetCurrentStateData();
		return currentStateData != null && currentStateData.kExTags.HasFlag(iTag);
	}

	// Token: 0x0601737C RID: 95100 RVA: 0x00701F78 File Offset: 0x00700378
	public void SetCurrentStateExTag(int iTag, bool bSet = true)
	{
		BeStates currentStateData = this.GetCurrentStateData();
		if (currentStateData != null)
		{
			if (bSet)
			{
				currentStateData.kExTags.SetFlag(iTag, null);
			}
			else
			{
				currentStateData.kExTags.ClearFlag(iTag);
			}
		}
	}

	// Token: 0x0601737D RID: 95101 RVA: 0x00701FB8 File Offset: 0x007003B8
	public void ResetCurrentStateExTag(int iTag)
	{
		BeStates currentStateData = this.GetCurrentStateData();
		if (currentStateData != null)
		{
			currentStateData.kExTags.Clear();
		}
	}

	// Token: 0x0601737E RID: 95102 RVA: 0x00701FE0 File Offset: 0x007003E0
	public virtual void LocomoteState()
	{
		BeStateData rkStateData = this.PopState();
		this.Locomote(rkStateData, true);
	}

	// Token: 0x0601737F RID: 95103 RVA: 0x00701FFC File Offset: 0x007003FC
	public bool HasStateInStack(int state)
	{
		for (int i = 0; i < this.m_vStateStack.Count; i++)
		{
			if (this.m_vStateStack[i]._State == state)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017380 RID: 95104 RVA: 0x00702042 File Offset: 0x00700442
	public void PushState(ref BeStateData rkData)
	{
		this.m_vStateStack.Add(rkData);
	}

	// Token: 0x06017381 RID: 95105 RVA: 0x00702058 File Offset: 0x00700458
	public BeStateData PopState()
	{
		BeStateData result = default(BeStateData);
		if (this.m_vStateStack.Count > 0)
		{
			result = this.m_vStateStack[this.m_vStateStack.Count - 1];
			this.m_vStateStack.RemoveAt(this.m_vStateStack.Count - 1);
		}
		return result;
	}

	// Token: 0x06017382 RID: 95106 RVA: 0x007020B0 File Offset: 0x007004B0
	public BeStateData GetTopState()
	{
		BeStateData result = default(BeStateData);
		if (this.m_vStateStack.Count > 0)
		{
			result = this.m_vStateStack[this.m_vStateStack.Count - 1];
		}
		return result;
	}

	// Token: 0x06017383 RID: 95107 RVA: 0x007020F0 File Offset: 0x007004F0
	public void ClearStateStack()
	{
		this.m_vStateStack.Clear();
	}

	// Token: 0x06017384 RID: 95108 RVA: 0x007020FD File Offset: 0x007004FD
	protected BeStates _getCurrentStateData()
	{
		return this.m_vkStates[this.m_iCurrentStatesIndex];
	}

	// Token: 0x06017385 RID: 95109 RVA: 0x00702110 File Offset: 0x00700510
	public void ClearSkillUseRecordInfo()
	{
	}

	// Token: 0x04010B73 RID: 68467
	protected BeStatesPhase m_iGraphState;

	// Token: 0x04010B74 RID: 68468
	protected List<BeStates> m_vkStates = new List<BeStates>();

	// Token: 0x04010B75 RID: 68469
	protected uint m_uiCurrentTimeSinceStart;

	// Token: 0x04010B76 RID: 68470
	protected uint m_uiCurrentStatesTime;

	// Token: 0x04010B77 RID: 68471
	protected int m_iCurrentStatesIndex;

	// Token: 0x04010B78 RID: 68472
	protected uint m_uiTimeSinceStart;

	// Token: 0x04010B79 RID: 68473
	protected BeStateData m_kCurState;

	// Token: 0x04010B7A RID: 68474
	protected List<BeStateData> m_vStateStack = new List<BeStateData>();

	// Token: 0x04010B7B RID: 68475
	public int m_lastState;

	// Token: 0x04010B7C RID: 68476
	public BeEntity m_pkEntity;

	// Token: 0x04010B7D RID: 68477
	public static string[] ActionNames = new string[]
	{
		"AS_IDLE",
		"AS_ATTACK",
		"AS_WALK",
		"AS_RUN",
		"AS_HURT",
		"AS_JUMP",
		"AS_JUMPBACK",
		"AS_RUNATTACK",
		"AS_JUMPATTACK",
		"AS_FALL",
		"AS_FALLCLICK",
		"AS_FALLGROUND",
		"AS_SKILL",
		"AS_BUSY",
		"AS_CASTSKILL",
		"AS_GRAPED",
		"AS_DEAD",
		"AS_GETUP",
		"AS_BIRTH",
		"AS_WIN",
		"AS_ROLL"
	};
}
