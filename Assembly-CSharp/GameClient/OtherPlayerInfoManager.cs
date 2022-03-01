using System;
using System.Collections.Generic;
using GamePool;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020045A3 RID: 17827
	internal class OtherPlayerInfoManager : DataManager<OtherPlayerInfoManager>
	{
		// Token: 0x06018E85 RID: 102021 RVA: 0x007CC790 File Offset: 0x007CAB90
		public override void Initialize()
		{
			NetProcess.AddMsgHandler(601702U, new Action<MsgDATA>(this.OnRecvWatchPlayerRet));
		}

		// Token: 0x06018E86 RID: 102022 RVA: 0x007CC7A8 File Offset: 0x007CABA8
		public override void Clear()
		{
			NetProcess.RemoveMsgHandler(601702U, new Action<MsgDATA>(this.OnRecvWatchPlayerRet));
		}

		// Token: 0x06018E87 RID: 102023 RVA: 0x007CC7C0 File Offset: 0x007CABC0
		public void SendWatchOtherPlayerInfo(ulong roleID, uint queryType = 0U, uint zoneId = 0U)
		{
			WorldQueryPlayerReq worldQueryPlayerReq = new WorldQueryPlayerReq();
			worldQueryPlayerReq.name = string.Empty;
			worldQueryPlayerReq.roleId = roleID;
			worldQueryPlayerReq.queryType = queryType;
			worldQueryPlayerReq.zoneId = zoneId;
			this.QueryPlayerType = WorldQueryPlayerType.WQPT_WATCH_PLAYER_INTO;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
		}

		// Token: 0x06018E88 RID: 102024 RVA: 0x007CC808 File Offset: 0x007CAC08
		public void SendWatchOnShelfItemOwnerInfo(ulong itemOwnerId)
		{
			WorldQueryPlayerReq worldQueryPlayerReq = new WorldQueryPlayerReq();
			worldQueryPlayerReq.name = string.Empty;
			worldQueryPlayerReq.roleId = itemOwnerId;
			this.QueryPlayerType = WorldQueryPlayerType.WQPT_Query_ON_SHELF_ITEM_OWNER_INFO;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
		}

		// Token: 0x06018E89 RID: 102025 RVA: 0x007CC844 File Offset: 0x007CAC44
		private void OnRecvWatchPlayerRet(MsgDATA msg)
		{
			WorldQueryPlayerRet worldQueryPlayerRet = new WorldQueryPlayerRet();
			worldQueryPlayerRet.decode(msg.bytes);
			ActorShowEquipData actorShowEquipData = new ActorShowEquipData();
			actorShowEquipData.m_iJob = (int)worldQueryPlayerRet.info.occu;
			actorShowEquipData.m_guid = worldQueryPlayerRet.info.id;
			actorShowEquipData.m_iLevel = (int)worldQueryPlayerRet.info.level;
			actorShowEquipData.m_kName = worldQueryPlayerRet.info.name;
			actorShowEquipData.vip = (int)worldQueryPlayerRet.info.vipLevel;
			actorShowEquipData.guildName = worldQueryPlayerRet.info.guildTitle.name;
			actorShowEquipData.guildJob = (int)worldQueryPlayerRet.info.guildTitle.post;
			actorShowEquipData.emblemLv = (int)worldQueryPlayerRet.info.emblemLevel;
			actorShowEquipData.totalEquipScore = worldQueryPlayerRet.info.totalEquipScore;
			actorShowEquipData.adventureTeamName = worldQueryPlayerRet.info.adventureTeamName;
			actorShowEquipData.adventureTeamGrade = worldQueryPlayerRet.info.adventureTeamGrade;
			actorShowEquipData.adventureTeamRank = worldQueryPlayerRet.info.adventureTeamRanking;
			actorShowEquipData.m_zoneId = worldQueryPlayerRet.zoneId;
			actorShowEquipData.m_queryPlayerType = worldQueryPlayerRet.queryType;
			if (string.IsNullOrEmpty(actorShowEquipData.m_kName))
			{
				Logger.LogErrorFormat("there is something wrong whit player name whose id = {0} job={1} level ={2}", new object[]
				{
					actorShowEquipData.m_guid,
					actorShowEquipData.m_iJob,
					actorShowEquipData.m_iLevel
				});
			}
			actorShowEquipData.m_akEquipts = new List<ItemData>();
			for (int i = 0; i < worldQueryPlayerRet.info.equips.Length; i++)
			{
				ItemBaseInfo itemBaseInfo = worldQueryPlayerRet.info.equips[i];
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)itemBaseInfo.typeId, 100, 0);
				if (itemData != null)
				{
					actorShowEquipData.m_akEquipts.Add(itemData);
					itemData.StrengthenLevel = (int)itemBaseInfo.strengthen;
					itemData.GUID = itemBaseInfo.id;
					itemData.Packing = false;
					itemData.EquipType = (EEquipType)itemBaseInfo.equipType;
					itemData.GrowthAttrType = (EGrowthAttrType)itemBaseInfo.enhanceType;
				}
			}
			actorShowEquipData.m_akFashions = new List<ItemData>();
			for (int j = 0; j < worldQueryPlayerRet.info.fashionEquips.Length; j++)
			{
				ItemBaseInfo itemBaseInfo2 = worldQueryPlayerRet.info.fashionEquips[j];
				ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)itemBaseInfo2.typeId, 100, 0);
				if (itemData2 != null)
				{
					actorShowEquipData.m_akFashions.Add(itemData2);
					itemData2.StrengthenLevel = (int)itemBaseInfo2.strengthen;
					itemData2.GUID = itemBaseInfo2.id;
					itemData2.Packing = false;
				}
			}
			List<ItemData> list = ListPool<ItemData>.Get();
			list.AddRange(actorShowEquipData.m_akEquipts);
			list.AddRange(actorShowEquipData.m_akFashions);
			actorShowEquipData.m_dictEquipSuitObjs = DataManager<EquipSuitDataManager>.GetInstance().CalculateEquipSuitInfos(list);
			actorShowEquipData.avatar = worldQueryPlayerRet.info.avatar;
			actorShowEquipData.m_pkInfo = worldQueryPlayerRet.info.pkInfo;
			actorShowEquipData.pkValue = worldQueryPlayerRet.info.seasonLevel;
			actorShowEquipData.matchScore = worldQueryPlayerRet.info.matchScore;
			for (int k = 0; k < worldQueryPlayerRet.info.pets.Length; k++)
			{
				ActorShowEquipData.PetData petData = default(ActorShowEquipData.PetData);
				petData.dataID = (int)worldQueryPlayerRet.info.pets[k].dataId;
				petData.level = (int)worldQueryPlayerRet.info.pets[k].level;
				petData.hunger = (int)worldQueryPlayerRet.info.pets[k].hunger;
				petData.skillIndex = (int)worldQueryPlayerRet.info.pets[k].skillIndex;
				petData.petScore = (int)worldQueryPlayerRet.info.pets[k].petScore;
				actorShowEquipData.pets[k] = petData;
			}
			switch (this.QueryPlayerType)
			{
			case WorldQueryPlayerType.WQPT_WATCH_PLAYER_INTO:
				Singleton<ClientSystemManager>.instance.CloseFrame<ActorShowGroup>(null, false);
				Singleton<ClientSystemManager>.instance.OpenFrame<ActorShowGroup>(FrameLayer.Middle, actorShowEquipData, string.Empty);
				break;
			case WorldQueryPlayerType.WQPT_FRIEND:
			{
				FriendRecommendedFrame friendRecommendedFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(FriendRecommendedFrame)) as FriendRecommendedFrame;
				if (friendRecommendedFrame != null && friendRecommendedFrame.IsQuerying())
				{
					UIEventSystem.GetInstance().SendUIEvent(new UIEventRecvQueryPlayer(worldQueryPlayerRet.info));
				}
				break;
			}
			case WorldQueryPlayerType.WQPT_TEACHER:
			{
				RelationData queryedTeacherInfo = new RelationData
				{
					uid = worldQueryPlayerRet.info.id,
					name = worldQueryPlayerRet.info.name,
					level = worldQueryPlayerRet.info.level,
					occu = worldQueryPlayerRet.info.occu,
					isOnline = 1,
					type = 0,
					vipLv = worldQueryPlayerRet.info.vipLevel,
					status = 0,
					seasonLv = worldQueryPlayerRet.info.seasonLevel,
					avatar = worldQueryPlayerRet.info.avatar,
					activeTimeType = worldQueryPlayerRet.info.activeTimeType,
					masterType = worldQueryPlayerRet.info.masterType,
					regionId = worldQueryPlayerRet.info.regionId,
					declaration = worldQueryPlayerRet.info.declaration
				};
				DataManager<RelationDataManager>.GetInstance().SetQueryedTeacherInfo(queryedTeacherInfo);
				break;
			}
			case WorldQueryPlayerType.WQPT_Query_ON_SHELF_ITEM_OWNER_INFO:
				AuctionNewUtility.OpenChatFrame(new RelationData
				{
					level = (ushort)actorShowEquipData.m_iLevel,
					uid = actorShowEquipData.m_guid,
					name = actorShowEquipData.m_kName,
					occu = (byte)actorShowEquipData.m_iJob,
					vipLv = (byte)actorShowEquipData.vip
				});
				break;
			}
			ListPool<ItemData>.Release(list);
		}

		// Token: 0x04011EA9 RID: 73385
		public WorldQueryPlayerType QueryPlayerType;
	}
}
