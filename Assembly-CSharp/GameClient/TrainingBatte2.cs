using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045C9 RID: 17865
	public class TrainingBatte2 : BaseBattle
	{
		// Token: 0x06019175 RID: 102773 RVA: 0x007ECD4B File Offset: 0x007EB14B
		public TrainingBatte2(BattleType type, eDungeonMode mode, int id) : base(type, eDungeonMode.LocalFrame, id)
		{
		}

		// Token: 0x06019176 RID: 102774 RVA: 0x007ECD56 File Offset: 0x007EB156
		private void CreateMainPlayer()
		{
		}

		// Token: 0x06019177 RID: 102775 RVA: 0x007ECD58 File Offset: 0x007EB158
		public void RecreatePlayers()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			bool removeMechanismFlag = BeClientSwitch.FunctionIsOpen(ClientSwitchType.TrainRemoveMechanism);
			beScene.ClearAllEntity(removeMechanismFlag);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
			{
				this._createPlayers();
				base._reLoadSkillButton();
				this._ResetSyncPlayerData();
			}, 0, 0, false);
		}

		// Token: 0x06019178 RID: 102776 RVA: 0x007ECDA4 File Offset: 0x007EB1A4
		protected override void _createPlayers()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				RacePlayerInfo playerInfo = allPlayers[i].playerInfo;
				Dictionary<int, int> skillInfo = BattlePlayer.GetSkillInfo(playerInfo);
				List<ItemProperty> equips = BattlePlayer.GetEquips(playerInfo, true);
				List<ItemProperty> sideEquips = BattlePlayer.GetSideEquips(playerInfo, true);
				int weaponStrengthenLevel;
				if (i == 0)
				{
					weaponStrengthenLevel = DataManager<PlayerBaseData>.GetInstance().GetWeaponStrengthenLevel();
				}
				else
				{
					weaponStrengthenLevel = BattlePlayer.GetWeaponStrengthenLevel(playerInfo);
				}
				Dictionary<int, string> avatar = new Dictionary<int, string>();
				if (i == 0)
				{
					avatar = DataManager<PlayerBaseData>.GetInstance().GetAvatar();
				}
				else
				{
					avatar = BattlePlayer.GetAvatar(playerInfo);
				}
				bool isShowWeapon;
				if (i == 0)
				{
					isShowWeapon = (DataManager<PlayerBaseData>.GetInstance().avatar.isShoWeapon == 1);
				}
				else
				{
					isShowWeapon = (playerInfo.avatar.isShoWeapon == 1);
				}
				BeActor actor = null;
				PetData petData = null;
				if (i == 0)
				{
					petData = DataManager<PlayerBaseData>.GetInstance().GetPetData(true);
					actor = beScene.CreateCharacter(true, (int)playerInfo.occupation, (int)playerInfo.level, (int)playerInfo.seat, DataManager<SkillDataManager>.GetInstance().GetSkillInfo(BattleMain.IsModePvP(BattleMain.battleType), SkillSystemSourceType.None), DataManager<PlayerBaseData>.GetInstance().GetEquipedEquipments(), null, 0, string.Empty, weaponStrengthenLevel, DataManager<PlayerBaseData>.GetInstance().GetRankBuff(), petData, DataManager<PlayerBaseData>.GetInstance().GetSideEquipments(), avatar, isShowWeapon, false);
				}
				else
				{
					actor = beScene.CreateCharacter(false, (int)playerInfo.occupation, (int)playerInfo.level, (int)playerInfo.seat, skillInfo, equips, null, 0, string.Empty, weaponStrengthenLevel, null, null, sideEquips, avatar, isShowWeapon, true);
					if (playerInfo.robotAIType > 0)
					{
						this.InitAIForRobot(actor, (int)playerInfo.robotAIType, (int)playerInfo.robotHard);
					}
				}
				actor.InitChangeEquipData(playerInfo.equips, playerInfo.equipScheme);
				actor.skillSlotMap = BattlePlayer.GetSkillSlotMap(playerInfo);
				allPlayers[i].playerActor = actor;
				VInt3 rkPos = new VInt3((i != 0) ? 30000 : -30000, 0, 0);
				actor.SetPosition(rkPos, true, true, false);
				actor.SetFace(i != 0, false, false);
				actor.m_iRemoveTime = 120000;
				if (playerInfo.accid == ClientApplication.playerinfo.accid)
				{
					actor.isLocalActor = true;
					actor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.PK_PLAYER, playerInfo.level, null, 0f);
					actor.m_pkGeActor.CreatePKHPBar(CPKHPBar.PKBarType.Left, playerInfo.name, PlayerInfoColor.PK_PLAYER);
					actor.m_pkGeActor.AddTittleComponent(DataManager<PlayerBaseData>.GetInstance().GetTitleID(), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.PK_PLAYER, string.Empty, null, 0, 0);
				}
				else
				{
					actor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.PK_OTHER_PLAYER, playerInfo.level, null, 0f);
					actor.m_pkGeActor.CreatePKHPBar(CPKHPBar.PKBarType.Right, playerInfo.name, PlayerInfoColor.PK_OTHER_PLAYER);
					actor.m_pkGeActor.AddTittleComponent(0, playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.PK_OTHER_PLAYER, string.Empty, null, 0, 0);
					actor.m_pkGeActor.CreateFootIndicator(null);
					actor.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
					{
						if (actor.GetEntityData().GetHP() <= 100)
						{
							actor.SetIsDead(false);
							actor.GetEntityData().SetHP(actor.GetEntityData().GetMaxHP());
							actor.m_pkGeActor.ResetHPBar();
						}
					});
				}
				actor.GetEntityData().AdjustHPForPvP((int)playerInfo.level, (int)playerInfo.level, 1, 1, 0);
				if (actor.m_pkGeActor != null)
				{
					actor.m_pkGeActor.AddSimpleShadow(Vector3.one);
				}
				actor.isMainActor = true;
				actor.UseProtect();
				actor.UseActorData();
				actor.UseAdjustBalance();
				if (playerInfo.accid == ClientApplication.playerinfo.accid)
				{
					if (petData != null)
					{
						actor.SetPetData(petData);
					}
					actor.CreateFollowMonster();
				}
			}
			this.mDungeonManager.GetGeScene().AttachCameraTo(this.mDungeonPlayers.GetMainPlayer().playerActor.m_pkGeActor);
		}

		// Token: 0x06019179 RID: 102777 RVA: 0x007ED230 File Offset: 0x007EB630
		private void InitAIForRobot(BeActor actor, int aiLevel, int matchNum = 0)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AIConfigTable>();
			AIConfigTable aiconfigTable = null;
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				AIConfigTable aiconfigTable2 = keyValuePair.Value as AIConfigTable;
				if (aiconfigTable2.JobID == actor.GetEntityData().professtion && aiconfigTable2.AIType == aiLevel)
				{
					aiconfigTable = aiconfigTable2;
				}
			}
			actor.isPkRobot = true;
			if (aiconfigTable != null)
			{
				actor.InitAutoFight(aiconfigTable.AIActionPath, aiconfigTable.AIDestinationSelectPath, aiconfigTable.AIEventPath, aiconfigTable.AIAttackDelay, aiconfigTable.AIDestinationChangeTerm, aiconfigTable.AIThinkTargetTerm, aiconfigTable.AIKeepDistance, true);
				actor.delayCaller.DelayCall(2000, delegate
				{
					actor.pauseAI = false;
				}, 0, 0, false);
			}
			else
			{
				Logger.LogErrorFormat("找不到机器人AI难度:{0}", new object[]
				{
					aiLevel
				});
			}
		}

		// Token: 0x0601917A RID: 102778 RVA: 0x007ED360 File Offset: 0x007EB760
		private void _ResetSyncPlayerData()
		{
			if (!BattleMain.IsModeTrain(BattleMain.battleType))
			{
				return;
			}
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor.isLocalActor)
				{
					playerActor.hasDoublePress = Global.Settings.hasDoubleRun;
					playerActor.hasRunAttackConfig = (Singleton<SettingManager>.GetInstance().GetRunAttackMode() == InputManager.RunAttackMode.QTE);
					string key = (!BattleMain.IsModePvP(base.GetBattleType())) ? "STR_CHASER_PVE" : "STR_CHASER_PVP";
					byte chaserSwitch = (byte)Singleton<SettingManager>.GetInstance().GetChaserSetting(key);
					playerActor.chaserSwitch = chaserSwitch;
					playerActor.XuanWuManualAttack = (Singleton<SettingManager>.GetInstance().GetSlideMode("3612") == InputManager.SlideSetting.SLIDE);
					playerActor.floatShotSwitch = (Singleton<SettingManager>.GetInstance().GetSlideMode("1006") == InputManager.SlideSetting.SLIDE);
					playerActor.headShotSwitch = (Singleton<SettingManager>.GetInstance().GetSlideMode("1104") == InputManager.SlideSetting.SLIDE);
				}
			}
		}
	}
}
