using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001145 RID: 4421
	public class BeFighter : BeBaseFighter
	{
		// Token: 0x0600A8C6 RID: 43206 RVA: 0x00238A50 File Offset: 0x00236E50
		public BeFighter(BeFighterData data, ClientSystemGameBattle systemTown) : base(data, systemTown)
		{
			if (data.State == 2)
			{
				this.AddMoveCommand(data.MoveData.Position, data.MoveData.TargetDirection, data.MoveData.FaceRight);
			}
		}

		// Token: 0x17001A13 RID: 6675
		// (get) Token: 0x0600A8C7 RID: 43207 RVA: 0x00238AA3 File Offset: 0x00236EA3
		public ushort GrassId
		{
			get
			{
				return this.m_grassId;
			}
		}

		// Token: 0x17001A14 RID: 6676
		// (get) Token: 0x0600A8C8 RID: 43208 RVA: 0x00238AAB File Offset: 0x00236EAB
		public bool IsDead
		{
			get
			{
				return this.m_isDead;
			}
		}

		// Token: 0x17001A15 RID: 6677
		// (get) Token: 0x0600A8C9 RID: 43209 RVA: 0x00238AB3 File Offset: 0x00236EB3
		public new GeActorEx GraphicActor
		{
			get
			{
				return this._geActor;
			}
		}

		// Token: 0x0600A8CA RID: 43210 RVA: 0x00238ABB File Offset: 0x00236EBB
		public override void Dispose()
		{
			this.DestroyPet();
			this.DestroyFollow();
			base.Dispose();
		}

		// Token: 0x0600A8CB RID: 43211 RVA: 0x00238ACF File Offset: 0x00236ECF
		public void SetDead()
		{
			if (!this.m_isDead)
			{
				this.m_isDead = true;
				base.ResetMoveCommand();
				this.DoActionDead();
			}
		}

		// Token: 0x0600A8CC RID: 43212 RVA: 0x00238AF0 File Offset: 0x00236EF0
		public override void InitGeActor(GeSceneEx geScene)
		{
			this._geScene = geScene;
			if (geScene == null)
			{
				return;
			}
			if (this._geActor == null)
			{
				BeFighterData beFighterData = base.ActorData as BeFighterData;
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(beFighterData.JobID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat(" 职业表 没有ID为 {0} 的条目", new object[]
					{
						beFighterData.JobID
					});
					return;
				}
				this._geActor = geScene.CreateActor(tableItem.Mode, 0, 0, false, false, false, false);
				this._geActor.mPostLoadInfoBar = new PosLoadGeActorEx(this.OnPostLoadInfoBar);
				this._geActor.CreateInfoBar(beFighterData.Name, beFighterData.NameColor, beFighterData.RoleLv, null, 0f);
				this._geActor.AddSimpleShadow(Vector3.one);
				this._geActor.SetProfessionId(beFighterData.JobID);
				if (this is BeFighterMain)
				{
				}
				if (Global.Settings.testFashionEquip || Singleton<DebugSettings>.instance.EnableTestFashionEquip)
				{
				}
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
							raycastObject.Initialize(beFighterData.JobID, RaycastObject.RaycastObjectType.ROT_TOWNPLAYER, beFighterData);
						}
					}
				}
				base.ActorData.SetAniInfos(tableItem.IdleAniName, tableItem.WalkAniName, tableItem.RunAniName, tableItem.DeadAniName);
				if (beFighterData.avatorInfo != null)
				{
					if (!Global.Settings.testFashionEquip && !Singleton<DebugSettings>.instance.EnableTestFashionEquip)
					{
						DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(null, beFighterData.avatorInfo.equipItemIds, beFighterData.JobID, (int)beFighterData.avatorInfo.weaponStrengthen, this._geActor, false, beFighterData.avatorInfo.isShoWeapon, !this.IsInChijiBattleField());
					}
				}
				this.CreateFollow();
				if (beFighterData.petID > 0)
				{
					this.CreatePet(beFighterData.petID);
				}
				else if (Global.Settings.testFashionEquip || Singleton<DebugSettings>.instance.EnableTestFashionEquip)
				{
				}
			}
			base.InitGeActor(geScene);
		}

		// Token: 0x0600A8CD RID: 43213 RVA: 0x00238D98 File Offset: 0x00237198
		public bool IsInChijiBattleField()
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemGameBattle.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Battle)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A8CE RID: 43214 RVA: 0x00238DEC File Offset: 0x002371EC
		public void RemoveGeActor()
		{
			if (this._geScene != null)
			{
				if (this._geActor != null)
				{
					this._geScene.DestroyActor(this._geActor);
					this.DestroyFollow();
					this.DestroyPet();
					this._geActor = null;
				}
			}
			else if (this._geActor != null)
			{
				Logger.LogError("Town player with error data!");
			}
		}

		// Token: 0x0600A8CF RID: 43215 RVA: 0x00238E50 File Offset: 0x00237250
		protected uint[] TestGetEquipFashions(int jobID)
		{
			int num = UnityEngine.Random.Range(0, 8);
			uint[] array = new uint[6];
			for (int i = 0; i < 5; i++)
			{
				array[i] = (uint)((ulong)BeFighter._fashionIDs[num] + (ulong)((long)((jobID - jobID % 10) * 100000)) + (ulong)((long)i));
			}
			array[5] = (uint)((ulong)BeFighter._wingIDs[num] + (ulong)((long)((jobID - jobID % 10) * 100000)));
			return array;
		}

		// Token: 0x0600A8D0 RID: 43216 RVA: 0x00238EB8 File Offset: 0x002372B8
		public sealed override void UpdateGeActor(float deltaTime)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			if (this._geActor != null)
			{
				if (beFighterData.bRoleLvDirty)
				{
					this._geActor.UpdateInfoBarLevel(beFighterData.RoleLv, true);
					beFighterData.bRoleLvDirty = false;
				}
				if (beFighterData.bDirty)
				{
					this._geActor.UpdatePkRank(beFighterData.pkRank, beFighterData.pkStar);
					this._geActor.UpdateName(beFighterData.Name);
					beFighterData.bDirty = false;
				}
				if (beFighterData.bAwakeDirty)
				{
					this._geActor.PlayAwakeEffect();
					beFighterData.bAwakeDirty = false;
				}
				base.UpdateGeActor(deltaTime);
			}
		}

		// Token: 0x0600A8D1 RID: 43217 RVA: 0x00238F5E File Offset: 0x0023735E
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			this._UpdateGrass();
			if (this.m_townPet != null)
			{
				this.m_townPet.Update(deltaTime);
			}
		}

		// Token: 0x0600A8D2 RID: 43218 RVA: 0x00238F84 File Offset: 0x00237384
		public override void UpdateMove(float timeElapsed)
		{
			this._TryDoMoveCommand();
			base.UpdateMove(timeElapsed);
		}

		// Token: 0x0600A8D3 RID: 43219 RVA: 0x00238F94 File Offset: 0x00237394
		protected ushort _GetGrassId(float x, float y)
		{
			if (this._battle == null || this._battle.LevelData == null)
			{
				return 0;
			}
			Vector2 gridSize = this._battle.LevelData.GetGridSize();
			Vector2 logicXSize = this._battle.LevelData.GetLogicXSize();
			Vector2 logicZSize = this._battle.LevelData.GetLogicZSize();
			int gridX = (int)Math.Floor((double)((x - logicXSize.x) / gridSize.x));
			int gridY = (int)Math.Floor((double)((y - logicZSize.x) / gridSize.y));
			return this._battle.LevelData.GetGrassId(gridX, gridY);
		}

		// Token: 0x0600A8D4 RID: 43220 RVA: 0x00239037 File Offset: 0x00237437
		public override void SetGrassStat(BeBaseFighter.GRASS_STATUS stat)
		{
			base.SetGrassStat(stat);
			if (this.m_townPet != null)
			{
				this.m_townPet.SetGrassStat(stat);
			}
		}

		// Token: 0x0600A8D5 RID: 43221 RVA: 0x00239057 File Offset: 0x00237457
		private void OnPostLoadInfoBar(GeActorEx geActor)
		{
			if (base.GrassStatus == BeBaseFighter.GRASS_STATUS.IN_GRASS && geActor != null)
			{
				geActor.HideActor(true);
			}
		}

		// Token: 0x0600A8D6 RID: 43222 RVA: 0x00239074 File Offset: 0x00237474
		protected void _UpdateGrass()
		{
			if (this._geActor == null || !this._geActor.IsAvatarLoadFinished())
			{
				return;
			}
			if (this._battle == null)
			{
				return;
			}
			if (this._battle.MainPlayer == null)
			{
				return;
			}
			ActorMoveData moveData = base.ActorData.MoveData;
			ushort num = this._GetGrassId(moveData.Position.x, moveData.Position.z);
			if (num != this.m_grassId)
			{
				this.m_grassId = num;
				if (this.m_grassId != 0)
				{
					if (this._battle.MainPlayer.ActorData.GUID != base.ActorData.GUID)
					{
						if (this._battle.MainPlayer.GrassId != 0 && this._battle.MainPlayer.GrassId == this.m_grassId)
						{
							this.SetGrassStat(BeBaseFighter.GRASS_STATUS.SAME_WITH_MAINROLE_IN_GRASS);
						}
						else
						{
							this.SetGrassStat(BeBaseFighter.GRASS_STATUS.IN_GRASS);
						}
					}
					else
					{
						this.SetGrassStat(BeBaseFighter.GRASS_STATUS.MAIN_ROLE_IN_GRASS);
					}
				}
				else
				{
					this.SetGrassStat(BeBaseFighter.GRASS_STATUS.NONE);
				}
			}
			else if (this._battle.MainPlayer.ActorData.GUID != base.ActorData.GUID && this.m_grassId != 0)
			{
				if (this._battle.MainPlayer.GrassId != this.m_grassId)
				{
					this.SetGrassStat(BeBaseFighter.GRASS_STATUS.IN_GRASS);
				}
				else
				{
					this.SetGrassStat(BeBaseFighter.GRASS_STATUS.MAIN_ROLE_IN_GRASS);
				}
			}
		}

		// Token: 0x0600A8D7 RID: 43223 RVA: 0x002391EC File Offset: 0x002375EC
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

		// Token: 0x0600A8D8 RID: 43224 RVA: 0x00239290 File Offset: 0x00237690
		public sealed override void DoActionIdle()
		{
			base.DoActionIdle();
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			if (this.IsFemaleGunner(beFighterData.JobID))
			{
				base.ActorData.SetAttachmentVisible("weapon", true);
			}
			base.ActorData.PlayAttachmentAction("wing", "Anim_Idle01");
		}

		// Token: 0x0600A8D9 RID: 43225 RVA: 0x002392E8 File Offset: 0x002376E8
		public sealed override void DoActionWalk()
		{
			base.DoActionWalk();
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			if (this.IsFemaleGunner(beFighterData.JobID))
			{
				base.ActorData.SetAttachmentVisible("weapon", false);
			}
			base.ActorData.PlayAttachmentAction("wing", "Anim_Walk");
		}

		// Token: 0x0600A8DA RID: 43226 RVA: 0x00239340 File Offset: 0x00237740
		public void AddMoveCommand(Vector3 pos, Vector3 dir, bool faceRight)
		{
			this.delayCaller.StopItem(this.m_delayCallStopMove);
			if (this.moveCommands.Count > 0 && this.moveCommands.Last.Value.currPosition == pos)
			{
				this.moveCommands.RemoveLast();
			}
			this.moveCommands.AddLast(new BeFighter.MoveCommand(pos, dir));
			if (this.moveCommands.Count > 10)
			{
				this.moveCommands.RemoveFirst();
			}
		}

		// Token: 0x0600A8DB RID: 43227 RVA: 0x002393D0 File Offset: 0x002377D0
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

		// Token: 0x0600A8DC RID: 43228 RVA: 0x00239494 File Offset: 0x00237894
		public void SetPlayerRoleLv(ushort RoleLv)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.RoleLv = RoleLv;
			beFighterData.bRoleLvDirty = true;
			if (this.GraphicActor != null)
			{
				this.GraphicActor.OnLevelChanged((int)RoleLv);
				this.GraphicActor.UpdateLevel((int)RoleLv);
			}
		}

		// Token: 0x0600A8DD RID: 43229 RVA: 0x002394E0 File Offset: 0x002378E0
		public void SetPlayerAwakeState(bool bAwake)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.bAwakeDirty = bAwake;
		}

		// Token: 0x0600A8DE RID: 43230 RVA: 0x00239500 File Offset: 0x00237900
		public void SetPlayerName(string a_strName)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.Name = a_strName;
		}

		// Token: 0x0600A8DF RID: 43231 RVA: 0x00239520 File Offset: 0x00237920
		public void SetPlayerPKRank(int a_nPKRank, int a_nStar)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.pkRank = a_nPKRank;
			beFighterData.pkStar = a_nStar;
		}

		// Token: 0x0600A8E0 RID: 43232 RVA: 0x00239548 File Offset: 0x00237948
		public void SetPlayerTittle(uint tittle)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.tittle = tittle;
			if (this.GraphicActor != null)
			{
				this.GraphicActor.OnTittleChanged((int)tittle);
			}
		}

		// Token: 0x0600A8E1 RID: 43233 RVA: 0x00239580 File Offset: 0x00237980
		public void SetPlayerGuildName(string name)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.GuildName = name;
			if (this.GraphicActor != null)
			{
				this.GraphicActor.OnGuildNameChanged(name);
			}
		}

		// Token: 0x0600A8E2 RID: 43234 RVA: 0x002395B8 File Offset: 0x002379B8
		public void SetPlayerGuildDuty(byte duty)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.GuildPost = duty;
			if (this.GraphicActor != null)
			{
				this.GraphicActor.OnGuildPostChanged(duty);
			}
		}

		// Token: 0x0600A8E3 RID: 43235 RVA: 0x002395F0 File Offset: 0x002379F0
		public void SetPlayerZoneID(int iZoneId)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.ZoneID = iZoneId;
		}

		// Token: 0x0600A8E4 RID: 43236 RVA: 0x00239610 File Offset: 0x00237A10
		public GeEffectEx CreateAttackAreaEffect(string EffectPath)
		{
			if (this.GraphicActor != null)
			{
				return this.GraphicActor.CreateEffect(EffectPath, "[actor]Orign", 1E+09f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
			}
			return null;
		}

		// Token: 0x0600A8E5 RID: 43237 RVA: 0x00239664 File Offset: 0x00237A64
		public int GetPlayerZoneID()
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			if (beFighterData != null)
			{
				return beFighterData.ZoneID;
			}
			return 0;
		}

		// Token: 0x0600A8E6 RID: 43238 RVA: 0x0023968C File Offset: 0x00237A8C
		public string GetPlayerName()
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			if (beFighterData != null)
			{
				return beFighterData.Name;
			}
			return string.Empty;
		}

		// Token: 0x0600A8E7 RID: 43239 RVA: 0x002396B8 File Offset: 0x00237AB8
		public void SetAdventureTeamName(string name)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.AdventureTeamName = name;
			if (this.GraphicActor != null)
			{
				this.GraphicActor.UpdateAdventTeamName(name);
			}
		}

		// Token: 0x0600A8E8 RID: 43240 RVA: 0x002396F0 File Offset: 0x00237AF0
		public void SetTitleName(PlayerWearedTitleInfo playerWearedTitleInfo)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.WearedTitleInfo = playerWearedTitleInfo;
			if (this.GraphicActor != null)
			{
				this.GraphicActor.UpdateTitleName(playerWearedTitleInfo);
			}
		}

		// Token: 0x0600A8E9 RID: 43241 RVA: 0x00239728 File Offset: 0x00237B28
		public void SetGuildEmblemLv(int guildEmblemLv)
		{
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			beFighterData.GuildEmblemLv = guildEmblemLv;
			if (this.GraphicActor != null)
			{
				this.GraphicActor.UpdateGuidLv(guildEmblemLv);
			}
		}

		// Token: 0x0600A8EA RID: 43242 RVA: 0x0023975F File Offset: 0x00237B5F
		public void ShowEquipStrengthenEffect(int strengthenLevel = 0)
		{
			if (strengthenLevel < 0)
			{
				return;
			}
			DataManager<PlayerBaseData>.GetInstance().AvatarShowWeaponStrengthen(null, strengthenLevel, this._geActor, false);
		}

		// Token: 0x0600A8EB RID: 43243 RVA: 0x0023977C File Offset: 0x00237B7C
		public bool IsFemaleGunner(int jobID)
		{
			return (jobID >= 50 && jobID <= 54) || (jobID >= 20 && jobID <= 24);
		}

		// Token: 0x0600A8EC RID: 43244 RVA: 0x002397A4 File Offset: 0x00237BA4
		public virtual void CreatePet(int a_nPetID)
		{
			this.DestroyPet();
			if (a_nPetID > 0)
			{
				BePetData bePetData = new BePetData
				{
					PetID = a_nPetID
				};
				bePetData.MoveData.PosLogicToGraph = base.ActorData.MoveData.PosLogicToGraph;
				this.m_townPet = new BePet(bePetData, this._battle);
				this.m_townPet.SetOwner(this);
				this.m_townPet.SetDialogEnable(false);
				if (this._geActor != null)
				{
					this.m_townPet.InitGeActor(this._geScene);
				}
			}
		}

		// Token: 0x0600A8ED RID: 43245 RVA: 0x0023982E File Offset: 0x00237C2E
		public void DestroyPet()
		{
			if (this.m_townPet != null)
			{
				this.m_townPet.Dispose();
				this.m_townPet = null;
			}
		}

		// Token: 0x0600A8EE RID: 43246 RVA: 0x00239850 File Offset: 0x00237C50
		public void CreateFollow()
		{
			this.DestroyFollow();
			if (this._geActor == null)
			{
				return;
			}
			BeFighterData beFighterData = base.ActorData as BeFighterData;
			if (beFighterData == null)
			{
				return;
			}
			string attachModelPath = BeUtility.GetAttachModelPath(beFighterData.JobID);
			if (attachModelPath == null)
			{
				return;
			}
			GameObject entityNode = this._geActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
			this.attachModel = Utility.AddModelToActor(attachModelPath, this._geActor, entityNode);
		}

		// Token: 0x0600A8EF RID: 43247 RVA: 0x002398B5 File Offset: 0x00237CB5
		public void DestroyFollow()
		{
			if (this.attachModel != null)
			{
				UnityEngine.Object.Destroy(this.attachModel);
				this.attachModel = null;
			}
		}

		// Token: 0x0600A8F0 RID: 43248 RVA: 0x002398DC File Offset: 0x00237CDC
		public void CreateFootIndicator(BeFighter.FootEffectType type = BeFighter.FootEffectType.DEFUALT)
		{
			string str = string.Empty;
			string attachRes = string.Empty;
			if (type == BeFighter.FootEffectType.DEFUALT)
			{
				attachRes = "Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_guo";
			}
			else if (type == BeFighter.FootEffectType.RED)
			{
				str = "red";
				attachRes = "Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_hong";
			}
			else if (type == BeFighter.FootEffectType.BULE)
			{
				str = "blue";
				attachRes = "Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_lan";
			}
			GeAttach geAttach = this._geActor.CreateAttachment(str + "Aureole", attachRes, "[actor]Orign", false, false, false);
			if (geAttach != null && this._geActor.GetAttachment("halo") != null && type == BeFighter.FootEffectType.DEFUALT)
			{
				geAttach.SetVisible(false);
			}
			else
			{
				geAttach.SetVisible(true);
			}
		}

		// Token: 0x0600A8F1 RID: 43249 RVA: 0x00239988 File Offset: 0x00237D88
		public void CreateBullet(ulong targetId, int projectileId)
		{
			BeBattleProjectile.BeBulletData data = new BeBattleProjectile.BeBulletData
			{
				attackId = base.ActorData.GUID,
				targetId = targetId,
				typeId = projectileId,
				damageValue = 5
			};
			BeBattleProjectile beBattleProjectile = new BeBattleProjectile(data, this._battle);
			beBattleProjectile.ActorData.MoveData.PosLogicToGraph = base.ActorData.MoveData.PosLogicToGraph;
			beBattleProjectile.ActorData.MoveData.PosServerToClient = base.ActorData.MoveData.PosServerToClient;
			beBattleProjectile.InitGeActor(this._geScene);
			this._battle.Projectiles.AddFighter(beBattleProjectile);
		}

		// Token: 0x04005E45 RID: 24133
		protected LinkedList<BeFighter.MoveCommand> moveCommands = new LinkedList<BeFighter.MoveCommand>();

		// Token: 0x04005E46 RID: 24134
		protected BeFighter.MoveCommand currMoveCommand;

		// Token: 0x04005E47 RID: 24135
		private DelayCallUnitHandle m_delayCallStopMove;

		// Token: 0x04005E48 RID: 24136
		private bool m_isDead;

		// Token: 0x04005E49 RID: 24137
		protected ushort m_grassId;

		// Token: 0x04005E4A RID: 24138
		protected BePet m_townPet;

		// Token: 0x04005E4B RID: 24139
		private GameObject attachModel;

		// Token: 0x04005E4C RID: 24140
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

		// Token: 0x04005E4D RID: 24141
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

		// Token: 0x04005E4E RID: 24142
		private bool m_lastInfoBarLoaded;

		// Token: 0x02001146 RID: 4422
		protected struct MoveCommand
		{
			// Token: 0x0600A8F4 RID: 43252 RVA: 0x00239A63 File Offset: 0x00237E63
			public MoveCommand(Vector3 pos, Vector3 dir)
			{
				this.currPosition = pos;
				this.targetDirection = dir;
			}

			// Token: 0x04005E4F RID: 24143
			public Vector3 currPosition;

			// Token: 0x04005E50 RID: 24144
			public Vector3 targetDirection;
		}

		// Token: 0x02001147 RID: 4423
		public enum FootEffectType
		{
			// Token: 0x04005E52 RID: 24146
			DEFUALT,
			// Token: 0x04005E53 RID: 24147
			RED,
			// Token: 0x04005E54 RID: 24148
			BULE
		}
	}
}
