using System;
using Battle;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001150 RID: 4432
	public sealed class BeItem : BeBaseFighter
	{
		// Token: 0x0600A922 RID: 43298 RVA: 0x0023AD24 File Offset: 0x00239124
		public BeItem(BeItemData data, ClientSystemGameBattle systemTown) : base(data, systemTown)
		{
			this.itemId = (int)data.mDropItem.data_id;
			this.mServerPos.x = data.mDropItem.pos.x;
			this.mServerPos.z = data.mDropItem.pos.y;
			base.ActorData.GUID = data.mDropItem.guid;
		}

		// Token: 0x17001A1C RID: 6684
		// (get) Token: 0x0600A923 RID: 43299 RVA: 0x0023ADBB File Offset: 0x002391BB
		public Vector3 Pos
		{
			get
			{
				return this.mPos;
			}
		}

		// Token: 0x17001A1D RID: 6685
		// (get) Token: 0x0600A924 RID: 43300 RVA: 0x0023ADC3 File Offset: 0x002391C3
		public int ItemID
		{
			get
			{
				return this.itemId;
			}
		}

		// Token: 0x17001A1E RID: 6686
		// (get) Token: 0x0600A925 RID: 43301 RVA: 0x0023ADCB File Offset: 0x002391CB
		public bool IsBuffItem
		{
			get
			{
				return this.isBuffItem;
			}
		}

		// Token: 0x17001A1F RID: 6687
		// (get) Token: 0x0600A926 RID: 43302 RVA: 0x0023ADD3 File Offset: 0x002391D3
		public ItemData ItemTableData
		{
			get
			{
				return this.mItemTable;
			}
		}

		// Token: 0x0600A927 RID: 43303 RVA: 0x0023ADDC File Offset: 0x002391DC
		public override void OnRemove()
		{
			if (this.itemId == 401000005)
			{
				BeItemData beItemData = base.ActorData as BeItemData;
				if (beItemData.mDropItem.owner != 0UL)
				{
				}
			}
			this.Dispose();
		}

		// Token: 0x0600A928 RID: 43304 RVA: 0x0023AE1D File Offset: 0x0023921D
		public void AddActorPostLoadCommand(PostLoadCommand async)
		{
			if (this._geActor != null)
			{
				this._geActor.PushPostLoadCommand(async);
			}
		}

		// Token: 0x0600A929 RID: 43305 RVA: 0x0023AE38 File Offset: 0x00239238
		public override void Update(float timeElapsed)
		{
			base.Update(timeElapsed);
			if (this.isBuffItem && this._battle != null && this._battle.MainPlayer != null && (base.ActorData.MoveData.Position.xz() - this._battle.MainPlayer.ActorData.MoveData.Position.xz()).magnitude <= 1f)
			{
				DataManager<ChijiDataManager>.GetInstance().SendPickUpBuffItems(base.ActorData.GUID);
				base.Remove();
			}
		}

		// Token: 0x0600A92A RID: 43306 RVA: 0x0023AED8 File Offset: 0x002392D8
		public override void InitGeActor(GeSceneEx geScene)
		{
			if (geScene == null)
			{
				return;
			}
			try
			{
				if (this._geActor == null)
				{
					ISceneData levelData = this._battle.LevelData;
					bool flag = false;
					ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(this.itemId, string.Empty, string.Empty);
					this.mItemTable = ItemDataManager.CreateItemDataFromTable(this.itemId, 100, 0);
					if (tableItem != null)
					{
						if (tableItem.SubType == ItemTable.eSubType.ChijiBuff)
						{
							this.isBuffItem = true;
							ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.ResID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								this._geActor = geScene.CreateActor(tableItem.ResID, 0, 0, false, false, true, false);
								if (this._geActor != null)
								{
									flag = true;
									if (this.isBuffItem)
									{
										GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Battle_Digit/SpritiBuffText", enResourceType.BattleScene, 2U);
										if (gameObject != null)
										{
											GeUtility.AttachTo(gameObject, this._geActor.GetEntityNode(GeEntity.GeEntityNodeType.Root), false);
											ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
											if (component != null)
											{
												Text com = component.GetCom<Text>("txtDesc");
												if (com != null)
												{
													com.text = tableItem.Name;
												}
											}
										}
									}
								}
							}
						}
					}
					else
					{
						Logger.LogErrorFormat("BeItem itemId {0} is not valid !", new object[]
						{
							this.itemId
						});
					}
					if (!flag && tableItem != null)
					{
						this._geActor = geScene.CreateActor(tableItem.ResID, 0, 0, false, false, true, false);
						if (this._geActor != null)
						{
							this._geActor.ChangeAction("Anim_Idle", 1f, true, true, false);
							bool flag2 = tableItem.ThirdType == ItemTable.eThirdType.ChijiGiftPackage || tableItem.ThirdType == ItemTable.eThirdType.UseToOther || tableItem.ThirdType == ItemTable.eThirdType.UseToOther;
							GameObject entityNode = this._geActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor);
							GameObject gameObject2 = null;
							if (flag2 && entityNode != null && entityNode.transform != null && entityNode.transform.childCount > 0)
							{
								Transform child = entityNode.transform.GetChild(0);
								if (child != null)
								{
									gameObject2 = child.gameObject;
								}
							}
							if (null != gameObject2)
							{
								gameObject2.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
								Utility.ClearChild(gameObject2, 2);
								if (tableItem != null)
								{
									GameObject gameObject3 = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Chiji/ChijiDropBoxText", true, 0U);
									ComCommonBind component2 = gameObject3.GetComponent<ComCommonBind>();
									this.objText = gameObject3;
									if (null == component2)
									{
										return;
									}
									GeUtility.AttachTo(gameObject3, gameObject2, false);
									gameObject3.transform.rotation = Quaternion.Euler(0f, 360f, 0f);
									Text com2 = component2.GetCom<Text>("dropName");
									GameObject gameObject4 = component2.GetGameObject("dropModel");
									GameObject gameObject5 = component2.GetGameObject("uniformTips");
									Text com3 = component2.GetCom<Text>("uniformText");
									gameObject5.SetActive(false);
									com2.text = string.Format("<color={0}>{1}</color>", this.mItemTable.GetQualityInfo().ColStr, tableItem.Name);
									this.dropModel = gameObject4;
									string modelPath = tableItem.ModelPath;
									if (this.IsGold(this.itemId))
									{
										Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(800, delegate
										{
											MonoSingleton<AudioManager>.instance.PlaySound(2);
										}, 0, 0, false);
									}
								}
								Singleton<GeMeshRenderManager>.GetInstance().AddMeshObject(entityNode);
							}
						}
						else
						{
							Logger.LogErrorFormat("resid = 0导致_geActor == null, 让鑫伟配吃鸡道具表的resId字段, 道具id：{0},name = {1}", new object[]
							{
								this.itemId,
								tableItem.Name
							});
						}
					}
					this.mPos = this.mServerPos;
					this._geScene = geScene;
					base.ActorData.MoveData.TransformDirty = true;
					this.UpdateGeActor(0f);
				}
			}
			catch (Exception ex)
			{
				this._geActor = null;
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600A92B RID: 43307 RVA: 0x0023B318 File Offset: 0x00239718
		private bool IsGold(int type)
		{
			return type == 600000001 || type == 600000007;
		}

		// Token: 0x04005E6E RID: 24174
		private SceneRegionTable mRegionTable;

		// Token: 0x04005E6F RID: 24175
		private ItemData mItemTable;

		// Token: 0x04005E70 RID: 24176
		private int itemId;

		// Token: 0x04005E71 RID: 24177
		private ulong guid;

		// Token: 0x04005E72 RID: 24178
		private string mDropItemExtraDesc = string.Empty;

		// Token: 0x04005E73 RID: 24179
		private Vector3 mPos = Vector3.zero;

		// Token: 0x04005E74 RID: 24180
		private Vector3 mServerPos = Vector3.zero;

		// Token: 0x04005E75 RID: 24181
		private bool isBuffItem;

		// Token: 0x04005E76 RID: 24182
		private GameObject objText;

		// Token: 0x04005E77 RID: 24183
		private GameObject objEffect;

		// Token: 0x04005E78 RID: 24184
		private GameObject objEffect2;

		// Token: 0x04005E79 RID: 24185
		private GameObject dropModel;
	}
}
