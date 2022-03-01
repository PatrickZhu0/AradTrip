using System;
using System.Collections.Generic;
using GameClient;
using Network;
using Protocol;
using UnityEngine;

// Token: 0x02004531 RID: 17713
public class FrameSync : GameBindSystem
{
	// Token: 0x17002015 RID: 8213
	// (get) Token: 0x06018A7B RID: 100987 RVA: 0x007B1C42 File Offset: 0x007B0042
	public static FrameSync instance
	{
		get
		{
			if (FrameSync.s_instance == null)
			{
				FrameSync.s_instance = new FrameSync();
			}
			return FrameSync.s_instance;
		}
	}

	// Token: 0x06018A7C RID: 100988 RVA: 0x007B1C5D File Offset: 0x007B005D
	public void SetMainLogic(IDungeonManager logic)
	{
		this.mMainLogic = logic;
	}

	// Token: 0x06018A7D RID: 100989 RVA: 0x007B1C66 File Offset: 0x007B0066
	public void ClearMainLogic()
	{
		this.mMainLogic = null;
		this.mLastTimeDifference = 0f;
		this._reset();
	}

	// Token: 0x06018A7E RID: 100990 RVA: 0x007B1C80 File Offset: 0x007B0080
	public string GetDebugString()
	{
		return string.Concat(new object[]
		{
			"\ncurFrame:",
			this.curFrame,
			" endFrame:",
			this.endFrame,
			" curFrameDelay:",
			this.curFrameDelay,
			" curframeNeedUpdate:",
			FrameSync.curframeNeedUpdate
		});
	}

	// Token: 0x17002016 RID: 8214
	// (get) Token: 0x06018A7F RID: 100991 RVA: 0x007B1CEF File Offset: 0x007B00EF
	// (set) Token: 0x06018A80 RID: 100992 RVA: 0x007B1CF7 File Offset: 0x007B00F7
	public bool isGetStartFrame
	{
		get
		{
			return this.mIsGetStartFrame;
		}
		private set
		{
			this.mIsGetStartFrame = value;
		}
	}

	// Token: 0x06018A81 RID: 100993 RVA: 0x007B1D00 File Offset: 0x007B0100
	public static uint GetTicksNow()
	{
		if (FrameSync.instance != null)
		{
			return FrameSync.instance.curFrame * FrameSync.instance.svrFrameMs;
		}
		return 0U;
	}

	// Token: 0x17002017 RID: 8215
	// (get) Token: 0x06018A82 RID: 100994 RVA: 0x007B1D23 File Offset: 0x007B0123
	public int QueueCount
	{
		get
		{
			return this.frameQueue.Count;
		}
	}

	// Token: 0x06018A83 RID: 100995 RVA: 0x007B1D30 File Offset: 0x007B0130
	private void _reset()
	{
		this.curFrame = 0U;
		this.endFrame = 0U;
		this.frameMs = 0U;
		this.svrFrame = 0U;
		this.svrFrameMs = 0U;
		this.avgFrameDelay = 66;
		this.curFrameDelay = 0;
		this.driftFactor = 0;
		this.timeStart = 0f;
		this.backupSvrFrame = 0U;
		this.keyFrameRate = 1U;
		this.serverSeed = 0U;
		this.frameSpeed = 1U;
		this.svrFrameLater = 0U;
		this.logicLoaded = false;
		this.frameQueue.Clear();
		this.isGetStartFrame = false;
		this.fLocalUpdateAcc = 0f;
		this.lastSvrFrame = 0U;
	}

	// Token: 0x06018A84 RID: 100996 RVA: 0x007B1DCF File Offset: 0x007B01CF
	public void ResetMove()
	{
		this.bInRunMode = false;
		this.nDegree = 0;
		if (this.bInMoveMode && InputManager.instance != null)
		{
			InputManager.instance.FireStopCommand();
		}
		this.bInMoveMode = false;
	}

	// Token: 0x06018A85 RID: 100997 RVA: 0x007B1E05 File Offset: 0x007B0205
	public void Init()
	{
		this.mState = FrameSync.eFrameSyncState.onStart;
		base.InitBindSystem(null);
		this.frameQueue.Clear();
	}

	// Token: 0x06018A86 RID: 100998 RVA: 0x007B1E20 File Offset: 0x007B0220
	public void SetDungeonMode(eDungeonMode mode)
	{
		this.mMode = mode;
		if (this.mMode != eDungeonMode.SyncFrame)
		{
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
		}
	}

	// Token: 0x06018A87 RID: 100999 RVA: 0x007B1E40 File Offset: 0x007B0240
	public void SetStartTick()
	{
		this.mState = FrameSync.eFrameSyncState.onTick;
		if (this.mMode == eDungeonMode.SyncFrame)
		{
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = true;
		}
		else
		{
			this.isGetStartFrame = true;
			GameStartFrame cmd = new GameStartFrame
			{
				startTime = (uint)(Time.time * (float)GlobalLogic.VALUE_1000)
			};
			this.FireFrameCommand(cmd, false);
		}
		this.fLocalUpdateAcc = 0f;
	}

	// Token: 0x06018A88 RID: 101000 RVA: 0x007B1EA5 File Offset: 0x007B02A5
	public void UnInit()
	{
		this.isFire = true;
		this.mState = FrameSync.eFrameSyncState.onCreate;
		this.SetDungeonMode(eDungeonMode.LocalFrame);
		base.ExistBindSystem();
		if (this.mLastTimeScaler != 1U)
		{
			this.mLastTimeScaler = 1U;
		}
		this._reset();
	}

	// Token: 0x06018A89 RID: 101001 RVA: 0x007B1EDB File Offset: 0x007B02DB
	public void PushUDPCommand(string str)
	{
	}

	// Token: 0x06018A8A RID: 101002 RVA: 0x007B1EE0 File Offset: 0x007B02E0
	public void StartFrameSync(uint serverSeed, bool initSvr = true)
	{
		this.curFrame = 0U;
		if (initSvr)
		{
			this.svrFrame = 1U;
			this.mLastTimeDifference = 0f;
		}
		this.frameMs = FrameSync.logicUpdateStep;
		this.svrFrameMs = 16U;
		this.keyFrameRate = 1U;
		this.avgFrameDelay = 0;
		this.curFrameDelay = 0;
		this.driftFactor = 2;
		this.frameSpeed = 1U;
		this.fLocalUpdateAcc = 0f;
		this.mLastTimeScaler = 1U;
		this.serverSeed = serverSeed;
		this.timeStart = Time.realtimeSinceStartup;
		this.logicLoaded = true;
		Application.runInBackground = true;
		this.ResetMove();
	}

	// Token: 0x06018A8B RID: 101003 RVA: 0x007B1F79 File Offset: 0x007B0379
	public void StartSingleFrame()
	{
		this.ResetMove();
		this.fLocalUpdateAcc = 0f;
	}

	// Token: 0x06018A8C RID: 101004 RVA: 0x007B1F8C File Offset: 0x007B038C
	public void StopFrameSync()
	{
	}

	// Token: 0x06018A8D RID: 101005 RVA: 0x007B1F8E File Offset: 0x007B038E
	public void ResetBattle()
	{
		this.ResetMove();
	}

	// Token: 0x06018A8E RID: 101006 RVA: 0x007B1F98 File Offset: 0x007B0398
	public void UpdateLiveShowFrame(bool isInPersuitMode, ref bool needPersue)
	{
		if (this.isGetStartFrame && this.mState != FrameSync.eFrameSyncState.onTick && this.mState != FrameSync.eFrameSyncState.onReconnect)
		{
			return;
		}
		int num = (int)Time.realtimeSinceStartup;
		if (FrameSync.preSec != num)
		{
			FrameSync.preSec = num;
		}
		this.driftFactor = 2;
		float num2 = 2f;
		int num3 = (int)((float)((ulong)this.endFrame / (ulong)((long)Global.Settings.logicFrameStep) - (ulong)this.curFrame / (ulong)((long)Global.Settings.logicFrameStep)) / num2);
		if (isInPersuitMode)
		{
			uint num4 = 1U;
			if (num3 < 16)
			{
				needPersue = false;
				if (this.mLastTimeDifference != 0f && this.timeStart != this.mLastTimeDifference)
				{
					this.timeStart = this.mLastTimeDifference;
				}
				if (num4 != this.mLastTimeScaler)
				{
					this.mLastTimeScaler = num4;
					this.frameSpeed = this.mLastTimeScaler;
				}
			}
			else
			{
				needPersue = true;
				num4 = 16U;
				if (num4 != this.mLastTimeScaler)
				{
					this.mLastTimeScaler = num4;
					this.frameSpeed = this.mLastTimeScaler;
				}
			}
		}
		num3 = Mathf.Clamp(num3, (int)(2U / Global.Settings.logicFrameStep), 100);
		FrameSync.curframeNeedUpdate = num3;
		int i = num3;
		long num5 = (long)((Time.realtimeSinceStartup - this.timeStart) * (float)GlobalLogic.VALUE_1000 * this.frameSpeed);
		long num6 = num5 - (long)(((ulong)(this.svrFrame / Global.Settings.logicFrameStep * Global.Settings.logicFrameStep) + (ulong)((long)FrameSync.logicFrameStepDelta)) * (ulong)this.svrFrameMs);
		int num7 = this.CalculateJitterDelay(num6 / (long)((ulong)this.frameSpeed));
		while (i > 0)
		{
			long num8 = (long)((ulong)(this.curFrame * this.svrFrameMs));
			long num9 = num5 - num8 / (long)((ulong)this.frameSpeed);
			num9 -= (long)num7;
			uint tickCount = (uint)Environment.TickCount;
			if (num9 >= (long)((ulong)this.frameMs))
			{
				if (this.endFrame == 0U || this.curFrame >= this.endFrame - Global.Settings.logicFrameStep + 1U)
				{
					i = 0;
				}
				else
				{
					this.curFrame += Global.Settings.logicFrameStep;
					this.UpdateSendChecksum();
					while (this.frameQueue.Count > 0)
					{
						IFrameCommand frameCommand = this.frameQueue.Peek();
						uint num10 = (frameCommand.GetFrame() + this.svrFrameLater) * this.keyFrameRate;
						if (num10 > this.curFrame)
						{
							break;
						}
						BaseFrameCommand baseFrameCommand = frameCommand as BaseFrameCommand;
						if (baseFrameCommand != null && baseFrameCommand.seat == ClientApplication.playerinfo.seat && baseFrameCommand.sendTime > 0U)
						{
							this.execCmdPerf.AddDelay(tickCount - baseFrameCommand.sendTime);
						}
						if (Singleton<RecordServer>.GetInstance().IsProcessRecord())
						{
							Singleton<RecordServer>.GetInstance().MarkString(142055188U, new string[]
							{
								frameCommand.GetString()
							});
						}
						IFrameCommand frameCommand2 = this.frameQueue.Dequeue();
						if (frameCommand2 != null)
						{
							BaseFrameCommand baseFrameCommand2 = frameCommand2 as BaseFrameCommand;
							baseFrameCommand2.battle = (BattleMain.instance.GetBattle() as BaseBattle);
							frameCommand2.ExecCommand();
						}
					}
					if (this.mMainLogic != null)
					{
						this.mMainLogic.Update((int)this.frameMs);
					}
					i--;
				}
			}
			else
			{
				i = 0;
			}
		}
		this.mMainLogic.UpdateGraphic((int)(Time.deltaTime * (float)GlobalLogic.VALUE_1000));
	}

	// Token: 0x06018A8F RID: 101007 RVA: 0x007B22F8 File Offset: 0x007B06F8
	public void SetSvrFrame(uint svrNum)
	{
		if (this.svrFrame != this.endFrame || this.svrFrame != this.lastSvrFrame)
		{
		}
		this.lastSvrFrame = svrNum;
		this.svrFrame = svrNum;
		this.endFrame = (svrNum + this.svrFrameLater) * this.keyFrameRate;
		if (this.svrFrame != this.endFrame || this.svrFrame != this.lastSvrFrame)
		{
		}
		if (this.backupSvrFrame != this.svrFrame)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			ulong num = (ulong)(this.svrFrame * this.svrFrameMs);
			float num2 = realtimeSinceStartup - num * 0.001f;
			float num3 = num2 - this.timeStart;
			if (num3 < 0f)
			{
				if (!Singleton<ReplayServer>.GetInstance().IsReplay())
				{
					this.timeStart = num2;
				}
				this.mLastTimeDifference = num2;
			}
			this.backupSvrFrame = this.svrFrame;
		}
	}

	// Token: 0x06018A90 RID: 101008 RVA: 0x007B23DC File Offset: 0x007B07DC
	public int CalculateJitterDelay(long nDelayMs)
	{
		this.curFrameDelay = ((nDelayMs > 0L) ? ((int)nDelayMs) : 0);
		if (this.avgFrameDelay < 0)
		{
			this.avgFrameDelay = this.curFrameDelay;
		}
		else
		{
			this.avgFrameDelay = (29 * this.avgFrameDelay + this.curFrameDelay) / 30;
		}
		return this.avgFrameDelay;
	}

	// Token: 0x06018A91 RID: 101009 RVA: 0x007B243C File Offset: 0x007B083C
	public void FireFrameCommand(IFrameCommand cmd, bool force = false)
	{
		if (!this.isFire && !force)
		{
			return;
		}
		switch (this.mMode)
		{
		case eDungeonMode.Test:
		case eDungeonMode.LocalFrame:
		{
			this.frameQueue.Enqueue(cmd);
			BaseFrameCommand baseFrameCommand = cmd as BaseFrameCommand;
			if (baseFrameCommand != null)
			{
				baseFrameCommand.sendTime = (uint)Environment.TickCount;
				if (BattleMain.battleType == BattleType.MutiPlayer || BattleMain.IsTeamMode(BattleMain.battleType, BattleMain.mode))
				{
					baseFrameCommand.seat = ClientApplication.playerinfo.seat;
				}
				else
				{
					baseFrameCommand.seat = 0;
				}
			}
			break;
		}
		case eDungeonMode.SyncFrame:
		{
			if (this.mState != FrameSync.eFrameSyncState.onTick)
			{
				return;
			}
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			_inputData inputData = cmd.GetInputData();
			inputData.sendTime = (uint)Environment.TickCount;
			RelaySvrPlayerInputReq cmd2 = new RelaySvrPlayerInputReq
			{
				session = ClientApplication.playerinfo.session,
				seat = ClientApplication.playerinfo.seat,
				roleid = DataManager<PlayerBaseData>.GetInstance().RoleID,
				input = inputData
			};
			int num = NetManager.Instance().SendCommand<RelaySvrPlayerInputReq>(ServerType.RELAY_SERVER, cmd2);
			if (num != 0)
			{
			}
			break;
		}
		}
	}

	// Token: 0x06018A92 RID: 101010 RVA: 0x007B2574 File Offset: 0x007B0974
	private void SendChecksum()
	{
		RelaySvrFrameChecksumRequest cmd = new RelaySvrFrameChecksumRequest
		{
			checksum = BattleMain.instance.FrameRandom.callNum,
			frame = this.curFrame
		};
		int num = NetManager.Instance().SendCommand<RelaySvrFrameChecksumRequest>(ServerType.RELAY_SERVER, cmd);
		if (num != 0)
		{
		}
	}

	// Token: 0x06018A93 RID: 101011 RVA: 0x007B25C2 File Offset: 0x007B09C2
	public void SendFinalCheckSum()
	{
	}

	// Token: 0x06018A94 RID: 101012 RVA: 0x007B25C4 File Offset: 0x007B09C4
	private void UpdateSendChecksum()
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			this.PushUDPCommand("IsInReplay");
			return;
		}
		if (this.curFrame > 0U && this.curFrame % 50U == 0U)
		{
			this.SendChecksum();
		}
	}

	// Token: 0x06018A95 RID: 101013 RVA: 0x007B2604 File Offset: 0x007B0A04
	public void OnRelayGameStart(uint startTime)
	{
		this.StartFrameSync(startTime, !Singleton<ReplayServer>.GetInstance().IsLiveShow());
		this.curFrame = 2U;
		if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
		{
			Singleton<RecordServer>.GetInstance().RecordStartTime(startTime);
			int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			Singleton<RecordServer>.GetInstance().RecordDungeonID(dungeonID);
			Singleton<RecordServer>.GetInstance().RecordSequence(this.lastSvrFrame);
		}
		BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
		if (mainPlayer != null)
		{
			BeActor playerActor = mainPlayer.playerActor;
			bool attackReplaceLigui = false;
			if (playerActor != null && playerActor.GetEntityData() != null && playerActor.GetEntityData().professtion == 11)
			{
				attackReplaceLigui = Singleton<SettingManager>.GetInstance().GetLiGuiValue("SETTING_LIGUI");
			}
			string key = "STR_CHASER_PVE";
			if (BattleMain.instance != null && BattleMain.instance.GetBattle() != null)
			{
				key = ((!BattleMain.IsModePvP(BattleMain.instance.GetBattle().GetBattleType())) ? "STR_CHASER_PVE" : "STR_CHASER_PVP");
			}
			byte chaserSwitch = (byte)Singleton<SettingManager>.GetInstance().GetChaserSetting(key);
			DoublePressConfigCommand cmd = new DoublePressConfigCommand
			{
				hasDoublePress = Global.Settings.hasDoubleRun,
				hasRunAttackConfig = (Singleton<SettingManager>.GetInstance().GetRunAttackMode() == InputManager.RunAttackMode.QTE),
				attackReplaceLigui = attackReplaceLigui,
				backHitConfig = Singleton<SettingManager>.GetInstance().GetValue("STR_BACKHIT"),
				autoHitConfig = Singleton<SettingManager>.GetInstance().GetValue("STR_AUTOHIT"),
				canUseCrystalSkill = BeUtility.CheckVipAutoUseCrystalSkill(),
				paladinAttackCharge = (Singleton<SettingManager>.GetInstance().GetPaladinAttack() == InputManager.PaladinAttack.OPEN),
				xuanWuManualAttack = (Singleton<SettingManager>.GetInstance().GetSlideMode("3612") == InputManager.SlideSetting.SLIDE),
				chaserSwitch = chaserSwitch,
				floatShotSwitch = (Singleton<SettingManager>.GetInstance().GetSlideMode("1006") == InputManager.SlideSetting.SLIDE),
				headShotSwitch = (Singleton<SettingManager>.GetInstance().GetSlideMode("1104") == InputManager.SlideSetting.SLIDE)
			};
			FrameSync.instance.FireFrameCommand(cmd, false);
		}
		if (Singleton<RecordServer>.GetInstance().IsProcessRecord())
		{
			Singleton<RecordServer>.GetInstance().RecordProcessPlayerInfo(BattleMain.instance.GetPlayerManager());
		}
	}

	// Token: 0x06018A96 RID: 101014 RVA: 0x007B282F File Offset: 0x007B0C2F
	public void OnRelaySvrNotifyGameStart(RelaySvrNotifyGameStart ret)
	{
		this.OnRelayGameStart((uint)ret.startTime);
	}

	// Token: 0x06018A97 RID: 101015 RVA: 0x007B283E File Offset: 0x007B0C3E
	public void ClearCmdQueue()
	{
		this.frameQueue.Clear();
	}

	// Token: 0x06018A98 RID: 101016 RVA: 0x007B284C File Offset: 0x007B0C4C
	private void _pushNetCommand(Frame[] frames)
	{
		uint tickCount = (uint)Environment.TickCount;
		float num = Time.realtimeSinceStartup * (float)GlobalLogic.VALUE_1000;
		this.timepre = num - this.timepre;
		this.timepre = num;
		foreach (Frame frame in frames)
		{
			uint num2 = this.lastSvrFrame;
			if (this.lastSvrFrame <= frame.sequence)
			{
				this.SetSvrFrame(frame.sequence);
				for (int j = 0; j < frame.data.Length; j++)
				{
					_fighterInput fighterInput = frame.data[j];
					byte seat = fighterInput.seat;
					_inputData input = fighterInput.input;
					if (seat == ClientApplication.playerinfo.seat && input.sendTime > 0U)
					{
						uint delay = tickCount - input.sendTime;
						this.recvCmdPerf.AddDelay(delay);
					}
					IFrameCommand frameCommand = FrameCommandFactory.CreateCommand(input.data1);
					if (frameCommand == null)
					{
						Logger.LogErrorFormat("Seat{0} Data Id {1}FrameCommand is Null!! \n", new object[]
						{
							seat,
							input.data1
						});
					}
					else
					{
						frameCommand.SetValue(frame.sequence, seat, input);
						BaseFrameCommand baseFrameCommand = frameCommand as BaseFrameCommand;
						if (baseFrameCommand != null)
						{
							baseFrameCommand.sendTime = input.sendTime;
						}
						FrameCommandID id = frameCommand.GetID();
						if (!this.isGetStartFrame)
						{
							if (id == FrameCommandID.GameStart)
							{
								this.isGetStartFrame = true;
								this.ClearCmdQueue();
							}
						}
						else if (id == FrameCommandID.RaceEnd)
						{
							Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
							if (baseFrameCommand != null && Global.Settings.logicFrameStep != 0U)
							{
								uint num3 = baseFrameCommand.frame % Global.Settings.logicFrameStep;
								if (num3 > 0U)
								{
									this.endFrame += num3;
								}
							}
						}
						if (this.frameQueue.Count > 0)
						{
							IFrameCommand frameCommand2 = this.frameQueue.Peek();
							if (frameCommand2 == null || frameCommand2.GetFrame() > frameCommand.GetFrame())
							{
							}
						}
						this.frameQueue.Enqueue(frameCommand);
						if (Singleton<RecordServer>.GetInstance().IsProcessRecord())
						{
							Singleton<RecordServer>.GetInstance().RecordProcess2("T[{0}][CMD]PUSH CMD:{1} FrameSequence:{2}", new object[]
							{
								DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"),
								frameCommand.GetString(),
								frame.sequence
							});
						}
					}
				}
			}
		}
	}

	// Token: 0x06018A99 RID: 101017 RVA: 0x007B2AC0 File Offset: 0x007B0EC0
	[ProtocolHandle(typeof(RelaySvrReconnectFrameData))]
	private void _onRelaySvrReconnectFrameData(RelaySvrReconnectFrameData rep)
	{
		if (this.mState == FrameSync.eFrameSyncState.onTick || this.mState == FrameSync.eFrameSyncState.onReconnect)
		{
			if (rep.finish == 0)
			{
				this.mState = FrameSync.eFrameSyncState.onReconnect;
			}
			else
			{
				this.mState = FrameSync.eFrameSyncState.onTick;
			}
			if (rep.frames.Length > 0)
			{
				if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
				{
					bool flag = false;
					for (int i = 0; i < rep.frames.Length; i++)
					{
						Frame frame = rep.frames[i];
						for (int j = 0; j < frame.data.Length; j++)
						{
							_fighterInput fighterInput = frame.data[j];
							_inputData input = fighterInput.input;
							FrameCommandID data = (FrameCommandID)input.data1;
							if (data != FrameCommandID.NetQuality)
							{
								flag = true;
							}
						}
					}
					if (flag)
					{
						Singleton<RecordServer>.GetInstance().RecordServerFrames(rep.frames);
					}
				}
				this._pushNetCommand(rep.frames);
			}
		}
		else
		{
			Logger.LogErrorFormat("reconnect with {0}", new object[]
			{
				this.mState
			});
		}
	}

	// Token: 0x06018A9A RID: 101018 RVA: 0x007B2BCC File Offset: 0x007B0FCC
	[MessageHandle(1300004U, false, 0)]
	private void OnRelaySvrFrameDataNotify(MsgDATA msg)
	{
		RelaySvrFrameDataNotify relaySvrFrameDataNotify = new RelaySvrFrameDataNotify();
		relaySvrFrameDataNotify.decode(msg.bytes);
		if (Singleton<RecordServer>.GetInstance().IsProcessRecord())
		{
			for (int i = 0; i < relaySvrFrameDataNotify.frames.Length; i++)
			{
				Frame frame = relaySvrFrameDataNotify.frames[i];
				for (int j = 0; j < frame.data.Length; j++)
				{
					_fighterInput fighterInput = frame.data[j];
					byte seat = fighterInput.seat;
					_inputData input = fighterInput.input;
					IFrameCommand frameCommand = FrameCommandFactory.CreateCommand(input.data1);
					if (frameCommand != null)
					{
						FrameCommandID data = (FrameCommandID)input.data1;
						frameCommand.SetValue(frame.sequence, seat, input);
					}
				}
			}
		}
		if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
		{
			bool flag = false;
			for (int k = 0; k < relaySvrFrameDataNotify.frames.Length; k++)
			{
				Frame frame2 = relaySvrFrameDataNotify.frames[k];
				for (int l = 0; l < frame2.data.Length; l++)
				{
					_fighterInput fighterInput2 = frame2.data[l];
					_inputData input2 = fighterInput2.input;
					FrameCommandID data2 = (FrameCommandID)input2.data1;
					if (data2 != FrameCommandID.NetQuality)
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				Singleton<RecordServer>.GetInstance().RecordServerFrames(relaySvrFrameDataNotify.frames);
			}
		}
		this._pushNetCommand(relaySvrFrameDataNotify.frames);
	}

	// Token: 0x06018A9B RID: 101019 RVA: 0x007B2D26 File Offset: 0x007B1126
	public void PushNetCommand(Frame[] frames)
	{
		this._pushNetCommand(frames);
	}

	// Token: 0x06018A9C RID: 101020 RVA: 0x007B2D30 File Offset: 0x007B1130
	protected void UpdateLocalFrameRandNum()
	{
		uint num = 0U;
		BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
		if (baseBattle != null)
		{
			num = baseBattle.FrameRandom.callNum;
		}
		if (this.mMainLogic != null)
		{
			this.mMainLogic.GetDungeonDataManager().PushLocalFrameRandNum(this.curFrame, num);
		}
	}

	// Token: 0x06018A9D RID: 101021 RVA: 0x007B2D84 File Offset: 0x007B1184
	protected void UpdateLocalFrameCmd()
	{
		while (this.frameQueue.Count > 0)
		{
			IFrameCommand frameCommand = this.frameQueue.Dequeue();
			BaseFrameCommand baseFrameCommand = frameCommand as BaseFrameCommand;
			baseFrameCommand.battle = (BattleMain.instance.GetBattle() as BaseBattle);
			if (baseFrameCommand != null)
			{
				baseFrameCommand.frame = this.curFrame;
				if (baseFrameCommand.frame == 0U)
				{
					Logger.LogErrorFormat("ExecCommand:{0}", new object[]
					{
						frameCommand.GetString()
					});
				}
			}
			if (frameCommand.GetSendTime() > 0U)
			{
				uint delay = (uint)(Environment.TickCount - (int)frameCommand.GetSendTime());
				this.execCmdPerf.AddDelay(delay);
			}
			if (this.mMainLogic != null)
			{
				this.mMainLogic.GetDungeonDataManager().PushLocalFrameData(frameCommand);
				if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
				{
					this.inputdatas.Add(frameCommand.GetInputData());
				}
				if (Singleton<RecordServer>.GetInstance().IsProcessRecord())
				{
					Singleton<RecordServer>.GetInstance().RecordProcess2("T[{0}][CMD]PUSH CMD:{1} FrameSequence:{2}", new object[]
					{
						DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"),
						frameCommand.GetString(),
						frameCommand.GetFrame()
					});
					Singleton<RecordServer>.GetInstance().MarkString(142055429U, new string[]
					{
						frameCommand.GetString()
					});
				}
			}
			frameCommand.ExecCommand();
		}
		if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false) && this.inputdatas.Count > 0)
		{
			RelaySvrFrameDataNotify relaySvrFrameDataNotify = new RelaySvrFrameDataNotify
			{
				frames = new Frame[1]
			};
			relaySvrFrameDataNotify.frames[0] = new Frame
			{
				sequence = this.curFrame,
				data = new _fighterInput[this.inputdatas.Count]
			};
			for (int i = 0; i < this.inputdatas.Count; i++)
			{
				relaySvrFrameDataNotify.frames[0].data[i] = new _fighterInput
				{
					seat = 0,
					input = this.inputdatas[i]
				};
			}
			this.inputdatas.Clear();
			Singleton<RecordServer>.GetInstance().RecordServerFrames(relaySvrFrameDataNotify.frames);
		}
	}

	// Token: 0x06018A9E RID: 101022 RVA: 0x007B2FBC File Offset: 0x007B13BC
	protected void UpdateLocalFrame()
	{
		float num = Time.deltaTime;
		num = Mathf.Clamp(num, 0f, 100f);
		this.fLocalUpdateAcc += num;
		float num2 = FrameSync.logicUpdateStep / 1000f;
		uint num3 = (uint)(Time.time * (float)GlobalLogic.VALUE_1000);
		while (this.fLocalUpdateAcc >= num2)
		{
			this.curFrame += Global.Settings.logicFrameStep;
			this.UpdateLocalFrameRandNum();
			this.UpdateLocalFrameCmd();
			if (this.mMainLogic != null)
			{
				this.mMainLogic.Update((int)FrameSync.logicUpdateStep);
			}
			this.fLocalUpdateAcc -= num2;
		}
		if (this.mMainLogic != null)
		{
			this.mMainLogic.UpdateGraphic((int)(Time.deltaTime * (float)GlobalLogic.VALUE_1000));
		}
	}

	// Token: 0x06018A9F RID: 101023 RVA: 0x007B308A File Offset: 0x007B148A
	public void UpdateReplayFrameGraphic(int delta)
	{
		if (this.mMainLogic != null)
		{
			this.mMainLogic.UpdateGraphic(delta);
		}
	}

	// Token: 0x06018AA0 RID: 101024 RVA: 0x007B30A4 File Offset: 0x007B14A4
	public void UpdateReplayFrame(int delta)
	{
		while (this.frameQueue.Count > 0)
		{
			IFrameCommand frameCommand = this.frameQueue.Peek();
			uint num = (frameCommand.GetFrame() + this.svrFrameLater) * this.keyFrameRate;
			if (num > this.curFrame)
			{
				break;
			}
			IFrameCommand frameCommand2 = this.frameQueue.Dequeue();
			if (frameCommand2 != null)
			{
				BaseFrameCommand baseFrameCommand = frameCommand2 as BaseFrameCommand;
				baseFrameCommand.battle = (BattleMain.instance.GetBattle() as BaseBattle);
				frameCommand2.ExecCommand();
			}
		}
		if (this.mMainLogic != null)
		{
			this.mMainLogic.Update(delta);
		}
	}

	// Token: 0x06018AA1 RID: 101025 RVA: 0x007B3144 File Offset: 0x007B1544
	protected void UpdateSyncFrame()
	{
		if (this.isGetStartFrame && this.mState != FrameSync.eFrameSyncState.onTick && this.mState != FrameSync.eFrameSyncState.onReconnect)
		{
			return;
		}
		int num = (int)Time.realtimeSinceStartup;
		if (FrameSync.preSec != num)
		{
			FrameSync.preSec = num;
		}
		this.driftFactor = 2;
		int num2 = (int)((this.endFrame - this.curFrame) / Global.Settings.drift);
		num2 = Mathf.Clamp(num2, (int)(2U / Global.Settings.logicFrameStep), 100);
		FrameSync.curframeNeedUpdate = num2;
		int i = num2;
		long num3 = (long)((Time.realtimeSinceStartup - this.timeStart) * (float)GlobalLogic.VALUE_1000 * this.frameSpeed);
		long nDelayMs = num3 - (long)(((ulong)(this.svrFrame / Global.Settings.logicFrameStep * Global.Settings.logicFrameStep) + (ulong)((long)FrameSync.logicFrameStepDelta)) * (ulong)this.svrFrameMs);
		int num4 = this.CalculateJitterDelay(nDelayMs);
		while (i > 0)
		{
			long num5 = (long)((ulong)(this.curFrame * this.svrFrameMs));
			long num6 = num3 - num5;
			num6 -= (long)num4;
			uint tickCount = (uint)Environment.TickCount;
			if (num6 >= (long)((ulong)this.frameMs))
			{
				if (this.endFrame == 0U || this.curFrame >= this.endFrame - Global.Settings.logicFrameStep + 1U)
				{
					i = 0;
				}
				else
				{
					this.curFrame += Global.Settings.logicFrameStep;
					this.UpdateSendChecksum();
					while (this.frameQueue.Count > 0)
					{
						IFrameCommand frameCommand = this.frameQueue.Peek();
						uint num7 = (frameCommand.GetFrame() + this.svrFrameLater) * this.keyFrameRate;
						if (num7 > this.curFrame)
						{
							break;
						}
						BaseFrameCommand baseFrameCommand = frameCommand as BaseFrameCommand;
						if (baseFrameCommand != null && baseFrameCommand.seat == ClientApplication.playerinfo.seat && baseFrameCommand.sendTime > 0U)
						{
							this.execCmdPerf.AddDelay(tickCount - baseFrameCommand.sendTime);
						}
						if (Singleton<RecordServer>.GetInstance().IsProcessRecord())
						{
							Singleton<RecordServer>.GetInstance().MarkString(142055430U, new string[]
							{
								frameCommand.GetString()
							});
						}
						IFrameCommand frameCommand2 = this.frameQueue.Dequeue();
						if (frameCommand2 != null)
						{
							BaseFrameCommand baseFrameCommand2 = frameCommand2 as BaseFrameCommand;
							baseFrameCommand2.battle = (BattleMain.instance.GetBattle() as BaseBattle);
							frameCommand2.ExecCommand();
						}
					}
					if (this.mMainLogic != null)
					{
						this.mMainLogic.Update((int)this.frameMs);
					}
					i--;
				}
			}
			else
			{
				i = 0;
			}
		}
		this.mMainLogic.UpdateGraphic((int)(Time.deltaTime * (float)GlobalLogic.VALUE_1000));
	}

	// Token: 0x06018AA2 RID: 101026 RVA: 0x007B33EC File Offset: 0x007B17EC
	public void UpdateFrame()
	{
		eDungeonMode eDungeonMode = this.mMode;
		if (eDungeonMode != eDungeonMode.LocalFrame && eDungeonMode != eDungeonMode.Test)
		{
			if (eDungeonMode == eDungeonMode.SyncFrame)
			{
				if (!Singleton<ReplayServer>.GetInstance().IsReplay())
				{
					this.UpdateSyncFrame();
				}
			}
		}
		else
		{
			this.UpdateLocalFrame();
		}
	}

	// Token: 0x04011C36 RID: 72758
	private static FrameSync s_instance;

	// Token: 0x04011C37 RID: 72759
	private eDungeonMode mMode = eDungeonMode.LocalFrame;

	// Token: 0x04011C38 RID: 72760
	private FrameSync.eFrameSyncState mState;

	// Token: 0x04011C39 RID: 72761
	private IDungeonManager mMainLogic;

	// Token: 0x04011C3A RID: 72762
	protected Queue<IFrameCommand> frameQueue = new Queue<IFrameCommand>();

	// Token: 0x04011C3B RID: 72763
	public uint curFrame;

	// Token: 0x04011C3C RID: 72764
	public uint endFrame;

	// Token: 0x04011C3D RID: 72765
	public uint frameMs;

	// Token: 0x04011C3E RID: 72766
	public uint svrFrame;

	// Token: 0x04011C3F RID: 72767
	public uint svrFrameMs;

	// Token: 0x04011C40 RID: 72768
	public int avgFrameDelay = 66;

	// Token: 0x04011C41 RID: 72769
	public int curFrameDelay;

	// Token: 0x04011C42 RID: 72770
	public int driftFactor;

	// Token: 0x04011C43 RID: 72771
	public float timeStart;

	// Token: 0x04011C44 RID: 72772
	public uint backupSvrFrame;

	// Token: 0x04011C45 RID: 72773
	public uint keyFrameRate = 1U;

	// Token: 0x04011C46 RID: 72774
	public uint serverSeed;

	// Token: 0x04011C47 RID: 72775
	public uint frameSpeed = 1U;

	// Token: 0x04011C48 RID: 72776
	public uint svrFrameLater;

	// Token: 0x04011C49 RID: 72777
	public bool logicLoaded;

	// Token: 0x04011C4A RID: 72778
	public uint lastSvrFrame;

	// Token: 0x04011C4B RID: 72779
	public FramePerformance recvCmdPerf = new FramePerformance();

	// Token: 0x04011C4C RID: 72780
	public FramePerformance execCmdPerf = new FramePerformance();

	// Token: 0x04011C4D RID: 72781
	private bool mIsGetStartFrame;

	// Token: 0x04011C4E RID: 72782
	public bool bInRunMode;

	// Token: 0x04011C4F RID: 72783
	public int nDegree;

	// Token: 0x04011C50 RID: 72784
	public bool bInMoveMode;

	// Token: 0x04011C51 RID: 72785
	public float fLocalUpdateAcc;

	// Token: 0x04011C52 RID: 72786
	public static uint logicUpdateStep = 32U;

	// Token: 0x04011C53 RID: 72787
	public static int logicFrameStepDelta;

	// Token: 0x04011C54 RID: 72788
	private float mLastTimeDifference;

	// Token: 0x04011C55 RID: 72789
	public static int sendCount;

	// Token: 0x04011C56 RID: 72790
	public static int preSec;

	// Token: 0x04011C57 RID: 72791
	public bool isFire = true;

	// Token: 0x04011C58 RID: 72792
	private float timepre;

	// Token: 0x04011C59 RID: 72793
	private List<_inputData> inputdatas = new List<_inputData>();

	// Token: 0x04011C5A RID: 72794
	private const int cFrameMin = 2;

	// Token: 0x04011C5B RID: 72795
	private static int curframeNeedUpdate;

	// Token: 0x04011C5C RID: 72796
	private uint mLastTimeScaler = 1U;

	// Token: 0x02004532 RID: 17714
	public enum eFrameSyncState
	{
		// Token: 0x04011C5E RID: 72798
		onCreate,
		// Token: 0x04011C5F RID: 72799
		onStart,
		// Token: 0x04011C60 RID: 72800
		onTick,
		// Token: 0x04011C61 RID: 72801
		onReconnect,
		// Token: 0x04011C62 RID: 72802
		onEnd
	}
}
