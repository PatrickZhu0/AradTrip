using System;
using System.Collections;
using System.Collections.Generic;
using Battle;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045CB RID: 17867
	public class TrainingSkillComboBattle : BaseBattle
	{
		// Token: 0x0601918B RID: 102795 RVA: 0x007EDD97 File Offset: 0x007EC197
		public TrainingSkillComboBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x0601918C RID: 102796 RVA: 0x007EDDA4 File Offset: 0x007EC1A4
		protected override void _createPlayers()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			this._prepareDebugData();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				RacePlayerInfo playerInfo = allPlayers[i].playerInfo;
				BeActor beActor = beScene.CreateCharacter(true, (int)playerInfo.occupation, (int)playerInfo.level, (int)playerInfo.seat, BattlePlayer.GetSkillInfo(playerInfo), BattlePlayer.GetEquips(playerInfo, false), null, 0, null, 0, null, null, null, DataManager<PlayerBaseData>.GetInstance().GetAvatar(), false, false);
				beActor.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
				{
					int skill = (int)args[0];
					this._onPlayerUseSkill(skill);
				});
				beActor.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
				{
					int skillID = (int)args[2];
					int id = 0;
					if (args.Length >= 5)
					{
						id = (int)args[4];
					}
					this._onPlayerHitOther(skillID, id);
				});
				allPlayers[i].playerActor = beActor;
				beActor.InitChangeEquipData(playerInfo.equips, playerInfo.equipScheme);
				beActor.SetPosition(dungeonDataManager.GetBirthPosition(), true, true, false);
				beActor.m_iRemoveTime = int.MaxValue;
				if (playerInfo.accid == ClientApplication.playerinfo.accid)
				{
					beActor.isLocalActor = true;
					beActor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.PK_PLAYER, playerInfo.level, null, 0f);
					beActor.m_pkGeActor.AddTittleComponent((int)DataManager<PlayerBaseData>.GetInstance().iTittle, playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.PK_PLAYER, string.Empty, null, 0, 0);
				}
				if (beActor.m_pkGeActor != null)
				{
					beActor.m_pkGeActor.AddSimpleShadow(Vector3.one);
				}
				beActor.isMainActor = true;
				beActor.UseProtect();
				beActor.UseActorData();
				beActor.UseAdjustBalance();
			}
			this.mDungeonManager.GetGeScene().AttachCameraTo(this.mDungeonPlayers.GetMainPlayer().playerActor.m_pkGeActor);
		}

		// Token: 0x0601918D RID: 102797 RVA: 0x007EDF90 File Offset: 0x007EC390
		public void RecreatePlayer()
		{
			if (this.mDungeonManager == null)
			{
				return;
			}
			BeScene beScene = this.mDungeonManager.GetBeScene();
			beScene.ClearAllEntity(false);
			this._createEntitys();
			this.mInputManager.SetVisible(true);
			this.mInputManager.ReloadButtons(this.mDungeonPlayers.GetMainPlayer().playerActor.professionID, this.mDungeonPlayers.GetMainPlayer().playerActor, this.GetSlot(), false);
		}

		// Token: 0x0601918E RID: 102798 RVA: 0x007EE005 File Offset: 0x007EC405
		protected sealed override void _onSceneStart()
		{
			this.mDungeonManager.GetBeScene().isUseBossShow = false;
			this.mDungeonManager.GetBeScene().SetTraceDoor(false);
		}

		// Token: 0x0601918F RID: 102799 RVA: 0x007EE029 File Offset: 0x007EC429
		protected override void _onStart()
		{
		}

		// Token: 0x06019190 RID: 102800 RVA: 0x007EE02B File Offset: 0x007EC42B
		protected override void _createDoors()
		{
		}

		// Token: 0x06019191 RID: 102801 RVA: 0x007EE02D File Offset: 0x007EC42D
		protected override void _onDoorStateChange(object[] arg)
		{
		}

		// Token: 0x06019192 RID: 102802 RVA: 0x007EE02F File Offset: 0x007EC42F
		protected override void _onAreaClear(object[] args)
		{
		}

		// Token: 0x06019193 RID: 102803 RVA: 0x007EE031 File Offset: 0x007EC431
		protected override void _onEnd()
		{
			base._onEnd();
			Singleton<SkillComboControl>.instance.SetEndBattle();
		}

		// Token: 0x06019194 RID: 102804 RVA: 0x007EE043 File Offset: 0x007EC443
		protected void _onPlayerUseSkill(int skill)
		{
			if (this.UseSkillCallBack != null)
			{
				this.UseSkillCallBack(skill);
			}
		}

		// Token: 0x06019195 RID: 102805 RVA: 0x007EE05C File Offset: 0x007EC45C
		protected virtual void _onPlayerHitOther(int skillID, int id)
		{
			if (this.playerHitCallBack != null)
			{
				this.playerHitCallBack(skillID, id);
			}
		}

		// Token: 0x06019196 RID: 102806 RVA: 0x007EE076 File Offset: 0x007EC476
		public void EndInstitueTrain()
		{
			if (this.hasSend)
			{
				return;
			}
			this.hasSend = true;
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sendDungeonRaceEndReqIter());
		}

		// Token: 0x06019197 RID: 102807 RVA: 0x007EE09C File Offset: 0x007EC49C
		private IEnumerator _sendDungeonRaceEndReqIter()
		{
			yield return this._sendDungeonReportDataIter();
			MessageEvents msgEvent = new MessageEvents();
			SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes();
			SceneDungeonRaceEndReq req = this._getDungeonRaceEndReq();
			yield return base._sendMsgWithResend<SceneDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.GATE_SERVER, msgEvent, req, res, true, 2f, 3, 3);
			if (msgEvent.IsAllMessageReceived())
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<InstituteFinishFrame>(FrameLayer.Middle, base.dungeonManager, string.Empty);
			}
			yield break;
		}

		// Token: 0x06019198 RID: 102808 RVA: 0x007EE0B8 File Offset: 0x007EC4B8
		protected IEnumerator _sendDungeonReportDataIter()
		{
			if (base.GetMode() == eDungeonMode.LocalFrame)
			{
				if (this.mDungeonManager == null)
				{
					yield break;
				}
				if (this.mDungeonManager.GetDungeonDataManager() == null)
				{
					yield break;
				}
				this.mDungeonManager.GetDungeonDataManager().PushFinalFrameData();
				this.mDungeonManager.GetDungeonDataManager().SendWorldDungeonReportFrame();
				yield return null;
				while (!this.mDungeonManager.GetDungeonDataManager().IsAllReportDataServerRecived())
				{
					yield return null;
				}
				this.mDungeonManager.GetDungeonDataManager().UnlockUpdateCheck();
			}
			yield break;
		}

		// Token: 0x06019199 RID: 102809 RVA: 0x007EE0D4 File Offset: 0x007EC4D4
		protected SceneDungeonRaceEndReq _getDungeonRaceEndReq()
		{
			if (this.mDungeonPlayers == null || this.mDungeonStatistics == null)
			{
				return null;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			uint lastFrame = 0U;
			uint lastChecksum = 0U;
			base.GetFinalFrameInfo(ref lastFrame, ref lastChecksum);
			SceneDungeonRaceEndReq sceneDungeonRaceEndReq = new SceneDungeonRaceEndReq
			{
				beHitCount = (ushort)this.mDungeonStatistics.HitCount(mainPlayer.playerInfo.seat),
				usedTime = (uint)this.mDungeonStatistics.AllFightTime(true),
				score = (byte)this.mDungeonStatistics.FinalDungeonScore(),
				maxDamage = this.mDungeonStatistics.GetAllMaxHurtDamage(),
				skillId = this.mDungeonStatistics.GetAllMaxHurtSkillID(),
				param = this.mDungeonStatistics.GetAllMaxHurtID(),
				totalDamage = this.mDungeonStatistics.GetAllHurtDamage(),
				lastFrame = lastFrame,
				lastChecksum = lastChecksum
			};
			sceneDungeonRaceEndReq.md5 = DungeonUtility.GetBattleEncryptMD5(string.Format("{0}{1}{2}", sceneDungeonRaceEndReq.score, sceneDungeonRaceEndReq.beHitCount, sceneDungeonRaceEndReq.usedTime));
			return sceneDungeonRaceEndReq;
		}

		// Token: 0x0601919A RID: 102810 RVA: 0x007EE1F0 File Offset: 0x007EC5F0
		protected override void _onPostStart()
		{
			if (this.mInputManager != null && this.mDungeonPlayers != null && base.dungeonManager != null)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<InstituteBattleFrame>(FrameLayer.Middle, null, string.Empty);
				this.mInputManager.ReloadButtons(this.mDungeonPlayers.GetMainPlayer().playerActor.professionID, this.mDungeonPlayers.GetMainPlayer().playerActor, this.GetSlot(), false);
				BeDungeon beDungeon = base.dungeonManager as BeDungeon;
				if (beDungeon != null && beDungeon.GetDungeonDataManager() != null)
				{
					Singleton<SkillComboControl>.instance.Init(beDungeon, beDungeon.GetDungeonDataManager().id.dungeonID);
				}
			}
		}

		// Token: 0x0601919B RID: 102811 RVA: 0x007EE2A0 File Offset: 0x007EC6A0
		public Dictionary<int, int> GetSlot()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			if (this.teachData == null)
			{
				return dictionary;
			}
			dictionary.Add(1, this.mInputManager.GetLocalSlotMap()[1]);
			dictionary.Add(2, -1);
			dictionary.Add(3, -1);
			for (int i = 0; i < this.teachData.datas.Length; i++)
			{
				ComboData comboData = this.teachData.datas[i];
				if (comboData.skillSlot != -1)
				{
					BeSkill skill = BattleMain.instance.GetLocalPlayer(0UL).playerActor.GetSkill(comboData.skillID);
					if (skill != null)
					{
						if (skill.comboSkillSourceID != 0)
						{
							dictionary[comboData.skillSlot] = skill.comboSkillSourceID;
						}
						else
						{
							dictionary[comboData.skillSlot] = comboData.skillID;
						}
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0601919C RID: 102812 RVA: 0x007EE384 File Offset: 0x007EC784
		public void ModifyPlayerInfo(RacePlayerInfo info)
		{
			InstituteTable dataByDungeonID = Singleton<TableManager>.instance.GetDataByDungeonID((int)info.occupation, base.dungeonManager.GetDungeonDataManager().id.dungeonID);
			if (dataByDungeonID != null)
			{
				info.equips = new RaceEquip[dataByDungeonID.EquipmentID.Count];
				for (int i = 0; i < dataByDungeonID.EquipmentID.Count; i++)
				{
					info.equips[i] = new RaceEquip();
					info.equips[i].id = (uint)dataByDungeonID.EquipmentID[i];
					if (i == 0)
					{
						info.equips[i].phyAtk = 1000U;
						info.equips[i].magAtk = 1000U;
						info.equips[i].strengthen = 15;
					}
				}
			}
			info.raceItems = new RaceItem[]
			{
				new RaceItem
				{
					id = 300000105U,
					num = ushort.MaxValue
				},
				new RaceItem
				{
					id = 300000106U,
					num = ushort.MaxValue
				}
			};
		}

		// Token: 0x0601919D RID: 102813 RVA: 0x007EE49C File Offset: 0x007EC89C
		private void _prepareDebugData()
		{
			this.LoadComboData();
			RacePlayerInfo racePlayerInfo = null;
			for (int i = 0; i < DataManager<BattleDataManager>.GetInstance().PlayerInfo.Length; i++)
			{
				RacePlayerInfo racePlayerInfo2 = DataManager<BattleDataManager>.GetInstance().PlayerInfo[i];
				if (racePlayerInfo2.accid == ClientApplication.playerinfo.accid)
				{
					racePlayerInfo = racePlayerInfo2;
				}
			}
			if (racePlayerInfo != null)
			{
				this.ModifyPlayerInfo(racePlayerInfo);
				racePlayerInfo.skills = this.GetRceSkillInfo((int)racePlayerInfo.occupation);
			}
		}

		// Token: 0x0601919E RID: 102814 RVA: 0x007EE514 File Offset: 0x007EC914
		protected override void _createMonsters()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonMonster> monsters = dungeonDataManager.CurrentMonsters();
			int num = beScene.CreateMonsterList(monsters, dungeonDataManager.IsBossArea(), dungeonDataManager.GetBirthPosition(), true);
		}

		// Token: 0x0601919F RID: 102815 RVA: 0x007EE558 File Offset: 0x007EC958
		private RaceSkillInfo[] GetRceSkillInfo(int jobID)
		{
			List<RaceSkillInfo> list = new List<RaceSkillInfo>();
			if (this.teachData == null)
			{
				return null;
			}
			for (int i = 0; i < this.teachData.datas.Length; i++)
			{
				ComboData data = this.teachData.datas[i];
				RaceSkillInfo raceSkillInfo = list.Find((RaceSkillInfo x) => (int)x.id == data.skillID);
				if (raceSkillInfo == null)
				{
					list.Add(new RaceSkillInfo
					{
						id = (ushort)data.skillID,
						level = (byte)data.skillLevel,
						slot = (byte)data.skillSlot
					});
				}
			}
			return list.ToArray();
		}

		// Token: 0x060191A0 RID: 102816 RVA: 0x007EE621 File Offset: 0x007ECA21
		private void LoadComboData()
		{
			this.teachData = Singleton<TableManager>.instance.GetComboData(base.dungeonManager.GetDungeonDataManager().id.dungeonID);
		}

		// Token: 0x060191A1 RID: 102817 RVA: 0x007EE648 File Offset: 0x007ECA48
		public bool IsLastCombo(int id)
		{
			if (this.teachData == null)
			{
				return false;
			}
			int num = 0;
			for (int i = 0; i < this.teachData.datas.Length; i++)
			{
				if (this.teachData.datas[i].skillGroupID >= num)
				{
					num = this.teachData.datas[i].skillGroupID;
				}
			}
			return id == num;
		}

		// Token: 0x060191A2 RID: 102818 RVA: 0x007EE6BD File Offset: 0x007ECABD
		public ComboData GetComboData(int index)
		{
			if (this.teachData == null)
			{
				return null;
			}
			return this.teachData.datas[index];
		}

		// Token: 0x04011FF3 RID: 73715
		public Action<int> UseSkillCallBack;

		// Token: 0x04011FF4 RID: 73716
		public Action<int, int> playerHitCallBack;

		// Token: 0x04011FF5 RID: 73717
		private bool hasSend;

		// Token: 0x04011FF6 RID: 73718
		public ComboTeachData teachData;
	}
}
