using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019A2 RID: 6562
	public class JoinPk2v2CrossFrame : GameFrame
	{
		// Token: 0x0600FFB2 RID: 65458 RVA: 0x0046E082 File Offset: 0x0046C482
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk2v2Cross/JoinPk2v2Cross";
		}

		// Token: 0x0600FFB3 RID: 65459 RVA: 0x0046E08C File Offset: 0x0046C48C
		protected override void OnOpenFrame()
		{
			this.InitTestComUIList();
			this.UpdateTestComUIList();
			this.BindUIEvent();
			int id = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ScoreWar2v2RewardTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("TableManager.instance.GetTable<ScoreWarRewardTable>() error!!!", new object[0]);
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ScoreWar2v2RewardTable scoreWar2v2RewardTable = keyValuePair.Value as ScoreWar2v2RewardTable;
				if (scoreWar2v2RewardTable != null)
				{
					if (scoreWar2v2RewardTable.RewardPreview.Count > 1)
					{
						id = scoreWar2v2RewardTable.ID;
						break;
					}
				}
			}
			ScoreWar2v2RewardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ScoreWar2v2RewardTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.RewardPreview.Count; i++)
				{
					string text = tableItem.RewardPreviewArray(i);
					string[] array = text.Split(new char[]
					{
						'_'
					});
					if (array.Length >= 2)
					{
						int tableId = int.Parse(array[0]);
						int count = int.Parse(array[1]);
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
						if (itemData != null)
						{
							itemData.Count = count;
							if (i < 4)
							{
								ComItem com = this.mBind.GetCom<ComItem>(string.Format("Item{0}", i));
								if (com != null)
								{
									com.Setup(itemData, delegate(GameObject var1, ItemData var2)
									{
										DataManager<ItemTipManager>.GetInstance().CloseAll();
										DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
									});
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600FFB4 RID: 65460 RVA: 0x0046E218 File Offset: 0x0046C618
		protected override void OnCloseFrame()
		{
			this.UnBindUIEvent();
		}

		// Token: 0x0600FFB5 RID: 65461 RVA: 0x0046E220 File Offset: 0x0046C620
		protected override void _bindExUI()
		{
			this.testComUIList = this.mBind.GetCom<ComUIListScript>("testComUIList");
			this.testTxt = this.mBind.GetCom<Text>("testTxt");
			this.Join = this.mBind.GetCom<Button>("Join");
			this.Join.SafeSetOnClickListener(delegate
			{
				if (DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("2v2melee_score_war_can_not_enter_with_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
				if (clientSystemTown == null)
				{
					return;
				}
				if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
				{
					return;
				}
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
				{
					currSceneID = clientSystemTown.CurrentSceneID,
					currDoorID = 0,
					targetSceneID = 5008,
					targetDoorID = 0
				}, false));
				this.frameMgr.CloseFrame<JoinPk2v2CrossFrame>(this, false);
			});
			this.testImg = this.mBind.GetCom<Image>("testImg");
			this.testSlider = this.mBind.GetCom<Slider>("testSlider");
			this.testSlider.SafeSetValueChangeListener(delegate(float value)
			{
			});
			this.testToggle = this.mBind.GetCom<Toggle>("testToggle");
			this.testToggle.SafeSetOnValueChangedListener(delegate(bool value)
			{
			});
			this.testGo = this.mBind.GetGameObject("testGo");
		}

		// Token: 0x0600FFB6 RID: 65462 RVA: 0x0046E32E File Offset: 0x0046C72E
		protected override void _unbindExUI()
		{
			this.testComUIList = null;
			this.testTxt = null;
			this.Join = null;
			this.testImg = null;
			this.testSlider = null;
			this.testToggle = null;
			this.testGo = null;
		}

		// Token: 0x0600FFB7 RID: 65463 RVA: 0x0046E361 File Offset: 0x0046C761
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0600FFB8 RID: 65464 RVA: 0x0046E364 File Offset: 0x0046C764
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600FFB9 RID: 65465 RVA: 0x0046E366 File Offset: 0x0046C766
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600FFBA RID: 65466 RVA: 0x0046E383 File Offset: 0x0046C783
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600FFBB RID: 65467 RVA: 0x0046E3A0 File Offset: 0x0046C7A0
		private void InitTestComUIList()
		{
			if (this.testComUIList == null)
			{
				return;
			}
			this.testComUIList.Initialize();
			this.testComUIList.onBindItem = ((GameObject go) => go);
			this.testComUIList.onItemVisiable = delegate(ComUIListElementScript go)
			{
				if (go == null)
				{
					return;
				}
				if (this.testComUIListDatas == null)
				{
					return;
				}
				ComUIListTemplateItem component = go.GetComponent<ComUIListTemplateItem>();
				if (component == null)
				{
					return;
				}
				if (go.m_index >= 0 && go.m_index < this.testComUIListDatas.Count)
				{
					component.SetUp(this.testComUIListDatas[go.m_index]);
				}
			};
		}

		// Token: 0x0600FFBC RID: 65468 RVA: 0x0046E409 File Offset: 0x0046C809
		private void CalcTestComUIListDatas()
		{
			this.testComUIListDatas = new List<object>();
			if (this.testComUIListDatas == null)
			{
				return;
			}
		}

		// Token: 0x0600FFBD RID: 65469 RVA: 0x0046E422 File Offset: 0x0046C822
		private void UpdateTestComUIList()
		{
			if (this.testComUIList == null)
			{
				return;
			}
			this.CalcTestComUIListDatas();
			if (this.testComUIListDatas == null)
			{
				return;
			}
			this.testComUIList.SetElementAmount(this.testComUIListDatas.Count);
		}

		// Token: 0x0600FFBE RID: 65470 RVA: 0x0046E45E File Offset: 0x0046C85E
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
		}

		// Token: 0x0400A14B RID: 41291
		private List<object> testComUIListDatas = new List<object>();

		// Token: 0x0400A14C RID: 41292
		private const int ITEM_NUM = 4;

		// Token: 0x0400A14D RID: 41293
		private ComUIListScript testComUIList;

		// Token: 0x0400A14E RID: 41294
		private Text testTxt;

		// Token: 0x0400A14F RID: 41295
		private Button Join;

		// Token: 0x0400A150 RID: 41296
		private Image testImg;

		// Token: 0x0400A151 RID: 41297
		private Slider testSlider;

		// Token: 0x0400A152 RID: 41298
		private Toggle testToggle;

		// Token: 0x0400A153 RID: 41299
		private GameObject testGo;
	}
}
