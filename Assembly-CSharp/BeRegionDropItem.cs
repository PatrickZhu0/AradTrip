using System;
using System.Collections.Generic;
using Battle;
using DG.Tweening;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020041AA RID: 16810
public class BeRegionDropItem : BeRegionBase
{
	// Token: 0x0601718E RID: 94606 RVA: 0x007156F5 File Offset: 0x00713AF5
	public BeRegionDropItem()
	{
		this.mCanRemove = false;
		this.mActive = true;
		this.mIsTrailPickedItem = false;
		this.mHasPickedItem = false;
	}

	// Token: 0x0601718F RID: 94607 RVA: 0x00715724 File Offset: 0x00713B24
	public void SetPickedList(List<int> list)
	{
		this.mPickedList = list;
	}

	// Token: 0x06017190 RID: 94608 RVA: 0x0071572D File Offset: 0x00713B2D
	public void SetDropItem(DungeonDropItem dropItem)
	{
		this.mDropItem = dropItem;
	}

	// Token: 0x06017191 RID: 94609 RVA: 0x00715736 File Offset: 0x00713B36
	private bool IsGold(int type)
	{
		return type == 600000001 || type == 600000007;
	}

	// Token: 0x06017192 RID: 94610 RVA: 0x00715750 File Offset: 0x00713B50
	private bool checkItemType(int itemId, ItemTable.eType checkType)
	{
		ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
		return tableItem != null && tableItem.Type == checkType;
	}

	// Token: 0x06017193 RID: 94611 RVA: 0x0071578C File Offset: 0x00713B8C
	private bool tryToPlayHighQualityEquipShowedSound(ItemTable res)
	{
		if (res == null)
		{
			return false;
		}
		if (res.Type != ItemTable.eType.EQUIP)
		{
			return false;
		}
		ItemTable.eColor color = res.Color;
		if (color == ItemTable.eColor.PINK)
		{
			MonoSingleton<AudioManager>.instance.PlaySound(104);
		}
		else
		{
			if (color != ItemTable.eColor.YELLOW)
			{
				return false;
			}
			MonoSingleton<AudioManager>.instance.PlaySound(105);
		}
		return true;
	}

	// Token: 0x06017194 RID: 94612 RVA: 0x007157EC File Offset: 0x00713BEC
	private string GetGoldName(int type)
	{
		ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(type, string.Empty, string.Empty);
		if (tableItem != null)
		{
			return tableItem.Name;
		}
		return string.Empty;
	}

	// Token: 0x06017195 RID: 94613 RVA: 0x00715824 File Offset: 0x00713C24
	protected override void _onLoadActorFinish()
	{
		if (!this.mInit)
		{
			GameObject entityNode = this.mGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
			GameObject gameObject = Utility.FindGameObject(entityNode, "DungeonBox(Clone)/DungeonBox", true);
			if (null != gameObject)
			{
				Utility.ClearChild(gameObject);
				ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(this.mDropItem.typeId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mDropItem.typeId, 100, 0);
					this.mItemTable = itemData;
					GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonBoxText", true, 0U);
					ComCommonBind component = gameObject2.GetComponent<ComCommonBind>();
					this.objText = gameObject2;
					if (null == component)
					{
						return;
					}
					GeUtility.AttachTo(gameObject2, gameObject, false);
					Text com = component.GetCom<Text>("dropName");
					Image com2 = component.GetCom<Image>("dropIcon");
					GameObject gameObject3 = component.GetGameObject("dropModel");
					GameObject gameObject4 = component.GetGameObject("uniformTips");
					Text com3 = component.GetCom<Text>("uniformText");
					if (null != com3 && this.mDropItem != null && this.mDropItem.isDouble)
					{
						this.mDropItemExtraDesc = com3.text;
					}
					gameObject4.SetActive(this.mDropItem != null && this.mDropItem.isDouble);
					com.text = string.Format("<color={0}>{1}</color>", itemData.GetQualityInfo().ColStr, tableItem.Name);
					this.dropModel = gameObject3;
					string path = tableItem.ModelPath;
					if (this.IsGold(this.mDropItem.typeId))
					{
						if (this.mDropItem.num >= 100 && this.mDropItem.num <= 500)
						{
							path = "UI/Image/Icon/Icon_Item/Drop_Gold2.png:Drop_Gold2";
						}
						else if (this.mDropItem.num > 500)
						{
							path = "UI/Image/Icon/Icon_Item/Drop_Gold3.png:Drop_Gold3";
						}
						Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(800, delegate
						{
							MonoSingleton<AudioManager>.instance.PlaySound(2);
						}, 0, 0, false);
					}
					if (!this.tryToPlayHighQualityEquipShowedSound(tableItem))
					{
						Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(800, delegate
						{
							MonoSingleton<AudioManager>.instance.PlaySound(3);
						}, 0, 0, false);
					}
					ETCImageLoader.LoadSprite(ref com2, path, true);
					string text = null;
					if (tableItem.Type == ItemTable.eType.EQUIP && tableItem.Color == ItemTable.eColor.YELLOW)
					{
						text = "Effects/Scene_effects/Eff_jipinzhuangbei_dimian_guo";
					}
					else if (tableItem.Type == ItemTable.eType.EQUIP && tableItem.Color == ItemTable.eColor.PINK)
					{
						text = "Effects/Scene_effects/Eff_jipinzhuangbei_dimian_guo02";
					}
					else if (tableItem.Color == ItemTable.eColor.PINK)
					{
						text = "Effects/Scene_effects/Eff_fensezhuangbei_guo";
					}
					else if (tableItem.Color == ItemTable.eColor.YELLOW)
					{
						text = "Effects/Scene_effects/Eff_jipinzhuangbei_guo";
					}
					if (text != null)
					{
						GameObject gameObject5 = Singleton<CGameObjectPool>.instance.GetGameObject(text, enResourceType.BattleScene, 2U);
						GeUtility.AttachTo(gameObject5, gameObject, false);
						this.objEffect2 = gameObject5;
					}
				}
				Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(entityNode);
				this.mInit = true;
			}
		}
	}

	// Token: 0x06017196 RID: 94614 RVA: 0x00715B4C File Offset: 0x00713F4C
	protected override void _onUpdate(int delta)
	{
		base._onUpdate(delta);
		if (this.trailObj != null)
		{
			this.trailObj.UpdatePosition(delta);
			if (this.trailObj != null)
			{
				base.SetPosition(new VInt3(this.trailObj.position));
			}
		}
		this._delayRemoveUpdate(delta);
	}

	// Token: 0x06017197 RID: 94615 RVA: 0x00715B9F File Offset: 0x00713F9F
	protected override void _onCreate()
	{
		this.mInit = false;
	}

	// Token: 0x06017198 RID: 94616 RVA: 0x00715BA8 File Offset: 0x00713FA8
	private void _delayRemove(int second)
	{
		if (this.mDelayStatus == BeRegionDropItem.eDelayRemoveStatus.eNone)
		{
			this.mDelayStatus = BeRegionDropItem.eDelayRemoveStatus.eStart;
			this.mDelayRemoveTime = second;
		}
	}

	// Token: 0x06017199 RID: 94617 RVA: 0x00715BC3 File Offset: 0x00713FC3
	private void _delayRemoveUpdate(int delta)
	{
		if (this.mDelayStatus != BeRegionDropItem.eDelayRemoveStatus.eStart)
		{
			return;
		}
		this.mDelayRemoveTime -= delta;
		if (this.mDelayRemoveTime <= 0)
		{
			this.mDelayStatus = BeRegionDropItem.eDelayRemoveStatus.eEnd;
			this._realRemoveItem(false);
		}
	}

	// Token: 0x0601719A RID: 94618 RVA: 0x00715BFA File Offset: 0x00713FFA
	private void _realRemoveItem(bool isChangeParent = false)
	{
		this.mCanRemove = true;
		this.m_needChangeParent = isChangeParent;
		this._unloadActivedEffect();
		this._unloadEffect();
		this._onRemove();
	}

	// Token: 0x0601719B RID: 94619 RVA: 0x00715C1C File Offset: 0x0071401C
	public void RemoveAll()
	{
		this._realRemoveItem(false);
	}

	// Token: 0x0601719C RID: 94620 RVA: 0x00715C28 File Offset: 0x00714028
	protected override void _unloadEffect()
	{
		if (this.m_needChangeParent)
		{
			if (this.objText != null)
			{
				this.objText.transform.SetParent(null);
			}
			if (this.objEffect != null)
			{
				this.objEffect.transform.SetParent(null);
			}
			if (this.objEffect2 != null)
			{
				this.objEffect2.transform.SetParent(null);
			}
		}
		base._unloadEffect();
	}

	// Token: 0x0601719D RID: 94621 RVA: 0x00715CAC File Offset: 0x007140AC
	protected override void _onEnterEffect(BeRegionTarget target)
	{
		this.mHasPickedItem = true;
		try
		{
			if (target != null && target.target != null)
			{
				ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle != null)
				{
					Vector3 zero = Vector3.zero;
					bool isGold = false;
					if (this.IsGold(this.mDropItem.typeId))
					{
						isGold = true;
						clientSystemBattle.dungeonMapCom.AddGlod(this.mDropItem.num);
						BeActor beActor = target.target.GetOwner() as BeActor;
						GameObject gameObject = this.mGeActor.CreateHeadText(HitTextType.GET_GOLD, this.mDropItem.num, true, this.GetGoldName(this.mDropItem.typeId));
						if (gameObject != null && beActor != null)
						{
							Vector3 position = gameObject.transform.position;
							position.z = beActor.GetGePosition().z - 2f;
							position.y += 0.5f;
							gameObject.transform.position = position;
						}
					}
					else
					{
						clientSystemBattle.dungeonMapCom.AddBox(this.mDropItem.num);
					}
					target.state = BeRegionState.None;
					GameObject entityNode = this.mGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
					this.mTrailEff = Singleton<CGameObjectPool>.instance.GetGameObject(this._getPickedEffectPath(), enResourceType.BattleScene, 2U);
					GeUtility.AttachTo(this.mTrailEff, entityNode, false);
					GameObject gameObject2 = Utility.FindThatChild("actor", entityNode, false);
					if (gameObject2)
					{
						gameObject2.gameObject.SetActive(false);
					}
					if (this.mIsTrailPickedItem)
					{
						TweenPosArc comp = entityNode.AddComponent<TweenPosArc>();
						BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
						comp.targetPosition = mainPlayer.playerActor.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
						comp.onFinish.AddListener(delegate()
						{
							this._realRemoveItem(comp != null && comp.isActiveAndEnabled);
							if (isGold)
							{
								MonoSingleton<AudioManager>.instance.PlaySound(100);
							}
							else
							{
								MonoSingleton<AudioManager>.instance.PlaySound(4);
							}
						});
					}
					else
					{
						this._delayRemove(BeRegionDropItem._getParticleSystemLength(entityNode.transform));
						if (isGold)
						{
							gameObject2.gameObject.SetActive(false);
						}
					}
					if (this.checkItemType(this.mDropItem.typeId, ItemTable.eType.EQUIP))
					{
						MonoSingleton<AudioManager>.instance.PlaySound(101);
					}
				}
			}
			if (this.mItemTable != null && this.mItemTable.GetQualityInfo() != null && !this.IsGold(this.mDropItem.typeId))
			{
				SystemNotifyManager.SystemNotify(6003, this.mItemTable.TableID, new object[]
				{
					this.mItemTable.Name,
					this.mDropItem.num
				});
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat(ex.ToString(), new object[0]);
		}
	}

	// Token: 0x0601719E RID: 94622 RVA: 0x00715FC4 File Offset: 0x007143C4
	private static int _getParticleSystemLength(Transform transform)
	{
		ParticleSystem[] componentsInChildren = transform.GetComponentsInChildren<ParticleSystem>();
		float num = 0f;
		foreach (ParticleSystem particleSystem in componentsInChildren)
		{
			if (particleSystem.enableEmission)
			{
				if (particleSystem.loop)
				{
					return int.MaxValue;
				}
				float num2;
				if (particleSystem.emissionRate <= 0f)
				{
					num2 = particleSystem.startDelay + particleSystem.startLifetime;
				}
				else
				{
					num2 = particleSystem.startDelay + particleSystem.duration + particleSystem.startLifetime;
				}
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		return (int)(num * 1000f);
	}

	// Token: 0x0601719F RID: 94623 RVA: 0x00716068 File Offset: 0x00714468
	private string _getPickedEffectPath()
	{
		string[] array = this._getPickedEffectArray();
		if (array == null)
		{
			return string.Empty;
		}
		int num = this._getPickedEffectIndex();
		if (num < 0 || num >= array.Length)
		{
			return string.Empty;
		}
		return array[num];
	}

	// Token: 0x060171A0 RID: 94624 RVA: 0x007160A8 File Offset: 0x007144A8
	private int _getPickedEffectIndex()
	{
		if (this.mDropItem == null)
		{
			return -1;
		}
		if (this.IsGold(this.mDropItem.typeId))
		{
			return 0;
		}
		ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(this.mDropItem.typeId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return -1;
		}
		if (tableItem.Type == ItemTable.eType.EQUIP && tableItem.Color == ItemTable.eColor.YELLOW)
		{
			return 2;
		}
		if (tableItem.Type == ItemTable.eType.EQUIP && tableItem.Color == ItemTable.eColor.PINK)
		{
			return 3;
		}
		if (tableItem.Color == ItemTable.eColor.PINK)
		{
			return 3;
		}
		if (tableItem.Color == ItemTable.eColor.YELLOW)
		{
			return 2;
		}
		return 1;
	}

	// Token: 0x060171A1 RID: 94625 RVA: 0x00716153 File Offset: 0x00714553
	private string[] _getPickedEffectArray()
	{
		if (this.mIsTrailPickedItem)
		{
			return BeRegionDropItem.kTrailPickedEffects;
		}
		return BeRegionDropItem.kGoundPickedEffects;
	}

	// Token: 0x060171A2 RID: 94626 RVA: 0x0071616B File Offset: 0x0071456B
	private void _playPickedSound()
	{
	}

	// Token: 0x060171A3 RID: 94627 RVA: 0x00716170 File Offset: 0x00714570
	public void ForceTriggerEnter(BeActor actor)
	{
		this.mIsTrailPickedItem = true;
		if (this.mHasPickedItem)
		{
			return;
		}
		for (int i = 0; i < this.mTargetList.Count; i++)
		{
			if (this.mTargetList[i].target == actor)
			{
				try
				{
					this._onEnterEffect(this.mTargetList[i]);
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat(ex.ToString(), new object[0]);
				}
			}
		}
	}

	// Token: 0x060171A4 RID: 94628 RVA: 0x00716204 File Offset: 0x00714604
	protected override void _onRemove()
	{
		base._onRemove();
		if (this.objText != null)
		{
			Object.Destroy(this.objText);
			this.objText = null;
		}
		if (this.objEffect != null)
		{
			if (this.m_needChangeParent)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.objEffect);
			}
			else
			{
				Object.Destroy(this.objEffect);
			}
			this.objEffect = null;
		}
		if (this.objEffect2 != null)
		{
			if (this.m_needChangeParent)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.objEffect2);
			}
			else
			{
				Object.Destroy(this.objEffect2);
			}
			this.objEffect2 = null;
		}
		if (null != this.mTrailEff)
		{
			if (this.m_needChangeParent)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.mTrailEff);
			}
			else
			{
				Object.Destroy(this.mTrailEff);
			}
			this.mTrailEff = null;
		}
	}

	// Token: 0x060171A5 RID: 94629 RVA: 0x00716304 File Offset: 0x00714704
	public void StartTrail(VInt3 _orgPos, VInt3 _targetPos)
	{
		float z = 1f;
		float num = 0.5f;
		Vec3 vec = _targetPos.vec3;
		Vec3 vec2 = _orgPos.vec3;
		vec.y -= 0.5f;
		float num2 = vec.x - vec2.x;
		float num3 = vec.y - vec2.y;
		float x = num2 / (num * 30f) * 60f / 3f;
		float y = num3 / (num * 30f) * 60f / 3f;
		float z2 = 7.5f;
		DropTrail dropTrail = new DropTrail();
		dropTrail.currentBeScene = base.currentBeScene;
		dropTrail.speed = new Vec3(x, y, z2);
		dropTrail.acc = new Vec3(0f, 0f, 35f);
		vec2.z = z;
		dropTrail.position = vec2;
		dropTrail.touchGroundDelegate = delegate()
		{
			if (this.trailObj != null)
			{
				base.SetPosition(new VInt3(this.trailObj.position));
			}
			this.trailObj = null;
			if (this.dropModel != null)
			{
				DOTween.Kill(this.dropModel, false);
				this.dropModel.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}
		};
		this.trailObj = dropTrail;
	}

	// Token: 0x04010A2A RID: 68138
	private List<int> mPickedList;

	// Token: 0x04010A2B RID: 68139
	private DungeonDropItem mDropItem;

	// Token: 0x04010A2C RID: 68140
	private ItemData mItemTable;

	// Token: 0x04010A2D RID: 68141
	private bool mInit;

	// Token: 0x04010A2E RID: 68142
	private string mDropItemExtraDesc = string.Empty;

	// Token: 0x04010A2F RID: 68143
	private const int kGoldTypeID = 600000001;

	// Token: 0x04010A30 RID: 68144
	private bool mIsTrailPickedItem;

	// Token: 0x04010A31 RID: 68145
	private bool mHasPickedItem;

	// Token: 0x04010A32 RID: 68146
	private bool m_needChangeParent;

	// Token: 0x04010A33 RID: 68147
	private GameObject objText;

	// Token: 0x04010A34 RID: 68148
	private GameObject objEffect;

	// Token: 0x04010A35 RID: 68149
	private GameObject objEffect2;

	// Token: 0x04010A36 RID: 68150
	private DropTrail trailObj;

	// Token: 0x04010A37 RID: 68151
	private GameObject dropModel;

	// Token: 0x04010A38 RID: 68152
	private int mDelayRemoveTime;

	// Token: 0x04010A39 RID: 68153
	private BeRegionDropItem.eDelayRemoveStatus mDelayStatus;

	// Token: 0x04010A3A RID: 68154
	private static string[] kGoundPickedEffects = new string[]
	{
		"Effects/Common/Sfx/DiaoLuo/Eff_jinbi_yuandi",
		"Effects/Common/Sfx/DiaoLuo/Eff_putong_yuandi",
		"Effects/Common/Sfx/DiaoLuo/Eff_jinse_yuandi",
		"Effects/Common/Sfx/DiaoLuo/Eff_fense_yuandi"
	};

	// Token: 0x04010A3B RID: 68155
	private static string[] kTrailPickedEffects = new string[]
	{
		"Effects/Common/Sfx/DiaoLuo/Eff_jinbi_tuowei",
		"Effects/Common/Sfx/DiaoLuo/Eff_putong_tuowei",
		"Effects/Common/Sfx/DiaoLuo/Eff_jinse_tuowei",
		"Effects/Common/Sfx/DiaoLuo/Eff_fense_tuowei"
	};

	// Token: 0x020041AB RID: 16811
	private enum eDelayRemoveStatus
	{
		// Token: 0x04010A3F RID: 68159
		eNone,
		// Token: 0x04010A40 RID: 68160
		eStart,
		// Token: 0x04010A41 RID: 68161
		eEnd
	}
}
