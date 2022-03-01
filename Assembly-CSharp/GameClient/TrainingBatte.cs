using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045C8 RID: 17864
	public class TrainingBatte : BaseBattle
	{
		// Token: 0x06019173 RID: 102771 RVA: 0x007ECAF0 File Offset: 0x007EAEF0
		public TrainingBatte(BattleType type, eDungeonMode mode, int id) : base(type, eDungeonMode.LocalFrame, 0)
		{
			if (Global.Settings.startSystem == EClientSystem.Battle)
			{
				this.mDungeonManager.GetDungeonDataManager().asset.GetAreaConnectList(0).SetSceneAreaPath(Global.Settings.scenePath);
				this.mDungeonManager.GetDungeonDataManager().asset.GetAreaConnectList(0).SetSceneData(DungeonUtility.LoadSceneData(Global.Settings.scenePath));
			}
		}

		// Token: 0x06019174 RID: 102772 RVA: 0x007ECB68 File Offset: 0x007EAF68
		protected override void _createPlayers()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			RacePlayerInfo playerInfo = this.mDungeonPlayers.GetMainPlayer().playerInfo;
			Dictionary<int, int> skillInfo = BattlePlayer.GetSkillInfo(playerInfo);
			List<ItemProperty> equips = BattlePlayer.GetEquips(playerInfo, true);
			List<ItemProperty> sideEquips = BattlePlayer.GetSideEquips(playerInfo, true);
			if (Global.Settings.startSystem == EClientSystem.Battle)
			{
				skillInfo = Singleton<TableManager>.GetInstance().GetSkillInfoByPid((int)playerInfo.occupation);
			}
			else
			{
				skillInfo = DataManager<SkillDataManager>.GetInstance().GetSkillInfo(BattleMain.IsModePvP(BattleMain.battleType), SkillSystemSourceType.None);
			}
			Dictionary<int, string> avatar = BattlePlayer.GetAvatar(playerInfo);
			bool isShowWeapon = playerInfo.avatar.isShoWeapon == 1;
			bool isAIRobot = playerInfo.robotAIType > 0;
			BeActor beActor = beScene.CreateCharacter(true, (int)playerInfo.occupation, (int)playerInfo.level, (int)playerInfo.seat, skillInfo, equips, null, 0, string.Empty, 0, null, null, sideEquips, avatar, isShowWeapon, isAIRobot);
			beActor.InitChangeEquipData(playerInfo.equips, playerInfo.equipScheme);
			beActor.skillSlotMap = BattlePlayer.GetSkillSlotMap(playerInfo);
			beActor.SetPosition(this.mDungeonManager.GetDungeonDataManager().GetBirthPosition(), false, true, false);
			beActor.isLocalActor = true;
			playerInfo.name = "测试玩家";
			beActor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.PK_PLAYER, playerInfo.level, null, 0f);
			beActor.m_pkGeActor.AddTittleComponent(DataManager<PlayerBaseData>.GetInstance().GetTitleID(), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.PK_PLAYER, string.Empty, null, 0, 0);
			beActor.isMainActor = true;
			beActor.UseProtect();
			beActor.UseActorData();
			if (beActor.m_pkGeActor != null)
			{
				beActor.m_pkGeActor.AddSimpleShadow(Vector3.one);
			}
			this.mDungeonPlayers.GetMainPlayer().playerActor = beActor;
			this.mDungeonManager.GetGeScene().AttachCameraTo(beActor.m_pkGeActor);
		}
	}
}
