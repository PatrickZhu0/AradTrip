using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045CA RID: 17866
	public class TrainingPVEBattle : PVEBattle
	{
		// Token: 0x0601917C RID: 102780 RVA: 0x007ED4F2 File Offset: 0x007EB8F2
		public TrainingPVEBattle(BattleType type, eDungeonMode mode, int id) : base(type, eDungeonMode.LocalFrame, id)
		{
		}

		// Token: 0x0601917D RID: 102781 RVA: 0x007ED514 File Offset: 0x007EB914
		protected override void _createPlayers()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				RacePlayerInfo playerInfo = allPlayers[i].playerInfo;
				Dictionary<int, int> skillInfo = BattlePlayer.GetSkillInfo(playerInfo);
				List<ItemProperty> equips = BattlePlayer.GetEquips(playerInfo, false);
				List<ItemProperty> sideEquips = BattlePlayer.GetSideEquips(playerInfo, false);
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
				BeActor beActor = null;
				PetData petData = null;
				if (i == 0)
				{
					petData = DataManager<PlayerBaseData>.GetInstance().GetPetData(false);
					beActor = beScene.CreateCharacter(true, (int)playerInfo.occupation, (int)playerInfo.level, (int)playerInfo.seat, DataManager<SkillDataManager>.GetInstance().GetSkillInfo(BattleMain.IsModePvP(BattleMain.battleType), SkillSystemSourceType.None), DataManager<PlayerBaseData>.GetInstance().GetEquipedEquipments(), null, 0, string.Empty, weaponStrengthenLevel, DataManager<PlayerBaseData>.GetInstance().GetRankBuff(), petData, DataManager<PlayerBaseData>.GetInstance().GetSideEquipments(), avatar, isShowWeapon, false);
					base.InitAutoFight(beActor);
					beActor.skillDamageManager.InitData(beScene);
				}
				beActor.InitTrainingPveBattleData();
				beActor.skillSlotMap = BattlePlayer.GetSkillSlotMap(playerInfo);
				allPlayers[i].playerActor = beActor;
				VInt3 rkPos = new VInt3((i != 0) ? 30000 : -30000, 0, 0);
				beActor.SetPosition(rkPos, true, true, false);
				beActor.SetFace(i != 0, false, false);
				beActor.m_iRemoveTime = 120000;
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
				beActor.UseActorData();
				if (playerInfo.accid == ClientApplication.playerinfo.accid)
				{
					if (petData != null)
					{
						beActor.SetPetData(petData);
					}
					beActor.CreateFollowMonster();
				}
			}
			this.mDungeonManager.GetGeScene().AttachCameraTo(this.mDungeonPlayers.GetMainPlayer().playerActor.m_pkGeActor);
		}

		// Token: 0x0601917E RID: 102782 RVA: 0x007ED803 File Offset: 0x007EBC03
		public void Init()
		{
			this.mainFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<TrainingPveFrame>(FrameLayer.Middle, null, string.Empty) as TrainingPveFrame);
			if (this.mainFrame != null)
			{
				this.mainFrame.InitUserData(this);
			}
		}

		// Token: 0x0601917F RID: 102783 RVA: 0x007ED838 File Offset: 0x007EBC38
		protected override void _onUpdate(int delta)
		{
			base._onUpdate(delta);
			this.CheckMonsterExist();
		}

		// Token: 0x06019180 RID: 102784 RVA: 0x007ED848 File Offset: 0x007EBC48
		public void ResetAllCD()
		{
			BeActor mainActor = this.GetMainActor();
			if (mainActor == null)
			{
				return;
			}
			mainActor.ResetSkillCoolDown();
			BeActor pet = mainActor.pet;
			if (pet != null)
			{
				pet.ResetSkillCoolDown();
			}
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.ResetChangeEquipCD();
				clientSystemBattle.ResetChangeWeaponCD();
			}
			mainActor.TriggerEvent(BeEventType.onTrainingPveResetSkillCD, null);
			mainActor.buffController.TryAddBuff(811042, 1, 1);
		}

		// Token: 0x06019181 RID: 102785 RVA: 0x007ED8C0 File Offset: 0x007EBCC0
		public BeActor SummonMonster()
		{
			if (this.GetMonsterCount() >= 5)
			{
				SystemNotifyManager.SysNotifyTextAnimation("召唤数量已达上限，无法召唤", CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				return null;
			}
			BeActor mainActor = this.GetMainActor();
			if (mainActor == null)
			{
				return null;
			}
			if (this.mainFrame == null)
			{
				return null;
			}
			TrainingPveMonsterData data = this.mainFrame.GetSummonMonsterData();
			int monsterId = data.monsterId;
			BeScene currentBeScene = mainActor.CurrentBeScene;
			if (currentBeScene == null)
			{
				return null;
			}
			BeActor monster = currentBeScene.SummonMonster(data.monsterId + data.level * 100, mainActor.GetPosition(), 1, null, false, 0, true, 0, false, false);
			if (monster == null)
			{
				return null;
			}
			monster.m_pkGeActor.goFootInfo.CustomActive(false);
			if (data.isBati)
			{
				monster.buffController.TryAddBuff(1, int.MaxValue, 1);
			}
			if (data.abnormalId != 0)
			{
				monster.delayCaller.DelayCall(1050, delegate
				{
					if (monster != null && !monster.IsDead())
					{
						monster.buffController.TryAddBuff(data.abnormalId, int.MaxValue, 60);
					}
				}, 0, 0, false);
			}
			this.monsterList.Add(monster);
			return monster;
		}

		// Token: 0x06019182 RID: 102786 RVA: 0x007EDA00 File Offset: 0x007EBE00
		public void ChangeMainActorBuff(int index, int attType)
		{
			BeActor mainActor = this.GetMainActor();
			if (mainActor == null)
			{
				return;
			}
			if (this.mainFrame == null)
			{
				return;
			}
			int num = 0;
			if (this.addBuffIdArr[attType] != 0)
			{
				mainActor.buffController.RemoveBuff(this.addBuffIdArr[attType], 0, 0);
			}
			if (index == 0)
			{
				return;
			}
			switch (attType)
			{
			case 0:
				num = this.mainFrame.critBuffIdArr[index - 1];
				break;
			case 1:
				num = this.mainFrame.staAddBuffIdArr[index - 1];
				break;
			case 2:
				num = this.mainFrame.attAddBuffIdArr[index - 1];
				break;
			case 3:
				num = this.mainFrame.speedAddBuffIdArr[index - 1];
				break;
			}
			if (num != 0)
			{
				mainActor.buffController.TryAddBuff(num, int.MaxValue, 1);
				this.addBuffIdArr[attType] = num;
			}
		}

		// Token: 0x06019183 RID: 102787 RVA: 0x007EDAE4 File Offset: 0x007EBEE4
		public void ChangeActorHitRate(bool value)
		{
			BeActor mainActor = this.GetMainActor();
			if (mainActor == null)
			{
				return;
			}
			if (value)
			{
				mainActor.buffController.TryAddBuff(811041, int.MaxValue, 1);
			}
			else
			{
				mainActor.buffController.RemoveBuff(811041, 0, 0);
			}
		}

		// Token: 0x06019184 RID: 102788 RVA: 0x007EDB34 File Offset: 0x007EBF34
		public void ChangeActorBroken(bool value)
		{
			BeActor mainActor = this.GetMainActor();
			if (mainActor == null)
			{
				return;
			}
			mainActor.absoluteBroken = value;
		}

		// Token: 0x06019185 RID: 102789 RVA: 0x007EDB58 File Offset: 0x007EBF58
		private BeActor GetMainActor()
		{
			if (BattleMain.instance == null || BattleMain.instance.GetPlayerManager() == null || BattleMain.instance.GetPlayerManager().GetMainPlayer() == null)
			{
				return null;
			}
			return BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor;
		}

		// Token: 0x06019186 RID: 102790 RVA: 0x007EDBAA File Offset: 0x007EBFAA
		public void ReturnToTown()
		{
			if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
			{
				Singleton<RecordServer>.GetInstance().EndRecord("DoBack");
			}
			BeUtility.ResetCamera();
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x06019187 RID: 102791 RVA: 0x007EDBE0 File Offset: 0x007EBFE0
		private int GetMonsterCount()
		{
			int num = 0;
			if (this.monsterList == null)
			{
				return num;
			}
			for (int i = 0; i < this.monsterList.Count; i++)
			{
				if (this.monsterList[i] != null && !this.monsterList[i].IsDead())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06019188 RID: 102792 RVA: 0x007EDC4C File Offset: 0x007EC04C
		public void DeleteAllMonster()
		{
			if (this.monsterList == null)
			{
				return;
			}
			for (int i = 0; i < this.monsterList.Count; i++)
			{
				if (this.monsterList[i] != null && !this.monsterList[i].IsDead())
				{
					this.monsterList[i].DoDead(false);
				}
			}
			this.PauseTiming();
		}

		// Token: 0x06019189 RID: 102793 RVA: 0x007EDCC8 File Offset: 0x007EC0C8
		private void CheckMonsterExist()
		{
			if (this.monsterList == null)
			{
				return;
			}
			for (int i = 0; i < this.monsterList.Count; i++)
			{
				if (!this.monsterList[i].IsDead())
				{
					return;
				}
			}
			this.PauseTiming();
		}

		// Token: 0x0601918A RID: 102794 RVA: 0x007EDD1C File Offset: 0x007EC11C
		private void PauseTiming()
		{
			BeActor mainActor = this.GetMainActor();
			if (mainActor == null)
			{
				return;
			}
			if (mainActor.skillDamageManager == null)
			{
				return;
			}
			mainActor.skillDamageManager.SetTimingFlag(false);
		}

		// Token: 0x04011FEF RID: 73711
		private TrainingPveFrame mainFrame;

		// Token: 0x04011FF0 RID: 73712
		private int[] addBuffIdArr = new int[4];

		// Token: 0x04011FF1 RID: 73713
		private int monsterCount;

		// Token: 0x04011FF2 RID: 73714
		private List<BeActor> monsterList = new List<BeActor>();
	}
}
