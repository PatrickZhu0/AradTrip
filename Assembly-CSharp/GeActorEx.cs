using System;
using System.Collections.Generic;
using System.IO;
using Battle;
using GameClient;
using GamePool;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000D0D RID: 3341
public class GeActorEx : GeEntity
{
	// Token: 0x0600883F RID: 34879 RVA: 0x001857F8 File Offset: 0x00183BF8
	public GeActorEx()
	{
		string[,] array = new string[2, 2];
		array[0, 0] = "UIFlatten/Prefabs/DialogParent/DialogParent_battle_skill";
		array[0, 1] = "UIFlatten/Prefabs/DialogParent/DialogParent";
		array[1, 0] = "UIFlatten/Prefabs/DialogParent/DialogParent_battle_skill";
		array[1, 1] = "UIFlatten/Prefabs/DialogParent/DialogParent_battle";
		this.kHeadDialogPaths = array;
		this.m_MatSurfObjDescList = new List<GeActorEx.MatSurfObjDesc>();
		this.m_LastEmissiveColor = Color.clear;
		this.m_DestEmissiveColor = Color.clear;
		this.hpBarBuffEffectNameList = new List<string>();
		this.curHpBarBuffName = string.Empty;
		this.mPlayerInfoBarDataHandle = uint.MaxValue;
		this.mBars = new List<IDungeonCharactorBar>();
		base..ctor();
	}

	// Token: 0x06008840 RID: 34880 RVA: 0x00185918 File Offset: 0x00183D18
	protected uint _addAsyncLoadGameObject(string path, PostLoadGameObject load, uint condition = 4294967295U)
	{
		uint num = Singleton<AsyncLoadTaskManager>.instance.AddAsyncLoadGameObject("GeActorEx_", path, load, condition);
		this.mCachedAsyncHandles.Add(num);
		return num;
	}

	// Token: 0x06008841 RID: 34881 RVA: 0x00185948 File Offset: 0x00183D48
	public uint _addAsyncLoadGameObject(string path, enResourceType restype, bool reserveLast, PostLoadGameObject load, uint condition = 4294967295U)
	{
		uint num = Singleton<AsyncLoadTaskManager>.instance.AddAsyncLoadGameObject("GeActorEx_", path, restype, reserveLast, load, condition);
		this.mCachedAsyncHandles.Add(num);
		return num;
	}

	// Token: 0x06008842 RID: 34882 RVA: 0x0018597C File Offset: 0x00183D7C
	public void _clearAsyncLoadGameObject()
	{
		for (int i = 0; i < this.mCachedAsyncHandles.Count; i++)
		{
			Singleton<AsyncLoadTaskManager>.instance.RemoveAsyncLoadGameObjectByHandle(this.mCachedAsyncHandles[i]);
		}
		this.mCachedAsyncHandles.Clear();
	}

	// Token: 0x1700182D RID: 6189
	// (get) Token: 0x06008843 RID: 34883 RVA: 0x001859C6 File Offset: 0x00183DC6
	public NpcDialogComponent NpcDialogComponent
	{
		get
		{
			return this.dialogComponent;
		}
	}

	// Token: 0x1700182E RID: 6190
	// (get) Token: 0x06008844 RID: 34884 RVA: 0x001859CE File Offset: 0x00183DCE
	public NpcVoiceComponent NpcVoiceComponent
	{
		get
		{
			return this.voiceComponent;
		}
	}

	// Token: 0x1700182F RID: 6191
	// (get) Token: 0x06008845 RID: 34885 RVA: 0x001859D6 File Offset: 0x00183DD6
	public Sprite EntityHeadIcon
	{
		get
		{
			return this.entityHeadIcon;
		}
	}

	// Token: 0x17001830 RID: 6192
	// (get) Token: 0x06008846 RID: 34886 RVA: 0x001859DE File Offset: 0x00183DDE
	public Material EntityHeadIconMaterial
	{
		get
		{
			return this.entityHeadIconMaterial;
		}
	}

	// Token: 0x06008847 RID: 34887 RVA: 0x001859E8 File Offset: 0x00183DE8
	private string _getHeadDialogPath(bool bUseLink, bool useSkill)
	{
		int num = (!bUseLink) ? 1 : 0;
		int num2 = (!useSkill) ? 1 : 0;
		return this.kHeadDialogPaths[num, num2];
	}

	// Token: 0x06008848 RID: 34888 RVA: 0x00185A1E File Offset: 0x00183E1E
	private bool _isAvatatrPrefabLoadFinish()
	{
		return null != this.m_EntitySpaceDesc.actorModel;
	}

	// Token: 0x06008849 RID: 34889 RVA: 0x00185A31 File Offset: 0x00183E31
	private bool _isPlayerInfoHeadLoadFinish()
	{
		return null != this.goInfoBar;
	}

	// Token: 0x0600884A RID: 34890 RVA: 0x00185A40 File Offset: 0x00183E40
	private void _onAddNpcArrowComponent(GameObject gameobject)
	{
		if (null == gameobject)
		{
			return;
		}
		this.npcArrowComponent = gameobject.GetComponent<NpcArrowComponent>();
		if (this.npcArrowComponent == null)
		{
			this.npcArrowComponent = gameobject.AddComponent<NpcArrowComponent>();
			this.npcArrowComponent.DeActive();
		}
		GeUtility.AttachTo(gameobject, this.m_EntitySpaceDesc.characterNode, false);
	}

	// Token: 0x0600884B RID: 34891 RVA: 0x00185AA0 File Offset: 0x00183EA0
	private void moveBuffsEffects(GameObject fr, GameObject to)
	{
		BeActor beActor = this.entity as BeActor;
		if (beActor == null)
		{
			return;
		}
		List<BeBuff> buffList = beActor.buffController.GetBuffList();
		int count = buffList.Count;
		if (count < 1)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			GeEffectEx effectEx = buffList[i].GetEffectEx();
			if (effectEx != null)
			{
				GameObject parentNode = effectEx.GetParentNode();
				if (!(parentNode == null))
				{
					GameObject attchNodeDescWithRareName = this.m_Avatar.GetAttchNodeDescWithRareName(parentNode.name);
					if (!(attchNodeDescWithRareName == null))
					{
						effectEx.SetParentNode(attchNodeDescWithRareName);
					}
				}
			}
		}
	}

	// Token: 0x0600884C RID: 34892 RVA: 0x00185B5C File Offset: 0x00183F5C
	private void PreLoadModelsFromSkill(BDEntityActionFrameData data)
	{
		if (data == null)
		{
			return;
		}
		List<BDEventBase> pEvents = data.pEvents;
		int count = pEvents.Count;
		if (count < 1)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			BDEventBase bdeventBase = pEvents[i];
			BDSkillFrameEffect bdskillFrameEffect = bdeventBase as BDSkillFrameEffect;
			if (bdskillFrameEffect != null)
			{
				EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(bdskillFrameEffect.effectID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(tableItem.BuffID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						if (tableItem2.MechanismID.Count >= 1)
						{
							MechanismTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<MechanismTable>(tableItem2.MechanismID[0], string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								if (tableItem3.Index == 27)
								{
									BeEntityData entityData = this.entity.GetEntityData();
									int monsterId = Mechanism27.GetMonsterId(entityData.monsterID, tableItem3);
									if (monsterId == 0)
									{
										break;
									}
									UnitTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(monsterId, string.Empty, string.Empty);
									if (tableItem4 == null)
									{
										break;
									}
									this.PreChangeModel(tableItem4.Mode, false);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0600884D RID: 34893 RVA: 0x00185CC0 File Offset: 0x001840C0
	private bool _initActorDescWithResTable(ResTable resData)
	{
		if (resData == null)
		{
			return false;
		}
		this.m_ActorDesc.resID = resData.ID;
		this.m_ActorDesc.resPath = resData.ModelPath;
		this.m_ActorDesc.resName = Path.GetFileNameWithoutExtension(this.m_ActorDesc.resPath);
		this.m_ActorDesc.portraitIconRes = resData.IconPath;
		return true;
	}

	// Token: 0x0600884E RID: 34894 RVA: 0x00185D24 File Offset: 0x00184124
	private void _onCreateNPCAsync(GameObject actorModel)
	{
		if (this._onActorModelPrefabLoadFinish(actorModel))
		{
			if (null != actorModel)
			{
				actorModel.CustomActive(true);
			}
			this.m_EntityState = GeActorEx.GeEntityState.Loaded;
			this._onPostActorModelPrefabLoadFinish(actorModel);
			if (this.mPostLoadTownNPC != null)
			{
				this.mPostLoadTownNPC(this);
			}
		}
		else
		{
			Logger.LogErrorFormat("[GeActorEx] Actor is nil with path {0}", new object[]
			{
				this.m_ActorDesc.resPath
			});
		}
	}

	// Token: 0x0600884F RID: 34895 RVA: 0x00185D98 File Offset: 0x00184198
	private bool _onActorModelPrefabLoadFinish(GameObject actorModel)
	{
		if (null == actorModel)
		{
			Logger.LogErrorFormat("[GeActorEx] Actor is nil with path {0}", new object[]
			{
				this.m_ActorDesc.resPath
			});
			return false;
		}
		this.m_ActorPartes = new GameObject[]
		{
			actorModel
		};
		GeUtility.AttachTo(actorModel, this.m_EntitySpaceDesc.actorNode, false);
		this.m_EntitySpaceDesc.actorModel = actorModel;
		Renderer component = actorModel.GetComponent<Renderer>();
		if (null != component)
		{
			this.m_BoundingBox.min = Vector3.Min(component.bounds.min, this.m_BoundingBox.min);
			this.m_BoundingBox.max = Vector3.Min(component.bounds.max, this.m_BoundingBox.max);
		}
		Singleton<GeGraphicSetting>.instance.CheckComponent(actorModel);
		return true;
	}

	// Token: 0x06008850 RID: 34896 RVA: 0x00185E70 File Offset: 0x00184270
	private void _onPostActorModelPrefabLoadFinish(GameObject actorModel)
	{
		actorModel.layer = 9;
		if (this.isBattleActor)
		{
			this.m_Material.AppendObject(this.m_ActorPartes);
		}
		this.m_EntitySpaceDesc.childNode = this.m_EntitySpaceDesc.actorNode;
		if (this.m_ActorDesc.portraitIconRes != "-" && this.m_ActorDesc.portraitIconRes.Length >= 2)
		{
			this.entityHeadIconAsset = Singleton<AssetLoader>.instance.LoadRes(this.m_ActorDesc.portraitIconRes, typeof(Sprite), true, 0U);
			this.entityHeadIcon = (this.entityHeadIconAsset.obj as Sprite);
			this.entityHeadIconMaterial = ETCImageLoader.LoadMaterialFromSpritePath(this.m_ActorDesc.portraitIconRes, true);
		}
		if (null != this.m_ModelData && null != this.m_EntitySpaceDesc.transformNode)
		{
			this.m_EntitySpaceDesc.transformNode.transform.localScale = this.m_ModelData.modelScale;
		}
		if (this.m_Scene != null)
		{
			this.SetDyeColor(this.m_Scene.GetObjectDyeColor(), this.m_ActorPartes);
		}
		this.InitAttachPoint();
		this._RefleshUIComponent();
		this.m_EntityState = GeActorEx.GeEntityState.Inited;
		Singleton<AssetGabageCollectorHelper>.instance.AddGCPurgeTick(AssetGCTickType.SceneActor);
		this.m_IsAvatarDirty = true;
	}

	// Token: 0x06008851 RID: 34897 RVA: 0x00185FCC File Offset: 0x001843CC
	private void _onAddComponetDialog(GameObject gameobject)
	{
		if (null == gameobject)
		{
			return;
		}
		if (this.mDialogComponentData == null)
		{
			return;
		}
		gameobject.name = "DialogParent";
		GeUtility.AttachTo(gameobject, this.m_EntitySpaceDesc.rootNode, false);
		GameObject gameObject = gameobject.transform.Find("PopUpDialog").gameObject;
		if (gameObject != null)
		{
			this.dialogComponent = gameObject.GetComponent<NpcDialogComponent>();
			if (this.dialogComponent == null)
			{
				this.dialogComponent = gameObject.AddComponent<NpcDialogComponent>();
			}
			if (this.dialogComponent != null && this.mDialogComponentData != null)
			{
				Vector3 worldPos = Vector3.zero;
				GameObject entityNode = base.GetEntityNode(GeEntity.GeEntityNodeType.Root);
				GameObject gameObject2 = Utility.FindThatChild("OverHead", entityNode, true);
				if (gameObject2 != null)
				{
					worldPos = gameObject2.transform.position;
					worldPos.y += 0.45f;
				}
				else
				{
					Logger.LogError("[GeActorEx] ObjOverhead is null");
				}
				this.dialogComponent.Initialize(worldPos, this.mDialogComponentData.iDialogID, this.mDialogComponentData.eIdBelong2);
			}
		}
		this.mDialogComponentData = null;
	}

	// Token: 0x06008852 RID: 34898 RVA: 0x001860F4 File Offset: 0x001844F4
	private void _onAddNPCBoxCollider()
	{
		if (this.mNPCBoxCollectData == null)
		{
			return;
		}
		GameObject entityNode = base.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
		if (entityNode != null)
		{
			if (entityNode != null && entityNode.GetComponent<BoxCollider>() != null)
			{
				RaycastObject raycastObject = entityNode.GetComponent<RaycastObject>();
				if (raycastObject == null)
				{
					raycastObject = entityNode.AddComponent<RaycastObject>();
					raycastObject.Initialize(this.mNPCBoxCollectData.townData.NpcID, RaycastObject.RaycastObjectType.ROT_NPC, this.mNPCBoxCollectData.townData);
				}
				else
				{
					Logger.LogError("[GeAcotrEx] comRayCastObject is nil");
				}
			}
		}
		else
		{
			Logger.LogError("[GeAcotrEx] objActor is nil");
		}
	}

	// Token: 0x06008853 RID: 34899 RVA: 0x00186198 File Offset: 0x00184598
	private void _onAddNPCInteraction()
	{
		if (null == this.goInfoBar)
		{
			return;
		}
		if (this.mNpcInteractionData == null)
		{
			return;
		}
		NpcInteraction npcInteraction = this.goInfoBar.GetComponent<NpcInteraction>();
		if (npcInteraction == null)
		{
			npcInteraction = this.goInfoBar.AddComponent<NpcInteraction>();
		}
		npcInteraction.Initialize(this.mNpcInteractionData.npcID, this.mNpcInteractionData.Guid);
		this.mNpcInteractionData = null;
	}

	// Token: 0x06008854 RID: 34900 RVA: 0x0018620C File Offset: 0x0018460C
	private void _onCreateInfoBar(GameObject gameobject)
	{
		if (null == gameobject)
		{
			return;
		}
		if (this.mPlayerInfoBarData == null)
		{
			CGameObjectPool.RecycleGameObjectEx(gameobject);
			return;
		}
		string name = gameobject.name;
		this.goInfoBar = gameobject;
		this.goInfoBar.name = "PlayerInfo_Head";
		this.goInfoBar.CustomActive(true);
		this.goInfoBar.transform.localPosition = new Vector3(0f, 2.215332f, 0f);
		this.goInfoBar.transform.localEulerAngles = new Vector3(20f, 0f, 0f);
		this.goInfoBar.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		GeUtility.AttachTo(this.goInfoBar, this.m_EntitySpaceDesc.rootNode, false);
		ComCommonBind component = this.goInfoBar.GetComponent<ComCommonBind>();
		if (component != null)
		{
			this.goInfoBarBottom = component.GetGameObject("goInfoBarBottom");
			if (this.goInfoBarBottom != null)
			{
				this.goInfoBarBottom.CustomActive(true);
			}
			else
			{
				Logger.LogErrorFormat("_onCreateInfoBar has not goInfoBarBottom {0}", new object[]
				{
					name
				});
			}
			GameObject gameObject = component.GetGameObject("ExchangeShop");
			if (gameObject != null)
			{
				gameObject.CustomActive(false);
			}
			this._updateChapterHeadInfoBarPosition();
			Text com = component.GetCom<Text>("textComp");
			if (com != null)
			{
				com.text = this.mPlayerInfoBarData.name;
				if (this.mPlayerInfoBarData.namecolors == null)
				{
					com.supportRichText = false;
					CPlayerInfo com2 = component.GetCom<CPlayerInfo>("info");
					if (com2 != null)
					{
						com.color = com2.GetColor(this.mPlayerInfoBarData.infoColor);
					}
				}
				else
				{
					com.supportRichText = true;
					com.text = string.Format("<color={0}>{1}</color>", this.mPlayerInfoBarData.namecolors, this.mPlayerInfoBarData.name);
				}
			}
			this.m_kLevelText = component.GetCom<Text>("levelText");
			this.UpdateLevel((int)this.mPlayerInfoBarData.RoleLevel);
			this.goTransportInfo = component.GetGameObject("transport");
		}
		else
		{
			Logger.LogErrorFormat("_onCreateInfoBar has not bind {0}", new object[]
			{
				name
			});
		}
		Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.goInfoBar);
		this._onPostLoadChapterHeadInfoRoot();
		this.SetGoInfoBarLocalPosition(this.goInfoBar.transform.localPosition);
	}

	// Token: 0x06008855 RID: 34901 RVA: 0x00186488 File Offset: 0x00184888
	private void _onCreateInfoBarCallBack(GameObject gameobject)
	{
		if (this.mPlayerInfoBarDataHandle == 4294967295U)
		{
			CGameObjectPool.RecycleGameObjectEx(gameobject);
			return;
		}
		if (base.CanRemove())
		{
			CGameObjectPool.RecycleGameObjectEx(gameobject);
			return;
		}
		this._onCreateInfoBar(gameobject);
		if (this.mPostLoadInfoBar != null)
		{
			this.mPostLoadInfoBar(this);
		}
	}

	// Token: 0x06008856 RID: 34902 RVA: 0x001864D8 File Offset: 0x001848D8
	private void SetGoInfoBarLocalPosition(Vector3 localPos)
	{
		if (this.mPlayerInfoBarData == null)
		{
			return;
		}
		if (this.mPlayerInfoBarData.NameLocalPosY > 0f)
		{
			Vector3 localPosition = this.goInfoBar.transform.localPosition;
			this.goInfoBar.transform.localPosition = new Vector3(localPosition.x, this.mPlayerInfoBarData.NameLocalPosY, localPosition.z);
		}
		else
		{
			this.goInfoBar.transform.localPosition = localPos;
		}
	}

	// Token: 0x06008857 RID: 34903 RVA: 0x0018655C File Offset: 0x0018495C
	private void _updateChapterHeadInfoBarPosition()
	{
		if (null == this.goInfoBar)
		{
			return;
		}
		Vector3 localPosition = this.buffOriginLocalPosition;
		if (this.entity != null && this.entity.GetEntityData() != null && this.entity.GetEntityData().isMonster && this.entity.GetEntityData().buffOriginHeight > 0f)
		{
			localPosition.y = this.entity.GetEntityData().buffOriginHeight;
		}
		else
		{
			localPosition.y -= 0.25f;
		}
		if (this.useCube)
		{
			localPosition.y = 1.5f;
		}
		this.goInfoBar.transform.localPosition = localPosition;
	}

	// Token: 0x06008858 RID: 34904 RVA: 0x00186623 File Offset: 0x00184A23
	private void _onPostLoadChapterHeadInfoRoot()
	{
		this._onAddTittleComponent();
	}

	// Token: 0x06008859 RID: 34905 RVA: 0x0018662C File Offset: 0x00184A2C
	private void _onAddTittleComponent()
	{
		if (this.m_EntitySpaceDesc.rootNode == null)
		{
			Logger.LogError("call create infobar first!");
			return;
		}
		if (this.goInfoBar == null)
		{
			Logger.LogError("call create infobar first!");
			return;
		}
		if (this.mTittleComponentData == null)
		{
			return;
		}
		CPlayerInfo component = this.goInfoBar.GetComponent<CPlayerInfo>();
		if (component == null)
		{
			Logger.LogError("can not find CPlayerInfo!");
			return;
		}
		Color color = component.GetColor(this.mTittleComponentData.color);
		if (this.titleComponent == null)
		{
			this.titleComponent = TitleComponent.Create(this.goInfoBar);
			if (this.titleComponent == null)
			{
				return;
			}
			this.goInfoBarBottom.CustomActive(false);
		}
		int iTitleID = this.mTittleComponentData.iTittleID;
		BeActor beActor = this.entity as BeActor;
		if (beActor != null && beActor.isLocalActor)
		{
			if (BattleMain.IsModePvP(beActor.battleType) || beActor.battleType == BattleType.TrainingSkillCombo)
			{
				if (Singleton<SettingManager>.GetInstance().GetCommmonSet("SETTING_TITLESETPVP") == SettingManager.SetCommonType.Close)
				{
					iTitleID = 0;
				}
			}
			else if (Singleton<SettingManager>.GetInstance().GetCommmonSet("SETTING_TITLESET") == SettingManager.SetCommonType.Close)
			{
				iTitleID = 0;
			}
		}
		this.titleComponent.SetTitleData(iTitleID, this.mTittleComponentData.a_nPKRank, this.mTittleComponentData.iVipLevel, this.mTittleComponentData.guildDuty, this.mTittleComponentData.bangName, this.mTittleComponentData.iRoleLv, this.mTittleComponentData.name, this.mTittleComponentData.adventTeamName, this.mTittleComponentData.playerWearedTitleInfo, this.mTittleComponentData.guildEmblemLv, color);
	}

	// Token: 0x0600885A RID: 34906 RVA: 0x001867E8 File Offset: 0x00184BE8
	private void _createBarRoot()
	{
		if (null == this.mBarsRoot)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonBarRoot", true, 0U);
			if (null != gameObject)
			{
				GeUtility.AttachTo(gameObject, this.m_EntitySpaceDesc.rootNode, false);
				Vector3 overHeadPosition = this.GetOverHeadPosition();
				if (this.entity.GetEntityData() != null && this.entity.GetEntityData().overHeadHeight > 0f)
				{
					overHeadPosition.y = this.entity.GetEntityData().overHeadHeight;
				}
				overHeadPosition.y += 0.78f;
				gameObject.transform.localPosition = overHeadPosition;
				this.mBarsRoot = gameObject.GetComponent<ComDungeonBarRoot>();
				this.mBarsRoot.dRoot.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0f, -75f * overHeadPosition.y, 0f);
			}
		}
	}

	// Token: 0x0600885B RID: 34907 RVA: 0x001868DC File Offset: 0x00184CDC
	private string _getBarPath(eDungeonCharactorBar type)
	{
		switch (type)
		{
		case eDungeonCharactorBar.Sing:
		case eDungeonCharactorBar.Buff:
		case eDungeonCharactorBar.Continue:
		case eDungeonCharactorBar.Progress:
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorHeadSn";
		case eDungeonCharactorBar.Power:
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorHeadPn";
		case eDungeonCharactorBar.Loop:
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorBar";
		case eDungeonCharactorBar.DunFuCD:
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonDunFuBar";
		case eDungeonCharactorBar.RayDrop:
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorRayBar";
		case eDungeonCharactorBar.Fire:
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorHeadFire";
		case eDungeonCharactorBar.MonsterEnergyBar:
			return "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonCharactorMonsterEnergy";
		}
		return string.Empty;
	}

	// Token: 0x0600885C RID: 34908 RVA: 0x00186954 File Offset: 0x00184D54
	private IDungeonCharactorBar _attachBarRoot(eDungeonCharactorBar type, GameObject go)
	{
		if (null == go)
		{
			return null;
		}
		if (null != this.mBarsRoot)
		{
			switch (type)
			{
			case eDungeonCharactorBar.Sing:
			case eDungeonCharactorBar.Power:
			case eDungeonCharactorBar.Buff:
			case eDungeonCharactorBar.Continue:
			case eDungeonCharactorBar.DunFuCD:
			case eDungeonCharactorBar.Progress:
				Utility.AttachTo(go, this.mBarsRoot.vRoot, false);
				return go.GetComponent<ComDungeonCharactorHeadBar>();
			case eDungeonCharactorBar.Loop:
			case eDungeonCharactorBar.RayDrop:
			case eDungeonCharactorBar.MonsterEnergyBar:
				Utility.AttachTo(go, this.mBarsRoot.hRoot, false);
				return go.GetComponent<ComDungeonCharactorBar>();
			case eDungeonCharactorBar.Fire:
				Utility.AttachTo(go, this.mBarsRoot.dRoot, false);
				return go.GetComponent<ComDungeonCharactorHeadFireBar>();
			}
		}
		return null;
	}

	// Token: 0x0600885D RID: 34909 RVA: 0x00186A08 File Offset: 0x00184E08
	private void _stopBarEffect(eDungeonCharactorBar type)
	{
		GameObject gameObject = null;
		switch (type)
		{
		case eDungeonCharactorBar.Sing:
		case eDungeonCharactorBar.Power:
		case eDungeonCharactorBar.Buff:
		case eDungeonCharactorBar.Continue:
		case eDungeonCharactorBar.Progress:
			gameObject = this.mBarsRoot.vRoot;
			break;
		case eDungeonCharactorBar.Loop:
		case eDungeonCharactorBar.RayDrop:
		case eDungeonCharactorBar.MonsterEnergyBar:
			gameObject = this.mBarsRoot.hRoot;
			break;
		case eDungeonCharactorBar.Fire:
			gameObject = this.mBarsRoot.dRoot;
			break;
		}
		if (null != gameObject)
		{
			IDungeonCharactorBar dungeonCharactorBar = this.mBars.Find((IDungeonCharactorBar x) => type == x.GetBarType());
			if (dungeonCharactorBar != null)
			{
				GeEffectEx geEffectEx = base.CreateEffect("Effects/Hero_Jixieshi/EZ-8Zibaozhe/Perfab/Eff_Ez-8Zibaozhe_guang", string.Empty, 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
				if (geEffectEx != null)
				{
					GeUtility.AttachTo(geEffectEx.GetRootNode(), gameObject, false);
					geEffectEx.GetRootNode().transform.position = dungeonCharactorBar.GetGameObject().transform.position;
				}
			}
		}
	}

	// Token: 0x17001831 RID: 6193
	// (get) Token: 0x0600885E RID: 34910 RVA: 0x00186B2D File Offset: 0x00184F2D
	public Bounds boundingBox
	{
		get
		{
			if (this.m_Avatar != null)
			{
				return this.m_Avatar.boundingBox;
			}
			return this.m_BoundingBox;
		}
	}

	// Token: 0x17001832 RID: 6194
	// (get) Token: 0x0600885F RID: 34911 RVA: 0x00186B4C File Offset: 0x00184F4C
	public GameObject[] renderObject
	{
		get
		{
			return this.m_ActorPartes;
		}
	}

	// Token: 0x06008860 RID: 34912 RVA: 0x00186B54 File Offset: 0x00184F54
	public void CreateBarRoot()
	{
		this._createBarRoot();
	}

	// Token: 0x06008861 RID: 34913 RVA: 0x00186B5C File Offset: 0x00184F5C
	public static void ClearStatic()
	{
		GeActorEx.cachedOverhead.Clear();
	}

	// Token: 0x06008862 RID: 34914 RVA: 0x00186B68 File Offset: 0x00184F68
	public Vector3 GetOverHeadPosition()
	{
		if (this.overheadLocalPosition == Vector3.zero)
		{
			this._RefreshOverHeadPostion();
		}
		return this.overheadLocalPosition;
	}

	// Token: 0x06008863 RID: 34915 RVA: 0x00186B8B File Offset: 0x00184F8B
	private void _RefreshOverHeadPostion()
	{
		this.overheadLocalPosition = this.buffOriginLocalPosition;
		this.overheadLocalPosition.y = this.overheadLocalPosition.y - 0.6f;
	}

	// Token: 0x06008864 RID: 34916 RVA: 0x00186BB0 File Offset: 0x00184FB0
	public void InitAttachPoint()
	{
		GameObject gameObject = Utility.FindThatChild("Orign", this.m_EntitySpaceDesc.actorNode, false);
		if (gameObject != null)
		{
			this.originLocalPosition = this.m_EntitySpaceDesc.rootNode.transform.InverseTransformVector(gameObject.transform.position);
			this.originLocalPosition.x = 0f;
			this.originLocalPosition.z = 0f;
		}
		this.objBuffOrigin = Utility.FindThatChild("OrignBuff", this.m_EntitySpaceDesc.actorNode, false);
		if (this.objBuffOrigin != null)
		{
			this.buffOriginPosition = this.objBuffOrigin.transform.position;
			this.buffOriginLocalPosition = this.m_EntitySpaceDesc.rootNode.transform.InverseTransformPoint(this.buffOriginPosition);
			this.buffOriginLocalPosition.x = 0f;
			this.buffOriginLocalPosition.z = 0f;
		}
		else
		{
			this.buffOriginLocalPosition = this.originLocalPosition;
			this.buffOriginLocalPosition.y = this.buffOriginLocalPosition.y + 1.5f;
		}
		this.overheadLocalPosition = Vector3.zero;
		GameObject gameObject2 = Utility.FindThatChild("Body", this.m_EntitySpaceDesc.actorNode, false);
		if (gameObject2 != null)
		{
			this.bodyLocalPosition = this.m_EntitySpaceDesc.rootNode.transform.InverseTransformVector(gameObject2.transform.position);
		}
		else
		{
			this.bodyLocalPosition = this.originLocalPosition;
			this.bodyLocalPosition.y = this.bodyLocalPosition.y + 1f;
		}
	}

	// Token: 0x06008865 RID: 34917 RVA: 0x00186D50 File Offset: 0x00185150
	public GameObject AttachRelativeToLocator(string resPath, GameObject parent, string locator, Vector3 offset)
	{
		if (parent == null)
		{
			return null;
		}
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(resPath, true, 0U);
		if (gameObject == null)
		{
			return null;
		}
		GeUtility.AttachTo(gameObject, parent, false);
		GameObject gameObject2 = Utility.FindThatChild("OverHead", this.m_EntitySpaceDesc.actorNode, false);
		if (gameObject2)
		{
			Vector3 vector = gameObject2.transform.position;
			vector += offset;
			vector = parent.transform.InverseTransformPoint(vector);
			gameObject.transform.localPosition = vector;
		}
		else
		{
			Vector3 vector2;
			vector2..ctor(0f, 1.7f, 0f);
			if (this.goInfoBar != null)
			{
				vector2 = this.goInfoBar.transform.localPosition;
			}
			vector2 += offset;
			gameObject.transform.localPosition = vector2;
		}
		return gameObject;
	}

	// Token: 0x06008866 RID: 34918 RVA: 0x00186E34 File Offset: 0x00185234
	public void ShowFindPath(bool show = true)
	{
		if (this.goShowFindPath == null)
		{
			this.goShowFindPath = this.AttachRelativeToLocator("Effects/Common/Sfx/Zidongxunlu/Eff_zidongxunlu", this.m_EntitySpaceDesc.rootNode, "OverHead", new Vector3(0f, 1f, 0f));
			Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.goShowFindPath);
		}
		if (null == this.goShowFindPath)
		{
			return;
		}
		if (this.goShowFindPath.activeSelf != show)
		{
			this.goShowFindPath.SetActive(show);
		}
	}

	// Token: 0x06008867 RID: 34919 RVA: 0x00186EC8 File Offset: 0x001852C8
	public void ShowHeadDialog(string text, bool hide = false, bool bLink = false, bool bUseLink = false, bool useSkill = false, float fLifeTime = 3.5f, bool isPet = false)
	{
		if (this.goDialog == null && hide)
		{
			return;
		}
		if (this.useCube)
		{
			return;
		}
		if (this.goDialog == null)
		{
			this.goDialog = Singleton<AssetLoader>.instance.LoadResAsGameObject(this._getHeadDialogPath(bUseLink, useSkill), true, 0U);
			GeUtility.AttachTo(this.goDialog, this.m_EntitySpaceDesc.rootNode, false);
			Vector3 overHeadPosition = this.GetOverHeadPosition();
			if (this.entity != null && this.entity.GetEntityData() != null && this.entity.GetEntityData().overHeadHeight > 0f)
			{
				overHeadPosition.y = this.entity.GetEntityData().overHeadHeight;
			}
			overHeadPosition.y += 0.45f;
			this.goDialog.transform.localPosition = overHeadPosition;
			this.dialog = this.goDialog.AddComponent<DialogScript>();
			this.dialog.Initialize(bUseLink);
			Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.goDialog);
		}
		if (this.dialog != null)
		{
			if (hide)
			{
				this.dialog.DoHide();
			}
			else
			{
				this.dialog.ShowText(text, bLink, fLifeTime);
			}
		}
	}

	// Token: 0x06008868 RID: 34920 RVA: 0x00187018 File Offset: 0x00185418
	public void CreateFootIndicator(string effect = null)
	{
		string path = "UIFlatten/Prefabs/PlayerInfo/PlayerInfo_Foot";
		if (effect != null)
		{
			path = effect;
		}
		if (this.goFootInfo != null)
		{
			Object.Destroy(this.goFootInfo);
		}
		this.goFootInfo = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		if (this.goFootInfo == null)
		{
			return;
		}
		GeUtility.AttachTo(this.goFootInfo, this.m_EntitySpaceDesc.rootNode, false);
		Vector3 localPosition = this.originLocalPosition;
		localPosition.y += 0.1f;
		this.goFootInfo.transform.localPosition = localPosition;
		Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.goFootInfo);
	}

	// Token: 0x06008869 RID: 34921 RVA: 0x001870C8 File Offset: 0x001854C8
	public void SetFootIndicatorTouchGround(float y)
	{
		if (this.goFootInfo == null)
		{
			return;
		}
		Vector3 localPosition = this.goFootInfo.transform.localPosition;
		localPosition.y = -y;
		localPosition.y += 0.02f;
		this.goFootInfo.transform.localPosition = localPosition;
	}

	// Token: 0x0600886A RID: 34922 RVA: 0x00187125 File Offset: 0x00185525
	public void SetFootIndicatorVisible(bool flag)
	{
		if (this.goFootInfo == null)
		{
			return;
		}
		this.goFootInfo.SetActive(flag);
	}

	// Token: 0x0600886B RID: 34923 RVA: 0x00187145 File Offset: 0x00185545
	public void SetHeadInfoVisible(bool flag)
	{
		if (this.goInfoBar == null)
		{
			return;
		}
		this.goInfoBar.SetActive(flag);
	}

	// Token: 0x0600886C RID: 34924 RVA: 0x00187168 File Offset: 0x00185568
	public void CreateMonsterLoop()
	{
		this.goFootInfo = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/BOSS/Prefab/Eff_BOSS_GH", true, 0U);
		if (this.goFootInfo != null)
		{
			GeUtility.AttachTo(this.goFootInfo, this.m_EntitySpaceDesc.rootNode, false);
		}
	}

	// Token: 0x0600886D RID: 34925 RVA: 0x001871B4 File Offset: 0x001855B4
	public void CreateMonsterInfoBar(string name, PlayerInfoColor infoColor)
	{
		string prefabFullPath = "UIFlatten/Prefabs/PlayerInfo/MonsterInfo_Head";
		if (this.goInfoBar == null)
		{
			this.goInfoBar = Singleton<CGameObjectPool>.instance.GetGameObject(prefabFullPath, enResourceType.BattleScene, 2U);
			GeUtility.AttachTo(this.goInfoBar, this.m_EntitySpaceDesc.rootNode, false);
			this._updateChapterHeadInfoBarPosition();
			Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.goInfoBar);
		}
		if (null == this.goInfoBar)
		{
			return;
		}
		GameObject gameObject = Utility.FindChild(this.goInfoBar, "Name");
		if (null == gameObject)
		{
			return;
		}
		Text component = gameObject.GetComponent<Text>();
		if (null == component)
		{
			return;
		}
		component.text = name;
		CPlayerInfo component2 = this.goInfoBar.GetComponent<CPlayerInfo>();
		if (null == component2)
		{
			return;
		}
		component.color = component2.GetColor(infoColor);
	}

	// Token: 0x0600886E RID: 34926 RVA: 0x0018728C File Offset: 0x0018568C
	public void SetTaskMonster(string name)
	{
		if (this.goInfoBar == null)
		{
			this.CreateMonsterInfoBar(name, PlayerInfoColor.TOWN_OTHER_PLAYER);
		}
		if (this.goInfoBar != null)
		{
			GameObject gameObject = Utility.FindChild(this.goInfoBar, "Name/task_indicate");
			if (gameObject != null)
			{
				gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x0600886F RID: 34927 RVA: 0x001872E8 File Offset: 0x001856E8
	public GameObject CreateHeadText(HitTextType type, object arg = null, bool noattach = false, object arg2 = null)
	{
		string text = string.Empty;
		string key = null;
		if (type == HitTextType.SPECIAL_ATTACK)
		{
			text = "UIFlatten/Prefabs/Battle_Digit/PlayerInfo_SpecialAttack";
			if (arg2 != null)
			{
				string text2 = arg2 as string;
				if (text2 != null)
				{
					text = text2;
				}
			}
			string key5 = arg as string;
			key = key5;
		}
		else if (type == HitTextType.SKILL_CANNOTUSE)
		{
			text = "UIFlatten/Prefabs/Battle_Digit/PlayerInfo_SpecialAttack";
			string key2 = arg as string;
			key = key2;
		}
		else if (type == HitTextType.BUFF_TEXT)
		{
			text = "UIFlatten/Prefabs/Battle_Digit/PlayerInfo_BuffName";
			key = "BUFF_TEXT";
		}
		else if (type == HitTextType.GET_EXP)
		{
			text = "UIFlatten/Prefabs/Battle_Digit/PlayerInfo_GetExp";
			key = "GET_EXP";
		}
		else if (type == HitTextType.GET_GOLD)
		{
			text = "UIFlatten/Prefabs/Battle_Digit/PlayerInfo_GetGold";
			key = "GET_GOLD";
		}
		if ((type == HitTextType.SPECIAL_ATTACK || type == HitTextType.SKILL_CANNOTUSE) && this.headTextCount.ContainsKey(key) && this.headTextCount[key] > 0)
		{
			return null;
		}
		if (!this.headTextCount.ContainsKey(key))
		{
			this.headTextCount.Add(key, 0);
		}
		Dictionary<string, int> dictionary;
		string key3;
		(dictionary = this.headTextCount)[key3 = key] = dictionary[key3] + 1;
		float num = (float)(this.headTextCount[key] - 1) * 0.3f;
		string tmpKey = null;
		if (type == HitTextType.SPECIAL_ATTACK || type == HitTextType.SKILL_CANNOTUSE)
		{
			tmpKey = ((type != HitTextType.SPECIAL_ATTACK) ? "SKILL_CANNOTUSE" : "SPECIAL_ATTACK");
			if (!this.headTextCount.ContainsKey(tmpKey))
			{
				this.headTextCount.Add(tmpKey, 0);
			}
			string tmpKey3;
			(dictionary = this.headTextCount)[tmpKey3 = tmpKey] = dictionary[tmpKey3] + 1;
			num = (float)(this.headTextCount[tmpKey] - 1) * 0.4f;
		}
		if (this.entity != null)
		{
			this.entity.delayCaller.DelayCall(1000, delegate
			{
				Dictionary<string, int> dictionary2;
				string key4;
				(dictionary2 = this.headTextCount)[key4 = key] = dictionary2[key4] - 1;
				if (tmpKey != null)
				{
					string tmpKey2;
					(dictionary2 = this.headTextCount)[tmpKey2 = tmpKey] = dictionary2[tmpKey2] - 1;
				}
			}, 0, 0, false);
		}
		GameObject go = null;
		if (text.Length > 1)
		{
			go = Singleton<CGameObjectPool>.instance.GetGameObject(text, enResourceType.BattleScene, 2U);
			if (go != null)
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(1300, delegate
				{
					Singleton<CGameObjectPool>.instance.RecycleGameObject(go);
				}, 0, 0, true);
			}
		}
		if (go == null)
		{
			return go;
		}
		if ((type == HitTextType.SPECIAL_ATTACK || type == HitTextType.BUFF_TEXT || type == HitTextType.SKILL_CANNOTUSE) && go != null)
		{
			string path = arg as string;
			Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(path, typeof(Sprite), true, 0U).obj as Sprite;
			if (text != null && sprite != null)
			{
				GameObject gameObject = Utility.FindGameObject(go, "root/text", false);
				if (gameObject != null)
				{
					Image component = gameObject.GetComponent<Image>();
					ETCImageLoader.LoadSprite(ref component, path, true);
					component.SetNativeSize();
					if (type == HitTextType.SPECIAL_ATTACK || type == HitTextType.SKILL_CANNOTUSE)
					{
						Color color = component.color;
						color.a = 1f;
						component.color = color;
					}
				}
			}
		}
		else if (type == HitTextType.GET_EXP || type == HitTextType.GET_GOLD)
		{
			int num2 = (int)arg;
			GameObject gameObject2 = Utility.FindThatChild("Text", go, false);
			if (gameObject2 != null)
			{
				Text component2 = gameObject2.GetComponent<Text>();
				component2.text = "+" + num2;
			}
			if (type == HitTextType.GET_GOLD)
			{
				string text3 = arg2 as string;
				if (text3 != null)
				{
					GameObject gameObject3 = Utility.FindThatChild("Text (1)", go, false);
					if (gameObject3 != null)
					{
						Text component3 = gameObject3.GetComponent<Text>();
						component3.text = text3;
					}
				}
			}
		}
		if (noattach)
		{
			go.transform.position = this.m_EntitySpaceDesc.rootNode.transform.position;
			return go;
		}
		GeUtility.AttachTo(go, this.m_EntitySpaceDesc.rootNode, false);
		if (type == HitTextType.SKILL_CANNOTUSE)
		{
			Vector3 localPosition = this.bodyLocalPosition;
			localPosition.z = -1f;
			go.transform.localPosition = localPosition;
		}
		else if (this.objBuffOrigin != null)
		{
			Vector3 vector = this.buffOriginPosition;
			vector.y += num;
			vector.x = 0f;
			vector.z = -0.1f;
			vector = this.m_EntitySpaceDesc.rootNode.transform.InverseTransformVector(vector);
			go.transform.localPosition = vector;
		}
		else if (this.objOverhead != null)
		{
			Vector3 vector2 = Vector3.zero;
			vector2.y += 0.35f;
			vector2.x = 0f;
			vector2.z = -0.1f;
			vector2 = this.m_EntitySpaceDesc.rootNode.transform.InverseTransformVector(vector2);
			go.transform.localPosition = vector2;
		}
		else
		{
			Vector3 localPosition2 = go.transform.localPosition;
			localPosition2.y += 2f;
			go.transform.localPosition = localPosition2;
		}
		return go;
	}

	// Token: 0x06008870 RID: 34928 RVA: 0x001878AD File Offset: 0x00185CAD
	public void CreateInfoBar(string name, PlayerInfoColor infoColor, ushort RoleLevel, string namecolors = null, float nameLocalPosY = 0f)
	{
		this.mPlayerInfoBarData = new GeActorEx.PlayerInfoBarData(name, infoColor, RoleLevel, namecolors, nameLocalPosY);
		this.mPlayerInfoBarDataHandle = this._addAsyncLoadGameObject("UIFlatten/Prefabs/PlayerInfo/PlayerInfo_Head", enResourceType.UIPrefab, true, new PostLoadGameObject(this._onCreateInfoBarCallBack), this.mPostLoadTownNPCHandle);
	}

	// Token: 0x06008871 RID: 34929 RVA: 0x001878E6 File Offset: 0x00185CE6
	public void ShowTranport(bool flag)
	{
		if (this.showTransport == flag)
		{
			return;
		}
		this.showTransport = flag;
		if (this.goTransportInfo != null)
		{
			this.goTransportInfo.CustomActive(this.showTransport);
		}
	}

	// Token: 0x06008872 RID: 34930 RVA: 0x00187920 File Offset: 0x00185D20
	public void CreatePropertyRiseEffect(string content)
	{
		string path = "UIFlatten/Prefabs/CommonSystemNotify/CommonFloatingEffectByPos";
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		Utility.AttachTo(gameObject, this.goInfoBar, false);
		GameObject gameObject2 = Utility.FindChild(gameObject, "Text");
		if (null != gameObject2)
		{
			Text component = gameObject2.GetComponent<Text>();
			if (component != null)
			{
				component.text = content;
			}
		}
		Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(gameObject);
	}

	// Token: 0x06008873 RID: 34931 RVA: 0x0018798C File Offset: 0x00185D8C
	public void UpdateLevel(int iLevel)
	{
		if (this.m_kLevelText != null)
		{
			if (iLevel > 0)
			{
				this.m_kLevelText.text = "Lv." + iLevel.ToString();
				this.m_kLevelText.enabled = true;
			}
			else
			{
				this.m_kLevelText.text = string.Empty;
				this.m_kLevelText.enabled = false;
			}
		}
	}

	// Token: 0x06008874 RID: 34932 RVA: 0x00187A00 File Offset: 0x00185E00
	public void UpdateDialogComponet(float delta)
	{
		if (this.dialogComponent != null)
		{
			this.dialogComponent.Tick(delta);
		}
	}

	// Token: 0x06008875 RID: 34933 RVA: 0x00187A20 File Offset: 0x00185E20
	public void UpdateNpcInteraction(float delta)
	{
		if (null != this.goInfoBar)
		{
			NpcInteraction component = this.goInfoBar.GetComponent<NpcInteraction>();
			if (component != null)
			{
				component.Tick();
			}
		}
	}

	// Token: 0x06008876 RID: 34934 RVA: 0x00187A5C File Offset: 0x00185E5C
	public void UpdateVoiceComponent(float delta)
	{
		if (this.voiceComponent != null)
		{
			this.voiceComponent.Tick(delta);
		}
	}

	// Token: 0x06008877 RID: 34935 RVA: 0x00187A7B File Offset: 0x00185E7B
	public void AddVoiceListener(NpcVoiceComponent.SoundEffectType eSoundEffect)
	{
		if (this.voiceComponent != null)
		{
			this.voiceComponent.PlaySound(eSoundEffect);
		}
	}

	// Token: 0x06008878 RID: 34936 RVA: 0x00187A9C File Offset: 0x00185E9C
	public void AddComponentDialog(int iDialogID = 2006, NpcDialogComponent.IdBelong2 eIdBelong2 = NpcDialogComponent.IdBelong2.IdBelong2_NpcTable)
	{
		if (this.m_EntitySpaceDesc.rootNode != null && this.dialogComponent == null)
		{
			Transform transform = this.m_EntitySpaceDesc.rootNode.transform.Find("DialogParent");
			if (transform == null)
			{
				string prefabFullPath = "UIFlatten/Prefabs/DialogParent/DialogParent";
				GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject(prefabFullPath, enResourceType.UIPrefab, 2U);
				this.mDialogComponentData = new GeActorEx.NpcDialogComponentData(iDialogID, eIdBelong2);
				this._onAddComponetDialog(gameObject);
			}
		}
	}

	// Token: 0x06008879 RID: 34937 RVA: 0x00187B20 File Offset: 0x00185F20
	public void AddNPCFunction(string name, PlayerInfoColor infoColor, ushort RoleLevel, string namecolors = null, float nameLocalPosY = 0f)
	{
		this.mPlayerInfoBarData = new GeActorEx.PlayerInfoBarData(name ?? string.Empty, infoColor, RoleLevel, namecolors, nameLocalPosY);
		GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/PlayerInfo/PlayerInfo_Head", enResourceType.UIPrefab, 2U);
		this._onCreateInfoBar(gameObject);
		this._onAddNPCInteraction();
		this._onAddTittleComponent();
	}

	// Token: 0x0600887A RID: 34938 RVA: 0x00187B70 File Offset: 0x00185F70
	public void _RefleshUIComponent()
	{
		if (null != this.goInfoBar)
		{
			Vector3 goInfoBarLocalPosition = this.buffOriginLocalPosition;
			goInfoBarLocalPosition.y -= 0.25f;
			this.SetGoInfoBarLocalPosition(goInfoBarLocalPosition);
		}
		if (this.entity == null)
		{
			return;
		}
		if (this.mBarsRoot != null && this.entity != null && this.entity.GetEntityData() != null)
		{
			this._RefreshOverHeadPostion();
			Vector3 localPosition = this.overheadLocalPosition;
			if (this.entity.GetEntityData() != null && this.entity.GetEntityData().overHeadHeight > 0f)
			{
				localPosition.y = this.entity.GetEntityData().overHeadHeight;
			}
			localPosition.y += 0.78f;
			this.mBarsRoot.gameObject.transform.localPosition = localPosition;
		}
	}

	// Token: 0x0600887B RID: 34939 RVA: 0x00187C5E File Offset: 0x0018605E
	public void AddNPCBoxCollider(BeTownNPCData townData)
	{
		this.mNPCBoxCollectData = new GeActorEx.NPCBoxCollectData(townData);
	}

	// Token: 0x0600887C RID: 34940 RVA: 0x00187C6C File Offset: 0x0018606C
	public void AddNpcInteraction(int npcID, ulong guid = 0UL)
	{
		this.mNpcInteractionData = new GeActorEx.NpcInteractionData(npcID, guid);
	}

	// Token: 0x0600887D RID: 34941 RVA: 0x00187C7C File Offset: 0x0018607C
	public void AddTittleComponent(int iTittleID, string name, byte guildDuty, string bangName, int iRoleLv, int a_nPKRank, PlayerInfoColor color, string adventTeamName = "", PlayerWearedTitleInfo playerWearedTitleInfo = null, int guileLv = 0, int iVipLevel = 0)
	{
		this.mTittleComponentData = new GeActorEx.TittleComponentData(iTittleID, name, guildDuty, bangName, iRoleLv, a_nPKRank, color, adventTeamName, playerWearedTitleInfo, guileLv, iVipLevel);
	}

	// Token: 0x0600887E RID: 34942 RVA: 0x00187CA7 File Offset: 0x001860A7
	public void OnLevelChanged(int iRoleLv)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.Level = iRoleLv;
		}
	}

	// Token: 0x0600887F RID: 34943 RVA: 0x00187CC6 File Offset: 0x001860C6
	public void OnTittleChanged(int iTittle)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.TitleID = iTittle;
		}
	}

	// Token: 0x06008880 RID: 34944 RVA: 0x00187CE5 File Offset: 0x001860E5
	public void OnGuildNameChanged(string name)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.GangName = name;
		}
	}

	// Token: 0x06008881 RID: 34945 RVA: 0x00187D04 File Offset: 0x00186104
	public void OnGuildPostChanged(byte duty)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.GangDuty = duty;
		}
	}

	// Token: 0x06008882 RID: 34946 RVA: 0x00187D23 File Offset: 0x00186123
	public void UpdatePkRank(int a_nPKRank, int a_nStar)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.PKRank = a_nPKRank;
		}
	}

	// Token: 0x06008883 RID: 34947 RVA: 0x00187D42 File Offset: 0x00186142
	public void UpdateName(string a_strName)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.Name = a_strName;
		}
	}

	// Token: 0x06008884 RID: 34948 RVA: 0x00187D61 File Offset: 0x00186161
	public void UpdateAdventTeamName(string a_strName)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.AdventTeamName = a_strName;
		}
	}

	// Token: 0x06008885 RID: 34949 RVA: 0x00187D80 File Offset: 0x00186180
	public void UpdateTitleName(PlayerWearedTitleInfo playerWearedTitleInfoe)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.PlayerWearedTitleInfo = playerWearedTitleInfoe;
		}
	}

	// Token: 0x06008886 RID: 34950 RVA: 0x00187D9F File Offset: 0x0018619F
	public void UpdateGuidLv(int guildLv)
	{
		if (this.titleComponent != null)
		{
			this.titleComponent.GuildEmblemLv = guildLv;
		}
	}

	// Token: 0x06008887 RID: 34951 RVA: 0x00187DC0 File Offset: 0x001861C0
	public void AddNpcVoiceComponent(int iNpcID)
	{
		if (this.m_EntitySpaceDesc.rootNode != null && this.voiceComponent == null)
		{
			Transform transform = this.m_EntitySpaceDesc.rootNode.transform.Find("VoiceParent");
			if (transform == null)
			{
				GameObject gameObject = new GameObject("VoiceParent");
				GeUtility.AttachTo(gameObject, this.m_EntitySpaceDesc.rootNode, false);
				transform = gameObject.transform;
			}
			if (transform != null)
			{
				this.voiceComponent = transform.GetComponent<NpcVoiceComponent>();
				if (this.voiceComponent == null)
				{
					this.voiceComponent = transform.gameObject.AddComponent<NpcVoiceComponent>();
				}
				if (this.voiceComponent != null)
				{
					this.voiceComponent.Initialize(iNpcID);
				}
			}
		}
	}

	// Token: 0x06008888 RID: 34952 RVA: 0x00187E98 File Offset: 0x00186298
	public void AddNpcArrowComponent()
	{
		if (this.m_EntitySpaceDesc.characterNode != null && this.npcArrowComponent == null)
		{
			GameObject gameObject = Utility.FindChild(this.m_EntitySpaceDesc.characterNode, "ArrowComponent");
			if (gameObject == null)
			{
				this._addAsyncLoadGameObject("UIFlatten/Prefabs/TownUI/NpcWaitArrow", new PostLoadGameObject(this._onAddNpcArrowComponent), this.mPostLoadTownNPCHandle);
			}
		}
	}

	// Token: 0x06008889 RID: 34953 RVA: 0x00187F0C File Offset: 0x0018630C
	public void ActiveArrow()
	{
		if (this.npcArrowComponent != null)
		{
			this.npcArrowComponent.Active();
		}
	}

	// Token: 0x0600888A RID: 34954 RVA: 0x00187F2A File Offset: 0x0018632A
	public void DeActiveArrow()
	{
		if (this.npcArrowComponent != null)
		{
			this.npcArrowComponent.DeActive();
		}
	}

	// Token: 0x0600888B RID: 34955 RVA: 0x00187F48 File Offset: 0x00186348
	public void UpdateInfoBarLevel(ushort RoleLevel, bool force = true)
	{
		if (this.goInfoBar != null)
		{
			GameObject gameObject = Utility.FindChild(this.goInfoBar, this.stringLevelPath);
			Text text = null;
			if (null != gameObject)
			{
				text = gameObject.GetComponent<Text>();
			}
			if (null == text)
			{
				return;
			}
			string text2 = string.Empty;
			if (text != null && RoleLevel > 0)
			{
				text2 = "Lv." + RoleLevel.ToString();
			}
			if (text2 != text.text || force)
			{
				text.text = text2;
				DAssetObject effectRes = new DAssetObject
				{
					m_AssetPath = "Effects/Common/Sfx/Levelup/Prefab/Eff_Common_levelup"
				};
				Vector3 position = base.GetPosition();
				base.CreateEffect(effectRes, EffectsFrames.Default, 0f, new Vec3(position.x, position.z, position.y), 1f, 1f, false, true, false);
				MonoSingleton<AudioManager>.instance.PlaySound(8);
				this.ResetHPBar();
			}
			this.UpdateHPBar((int)RoleLevel);
		}
	}

	// Token: 0x0600888C RID: 34956 RVA: 0x0018805C File Offset: 0x0018645C
	public void PlayAwakeEffect()
	{
		DAssetObject effectRes = new DAssetObject
		{
			m_AssetPath = "Effects/Common/Sfx/Levelup/Prefab/Eff_Common_levelup"
		};
		Vector3 position = base.GetPosition();
		base.CreateEffect(effectRes, EffectsFrames.Default, 0f, new Vec3(position.x, position.z, position.y), 1f, 1f, false, true, false);
		MonoSingleton<AudioManager>.instance.PlaySound(8);
	}

	// Token: 0x0600888D RID: 34957 RVA: 0x001880CC File Offset: 0x001864CC
	public void UpdateInfoBarPKPoints(uint pkPoints)
	{
		if (this.goInfoBar != null)
		{
			GameObject gameObject = Utility.FindChild(this.goInfoBar, "pkGrades");
			if (gameObject == null)
			{
				return;
			}
			Image component = gameObject.GetComponent<Image>();
			if (component != null && pkPoints > 0U)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				bool flag = false;
				string pathByPkPoints = Utility.GetPathByPkPoints(pkPoints, ref num, ref num2, ref num3, ref flag);
				if (pathByPkPoints != string.Empty && pathByPkPoints != "-" && pathByPkPoints != "0")
				{
					ETCImageLoader.LoadSprite(ref component, pathByPkPoints, true);
				}
			}
		}
	}

	// Token: 0x0600888E RID: 34958 RVA: 0x0018817C File Offset: 0x0018657C
	public void CreateOverHeadHpBar(eHpBarType type, bool enemy = true, bool isShow = true)
	{
		string prefabFullPath = "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonHpBar";
		if (type != eHpBarType.Player && this.entity != null)
		{
			if (!enemy)
			{
				prefabFullPath = "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonMonsterHpBar_Green";
				isShow = true;
			}
			else
			{
				prefabFullPath = "UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonMonsterHpBar";
			}
		}
		this.goHPBar = Singleton<CGameObjectPool>.instance.GetGameObject(prefabFullPath, enResourceType.BattleScene, 2U);
		GeUtility.AttachTo(this.goHPBar, this.m_EntitySpaceDesc.rootNode, false);
		this._updateHPHeadBarPostion();
		ComCharactorHeadHPBar component = this.goHPBar.GetComponent<ComCharactorHeadHPBar>();
		this.mCurHpHeadBar = component;
		if (!enemy)
		{
			component.mType = eHpBarType.player_Monster;
			isShow = true;
		}
		else
		{
			component.mType = type;
			isShow = false;
		}
		this.hpBarManager.AddHpBar(component, isShow);
		BeEntityData entityData = this.entity.GetEntityData();
		if (entityData != null)
		{
			component.Init(entityData.battleData.maxHp, entityData.battleData.maxMp, -1, 0);
		}
		Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.goHPBar);
	}

	// Token: 0x0600888F RID: 34959 RVA: 0x00188274 File Offset: 0x00186674
	private void _updateHPHeadBarPostion()
	{
		if (null == this.goHPBar)
		{
			return;
		}
		Vector3 overHeadPosition = this.GetOverHeadPosition();
		if (this.entity.GetEntityData() != null && this.entity.GetEntityData().overHeadHeight > 0f)
		{
			overHeadPosition.y = this.entity.GetEntityData().overHeadHeight;
		}
		overHeadPosition.y += 0.15f;
		if (overHeadPosition.y <= 0f)
		{
			overHeadPosition.y = 2f;
		}
		if (this.useCube)
		{
			overHeadPosition.y = 2f;
		}
		this.goHPBar.transform.localPosition = overHeadPosition;
	}

	// Token: 0x06008890 RID: 34960 RVA: 0x00188334 File Offset: 0x00186734
	public void CreateSpellBar()
	{
		if (this.goSpellBar == null)
		{
			string path = "UI/Prefabs/HPBar_Head";
			this.goSpellBar = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			GeUtility.AttachTo(this.goSpellBar, this.m_EntitySpaceDesc.rootNode, false);
			Vector3 overHeadPosition = this.GetOverHeadPosition();
			if (this.entity.GetEntityData() != null && this.entity.GetEntityData().overHeadHeight > 0f)
			{
				overHeadPosition.y = this.entity.GetEntityData().overHeadHeight;
			}
			overHeadPosition.y += 0.2f;
			this.goSpellBar.transform.localPosition = overHeadPosition;
			this.cSpellBar = this.goSpellBar.GetComponent<CHPBar>();
			this.goSpellBar.SetActive(false);
		}
		this.goSpellBar.SetActive(true);
		Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.goSpellBar);
	}

	// Token: 0x06008891 RID: 34961 RVA: 0x00188428 File Offset: 0x00186828
	public void SetSpellBar(float progress)
	{
		if (this.goSpellBar != null && this.cSpellBar != null)
		{
			progress = Mathf.Clamp(progress, 0f, 1f);
			this.cSpellBar.SetPercent(progress);
		}
	}

	// Token: 0x06008892 RID: 34962 RVA: 0x00188475 File Offset: 0x00186875
	public void StopSpellBar()
	{
		if (this.goSpellBar != null)
		{
			this.goSpellBar.SetActive(false);
		}
	}

	// Token: 0x06008893 RID: 34963 RVA: 0x00188494 File Offset: 0x00186894
	public void CreateStateBar(string text, int duration)
	{
		if (this.stateBarManager != null)
		{
			this.stateBarManager.CreateStateBar();
			this.mCurrentStateBarId = this.stateBarManager.AddStateBar(text, duration, CStateBar.eBarColor.Yellow, false);
			if (this == this.stateBarManager.currentActor)
			{
				this.stateBarManager.SetBarActive(true);
			}
		}
	}

	// Token: 0x06008894 RID: 34964 RVA: 0x001884E9 File Offset: 0x001868E9
	public void RemoveStateBar()
	{
		if (this.stateBarManager != null)
		{
			this.stateBarManager.RemoveStateBar(this.mCurrentStateBarId);
		}
	}

	// Token: 0x06008895 RID: 34965 RVA: 0x00188508 File Offset: 0x00186908
	private GameObject _getStateBarRoot()
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemBattle;
		if (clientSystemBattle == null)
		{
			clientSystemBattle = (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle);
		}
		if (clientSystemBattle == null)
		{
			return null;
		}
		return clientSystemBattle.MonsterBossRoot;
	}

	// Token: 0x06008896 RID: 34966 RVA: 0x0018854C File Offset: 0x0018694C
	public void CreateComboTips(int[] skills)
	{
		this._createBarRoot();
		if (null != this.mBarsRoot)
		{
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonBar/DungeonComboTips", true, 0U);
			this.mTips = gameObject.GetComponent<ComDungeonComboTips>();
			this.mTips.SetSkills(skills);
			this.mTips.BindEvent();
			Utility.AttachTo(gameObject, this.mBarsRoot.hRoot, false);
		}
	}

	// Token: 0x06008897 RID: 34967 RVA: 0x001885B7 File Offset: 0x001869B7
	public void RemoveComboTips()
	{
		if (null != this.mTips)
		{
			this.mTips.UnbindEvent();
			Object.Destroy(this.mTips.gameObject);
			this.mTips = null;
		}
	}

	// Token: 0x06008898 RID: 34968 RVA: 0x001885EC File Offset: 0x001869EC
	public IDungeonCharactorBar CreateBar(eDungeonCharactorBar type)
	{
		this._createBarRoot();
		if (this.mBarsRoot != null)
		{
			IDungeonCharactorBar dungeonCharactorBar = this.mBars.Find((IDungeonCharactorBar x) => x.GetBarType() == type);
			if (dungeonCharactorBar == null)
			{
				string path = this._getBarPath(type);
				GameObject go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(path, true, 0U);
				dungeonCharactorBar = this._attachBarRoot(type, go);
				this.mBars.Add(dungeonCharactorBar);
			}
			dungeonCharactorBar.Show(true);
			return dungeonCharactorBar;
		}
		return null;
	}

	// Token: 0x06008899 RID: 34969 RVA: 0x0018867C File Offset: 0x00186A7C
	protected IDungeonCharactorBar _GetBarByType(eDungeonCharactorBar type)
	{
		int i = 0;
		int count = this.mBars.Count;
		while (i < count)
		{
			IDungeonCharactorBar dungeonCharactorBar = this.mBars[i];
			if (dungeonCharactorBar.GetBarType() == type)
			{
				return dungeonCharactorBar;
			}
			i++;
		}
		return null;
	}

	// Token: 0x0600889A RID: 34970 RVA: 0x001886C4 File Offset: 0x00186AC4
	public void SetBar(eDungeonCharactorBar type, float rate, bool show = true)
	{
		IDungeonCharactorBar dungeonCharactorBar = this._GetBarByType(type);
		if (dungeonCharactorBar != null)
		{
			dungeonCharactorBar.Show(show);
			dungeonCharactorBar.SetRate(rate);
		}
	}

	// Token: 0x0600889B RID: 34971 RVA: 0x001886F0 File Offset: 0x00186AF0
	public void SetCdTime(eDungeonCharactorBar type, float cdTime, bool show = true)
	{
		IDungeonCharactorBar dungeonCharactorBar = this._GetBarByType(type);
		if (dungeonCharactorBar != null)
		{
			dungeonCharactorBar.Show(show);
			dungeonCharactorBar.SetCdText(cdTime);
		}
	}

	// Token: 0x0600889C RID: 34972 RVA: 0x0018871C File Offset: 0x00186B1C
	public void StopBar(eDungeonCharactorBar type, bool iscancel)
	{
		IDungeonCharactorBar dungeonCharactorBar = this._GetBarByType(type);
		if (dungeonCharactorBar != null)
		{
			dungeonCharactorBar.Show(false);
			if (!iscancel)
			{
				this._stopBarEffect(type);
			}
		}
	}

	// Token: 0x0600889D RID: 34973 RVA: 0x0018874C File Offset: 0x00186B4C
	public void CreatePKHPBar(CPKHPBar.PKBarType type, string name, PlayerInfoColor color)
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemBattle;
		if (clientSystemBattle == null)
		{
			clientSystemBattle = (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle);
		}
		string path = string.Empty;
		if (clientSystemBattle != null)
		{
			string path2 = string.Empty;
			GameObject parent = null;
			if (type != CPKHPBar.PKBarType.Right)
			{
				if (type == CPKHPBar.PKBarType.Left)
				{
					path = "UIFlatten/Prefabs/Battle/Bars/Charactor/BuffIconContentLeft";
					if (BattleMain.battleType == BattleType.ScufflePVP)
					{
						path2 = "UIFlatten/Prefabs/Battle/Bars/Charactor/PK/PlayerLeftScufflePKHPBar";
						parent = clientSystemBattle.Pvp3v3LeftHpBarRoot;
					}
					else
					{
						path2 = "UIFlatten/Prefabs/Battle/Bars/Charactor/PK/PlayerLeftPKHPBar";
						parent = clientSystemBattle.PlayerPKLeftRoot;
					}
				}
			}
			else
			{
				path = "UIFlatten/Prefabs/Battle/Bars/Charactor/BuffIconContentRight";
				if (BattleMain.battleType == BattleType.ScufflePVP)
				{
					path2 = "UIFlatten/Prefabs/Battle/Bars/Charactor/PK/PlayerRightScufflePKHPBar";
					parent = clientSystemBattle.Pvp3v3RightHpBarRoot;
				}
				else
				{
					path2 = "UIFlatten/Prefabs/Battle/Bars/Charactor/PK/PlayerRightPKHPBar";
					parent = clientSystemBattle.PlayerPKRightRoot;
				}
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path2, true, 0U);
			Utility.AttachTo(gameObject, parent, false);
			CPKHPBar com = gameObject.GetComponent<CPKHPBar>();
			com.type = type;
			com.SetHPPercent(1f);
			com.SetMPPercent(1f);
			this.entity.delayCaller.DelayCall(10, delegate
			{
				com.SetHPValue(this.entity.GetEntityData().GetHP(), this.entity.GetEntityData().GetMaxHP());
			}, 0, 0, false);
			com.action = delegate()
			{
				BeActor beActor2 = this.entity as BeActor;
				if (beActor2 != null && BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor.IsDead())
				{
					beActor2.CurrentBeScene.currentGeScene.AttachCameraTo(beActor2.m_pkGeActor);
				}
			};
			com.SetNameText(name, string.Empty);
			com.SetIcon(this.entityHeadIcon, this.entityHeadIconMaterial);
			BeActor beActor = this.entity as BeActor;
			if (beActor != null && BattleMain.instance != null && BattleMain.instance.GetPlayerManager() != null && BattleMain.instance.GetPlayerManager().GetMainPlayer() != null && BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor == beActor)
			{
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component != null)
				{
					GameObject gameObject2 = component.GetGameObject("buffRoot");
					if (gameObject2 != null)
					{
						GameObject gameObject3 = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
						Utility.AttachTo(gameObject3, gameObject2, false);
						ComDungeonBuffGroup component2 = gameObject3.GetComponent<ComDungeonBuffGroup>();
						if (component2 != null)
						{
							component2.InitBattleBuff(this.entity as BeActor);
						}
					}
				}
			}
			if (this.goInfoBar != null)
			{
			}
			this.goHPPKBar = gameObject;
			this.comHPPKBar = com;
			Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(this.goHPPKBar);
		}
	}

	// Token: 0x0600889E RID: 34974 RVA: 0x001889D9 File Offset: 0x00186DD9
	public void SetPlayerHPPKBarName(string name)
	{
		if (this.comHPPKBar != null)
		{
			this.comHPPKBar.SetNameText(name, string.Empty);
		}
	}

	// Token: 0x0600889F RID: 34975 RVA: 0x00188A00 File Offset: 0x00186E00
	public void CreateHPBarCharactor(int seat = 0)
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemBattle;
		if (clientSystemBattle == null)
		{
			clientSystemBattle = (Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle);
		}
		if (clientSystemBattle != null)
		{
			BeEntityData entityData = this.entity.GetEntityData();
			if (entityData != null)
			{
				if (seat == (int)ClientApplication.playerinfo.seat)
				{
					this.goHPBarHUD = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Battle/Bars/Charactor/PlayerSelfHPBar", true, 0U);
					Utility.AttachTo(this.goHPBarHUD, clientSystemBattle.PlayerSelfInfoRoot, false);
					this.goHPBarHUD.transform.SetAsFirstSibling();
				}
				else
				{
					this.goHPBarHUD = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Battle/Bars/Charactor/PlayerOtherHPBar", true, 0U);
					Utility.AttachTo(this.goHPBarHUD, clientSystemBattle.PlayerOtherInfoRoot, false);
					this.goHPBarHUD.transform.SetAsLastSibling();
				}
				PlayerLabelInfo headPortraitFrame = null;
				if (this.entity != null && this.entity.CurrentBeBattle != null && this.entity.CurrentBeBattle.dungeonPlayerManager != null)
				{
					BattlePlayer playerBySeat = this.entity.CurrentBeBattle.dungeonPlayerManager.GetPlayerBySeat((byte)seat);
					if (playerBySeat != null && playerBySeat.playerInfo != null)
					{
						headPortraitFrame = playerBySeat.playerInfo.playerLabelInfo;
					}
				}
				ComCharactorHPBar component = this.goHPBarHUD.GetComponent<ComCharactorHPBar>();
				component.Init(entityData.battleData.maxHp, entityData.battleData.maxMp, 1, entityData.GetResistMagic());
				component.SetIcon(this.entityHeadIcon, this.entityHeadIconMaterial);
				component.SetName(entityData.name, entityData.level);
				component.SetHidden(false);
				component.SetSeat((byte)seat);
				component.SetHeadPortraitFrame(headPortraitFrame);
				component._InitHellDropItemRoot(seat == (int)ClientApplication.playerinfo.seat);
				ComCommonBind component2 = this.goHPBarHUD.GetComponent<ComCommonBind>();
				if (component2 != null)
				{
					GameObject gameObject = component2.GetGameObject("buffRoot");
					if (gameObject != null)
					{
						GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Battle/Bars/Charactor/BuffIconContentLeft", true, 0U);
						Utility.AttachTo(gameObject2, gameObject, false);
						ComDungeonBuffGroup component3 = gameObject2.GetComponent<ComDungeonBuffGroup>();
						if (component3 != null)
						{
							component3.InitBattleBuff(this.entity as BeActor);
						}
					}
				}
				component.InitResistMagic(entityData.GetResistMagic(), this.entity as BeActor);
				this.mCurHpBar = component;
				this.hpBarManager.AddHpBar(this.mCurHpBar, true);
			}
		}
	}

	// Token: 0x060088A0 RID: 34976 RVA: 0x00188C78 File Offset: 0x00187078
	public void RemoveHPBarMonster()
	{
		this.mCurHpBar = null;
	}

	// Token: 0x060088A1 RID: 34977 RVA: 0x00188C84 File Offset: 0x00187084
	public void CreateHPBarMonster(UnitTable.eType type, string name, Color nameColor, int singleBarValue = -1, bool enemy = true)
	{
		eHpBarType type2;
		if (type != UnitTable.eType.BOSS)
		{
			if (type != UnitTable.eType.ELITE)
			{
				type2 = eHpBarType.Monster;
			}
			else
			{
				type2 = eHpBarType.Elite;
			}
		}
		else
		{
			type2 = eHpBarType.Boss;
		}
		this.CreateOverHeadHpBar(type2, enemy, true);
		if (enemy && !BattleMain.IsModePvP(BattleMain.battleType) && BattleMain.battleType != BattleType.TrainingSkillCombo)
		{
			this.mCurrentHpBarId = this.hpBarManager.AddHpBar(this.entity, type2, name, singleBarValue, this.entityHeadIcon, this.entityHeadIconMaterial);
		}
	}

	// Token: 0x060088A2 RID: 34978 RVA: 0x00188D10 File Offset: 0x00187110
	public void SetDebugDrawData(BDEntityActionFrameData data, float scale = 1f, float zDimScale = 1f)
	{
		if (this.m_drawBox == null && this.m_EntitySpaceDesc.characterNode != null)
		{
			this.m_drawBox = this.m_EntitySpaceDesc.characterNode.AddComponent<Helper_DrawBox>();
		}
		if (this.m_drawBox != null)
		{
			this.m_drawBox.SetFrameData(data, scale, zDimScale, 1f);
		}
	}

	// Token: 0x060088A3 RID: 34979 RVA: 0x00188D80 File Offset: 0x00187180
	public void ResetHPBar()
	{
		if (this.entity != null)
		{
			int maxHp = -1;
			BeEntityData entityData = this.entity.GetEntityData();
			if (entityData != null && entityData.type == 3 && this.entity.CurrentBeScene != null)
			{
				maxHp = this.entity.CurrentBeScene.singleBloodBarCount;
			}
			if (this.mCurrentHpBarId != -1)
			{
				this.hpBarManager.ResetHpBar(this.mCurrentHpBarId);
			}
			if (this.mCurHpBar != null)
			{
				this.mCurHpBar.Init(this.entity.attribute.battleData.maxHp, this.entity.attribute.battleData.maxMp, maxHp, this.entity.attribute.GetResistMagic());
			}
			if (this.mCurHpHeadBar != null)
			{
				this.mCurHpHeadBar.Init(this.entity.attribute.battleData.maxHp, this.entity.attribute.battleData.maxMp, maxHp, 0);
			}
		}
	}

	// Token: 0x060088A4 RID: 34980 RVA: 0x00188E9D File Offset: 0x0018729D
	public void UpdateHPBar(int level)
	{
		if (this.entity != null && this.entity.m_iCamp == 0 && this.mCurHpBar != null)
		{
			this.mCurHpBar.SetLevel(level);
		}
	}

	// Token: 0x060088A5 RID: 34981 RVA: 0x00188ED4 File Offset: 0x001872D4
	public void SetHPDamage(int value, HitTextType type = HitTextType.NORMAL)
	{
		if (this.mCurHpBar != null)
		{
			this.hpBarManager.ShowHPBar(this.mCurHpBar, value, type);
		}
		if (this.mCurrentHpBarId != -1)
		{
			this.stateBarManager.currentActor = this;
			this.hpBarManager.ShowHPBar(this.mCurrentHpBarId, value, type);
		}
		if (this.mCurHpHeadBar != null)
		{
			this.hpBarManager.ShowHPBar(this.mCurHpHeadBar, value, type);
		}
		if (this.mCurrentStateBarId != StateBarManager.kInvalidStateBarId)
		{
			this.stateBarManager.SetBarActive(true);
		}
	}

	// Token: 0x060088A6 RID: 34982 RVA: 0x00188F64 File Offset: 0x00187364
	public void SetHPValue(float percent)
	{
		if (!this.isSyncHPMP)
		{
			return;
		}
		if (this.comHPPKBar != null)
		{
			this.comHPPKBar.SetHPPercent(percent);
			if (this.entity != null)
			{
				this.comHPPKBar.SetHPValue(this.entity.GetEntityData().GetHP(), this.entity.GetEntityData().GetMaxHP());
			}
		}
	}

	// Token: 0x060088A7 RID: 34983 RVA: 0x00188FD0 File Offset: 0x001873D0
	public void SetMpValue(float percent)
	{
		if (!this.isSyncHPMP)
		{
			return;
		}
		if (this.mCurHpBar != null)
		{
			this.hpBarManager.ShowMPBar(this.mCurHpBar, percent);
		}
		if (this.goHPPKBar != null)
		{
			this.comHPPKBar.SetMPPercent(percent);
		}
	}

	// Token: 0x060088A8 RID: 34984 RVA: 0x00189024 File Offset: 0x00187424
	public void SyncHPBar()
	{
		if (!this.isSyncHPMP)
		{
			return;
		}
		if (this.mCurHpBar != null && this.entity != null && this.entity.GetEntityData() != null)
		{
			this.mCurHpBar.SetHP(this.entity.GetEntityData().GetHP(), this.entity.GetEntityData().GetMaxHP());
			this.mCurHpBar.SetMP(this.entity.GetEntityData().GetMP(), this.entity.GetEntityData().GetMaxMP());
		}
		if (this.goHPPKBar != null && this.entity != null && this.entity.GetEntityData() != null)
		{
			this.comHPPKBar.SetHPValue(this.entity.GetEntityData().GetHP(), this.entity.GetEntityData().GetMaxHP());
		}
		if (this.mCurrentHpBarId != -1)
		{
			this.hpBarManager.SyncHPBar(this.mCurrentHpBarId, this.entity.GetEntityData().GetHP(), this.entity.GetEntityData().GetMaxHP());
		}
		if (this.mCurHpHeadBar != null && this.entity != null && this.entity.GetEntityData() != null)
		{
			this.mCurHpHeadBar.SetHP(this.entity.GetEntityData().GetHP(), this.entity.GetEntityData().GetMaxHP());
		}
	}

	// Token: 0x060088A9 RID: 34985 RVA: 0x001891A0 File Offset: 0x001875A0
	public void CreateAsyncForTownNPC(int resID, GameObject entityRoot, GeSceneEx scene, int iUnitId, bool isBattleActor = true, bool usePool = true, PosLoadGeActorEx load = null)
	{
		if (null == entityRoot)
		{
			Logger.LogError("[GeActorEx] Entity root can not be null!");
			return;
		}
		if (scene == null)
		{
			Logger.LogError("[GeActorEx] Entity scene can not be null!");
			return;
		}
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
		if (this._initActorDescWithResTable(tableItem))
		{
			base.Init(tableItem.Name, entityRoot, scene, isBattleActor);
			this.m_EntitySpaceDesc.rootNode.name = tableItem.ParentName;
			if (null == this.m_EntitySpaceDesc.actorNode)
			{
				this.m_EntitySpaceDesc.actorNode = new GameObject("actor");
			}
			GeUtility.AttachTo(this.m_EntitySpaceDesc.actorNode, this.m_EntitySpaceDesc.characterNode, false);
			this.mPostLoadTownNPC = load;
			this.mPostLoadTownNPCHandle = this._addAsyncLoadGameObject(this.m_ActorDesc.resPath, enResourceType.BattleScene, false, new PostLoadGameObject(this._onCreateNPCAsync), uint.MaxValue);
		}
		else
		{
			Logger.LogErrorFormat("[GeActorEx] actor model is nil with path {0}", new object[]
			{
				this.m_ActorDesc.resPath
			});
		}
	}

	// Token: 0x060088AA RID: 34986 RVA: 0x001892B6 File Offset: 0x001876B6
	public void RecreateForProjectile(bool useCube = false)
	{
		if (this.m_EntitySpaceDesc.actorModel != null && !useCube)
		{
			this.m_EntitySpaceDesc.actorModel.CustomActive(true);
		}
	}

	// Token: 0x060088AB RID: 34987 RVA: 0x001892E5 File Offset: 0x001876E5
	public void ReleaseForProjectile(bool useCube = false)
	{
		if (null != this.m_EntitySpaceDesc.actorModel)
		{
			this.m_EntitySpaceDesc.actorModel.CustomActive(false);
		}
	}

	// Token: 0x060088AC RID: 34988 RVA: 0x00189310 File Offset: 0x00187710
	public bool Create(int resID, GameObject entityRoot, GeSceneEx scene, int iUnitId, bool isBattleActor = true, bool usePool = true, bool useCube = false)
	{
		if (null == entityRoot)
		{
			Logger.LogError("Entity root can not be null!");
			return false;
		}
		if (scene == null)
		{
			Logger.LogError("Entity scene can not be null!");
			return false;
		}
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.m_ActorDesc.resID = resID;
			this.m_ActorDesc.resPath = tableItem.ModelPath;
			this.m_ActorDesc.resName = Path.GetFileNameWithoutExtension(this.m_ActorDesc.resPath);
			this.m_ActorDesc.portraitIconRes = tableItem.IconPath;
			this.m_ActorDesc.name = tableItem.ParentName;
			base.Init(tableItem.Name, entityRoot, scene, isBattleActor);
			this.m_EntitySpaceDesc.rootNode.name = tableItem.ParentName;
			if (null == this.m_EntitySpaceDesc.actorNode)
			{
				this.m_EntitySpaceDesc.actorNode = new GameObject("actor");
			}
			GeUtility.AttachTo(this.m_EntitySpaceDesc.actorNode, this.m_EntitySpaceDesc.characterNode, false);
			GameObject gameObject = null;
			this.m_ActorDesc.modelDataRes = tableItem.ModelPath;
			base.SetUseCube(useCube);
			if (useCube)
			{
				this.m_ActorDesc.resPath = "Actor/Other/Cube";
			}
			else
			{
				if (Path.GetExtension(this.m_ActorDesc.modelDataRes).Contains("asset"))
				{
					this.m_ModelDataAsset = Singleton<AssetLoader>.instance.LoadRes(this.m_ActorDesc.modelDataRes, false, 0U);
					if (this.m_ModelDataAsset != null)
					{
						this.m_ModelData = (this.m_ModelDataAsset.obj as DModelData);
					}
				}
				if (null != this.m_ModelData)
				{
					if (this.m_Avatar.Init(this.m_ModelData.modelAvatar.m_AssetPath, 9, usePool, false, false))
					{
						this.m_IsAvatarDirty = true;
						this.m_Avatar.GetAvatarRoot().transform.SetParent(this.m_EntitySpaceDesc.actorNode.transform, true);
						for (int i = 0; i < this.m_ModelData.partsChunk.Length; i++)
						{
							int partChannel = (int)this.m_ModelData.partsChunk[i].partChannel;
							if (0 <= partChannel && partChannel < GeActorEx.avatarChanTbl.Length)
							{
								this.m_Avatar.AddDefaultAvatar(GeActorEx.avatarChanTbl[partChannel], this.m_ModelData.partsChunk[i].partAsset);
							}
						}
						base.PushPostLoadCommand(delegate
						{
							this.m_ActorPartes = this.m_Avatar.suitPartModel;
						});
						gameObject = this.m_Avatar.GetAvatarRoot();
					}
					else
					{
						this.m_ModelDataAsset = null;
						this.m_ModelData = null;
					}
				}
				else if (this.m_ModelDataAsset != null && this.m_ModelDataAsset.obj is GameObject)
				{
					Object.Destroy(this.m_ModelDataAsset.obj);
					this.m_ModelDataAsset = null;
					this.m_ModelData = null;
				}
			}
			if (null == gameObject)
			{
				if (this.m_Avatar.Init(this.m_ActorDesc.resPath, 9, usePool, false, false))
				{
					this.m_IsAvatarDirty = true;
					gameObject = this.m_Avatar.GetAvatarRoot();
					if (!this._onActorModelPrefabLoadFinish(this.m_Avatar.GetAvatarRoot()))
					{
						Logger.LogErrorFormat("actor model is nil with path {0}", new object[]
						{
							this.m_ActorDesc.resPath
						});
						return false;
					}
				}
				if (isBattleActor)
				{
					this.m_ModelManager = new GeModelManager(this, resID, gameObject);
				}
			}
			this.m_EntityState = GeActorEx.GeEntityState.Loaded;
			this._onPostActorModelPrefabLoadFinish(gameObject);
			return true;
		}
		return false;
	}

	// Token: 0x060088AD RID: 34989 RVA: 0x001896AC File Offset: 0x00187AAC
	public bool CreateAsync(int resID, GameObject entityRoot, GeSceneEx scene, int iUnitId, PosLoadGeActorEx postLoadCallback, bool isBattleActor = true, bool usePool = true, bool useCube = false)
	{
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.m_ActorDesc.resID = resID;
			this.m_ActorDesc.resPath = tableItem.ModelPath;
			this.m_ActorDesc.resName = Path.GetFileNameWithoutExtension(this.m_ActorDesc.resPath);
			this.m_ActorDesc.portraitIconRes = tableItem.IconPath;
			this.m_ActorDesc.name = tableItem.ParentName;
			base.Init(tableItem.Name, entityRoot, scene, isBattleActor);
			this.m_EntitySpaceDesc.rootNode.name = tableItem.ParentName;
			if (null == this.m_EntitySpaceDesc.actorNode)
			{
				this.m_EntitySpaceDesc.actorNode = new GameObject("actor");
			}
			GeUtility.AttachTo(this.m_EntitySpaceDesc.actorNode, this.m_EntitySpaceDesc.characterNode, false);
			GameObject actorModel = null;
			this.m_ActorDesc.modelDataRes = tableItem.ModelPath;
			base.SetUseCube(useCube);
			if (useCube)
			{
				this.m_ActorDesc.resPath = "Actor/Other/Cube";
			}
			else
			{
				if (Path.GetExtension(this.m_ActorDesc.modelDataRes).Contains("asset"))
				{
					this.m_ModelDataAsset = Singleton<AssetLoader>.instance.LoadRes(this.m_ActorDesc.modelDataRes, false, 0U);
					if (this.m_ModelDataAsset != null)
					{
						this.m_ModelData = (this.m_ModelDataAsset.obj as DModelData);
					}
				}
				if (null != this.m_ModelData)
				{
					if (this.m_Avatar.Init(this.m_ModelData.modelAvatar.m_AssetPath, 9, usePool, false, false))
					{
						this.m_IsAvatarDirty = true;
						this.m_Avatar.GetAvatarRoot().transform.SetParent(this.m_EntitySpaceDesc.actorNode.transform, true);
						for (int i = 0; i < this.m_ModelData.partsChunk.Length; i++)
						{
							int partChannel = (int)this.m_ModelData.partsChunk[i].partChannel;
							if (0 <= partChannel && partChannel < GeActorEx.avatarChanTbl.Length)
							{
								this.m_Avatar.AddDefaultAvatar(GeActorEx.avatarChanTbl[partChannel], this.m_ModelData.partsChunk[i].partAsset);
							}
						}
						base.PushPostLoadCommand(delegate
						{
							this.m_ActorPartes = this.m_Avatar.suitPartModel;
						});
						actorModel = this.m_Avatar.GetAvatarRoot();
					}
					else
					{
						this.m_ModelDataAsset = null;
						this.m_ModelData = null;
					}
				}
				else if (this.m_ModelDataAsset != null && this.m_ModelDataAsset.obj is GameObject)
				{
					Object.Destroy(this.m_ModelDataAsset.obj);
					this.m_ModelDataAsset = null;
					this.m_ModelData = null;
				}
			}
			if (null == actorModel)
			{
				this.m_IsAvatarDirty = true;
				this.m_Avatar.Init(this.m_ActorDesc.resPath, 9, usePool, true, false);
			}
			base.PushPostLoadCommand(delegate
			{
				actorModel = this.m_Avatar.GetAvatarRoot();
				if (null != actorModel)
				{
					actorModel.SetActive(true);
				}
				this._onActorModelPrefabLoadFinish(actorModel);
				this.m_ModelManager = new GeModelManager(this, resID, actorModel);
				this.m_EntityState = GeActorEx.GeEntityState.Loaded;
				this._onPostActorModelPrefabLoadFinish(actorModel);
				actorModel.SetActive(true);
				this.ChangeAction("Anim_Idle01", 1f, false, true, false);
				if (postLoadCallback != null)
				{
					postLoadCallback(this);
				}
			});
			return true;
		}
		return false;
	}

	// Token: 0x060088AE RID: 34990 RVA: 0x00189A10 File Offset: 0x00187E10
	public void RemoveHPBar()
	{
		if (this.mCurrentHpBarId != -1)
		{
			this.hpBarManager.RemoveHPBar(this.mCurrentHpBarId);
			this.mCurrentHpBarId = -1;
		}
		if (this.mCurHpHeadBar != null)
		{
			this.hpBarManager.RemoveHPBar(this.mCurHpHeadBar);
			this.mCurHpHeadBar.Unload();
			this.mCurHpHeadBar = null;
		}
		if (this.mCurHpBar != null)
		{
			this.hpBarManager.RemoveHPBar(this.mCurHpBar);
			this.mCurHpBar.Unload();
			this.mCurHpBar = null;
		}
		if (this.goHPBar != null)
		{
			Singleton<CGameObjectPool>.instance.RecycleGameObject(this.goHPBar);
			this.goHPBar = null;
		}
	}

	// Token: 0x060088AF RID: 34991 RVA: 0x00189AC5 File Offset: 0x00187EC5
	public void DestroySelfHPBar()
	{
		if (this.goHPBarHUD != null)
		{
			Object.Destroy(this.goHPBarHUD);
			this.goHPBarHUD = null;
		}
	}

	// Token: 0x060088B0 RID: 34992 RVA: 0x00189AEC File Offset: 0x00187EEC
	public void Destroy()
	{
		this._ClearMaterial();
		this._ClearEmissiveRenderer();
		this.RemoveHPBar();
		if (this.goHPBarHUD != null)
		{
			Object.Destroy(this.goHPBarHUD);
			this.goHPBarHUD = null;
		}
		if (this.goHPPKBar != null)
		{
			Object.Destroy(this.goHPPKBar);
			this.goHPPKBar = null;
		}
		if (null != this.m_kLevelText)
		{
			Object.Destroy(this.m_kLevelText);
			this.m_kLevelText = null;
		}
		if (this.entityHeadIconAsset != null)
		{
			this.entityHeadIcon = null;
			this.entityHeadIconAsset = null;
			this.entityHeadIconMaterial = null;
		}
		if (this.titleComponent != null)
		{
			this.titleComponent.OnRecycle();
			this.titleComponent = null;
		}
		if (this.goInfoBar != null)
		{
			this.goInfoBar.transform.SetParent(null);
			this.goInfoBar.CustomActive(false);
			this.goInfoBarBottom = null;
			Singleton<CGameObjectPool>.instance.RecycleGameObject(this.goInfoBar);
			this.goInfoBar = null;
		}
		this.mDialogComponentData = null;
		this.mPlayerInfoBarData = null;
		this.mPlayerInfoBarDataHandle = uint.MaxValue;
		this.mNpcInteractionData = null;
		this.mTittleComponentData = null;
		this.mNPCBoxCollectData = null;
		if (this.mPostLoadTownNPC != null && null != this.m_EntitySpaceDesc.actorModel)
		{
			this.m_EntitySpaceDesc.actorModel.CustomActive(false);
		}
		this.mPostLoadInfoBar = null;
		this.mPostLoadTownNPC = null;
		this.mPostLoadTownNPCHandle = uint.MaxValue;
		if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.HideObjUseSetlayer) && this.m_EntitySpaceDesc.actorModel != null)
		{
			this.m_EntitySpaceDesc.actorNode.SetLayer(0);
		}
		base.Deinit();
		this.m_EntityState = GeActorEx.GeEntityState.Removed;
		this.m_EntityState = GeActorEx.GeEntityState.Removed;
		this._clearAsyncLoadGameObject();
		Singleton<AssetGabageCollectorHelper>.instance.AddGCPurgeTick(AssetGCTickType.SceneActor);
		if (this.m_ModelManager != null)
		{
			this.m_ModelManager.Clear();
		}
		if (this.slideArrowBind != null)
		{
			Object.Destroy(this.slideArrowBind.gameObject);
			this.slideArrowBind = null;
		}
		if (this.forwardBackArrowBind != null)
		{
			Object.Destroy(this.forwardBackArrowBind.gameObject);
			this.forwardBackArrowBind = null;
		}
	}

	// Token: 0x060088B1 RID: 34993 RVA: 0x00189D32 File Offset: 0x00188132
	public bool SetMaterial(string shaderName)
	{
		return true;
	}

	// Token: 0x060088B2 RID: 34994 RVA: 0x00189D38 File Offset: 0x00188138
	protected void _ClearMaterial()
	{
		if (null != this.m_SurfMaterial)
		{
			this.m_MatSurfObjDescList.RemoveAll(delegate(GeActorEx.MatSurfObjDesc e)
			{
				for (int i = 0; i < e.m_MatMeshRendDescList.Length; i++)
				{
					e.m_MatMeshRendDescList[i].m_MeshRenderer.materials = e.m_MatMeshRendDescList[i].m_OriginMatList;
				}
				return true;
			});
			Object.Destroy(this.m_SurfMaterial);
			this.m_SurfMaterial = null;
		}
	}

	// Token: 0x060088B3 RID: 34995 RVA: 0x00189D91 File Offset: 0x00188191
	public string GetResPath()
	{
		return this.m_ActorDesc.resPath;
	}

	// Token: 0x060088B4 RID: 34996 RVA: 0x00189D9E File Offset: 0x0018819E
	public string GetResName()
	{
		return this.m_ActorDesc.resName;
	}

	// Token: 0x060088B5 RID: 34997 RVA: 0x00189DAB File Offset: 0x001881AB
	public int GetResID()
	{
		return this.m_ActorDesc.resID;
	}

	// Token: 0x060088B6 RID: 34998 RVA: 0x00189DB8 File Offset: 0x001881B8
	public void SetHighLight(bool hightLight)
	{
		if (this.m_IsHighLight != hightLight)
		{
			if (hightLight)
			{
				base.ChangeSurface("选中高亮", 0f, true, true);
			}
			else
			{
				base.ChangeSurface(string.Empty, 0f, true, true);
			}
			this.m_IsHighLight = hightLight;
		}
	}

	// Token: 0x060088B7 RID: 34999 RVA: 0x00189E09 File Offset: 0x00188209
	public void SetDyeColor(Color dyeColor, GameObject[] modelRoot)
	{
	}

	// Token: 0x060088B8 RID: 35000 RVA: 0x00189E0C File Offset: 0x0018820C
	public void SetEmissiveColor(Color color, float duration = 1f)
	{
		this.m_EnableEmissiveColor = true;
		if (this.m_LastEmissiveColor == Color.clear)
		{
			this.m_LastEmissiveColor = color;
		}
		else
		{
			this.m_LastEmissiveColor = this.m_DestEmissiveColor;
		}
		this.m_DestEmissiveColor = color;
		this.m_EmissiveDuration = duration;
		this.m_EmissiveTimer = 0f;
		if (this.m_EmissiveRenderers == null)
		{
			this.m_EmissiveRenderers = new List<Renderer>();
			this._CollectEmissiveRenderer();
		}
	}

	// Token: 0x060088B9 RID: 35001 RVA: 0x00189E84 File Offset: 0x00188284
	private void _UpdateEmissiveColor(int delta)
	{
		if (this.m_EmissiveRenderers != null)
		{
			this.m_EmissiveTimer += (float)delta / 1000f;
			if (this.m_EmissiveTimer > this.m_EmissiveDuration)
			{
				return;
			}
			if (this.m_EmissiveBlock == null)
			{
				this.m_EmissiveBlock = new MaterialPropertyBlock();
			}
			for (int i = 0; i < this.m_EmissiveRenderers.Count; i++)
			{
				Color color = Color.Lerp(this.m_LastEmissiveColor, this.m_DestEmissiveColor, this.m_EmissiveTimer / this.m_EmissiveDuration);
				if (this.m_EmissiveRenderers[i] != null)
				{
					this.m_EmissiveRenderers[i].GetPropertyBlock(this.m_EmissiveBlock);
					this.m_EmissiveBlock.SetColor("_TintColor", color);
					this.m_EmissiveRenderers[i].SetPropertyBlock(this.m_EmissiveBlock);
				}
			}
		}
	}

	// Token: 0x060088BA RID: 35002 RVA: 0x00189F6C File Offset: 0x0018836C
	private void _CollectEmissiveRenderer()
	{
		if (this.m_EnableEmissiveColor && this.m_EmissiveRenderers != null)
		{
			this.m_EmissiveRenderers.Clear();
			for (int i = 0; i < this.m_ActorPartes.Length; i++)
			{
				for (int j = 0; j < this.m_ActorPartes[i].transform.childCount; j++)
				{
					Transform child = this.m_ActorPartes[i].transform.GetChild(j);
					if (child.CompareTag("EffectModel"))
					{
						Renderer component = child.GetComponent<Renderer>();
						if (component != null)
						{
							this.m_EmissiveRenderers.Add(component);
						}
					}
				}
			}
		}
	}

	// Token: 0x060088BB RID: 35003 RVA: 0x0018A01C File Offset: 0x0018841C
	private void _ClearEmissiveRenderer()
	{
		if (this.m_EmissiveRenderers != null)
		{
			this.m_EmissiveRenderers.Clear();
			this.m_EmissiveRenderers = null;
		}
		this.m_EmissiveBlock = null;
		this.m_LastEmissiveColor = Color.clear;
		this.m_DestEmissiveColor = Color.clear;
		this.m_EmissiveTimer = 0f;
		this.m_EmissiveDuration = 0f;
	}

	// Token: 0x060088BC RID: 35004 RVA: 0x0018A079 File Offset: 0x00188479
	public void SetShadowVisible(GeSceneEx scene, bool visible)
	{
		if (scene != null)
		{
			if (!visible)
			{
				base._RemoveShadow();
			}
			else
			{
				base._AddShadow();
			}
		}
	}

	// Token: 0x060088BD RID: 35005 RVA: 0x0018A098 File Offset: 0x00188498
	public void SetActorVisible(bool visible)
	{
		if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.HideObjUseSetlayer))
		{
			int layer = (!visible) ? 19 : 0;
			this.m_EntitySpaceDesc.actorNode.SetLayer(layer);
		}
		else
		{
			this.m_EntitySpaceDesc.actorNode.CustomActive(visible);
		}
		if (this.goFootInfo != null)
		{
			this.goFootInfo.CustomActive(visible);
		}
		if (this.goInfoBar != null)
		{
			this.goInfoBar.CustomActive(visible);
		}
		if (this.goHPBar != null)
		{
			this.goHPBar.CustomActive(visible);
		}
		if (this.goDialog != null && this.dialog.IsShow())
		{
			this.goDialog.CustomActive(visible);
		}
	}

	// Token: 0x060088BE RID: 35006 RVA: 0x0018A16C File Offset: 0x0018856C
	public void SetActorForLowLevel()
	{
		if (null != this.m_EntitySpaceDesc.actorNode)
		{
			this.m_EntitySpaceDesc.actorNode.CustomActive(false);
		}
		this.RemoveHPBar();
		if (this.goHPBarHUD != null)
		{
			Object.Destroy(this.goHPBarHUD);
			this.goHPBarHUD = null;
		}
		if (this.goHPPKBar != null)
		{
			Object.Destroy(this.goHPPKBar);
			this.goHPPKBar = null;
		}
		if (null != this.m_kLevelText)
		{
			Object.Destroy(this.m_kLevelText);
			this.m_kLevelText = null;
		}
		if (this.entityHeadIconAsset != null)
		{
			this.entityHeadIcon = null;
			this.entityHeadIconAsset = null;
			this.entityHeadIconMaterial = null;
		}
		if (this.titleComponent != null)
		{
			this.titleComponent.OnRecycle();
			this.titleComponent = null;
		}
		if (this.goInfoBar != null)
		{
			this.goInfoBar.transform.SetParent(null);
			this.goInfoBar.CustomActive(false);
			this.goInfoBarBottom = null;
			Singleton<CGameObjectPool>.instance.RecycleGameObject(this.goInfoBar);
			this.goInfoBar = null;
		}
		if (null != this.m_EntitySpaceDesc.actorModel)
		{
			this.m_EntitySpaceDesc.actorModel.transform.SetParent(null, false);
			Singleton<CGameObjectPool>.instance.RecycleGameObject(this.m_EntitySpaceDesc.actorModel);
			this.m_EntitySpaceDesc.actorModel = null;
		}
	}

	// Token: 0x060088BF RID: 35007 RVA: 0x0018A2EC File Offset: 0x001886EC
	public void SetHPBarVisible(bool visible)
	{
		if (this.goHPBar != null)
		{
			this.goHPBar.CustomActive(visible);
		}
	}

	// Token: 0x060088C0 RID: 35008 RVA: 0x0018A30B File Offset: 0x0018870B
	public void SetProfessionId(int proId)
	{
		if (this.m_Avatar != null)
		{
			this.m_Avatar.SetProfessionalId(proId);
		}
	}

	// Token: 0x060088C1 RID: 35009 RVA: 0x0018A324 File Offset: 0x00188724
	public void EquipFashions(Dictionary<int, string> fashions, int prodid = 0)
	{
		if (fashions != null)
		{
			foreach (KeyValuePair<int, string> keyValuePair in fashions)
			{
				int key = keyValuePair.Key;
				string value = keyValuePair.Value;
				if (key == 14 || key == 3)
				{
					base.ChangeAvatar(GeAvatarChannel.UpperPart, value, Singleton<AssetLoadConfig>.instance.asyncLoad, false, prodid);
				}
				else if (key == 12 || key == 2)
				{
					base.ChangeAvatar(GeAvatarChannel.Head, value, Singleton<AssetLoadConfig>.instance.asyncLoad, false, prodid);
				}
				else if (key == 15 || key == 6)
				{
					base.ChangeAvatar(GeAvatarChannel.LowerPart, value, Singleton<AssetLoadConfig>.instance.asyncLoad, false, prodid);
				}
				else if (key == 13 || key == 5)
				{
					base.ChangeAvatar(GeAvatarChannel.Bracelet, value, Singleton<AssetLoadConfig>.instance.asyncLoad, false, prodid);
				}
				else if (key == 16 || key == 4)
				{
					base.ChangeAvatar(GeAvatarChannel.Headwear, value, Singleton<AssetLoadConfig>.instance.asyncLoad, false, prodid);
				}
				else if (key == 11)
				{
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipWingFromRes(null, value, "[actor]Back", this, false, "wing");
				}
			}
		}
	}

	// Token: 0x060088C2 RID: 35010 RVA: 0x0018A480 File Offset: 0x00188880
	public void HackRamp(Texture rampTex)
	{
		if (null == rampTex)
		{
			return;
		}
		int num = this.renderObject.Length;
		for (int i = 0; i < num; i++)
		{
			SkinnedMeshRenderer[] componentsInChildren = this.renderObject[i].GetComponentsInChildren<SkinnedMeshRenderer>();
			if (componentsInChildren != null)
			{
				int j = 0;
				int num2 = componentsInChildren.Length;
				while (j < num2)
				{
					if (!(null == componentsInChildren[j]))
					{
						Material[] materials = componentsInChildren[j].materials;
						if (materials != null)
						{
							int k = 0;
							int num3 = materials.Length;
							while (k < num3)
							{
								if (!(null == materials[k]))
								{
									if (materials[k].HasProperty("_Ramp"))
									{
										materials[k].SetTexture("_Ramp", rampTex);
									}
									if (materials[k].HasProperty("_LightExposure"))
									{
										materials[k].SetFloat("_LightExposure", 1.1f);
									}
								}
								k++;
							}
						}
					}
					j++;
				}
			}
		}
	}

	// Token: 0x060088C3 RID: 35011 RVA: 0x0018A583 File Offset: 0x00188983
	public void ShowProtectFloat(bool show, float percent = 0f)
	{
		if (!BattleMain.IsProtectFloat(BattleMain.battleType))
		{
			return;
		}
		if (this.comHPPKBar != null)
		{
			this.comHPPKBar.ShowProtectFloat(show, percent);
		}
	}

	// Token: 0x060088C4 RID: 35012 RVA: 0x0018A5B3 File Offset: 0x001889B3
	public void ShowProtectGround(bool show, float percent = 0f)
	{
		if (!BattleMain.IsProtectGround(BattleMain.battleType))
		{
			return;
		}
		if (this.comHPPKBar != null)
		{
			this.comHPPKBar.ShowProtectGround(show, percent);
		}
	}

	// Token: 0x060088C5 RID: 35013 RVA: 0x0018A5E3 File Offset: 0x001889E3
	public void ShowProtectStand(bool show, float percent = 0f)
	{
		if (!BattleMain.IsProtectStand(BattleMain.battleType))
		{
			return;
		}
		if (this.comHPPKBar != null)
		{
			this.comHPPKBar.ShowProtectStand(show, percent);
		}
	}

	// Token: 0x060088C6 RID: 35014 RVA: 0x0018A614 File Offset: 0x00188A14
	public void AddKillMark()
	{
		if (null != this.m_EntitySpaceDesc.rootNode)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/Scene_effects/EffectUI/EffUI_KillMark", true, 0U);
			gameObject.transform.SetParent(this.m_EntitySpaceDesc.rootNode.transform, false);
			Vector3 localPosition = gameObject.transform.localPosition;
			GameObject attachNode = this.m_Avatar.GetAttachNode("[actor]OverHead");
			if (null != attachNode)
			{
				localPosition.y += attachNode.transform.position.y;
			}
			gameObject.transform.localPosition = localPosition;
		}
	}

	// Token: 0x060088C7 RID: 35015 RVA: 0x0018A6BC File Offset: 0x00188ABC
	public void HideActor(bool bIsHide)
	{
		int layer = (!bIsHide) ? 0 : 19;
		this.m_EntitySpaceDesc.m_IsEntityHide = bIsHide;
		if (null != this.m_EntitySpaceDesc.rootNode)
		{
			if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.HideObjUseSetlayer))
			{
				this.m_EntitySpaceDesc.rootNode.SetLayer(layer);
			}
			else
			{
				this.m_EntitySpaceDesc.rootNode.SetActive(!bIsHide);
			}
			base.PushPostLoadCommand(delegate
			{
				if (null != this.m_EntitySpaceDesc.rootNode)
				{
					if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.HideObjUseSetlayer))
					{
						this.m_EntitySpaceDesc.rootNode.SetLayer(layer);
					}
					else
					{
						this.m_EntitySpaceDesc.rootNode.SetActive(!bIsHide);
					}
				}
			});
		}
	}

	// Token: 0x060088C8 RID: 35016 RVA: 0x0018A76F File Offset: 0x00188B6F
	public bool IsActorHide()
	{
		return this.m_EntitySpaceDesc.m_IsEntityHide;
	}

	// Token: 0x060088C9 RID: 35017 RVA: 0x0018A77C File Offset: 0x00188B7C
	public void PreChangeModel(int resID, bool needRebindAttach = false)
	{
		if (this.m_ModelManager == null)
		{
			return;
		}
		this.m_ModelManager.PreChangeModel(resID, false, needRebindAttach);
	}

	// Token: 0x060088CA RID: 35018 RVA: 0x0018A799 File Offset: 0x00188B99
	public void TryChangeModel(int resID, bool needRebindAttach = false)
	{
		if (this.m_ModelManager == null)
		{
			return;
		}
		this.m_ModelManager.TryChangeModel(resID, needRebindAttach);
	}

	// Token: 0x060088CB RID: 35019 RVA: 0x0018A7B4 File Offset: 0x00188BB4
	public bool ChangeModel(GameObject toModel, bool needRebindAttach = false)
	{
		if (toModel == null || this.m_ActorPartes == null || this.m_ModelManager == null)
		{
			return false;
		}
		GameObject actorNode = this.m_EntitySpaceDesc.actorNode;
		GameObject actorModel = this.m_EntitySpaceDesc.actorModel;
		GameObject[] actorPartes = this.m_ActorPartes;
		this.m_ActorPartes = new GameObject[]
		{
			toModel
		};
		this.snapShotCache = this.m_ActorPartes;
		this.m_EntitySpaceDesc.actorModel = toModel;
		Transform transform = actorModel.transform;
		Transform transform2 = toModel.transform;
		transform2.localScale = transform.localScale;
		transform2.localPosition = new Vector3(0f, 0f, 0f);
		transform2.position = new Vector3(0f, 0f, 0f);
		transform2.localRotation = transform.localRotation;
		actorNode.transform.DetachChildren();
		transform2.SetParent(actorNode.transform, false);
		if (!needRebindAttach)
		{
			this.entity.attachmentproxy.Clear();
			base.ClearCached();
			this.m_Avatar.Clear(2U);
		}
		this.m_Avatar.Rebind(toModel, needRebindAttach);
		this.m_Avatar.SetSkeletonRoot(toModel);
		actorModel.CustomActive(false);
		toModel.CustomActive(true);
		this.m_Material.RemoveObject(actorPartes);
		this.m_Material.AppendObject(this.m_ActorPartes);
		this.moveBuffsEffects(actorModel, toModel);
		this.m_ModelManager.RmoveModel(actorModel);
		this.m_Avatar.ReplayAction();
		this._CollectEmissiveRenderer();
		this._updateChapterHeadInfoBarPosition();
		this._updateHPHeadBarPostion();
		return true;
	}

	// Token: 0x060088CC RID: 35020 RVA: 0x0018A942 File Offset: 0x00188D42
	public override void Update(int deltaTime, int Mask = 63, float height = 0f, int accTime = 0)
	{
		base.Update(deltaTime, Mask, height, accTime);
		this.UpdateBuffName(deltaTime);
		this._UpdateEmissiveColor(deltaTime);
	}

	// Token: 0x060088CD RID: 35021 RVA: 0x0018A960 File Offset: 0x00188D60
	private void UpdateBuffName(int deltaTime)
	{
		if (this.hpBarManager == null)
		{
			return;
		}
		this.hpBarManager.ShowBuffName(this.mCurrentHpBarId, string.Empty);
		if (this.index >= this.hpBarBuffEffectNameList.Count)
		{
			this.index = 0;
		}
		if (this.hpBarBuffEffectNameList.Count == 0)
		{
			return;
		}
		this.curHpBarBuffName = this.hpBarBuffEffectNameList[this.index];
		this.hpBarManager.ShowBuffName(this.mCurrentHpBarId, this.curHpBarBuffName);
		this.timer += deltaTime;
		if (this.timer > 1000)
		{
			this.index++;
			this.timer = 0;
			if (this.index >= this.hpBarBuffEffectNameList.Count)
			{
				this.index = 0;
			}
		}
	}

	// Token: 0x060088CE RID: 35022 RVA: 0x0018AA3C File Offset: 0x00188E3C
	public void LoadOneSkillConfig(string path, BDEntityRes res, List<string> configList = null, int tag = 0, List<int> types = null)
	{
		List<BDEntityActionInfo> list = ListPool<BDEntityActionInfo>.Get();
		BDEntityActionInfo.SaveLoad(this.entity.CurrentBeBattle.GetBattleType(), path, configList, false, false, list, null, types);
		for (int i = 0; i < list.Count; i++)
		{
			BDEntityActionInfo bdentityActionInfo = list[i];
			bdentityActionInfo.weaponTag = tag;
			res.AddActionInfo(bdentityActionInfo, path);
		}
		ListPool<BDEntityActionInfo>.Release(list);
	}

	// Token: 0x060088CF RID: 35023 RVA: 0x0018AAA4 File Offset: 0x00188EA4
	public void LoadSkillConfig(BDEntityRes res, bool loadCommonSkill = false, List<string> configList = null, int resID = 0)
	{
		if (resID == 0)
		{
			resID = this.m_ActorDesc.resID;
		}
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			if (resID != 0)
			{
				Logger.LogErrorFormat("模型资源表 中没有ID为 {0} 的项目", new object[]
				{
					resID
				});
			}
			return;
		}
		if (this.entity != null && this.entity.CurrentBeScene != null)
		{
			BeActionFrameMgr actionFrameMgr = this.entity.CurrentBeScene.ActionFrameMgr;
			SkillFileListCache skillFileCache = this.entity.CurrentBeScene.SkillFileCache;
		}
		for (int i = 0; i < tableItem.ActionConfigPath.Count; i++)
		{
			string text = tableItem.ActionConfigPath[i];
			if (Utility.IsStringValid(text))
			{
				this.LoadOneSkillConfig(text, res, configList, 0, null);
			}
		}
		if (loadCommonSkill)
		{
			this.LoadOneSkillConfig("Data/SkillData/Common", res, null, 0, null);
		}
	}

	// Token: 0x060088D0 RID: 35024 RVA: 0x0018AB9C File Offset: 0x00188F9C
	public void LoadWeaponRelatedConfig(BDEntityRes res, int tag, List<string> configList = null, List<int> types = null)
	{
		if (tag == 0)
		{
			return;
		}
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(this.m_ActorDesc.resID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			if (this.m_ActorDesc.resID != 0)
			{
				Logger.LogErrorFormat("模型资源表 中没有ID为 {0} 的项目", new object[]
				{
					this.m_ActorDesc.resID
				});
			}
			return;
		}
		if (this.entity != null && this.entity.CurrentBeScene != null)
		{
			BeActionFrameMgr actionFrameMgr = this.entity.CurrentBeScene.ActionFrameMgr;
			SkillFileListCache skillFileCache = this.entity.CurrentBeScene.SkillFileCache;
		}
		for (int i = 0; i < tableItem.ActionConfigPath.Count; i++)
		{
			string text = tableItem.ActionConfigPath[i];
			if (Utility.IsStringValid(text))
			{
				string path = text + "_" + tag;
				this.LoadOneSkillConfig(path, res, configList, tag, types);
			}
		}
	}

	// Token: 0x060088D1 RID: 35025 RVA: 0x0018ACA2 File Offset: 0x001890A2
	public string GetSkillDataNameByID(int ID)
	{
		if (this.skillData.ContainsKey(ID))
		{
			return this.skillData[ID];
		}
		return null;
	}

	// Token: 0x060088D2 RID: 35026 RVA: 0x0018ACC4 File Offset: 0x001890C4
	public ComCommonBind GetArrowBind(string path)
	{
		if (this.slideArrowBind != null)
		{
			return this.slideArrowBind;
		}
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		if (gameObject == null)
		{
			return null;
		}
		GameObject attachNode = base.GetAttachNode("[actor]Orign");
		if (attachNode == null)
		{
			return null;
		}
		GeUtility.AttachTo(gameObject, attachNode, false);
		this.slideArrowBind = gameObject.GetComponent<ComCommonBind>();
		return this.slideArrowBind;
	}

	// Token: 0x060088D3 RID: 35027 RVA: 0x0018AD3C File Offset: 0x0018913C
	public ComCommonBind GetForwardBackArrowBind(string path)
	{
		if (this.forwardBackArrowBind != null)
		{
			return this.forwardBackArrowBind;
		}
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		if (gameObject == null)
		{
			return null;
		}
		GameObject attachNode = base.GetAttachNode("[actor]Orign");
		if (attachNode == null)
		{
			return null;
		}
		GeUtility.AttachTo(gameObject, attachNode, false);
		this.forwardBackArrowBind = gameObject.GetComponent<ComCommonBind>();
		return this.forwardBackArrowBind;
	}

	// Token: 0x060088D4 RID: 35028 RVA: 0x0018ADB4 File Offset: 0x001891B4
	public void CreateChainEffect(BeActor target, string path, EffectTimeType timeType = EffectTimeType.SYNC_ANIMATION, bool forceDisplay = false)
	{
		this.chainEffect = base.CreateEffect(path, null, 99999f, Vec3.zero, 1f, 1f, false, false, timeType, forceDisplay);
		GameObject rootNode = this.chainEffect.GetRootNode();
		bool flag = false;
		BeActor beActor = this.entity as BeActor;
		if (beActor == null)
		{
			return;
		}
		GameObject attachGameObject = this.GetAttachGameObject(beActor, "[actor]Body", ref flag);
		GeUtility.AttachTo(rootNode, attachGameObject, false);
		if (flag)
		{
			Vector3 position = this.chainEffect.GetPosition();
			position.z += (float)VInt.Float2VIntValue(1.5f);
			this.chainEffect.SetPosition(position);
		}
		ComCommonBind componentInChildren = rootNode.GetComponentInChildren<ComCommonBind>();
		if (componentInChildren != null)
		{
			LightningChain com = componentInChildren.GetCom<LightningChain>("lcScript");
			if (com != null)
			{
				GameObject attachNode = target.m_pkGeActor.GetAttachNode("[actor]Orign");
				if (attachNode != null)
				{
					if (this.chainNode == null)
					{
						this.chainNode = new GameObject("Node");
					}
					Utility.AttachTo(this.chainNode, attachNode, false);
					this.chainNode.transform.localPosition = new Vector3(0f, 1f, 0f);
					com.target = this.chainNode;
					com.ForceUpdate();
				}
			}
			GameObject gameObject = componentInChildren.GetGameObject("goNodeA");
			if (gameObject != null)
			{
				OffsetChange offsetChange = gameObject.GetComponent<OffsetChange>();
				if (offsetChange == null)
				{
					offsetChange = gameObject.AddComponent<OffsetChange>();
					offsetChange.LoopCount = 0f;
					offsetChange.AStartTime = 0f;
					offsetChange.AXSpeed = -5f;
					offsetChange.AYSpeed = 0f;
					offsetChange.BStartTime = 0f;
					offsetChange.BXSpeed = 0f;
					offsetChange.BYSpeed = 0f;
				}
			}
		}
	}

	// Token: 0x060088D5 RID: 35029 RVA: 0x0018AFA0 File Offset: 0x001893A0
	public void ClearChainEffect()
	{
		if (this.chainEffect != null)
		{
			GameObject rootNode = this.chainEffect.GetRootNode();
			if (rootNode != null)
			{
				ComCommonBind componentInChildren = rootNode.GetComponentInChildren<ComCommonBind>();
				if (componentInChildren != null)
				{
					LightningChain com = componentInChildren.GetCom<LightningChain>("lcScript");
					com.target = null;
					com.SetVertexCount(0);
				}
			}
			base.DestroyEffect(this.chainEffect);
		}
		if (this.chainNode != null)
		{
			Object.Destroy(this.chainNode);
			this.chainNode = null;
		}
	}

	// Token: 0x060088D6 RID: 35030 RVA: 0x0018B02C File Offset: 0x0018942C
	protected GameObject GetAttachGameObject(BeActor actor, string nodeName, ref bool noStrNode)
	{
		GameObject gameObject = base.GetAttachNode(nodeName);
		if (gameObject == null)
		{
			noStrNode = true;
			gameObject = actor.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		}
		return gameObject;
	}

	// Token: 0x04004212 RID: 16914
	private const string kGeActorExTag = "GeActorEx_";

	// Token: 0x04004213 RID: 16915
	public GeActorEx.GeActorDesc m_ActorDesc;

	// Token: 0x04004214 RID: 16916
	private static readonly GeAvatarChannel[] avatarChanTbl = new GeAvatarChannel[]
	{
		GeAvatarChannel.Head,
		GeAvatarChannel.UpperPart,
		GeAvatarChannel.LowerPart,
		GeAvatarChannel.Bracelet,
		GeAvatarChannel.Headwear,
		GeAvatarChannel.Wings,
		GeAvatarChannel.WholeBody
	};

	// Token: 0x04004215 RID: 16917
	protected GeActorEx.GeEntityState m_EntityState;

	// Token: 0x04004216 RID: 16918
	public BeEntity entity;

	// Token: 0x04004217 RID: 16919
	public Dictionary<int, string> skillData = new Dictionary<int, string>();

	// Token: 0x04004218 RID: 16920
	protected GameObject[] m_ActorPartes;

	// Token: 0x04004219 RID: 16921
	protected Bounds m_BoundingBox;

	// Token: 0x0400421A RID: 16922
	protected bool m_IsHighLight;

	// Token: 0x0400421B RID: 16923
	private uint mPostLoadTownNPCHandle = uint.MaxValue;

	// Token: 0x0400421C RID: 16924
	private PosLoadGeActorEx mPostLoadTownNPC;

	// Token: 0x0400421D RID: 16925
	public PosLoadGeActorEx mPostLoadInfoBar;

	// Token: 0x0400421E RID: 16926
	public GameObject goHPBar;

	// Token: 0x0400421F RID: 16927
	public IHPBar mCurHpBar;

	// Token: 0x04004220 RID: 16928
	public int mCurrentHpBarId = -1;

	// Token: 0x04004221 RID: 16929
	public int mCurrentStateBarId = StateBarManager.kInvalidStateBarId;

	// Token: 0x04004222 RID: 16930
	protected List<uint> mCachedAsyncHandles = new List<uint>();

	// Token: 0x04004223 RID: 16931
	public IHPBar mCurHpHeadBar;

	// Token: 0x04004224 RID: 16932
	public GameObject goHPPKBar;

	// Token: 0x04004225 RID: 16933
	public CPKHPBar comHPPKBar;

	// Token: 0x04004226 RID: 16934
	public GameObject goHPBarHUD;

	// Token: 0x04004227 RID: 16935
	public GameObject goInfoBar;

	// Token: 0x04004228 RID: 16936
	public GameObject goTransportInfo;

	// Token: 0x04004229 RID: 16937
	public GameObject goInfoBarBottom;

	// Token: 0x0400422A RID: 16938
	public GameObject goSpellBar;

	// Token: 0x0400422B RID: 16939
	public GameObject goFootInfo;

	// Token: 0x0400422C RID: 16940
	public GameObject goDialog;

	// Token: 0x0400422D RID: 16941
	public GameObject goShowFindPath;

	// Token: 0x0400422E RID: 16942
	private DialogScript dialog;

	// Token: 0x0400422F RID: 16943
	public TitleComponent titleComponent;

	// Token: 0x04004230 RID: 16944
	private NpcArrowComponent npcArrowComponent;

	// Token: 0x04004231 RID: 16945
	private NpcDialogComponent dialogComponent;

	// Token: 0x04004232 RID: 16946
	private NpcVoiceComponent voiceComponent;

	// Token: 0x04004233 RID: 16947
	public bool isSyncHPMP = true;

	// Token: 0x04004234 RID: 16948
	public CHPBar cSpellBar;

	// Token: 0x04004235 RID: 16949
	public CStateBar cStateBar;

	// Token: 0x04004236 RID: 16950
	public ComTags cTagsBar;

	// Token: 0x04004237 RID: 16951
	public Helper_DrawBox m_drawBox;

	// Token: 0x04004238 RID: 16952
	public bool showDebugBox;

	// Token: 0x04004239 RID: 16953
	private Sprite entityHeadIcon;

	// Token: 0x0400423A RID: 16954
	private AssetInst entityHeadIconAsset;

	// Token: 0x0400423B RID: 16955
	private Material entityHeadIconMaterial;

	// Token: 0x0400423C RID: 16956
	public HPBarManager hpBarManager;

	// Token: 0x0400423D RID: 16957
	public StateBarManager stateBarManager;

	// Token: 0x0400423E RID: 16958
	public string stringLevelPath = "Bottom/Lv";

	// Token: 0x0400423F RID: 16959
	public Dictionary<string, int> headTextCount = new Dictionary<string, int>();

	// Token: 0x04004240 RID: 16960
	public bool showTransport;

	// Token: 0x04004241 RID: 16961
	public GameObject objOverhead;

	// Token: 0x04004242 RID: 16962
	public GameObject objBuffOrigin;

	// Token: 0x04004243 RID: 16963
	public Vector3 buffOriginPosition = Vector3.zero;

	// Token: 0x04004244 RID: 16964
	public Vector3 buffOriginLocalPosition = Vector3.zero;

	// Token: 0x04004245 RID: 16965
	public Vector3 bodyLocalPosition = Vector3.zero;

	// Token: 0x04004246 RID: 16966
	public Vector3 originLocalPosition = Vector3.zero;

	// Token: 0x04004247 RID: 16967
	private Vector3 overheadLocalPosition = Vector3.zero;

	// Token: 0x04004248 RID: 16968
	public ComCommonBind slideArrowBind;

	// Token: 0x04004249 RID: 16969
	public ComCommonBind forwardBackArrowBind;

	// Token: 0x0400424A RID: 16970
	private string[,] kHeadDialogPaths;

	// Token: 0x0400424B RID: 16971
	protected Material m_SurfMaterial;

	// Token: 0x0400424C RID: 16972
	protected List<GeActorEx.MatSurfObjDesc> m_MatSurfObjDescList;

	// Token: 0x0400424D RID: 16973
	private List<Renderer> m_EmissiveRenderers;

	// Token: 0x0400424E RID: 16974
	private MaterialPropertyBlock m_EmissiveBlock;

	// Token: 0x0400424F RID: 16975
	private bool m_EnableEmissiveColor;

	// Token: 0x04004250 RID: 16976
	private Color m_LastEmissiveColor;

	// Token: 0x04004251 RID: 16977
	private Color m_DestEmissiveColor;

	// Token: 0x04004252 RID: 16978
	private float m_EmissiveTimer;

	// Token: 0x04004253 RID: 16979
	private float m_EmissiveDuration;

	// Token: 0x04004254 RID: 16980
	public List<string> hpBarBuffEffectNameList;

	// Token: 0x04004255 RID: 16981
	public string curHpBarBuffName;

	// Token: 0x04004256 RID: 16982
	protected static Dictionary<string, Vector3> cachedOverhead = new Dictionary<string, Vector3>();

	// Token: 0x04004257 RID: 16983
	private GeActorEx.NpcDialogComponentData mDialogComponentData;

	// Token: 0x04004258 RID: 16984
	private GeActorEx.NPCBoxCollectData mNPCBoxCollectData;

	// Token: 0x04004259 RID: 16985
	private GeActorEx.NpcInteractionData mNpcInteractionData;

	// Token: 0x0400425A RID: 16986
	private Text m_kLevelText;

	// Token: 0x0400425B RID: 16987
	private GeActorEx.PlayerInfoBarData mPlayerInfoBarData;

	// Token: 0x0400425C RID: 16988
	private uint mPlayerInfoBarDataHandle;

	// Token: 0x0400425D RID: 16989
	private GeActorEx.TittleComponentData mTittleComponentData;

	// Token: 0x0400425E RID: 16990
	public ComDungeonBarRoot mBarsRoot;

	// Token: 0x0400425F RID: 16991
	private List<IDungeonCharactorBar> mBars;

	// Token: 0x04004260 RID: 16992
	private const float BAR_ROOT_HEIGHT = 0.78f;

	// Token: 0x04004261 RID: 16993
	private const float HEAD_DIALOG_HEIGHT = 0.45f;

	// Token: 0x04004262 RID: 16994
	private const float HP_BAR_HEIGHT = 0.15f;

	// Token: 0x04004263 RID: 16995
	private const float SPELL_BAR_HEIGHT = 0.2f;

	// Token: 0x04004264 RID: 16996
	private ComDungeonComboTips mTips;

	// Token: 0x04004265 RID: 16997
	private int timer;

	// Token: 0x04004266 RID: 16998
	private int index;

	// Token: 0x04004267 RID: 16999
	private GeEffectEx chainEffect;

	// Token: 0x04004268 RID: 17000
	private GameObject chainNode;

	// Token: 0x02000D0E RID: 3342
	public struct GeActorDesc
	{
		// Token: 0x0400426A RID: 17002
		public string name;

		// Token: 0x0400426B RID: 17003
		public int resID;

		// Token: 0x0400426C RID: 17004
		public string resName;

		// Token: 0x0400426D RID: 17005
		public string resPath;

		// Token: 0x0400426E RID: 17006
		public string modelDataRes;

		// Token: 0x0400426F RID: 17007
		public string portraitIconRes;
	}

	// Token: 0x02000D0F RID: 3343
	protected enum GeEntityState
	{
		// Token: 0x04004271 RID: 17009
		Invalid,
		// Token: 0x04004272 RID: 17010
		Loaded,
		// Token: 0x04004273 RID: 17011
		Inited,
		// Token: 0x04004274 RID: 17012
		Removed
	}

	// Token: 0x02000D10 RID: 3344
	protected class MatSurfRenderDesc
	{
		// Token: 0x060088DA RID: 35034 RVA: 0x0018B0DA File Offset: 0x001894DA
		public MatSurfRenderDesc(Material[] origMat, Renderer mr)
		{
			this.m_MeshRenderer = mr;
			this.m_OriginMatList = origMat;
		}

		// Token: 0x04004275 RID: 17013
		public Renderer m_MeshRenderer;

		// Token: 0x04004276 RID: 17014
		public Material[] m_OriginMatList;
	}

	// Token: 0x02000D11 RID: 3345
	protected class MatSurfObjDesc
	{
		// Token: 0x060088DB RID: 35035 RVA: 0x0018B0F0 File Offset: 0x001894F0
		public MatSurfObjDesc(GeActorEx.MatSurfRenderDesc[] meshRendDesc)
		{
			this.m_MatMeshRendDescList = meshRendDesc;
		}

		// Token: 0x04004277 RID: 17015
		public GeActorEx.MatSurfRenderDesc[] m_MatMeshRendDescList;
	}

	// Token: 0x02000D12 RID: 3346
	private class NpcDialogComponentData
	{
		// Token: 0x060088DC RID: 35036 RVA: 0x0018B0FF File Offset: 0x001894FF
		public NpcDialogComponentData(int iDialogID, NpcDialogComponent.IdBelong2 eIdBelong2)
		{
			this.iDialogID = iDialogID;
			this.eIdBelong2 = eIdBelong2;
		}

		// Token: 0x17001833 RID: 6195
		// (get) Token: 0x060088DD RID: 35037 RVA: 0x0018B115 File Offset: 0x00189515
		// (set) Token: 0x060088DE RID: 35038 RVA: 0x0018B11D File Offset: 0x0018951D
		public int iDialogID { get; private set; }

		// Token: 0x17001834 RID: 6196
		// (get) Token: 0x060088DF RID: 35039 RVA: 0x0018B126 File Offset: 0x00189526
		// (set) Token: 0x060088E0 RID: 35040 RVA: 0x0018B12E File Offset: 0x0018952E
		public NpcDialogComponent.IdBelong2 eIdBelong2 { get; private set; }
	}

	// Token: 0x02000D13 RID: 3347
	private class NPCBoxCollectData
	{
		// Token: 0x060088E1 RID: 35041 RVA: 0x0018B137 File Offset: 0x00189537
		public NPCBoxCollectData(BeTownNPCData data)
		{
			this.townData = data;
		}

		// Token: 0x17001835 RID: 6197
		// (get) Token: 0x060088E2 RID: 35042 RVA: 0x0018B146 File Offset: 0x00189546
		// (set) Token: 0x060088E3 RID: 35043 RVA: 0x0018B14E File Offset: 0x0018954E
		public BeTownNPCData townData { get; private set; }
	}

	// Token: 0x02000D14 RID: 3348
	private class NpcInteractionData
	{
		// Token: 0x060088E4 RID: 35044 RVA: 0x0018B157 File Offset: 0x00189557
		public NpcInteractionData(int npcID, ulong guid = 0UL)
		{
			this.npcID = npcID;
			this.Guid = guid;
		}

		// Token: 0x17001836 RID: 6198
		// (get) Token: 0x060088E5 RID: 35045 RVA: 0x0018B16D File Offset: 0x0018956D
		// (set) Token: 0x060088E6 RID: 35046 RVA: 0x0018B175 File Offset: 0x00189575
		public ulong Guid { get; set; }

		// Token: 0x17001837 RID: 6199
		// (get) Token: 0x060088E7 RID: 35047 RVA: 0x0018B17E File Offset: 0x0018957E
		// (set) Token: 0x060088E8 RID: 35048 RVA: 0x0018B186 File Offset: 0x00189586
		public int npcID { get; private set; }
	}

	// Token: 0x02000D15 RID: 3349
	private class PlayerInfoBarData
	{
		// Token: 0x060088E9 RID: 35049 RVA: 0x0018B18F File Offset: 0x0018958F
		public PlayerInfoBarData(string name, PlayerInfoColor infoColor, ushort RoleLevel, string namecolors, float nameLocalPosY)
		{
			this.name = name;
			this.infoColor = infoColor;
			this.RoleLevel = RoleLevel;
			this.namecolors = namecolors;
			this.NameLocalPosY = nameLocalPosY;
		}

		// Token: 0x17001838 RID: 6200
		// (get) Token: 0x060088EA RID: 35050 RVA: 0x0018B1BC File Offset: 0x001895BC
		// (set) Token: 0x060088EB RID: 35051 RVA: 0x0018B1C4 File Offset: 0x001895C4
		public string name { get; private set; }

		// Token: 0x17001839 RID: 6201
		// (get) Token: 0x060088EC RID: 35052 RVA: 0x0018B1CD File Offset: 0x001895CD
		// (set) Token: 0x060088ED RID: 35053 RVA: 0x0018B1D5 File Offset: 0x001895D5
		public PlayerInfoColor infoColor { get; private set; }

		// Token: 0x1700183A RID: 6202
		// (get) Token: 0x060088EE RID: 35054 RVA: 0x0018B1DE File Offset: 0x001895DE
		// (set) Token: 0x060088EF RID: 35055 RVA: 0x0018B1E6 File Offset: 0x001895E6
		public ushort RoleLevel { get; private set; }

		// Token: 0x1700183B RID: 6203
		// (get) Token: 0x060088F0 RID: 35056 RVA: 0x0018B1EF File Offset: 0x001895EF
		// (set) Token: 0x060088F1 RID: 35057 RVA: 0x0018B1F7 File Offset: 0x001895F7
		public string namecolors { get; private set; }

		// Token: 0x1700183C RID: 6204
		// (get) Token: 0x060088F2 RID: 35058 RVA: 0x0018B200 File Offset: 0x00189600
		// (set) Token: 0x060088F3 RID: 35059 RVA: 0x0018B208 File Offset: 0x00189608
		public float NameLocalPosY { get; private set; }
	}

	// Token: 0x02000D16 RID: 3350
	private class TittleComponentData
	{
		// Token: 0x060088F4 RID: 35060 RVA: 0x0018B214 File Offset: 0x00189614
		public TittleComponentData(int iTittleID, string name, byte guildDuty, string bangName, int iRoleLv, int a_nPKRank, PlayerInfoColor color, string adventTeamName, PlayerWearedTitleInfo playerWearedTitleInfo, int guileEmblemLv, int iVipLevel = 0)
		{
			this.iTittleID = iTittleID;
			this.name = name;
			this.guildDuty = guildDuty;
			this.bangName = bangName;
			this.iRoleLv = iRoleLv;
			this.a_nPKRank = a_nPKRank;
			this.color = color;
			this.iVipLevel = iVipLevel;
			this.adventTeamName = adventTeamName;
			this.playerWearedTitleInfo = playerWearedTitleInfo;
			this.guildEmblemLv = guileEmblemLv;
		}

		// Token: 0x1700183D RID: 6205
		// (get) Token: 0x060088F5 RID: 35061 RVA: 0x0018B27C File Offset: 0x0018967C
		// (set) Token: 0x060088F6 RID: 35062 RVA: 0x0018B284 File Offset: 0x00189684
		public int iTittleID { get; private set; }

		// Token: 0x1700183E RID: 6206
		// (get) Token: 0x060088F7 RID: 35063 RVA: 0x0018B28D File Offset: 0x0018968D
		// (set) Token: 0x060088F8 RID: 35064 RVA: 0x0018B295 File Offset: 0x00189695
		public string name { get; private set; }

		// Token: 0x1700183F RID: 6207
		// (get) Token: 0x060088F9 RID: 35065 RVA: 0x0018B29E File Offset: 0x0018969E
		// (set) Token: 0x060088FA RID: 35066 RVA: 0x0018B2A6 File Offset: 0x001896A6
		public byte guildDuty { get; private set; }

		// Token: 0x17001840 RID: 6208
		// (get) Token: 0x060088FB RID: 35067 RVA: 0x0018B2AF File Offset: 0x001896AF
		// (set) Token: 0x060088FC RID: 35068 RVA: 0x0018B2B7 File Offset: 0x001896B7
		public string bangName { get; private set; }

		// Token: 0x17001841 RID: 6209
		// (get) Token: 0x060088FD RID: 35069 RVA: 0x0018B2C0 File Offset: 0x001896C0
		// (set) Token: 0x060088FE RID: 35070 RVA: 0x0018B2C8 File Offset: 0x001896C8
		public int iRoleLv { get; private set; }

		// Token: 0x17001842 RID: 6210
		// (get) Token: 0x060088FF RID: 35071 RVA: 0x0018B2D1 File Offset: 0x001896D1
		// (set) Token: 0x06008900 RID: 35072 RVA: 0x0018B2D9 File Offset: 0x001896D9
		public int a_nPKRank { get; private set; }

		// Token: 0x17001843 RID: 6211
		// (get) Token: 0x06008901 RID: 35073 RVA: 0x0018B2E2 File Offset: 0x001896E2
		// (set) Token: 0x06008902 RID: 35074 RVA: 0x0018B2EA File Offset: 0x001896EA
		public PlayerInfoColor color { get; private set; }

		// Token: 0x17001844 RID: 6212
		// (get) Token: 0x06008903 RID: 35075 RVA: 0x0018B2F3 File Offset: 0x001896F3
		// (set) Token: 0x06008904 RID: 35076 RVA: 0x0018B2FB File Offset: 0x001896FB
		public int iVipLevel { get; private set; }

		// Token: 0x17001845 RID: 6213
		// (get) Token: 0x06008905 RID: 35077 RVA: 0x0018B304 File Offset: 0x00189704
		// (set) Token: 0x06008906 RID: 35078 RVA: 0x0018B30C File Offset: 0x0018970C
		public string adventTeamName { get; private set; }

		// Token: 0x17001846 RID: 6214
		// (get) Token: 0x06008907 RID: 35079 RVA: 0x0018B315 File Offset: 0x00189715
		// (set) Token: 0x06008908 RID: 35080 RVA: 0x0018B31D File Offset: 0x0018971D
		public PlayerWearedTitleInfo playerWearedTitleInfo { get; private set; }

		// Token: 0x17001847 RID: 6215
		// (get) Token: 0x06008909 RID: 35081 RVA: 0x0018B326 File Offset: 0x00189726
		// (set) Token: 0x0600890A RID: 35082 RVA: 0x0018B32E File Offset: 0x0018972E
		public int guildEmblemLv { get; private set; }
	}
}
