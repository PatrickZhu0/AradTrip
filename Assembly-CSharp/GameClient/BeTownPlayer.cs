using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001192 RID: 4498
	internal class BeTownPlayer : BeBaseActor
	{
		// Token: 0x0600AC3C RID: 44092 RVA: 0x00250884 File Offset: 0x0024EC84
		public BeTownPlayer(BeTownPlayerData data, ClientSystemTown systemTown) : base(data, systemTown)
		{
			if (data.State == 2)
			{
				this.AddMoveCommand(data.MoveData.Position, data.MoveData.TargetDirection, data.MoveData.FaceRight);
			}
			this.CreatePet(data.petID);
			this.CreateFollow();
		}

		// Token: 0x0600AC3D RID: 44093 RVA: 0x002508E9 File Offset: 0x0024ECE9
		public override void Dispose()
		{
			this.DestroyPet();
			this.DestroyFollow();
			base.Dispose();
		}

		// Token: 0x0600AC3E RID: 44094 RVA: 0x00250900 File Offset: 0x0024ED00
		public override void InitGeActor(GeSceneEx geScene)
		{
			this._geScene = geScene;
			if (geScene == null)
			{
				return;
			}
			if (this._geActor == null)
			{
				BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(beTownPlayerData.JobID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat(" 职业表 没有ID为 {0} 的条目 playerInfo {1} {2} {3}", new object[]
					{
						beTownPlayerData.JobID,
						beTownPlayerData.Name,
						beTownPlayerData.ZoneID,
						beTownPlayerData.GUID
					});
					return;
				}
				this._geActor = geScene.CreateActor(tableItem.Mode, 0, 0, false, false, false, false);
				if (this._geActor != null)
				{
					this._geActor.CreateInfoBar(beTownPlayerData.Name, beTownPlayerData.NameColor, beTownPlayerData.RoleLv, null, 0f);
					this._geActor.AddSimpleShadow(Vector3.one);
					PlayerInfoColor color = PlayerInfoColor.TOWN_OTHER_PLAYER;
					if (this is BeTownPlayerMain)
					{
						color = PlayerInfoColor.TOWN_PLAYER;
					}
					if (Global.Settings.testFashionEquip || Singleton<DebugSettings>.instance.EnableTestFashionEquip)
					{
					}
					this._geActor.AddTittleComponent((int)beTownPlayerData.tittle, beTownPlayerData.Name, beTownPlayerData.GuildPost, beTownPlayerData.GuildName, (int)beTownPlayerData.RoleLv, beTownPlayerData.pkRank, color, beTownPlayerData.AdventureTeamName, beTownPlayerData.WearedTitleInfo, beTownPlayerData.GuildEmblemLv, 0);
					GameObject entityNode = this._geActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
					if (entityNode != null)
					{
						BoxCollider boxCollider = entityNode.GetComponent<BoxCollider>();
						if (boxCollider == null)
						{
							boxCollider = entityNode.AddComponent<BoxCollider>();
							boxCollider.center = new Vector3(0f, 0.85f, 0f);
							boxCollider.size = new Vector3(0.6f, 1.8f, 0.86f);
							boxCollider.enabled = true;
						}
						if (boxCollider != null)
						{
							RaycastObject raycastObject = entityNode.GetComponent<RaycastObject>();
							if (raycastObject == null)
							{
								raycastObject = entityNode.AddComponent<RaycastObject>();
							}
							if (raycastObject != null)
							{
								raycastObject.Initialize(beTownPlayerData.JobID, RaycastObject.RaycastObjectType.ROT_TOWNPLAYER, beTownPlayerData);
							}
						}
					}
				}
				else
				{
					Logger.LogErrorFormat("TownPlayer createActor {0} failed", new object[]
					{
						tableItem.Mode
					});
				}
				base.ActorData.SetAniInfos(tableItem.IdleAniName, tableItem.WalkAniName, tableItem.RunAniName, tableItem.DeadAniName);
				if (beTownPlayerData.avatorInfo != null)
				{
					if (!Global.Settings.testFashionEquip && !Singleton<DebugSettings>.instance.EnableTestFashionEquip)
					{
						DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(null, beTownPlayerData.avatorInfo.equipItemIds, beTownPlayerData.JobID, (int)beTownPlayerData.avatorInfo.weaponStrengthen, this._geActor, false, beTownPlayerData.avatorInfo.isShoWeapon, true);
					}
				}
				this.CreateFollow();
				if (beTownPlayerData.petID > 0)
				{
					this.CreatePet(beTownPlayerData.petID);
				}
				else if (Global.Settings.testFashionEquip || Singleton<DebugSettings>.instance.EnableTestFashionEquip)
				{
				}
			}
			base.InitGeActor(geScene);
		}

		// Token: 0x0600AC3F RID: 44095 RVA: 0x00250C10 File Offset: 0x0024F010
		public void RemoveGeActor()
		{
			if (this._geScene != null)
			{
				if (this._geActor != null)
				{
					this._geScene.DestroyActor(this._geActor);
					this._geActor = null;
					this.DestroyFollow();
					this.DestroyPet();
				}
			}
			else if (this._geActor != null)
			{
				Logger.LogError("Town player with error data!");
			}
		}

		// Token: 0x0600AC40 RID: 44096 RVA: 0x00250C74 File Offset: 0x0024F074
		private uint[] TestGetEquipFashions(int jobID)
		{
			int num = Random.Range(0, 8);
			uint[] array = new uint[6];
			for (int i = 0; i < 5; i++)
			{
				array[i] = (uint)((ulong)BeTownPlayer._fashionIDs[num] + (ulong)((long)((jobID - jobID % 10) * 100000)) + (ulong)((long)i));
			}
			array[5] = (uint)((ulong)BeTownPlayer._wingIDs[num] + (ulong)((long)((jobID - jobID % 10) * 100000)));
			return array;
		}

		// Token: 0x0600AC41 RID: 44097 RVA: 0x00250CDC File Offset: 0x0024F0DC
		public sealed override void UpdateGeActor(float deltaTime)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			if (this._geActor != null)
			{
				if (beTownPlayerData.bRoleLvDirty)
				{
					this._geActor.UpdateInfoBarLevel(beTownPlayerData.RoleLv, true);
					beTownPlayerData.bRoleLvDirty = false;
				}
				if (beTownPlayerData.bDirty)
				{
					this._geActor.UpdatePkRank(beTownPlayerData.pkRank, beTownPlayerData.pkStar);
					this._geActor.UpdateName(beTownPlayerData.Name);
					beTownPlayerData.bDirty = false;
				}
				if (beTownPlayerData.bAwakeDirty)
				{
					this._geActor.PlayAwakeEffect();
					beTownPlayerData.bAwakeDirty = false;
				}
				base.UpdateGeActor(deltaTime);
			}
		}

		// Token: 0x0600AC42 RID: 44098 RVA: 0x00250D82 File Offset: 0x0024F182
		public override void UpdateMove(float timeElapsed)
		{
			this._TryDoMoveCommand();
			base.UpdateMove(timeElapsed);
		}

		// Token: 0x0600AC43 RID: 44099 RVA: 0x00250D94 File Offset: 0x0024F194
		public override void CommandStopMove()
		{
			base.CommandStopMove();
			if (this.currMoveCommand.targetDirection.x != 0f || this.currMoveCommand.targetDirection.z != 0f)
			{
				this.currMoveCommand.targetDirection = new Vector3(0f, 0f, 0f);
				this.DoActionWalk();
				if (!this.m_delayCallStopMove.IsValid())
				{
					this.m_delayCallStopMove = this.delayCaller.DelayCall(2000, delegate
					{
						this.CommandStopMove();
					}, 0, 0, false);
				}
			}
		}

		// Token: 0x0600AC44 RID: 44100 RVA: 0x00250E38 File Offset: 0x0024F238
		public sealed override void DoActionIdle()
		{
			base.DoActionIdle();
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			if (this.IsFemaleGunner(beTownPlayerData.JobID))
			{
				base.ActorData.SetAttachmentVisible("weapon", true);
			}
			base.ActorData.PlayAttachmentAction("wing", "Anim_Idle01");
		}

		// Token: 0x0600AC45 RID: 44101 RVA: 0x00250E90 File Offset: 0x0024F290
		public sealed override void DoActionWalk()
		{
			base.DoActionWalk();
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			if (this.IsFemaleGunner(beTownPlayerData.JobID))
			{
				base.ActorData.SetAttachmentVisible("weapon", false);
			}
			base.ActorData.PlayAttachmentAction("wing", "Anim_Walk");
		}

		// Token: 0x0600AC46 RID: 44102 RVA: 0x00250EE8 File Offset: 0x0024F2E8
		public void AddMoveCommand(Vector3 pos, Vector3 dir, bool faceRight)
		{
			this.delayCaller.StopItem(this.m_delayCallStopMove);
			if (this.moveCommands.Count > 0 && this.moveCommands.Last.Value.currPosition == pos)
			{
				this.moveCommands.RemoveLast();
			}
			this.moveCommands.AddLast(new BeTownPlayer.MoveCommand(pos, dir));
			if (this.moveCommands.Count > 10)
			{
				this.moveCommands.RemoveFirst();
			}
		}

		// Token: 0x0600AC47 RID: 44103 RVA: 0x00250F78 File Offset: 0x0024F378
		protected void _TryDoMoveCommand()
		{
			if (base.ActorData.MoveData.MoveType == EActorMoveType.Invalid && this.moveCommands.Count > 0)
			{
				this.currMoveCommand = this.moveCommands.First.Value;
				this.CommandDirectMoveTo(this.currMoveCommand.currPosition);
				if (this.currMoveCommand.targetDirection.x > 0f)
				{
					base.ActorData.MoveData.FaceRight = true;
				}
				else if (this.currMoveCommand.targetDirection.x < 0f)
				{
					base.ActorData.MoveData.FaceRight = false;
				}
				this.moveCommands.RemoveFirst();
			}
		}

		// Token: 0x0600AC48 RID: 44104 RVA: 0x0025103C File Offset: 0x0024F43C
		public void SetPlayerJobTableID(int JobTableID)
		{
			if (base.ActorData != null)
			{
				BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
				beTownPlayerData.JobID = JobTableID;
			}
		}

		// Token: 0x0600AC49 RID: 44105 RVA: 0x00251068 File Offset: 0x0024F468
		public void SetPlayerRoleLv(ushort RoleLv)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.RoleLv = RoleLv;
			beTownPlayerData.bRoleLvDirty = true;
			if (base.GraphicActor != null)
			{
				base.GraphicActor.OnLevelChanged((int)RoleLv);
				base.GraphicActor.UpdateLevel((int)RoleLv);
			}
		}

		// Token: 0x0600AC4A RID: 44106 RVA: 0x002510B4 File Offset: 0x0024F4B4
		public void SetPlayerAwakeState(bool bAwake)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.bAwakeDirty = bAwake;
		}

		// Token: 0x0600AC4B RID: 44107 RVA: 0x002510D4 File Offset: 0x0024F4D4
		public void SetPlayerName(string a_strName)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.Name = a_strName;
		}

		// Token: 0x0600AC4C RID: 44108 RVA: 0x002510F4 File Offset: 0x0024F4F4
		public void SetPlayerPKRank(int a_nPKRank, int a_nStar)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.pkRank = a_nPKRank;
			beTownPlayerData.pkStar = a_nStar;
		}

		// Token: 0x0600AC4D RID: 44109 RVA: 0x0025111C File Offset: 0x0024F51C
		public void SetPlayerTittle(uint tittle)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.tittle = tittle;
			if (base.GraphicActor != null)
			{
				base.GraphicActor.OnTittleChanged((int)tittle);
			}
		}

		// Token: 0x0600AC4E RID: 44110 RVA: 0x00251154 File Offset: 0x0024F554
		public void SetPlayerGuildName(string name)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.GuildName = name;
			if (base.GraphicActor != null)
			{
				base.GraphicActor.OnGuildNameChanged(name);
			}
		}

		// Token: 0x0600AC4F RID: 44111 RVA: 0x0025118C File Offset: 0x0024F58C
		public void SetPlayerGuildDuty(byte duty)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.GuildPost = duty;
			if (base.GraphicActor != null)
			{
				base.GraphicActor.OnGuildPostChanged(duty);
			}
		}

		// Token: 0x0600AC50 RID: 44112 RVA: 0x002511C4 File Offset: 0x0024F5C4
		public void SetPlayerZoneID(int iZoneId)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.ZoneID = iZoneId;
		}

		// Token: 0x0600AC51 RID: 44113 RVA: 0x002511E4 File Offset: 0x0024F5E4
		public int GetPlayerZoneID()
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			if (beTownPlayerData != null)
			{
				return beTownPlayerData.ZoneID;
			}
			return 0;
		}

		// Token: 0x0600AC52 RID: 44114 RVA: 0x0025120C File Offset: 0x0024F60C
		public void SetAdventureTeamName(string name)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.AdventureTeamName = name;
			if (base.GraphicActor != null)
			{
				base.GraphicActor.UpdateAdventTeamName(name);
			}
		}

		// Token: 0x0600AC53 RID: 44115 RVA: 0x00251244 File Offset: 0x0024F644
		public void SetTitleName(PlayerWearedTitleInfo wearedTitleInfo)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.WearedTitleInfo = wearedTitleInfo;
			if (base.GraphicActor != null)
			{
				base.GraphicActor.UpdateTitleName(wearedTitleInfo);
			}
		}

		// Token: 0x0600AC54 RID: 44116 RVA: 0x0025127C File Offset: 0x0024F67C
		public void SetGuildEmblemLv(int guildEmblemLv)
		{
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			beTownPlayerData.GuildEmblemLv = guildEmblemLv;
			if (base.GraphicActor != null)
			{
				base.GraphicActor.UpdateGuidLv(guildEmblemLv);
			}
		}

		// Token: 0x0600AC55 RID: 44117 RVA: 0x002512B3 File Offset: 0x0024F6B3
		public void ShowEquipStrengthenEffect(int strengthenLevel = 0)
		{
			if (strengthenLevel < 0)
			{
				return;
			}
			DataManager<PlayerBaseData>.GetInstance().AvatarShowWeaponStrengthen(null, strengthenLevel, this._geActor, false);
		}

		// Token: 0x0600AC56 RID: 44118 RVA: 0x002512D0 File Offset: 0x0024F6D0
		public bool IsFemaleGunner(int jobID)
		{
			return (jobID >= 50 && jobID <= 54) || (jobID >= 20 && jobID <= 24);
		}

		// Token: 0x0600AC57 RID: 44119 RVA: 0x002512F8 File Offset: 0x0024F6F8
		public virtual void CreatePet(int a_nPetID)
		{
			this.DestroyPet();
			if (a_nPetID > 0)
			{
				BeTownPetData beTownPetData = new BeTownPetData
				{
					PetID = a_nPetID
				};
				beTownPetData.MoveData.PosLogicToGraph = base.ActorData.MoveData.PosLogicToGraph;
				this.m_townPet = new BeTownPet(beTownPetData, this._systemTown, true);
				this.m_townPet.SetOwner(this);
				this.m_townPet.SetDialogEnable(false);
				if (this._geActor != null)
				{
					this.m_townPet.InitGeActor(this._geScene);
				}
			}
		}

		// Token: 0x0600AC58 RID: 44120 RVA: 0x00251383 File Offset: 0x0024F783
		public void DestroyPet()
		{
			if (this.m_townPet != null)
			{
				this.m_townPet.Dispose();
				this.m_townPet = null;
			}
		}

		// Token: 0x0600AC59 RID: 44121 RVA: 0x002513A4 File Offset: 0x0024F7A4
		public void CreateFollow()
		{
			this.DestroyFollow();
			if (this._geActor == null)
			{
				return;
			}
			BeTownPlayerData beTownPlayerData = base.ActorData as BeTownPlayerData;
			if (beTownPlayerData == null)
			{
				return;
			}
			string attachModelPath = BeUtility.GetAttachModelPath(beTownPlayerData.JobID);
			if (attachModelPath == null)
			{
				return;
			}
			GameObject entityNode = this._geActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
			this.attachModel = Utility.AddModelToActor(attachModelPath, this._geActor, entityNode);
		}

		// Token: 0x0600AC5A RID: 44122 RVA: 0x00251409 File Offset: 0x0024F809
		public void DestroyFollow()
		{
			if (this.attachModel != null)
			{
				Object.Destroy(this.attachModel);
				this.attachModel = null;
			}
		}

		// Token: 0x0600AC5B RID: 44123 RVA: 0x00251430 File Offset: 0x0024F830
		public void Init3v3RoomPlayerJiaoDiGuangQuan()
		{
			if (this._geActor == null)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.Pk3v3)
			{
				return;
			}
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null || roomInfo.roomSlotInfos == null)
			{
				this.CreateFootIndicator(BeTownPlayer.FootEffectType.DEFUALT);
				return;
			}
			bool flag = false;
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].playerId == base.ActorData.GUID)
				{
					if (roomInfo.roomSlotInfos[i].group == 1)
					{
						this.CreateFootIndicator(BeTownPlayer.FootEffectType.RED);
					}
					else
					{
						this.CreateFootIndicator(BeTownPlayer.FootEffectType.BULE);
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.CreateFootIndicator(BeTownPlayer.FootEffectType.DEFUALT);
			}
		}

		// Token: 0x0600AC5C RID: 44124 RVA: 0x0025152B File Offset: 0x0024F92B
		public void Update3v3RoomPlayerJiaoDiGuangQuan(byte group)
		{
			if (this._geActor == null)
			{
				return;
			}
			if (group == 1)
			{
				this.CreateFootIndicator(BeTownPlayer.FootEffectType.RED);
			}
			else
			{
				this.CreateFootIndicator(BeTownPlayer.FootEffectType.BULE);
			}
		}

		// Token: 0x0600AC5D RID: 44125 RVA: 0x00251554 File Offset: 0x0024F954
		public void CreateFootIndicator(BeTownPlayer.FootEffectType type = BeTownPlayer.FootEffectType.DEFUALT)
		{
			string str = string.Empty;
			string attachRes = string.Empty;
			if (type == BeTownPlayer.FootEffectType.DEFUALT)
			{
				attachRes = "Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_guo";
			}
			else if (type == BeTownPlayer.FootEffectType.RED)
			{
				str = "red";
				attachRes = "Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_hong";
			}
			else if (type == BeTownPlayer.FootEffectType.BULE)
			{
				str = "blue";
				attachRes = "Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_lan";
			}
			GeAttach geAttach = this._geActor.CreateAttachment(str + "Aureole", attachRes, "[actor]Orign", false, false, false);
			if (geAttach != null && this._geActor.GetAttachment("halo") != null && type == BeTownPlayer.FootEffectType.DEFUALT)
			{
				geAttach.SetVisible(false);
			}
			else
			{
				geAttach.SetVisible(true);
			}
		}

		// Token: 0x0400609D RID: 24733
		protected LinkedList<BeTownPlayer.MoveCommand> moveCommands = new LinkedList<BeTownPlayer.MoveCommand>();

		// Token: 0x0400609E RID: 24734
		protected BeTownPlayer.MoveCommand currMoveCommand;

		// Token: 0x0400609F RID: 24735
		private DelayCallUnitHandle m_delayCallStopMove;

		// Token: 0x040060A0 RID: 24736
		protected BeTownPet m_townPet;

		// Token: 0x040060A1 RID: 24737
		private GameObject attachModel;

		// Token: 0x040060A2 RID: 24738
		private static uint[] _fashionIDs = new uint[]
		{
			530002001U,
			530003001U,
			530003007U,
			530003012U,
			530003017U,
			530003022U,
			530003027U,
			530003032U
		};

		// Token: 0x040060A3 RID: 24739
		private static uint[] _wingIDs = new uint[]
		{
			530005006U,
			530005007U,
			530005008U,
			530005009U,
			530005010U,
			530005011U,
			530005017U,
			530005018U
		};

		// Token: 0x02001193 RID: 4499
		protected struct MoveCommand
		{
			// Token: 0x0600AC60 RID: 44128 RVA: 0x00251633 File Offset: 0x0024FA33
			public MoveCommand(Vector3 pos, Vector3 dir)
			{
				this.currPosition = pos;
				this.targetDirection = dir;
			}

			// Token: 0x040060A4 RID: 24740
			public Vector3 currPosition;

			// Token: 0x040060A5 RID: 24741
			public Vector3 targetDirection;
		}

		// Token: 0x02001194 RID: 4500
		public enum FootEffectType
		{
			// Token: 0x040060A7 RID: 24743
			DEFUALT,
			// Token: 0x040060A8 RID: 24744
			RED,
			// Token: 0x040060A9 RID: 24745
			BULE
		}
	}
}
