using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014AF RID: 5295
	internal class BudoRewardsFrame : ClientFrame
	{
		// Token: 0x0600CD2E RID: 52526 RVA: 0x00327090 File Offset: 0x00325490
		public static void Open(BudoRewardsFrameData data)
		{
			if (data != null)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<BudoResultFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<BudoRewardsFrame>(FrameLayer.Middle, data, string.Empty);
			}
		}

		// Token: 0x0600CD2F RID: 52527 RVA: 0x003270B8 File Offset: 0x003254B8
		public override string GetPrefabPath()
		{
			BudoRewardsFrameData budoRewardsFrameData = this.userData as BudoRewardsFrameData;
			if (budoRewardsFrameData != null && !budoRewardsFrameData.bJustPreView)
			{
				return "UIFlatten/Prefabs/Budo/BudoRewardsFrame";
			}
			return "UIFlatten/Prefabs/Budo/BudoRewardsFrame_Preview";
		}

		// Token: 0x0600CD30 RID: 52528 RVA: 0x003270F0 File Offset: 0x003254F0
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as BudoRewardsFrameData);
			this.goComItemsParent = Utility.FindChild(this.frame, "ScrollView/ViewPort/Content");
			this.goPrefab = Utility.FindChild(this.frame, "ScrollView/ViewPort/Content/ItemParent");
			this.goPrefab.CustomActive(false);
			Text text = Utility.FindComponent<Text>(this.frame, "Up/Title", true);
			text.text = this.m_kData.title;
			this.receiveItemLabel = Utility.FindComponent<Text>(this.frame, "ReceiveItemRoot/receiveItemLabel", true);
			this.previewTipLabel = Utility.FindComponent<Text>(this.frame, "ReceiveItemRoot/previewTipLabel", true);
			this._SetData();
			if (this.m_kData != null && this.m_kData.bJustPreView)
			{
				this.UpdateReceiveItemLabel();
				this.UpdatePreviewTipLabel();
			}
		}

		// Token: 0x0600CD31 RID: 52529 RVA: 0x003271C4 File Offset: 0x003255C4
		protected override void _OnCloseFrame()
		{
			this.m_kData.datas.Clear();
			this.m_kData.title = null;
			this.m_kData = null;
			this.m_akAwardItems.DestroyAllObjects();
			this.goComItemsParent = null;
			this.goPrefab = null;
			this.m_kTempData.Clear();
			this.receiveItemLabel = null;
			this.previewTipLabel = null;
		}

		// Token: 0x0600CD32 RID: 52530 RVA: 0x00327228 File Offset: 0x00325628
		private IEnumerator _CreateAwards()
		{
			int i = 0;
			while (this.m_kData.datas != null && i < this.m_kData.datas.Count)
			{
				ItemData current = this.m_kData.datas[i];
				if (current != null)
				{
					if (!this.m_akAwardItems.HasObject((ulong)((long)current.TableID)))
					{
						this.m_kTempData.goParent = this.goComItemsParent;
						this.m_kTempData.goPrefab = this.goPrefab;
						this.m_kTempData.itemData = current;
						this.m_kTempData.frame = this;
						this.m_kTempData.bPreView = false;
						this.m_akAwardItems.Create((ulong)((long)current.TableID), new object[]
						{
							this.m_kTempData
						});
						yield return Yielders.GetWaitForSeconds(0.35f);
					}
				}
				i++;
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x0600CD33 RID: 52531 RVA: 0x00327244 File Offset: 0x00325644
		private void _SetData()
		{
			if (this.m_kData != null)
			{
				if (!this.m_kData.bJustPreView)
				{
					base.StartCoroutine(this._CreateAwards());
				}
				else
				{
					int num = 0;
					while (this.m_kData.datas != null && num < this.m_kData.datas.Count)
					{
						ItemData itemData = this.m_kData.datas[num];
						if (itemData != null)
						{
							if (!this.m_akAwardItems.HasObject((ulong)((long)itemData.TableID)))
							{
								this.m_kTempData.goParent = this.goComItemsParent;
								this.m_kTempData.goPrefab = this.goPrefab;
								this.m_kTempData.itemData = itemData;
								this.m_kTempData.frame = this;
								this.m_kTempData.bPreView = true;
								this.m_akAwardItems.Create((ulong)((long)itemData.TableID), new object[]
								{
									this.m_kTempData
								});
							}
						}
						num++;
					}
				}
			}
		}

		// Token: 0x0600CD34 RID: 52532 RVA: 0x0032734B File Offset: 0x0032574B
		[UIEventHandle("Close")]
		private void OnClickClose()
		{
			this._BudoReturn();
			this.frameMgr.CloseFrame<BudoRewardsFrame>(this, false);
		}

		// Token: 0x0600CD35 RID: 52533 RVA: 0x00327360 File Offset: 0x00325760
		[UIEventHandle("Btn")]
		private void OnClickClose2()
		{
			this._BudoReturn();
			this.frameMgr.CloseFrame<BudoRewardsFrame>(this, false);
		}

		// Token: 0x0600CD36 RID: 52534 RVA: 0x00327375 File Offset: 0x00325775
		private void _BudoReturn()
		{
			if (this.m_kData.bJustPreView)
			{
				return;
			}
			DataManager<BudoManager>.GetInstance().SendReturnToTownRelation();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<BudoArenaFrame>(null, false);
		}

		// Token: 0x0600CD37 RID: 52535 RVA: 0x003273A0 File Offset: 0x003257A0
		private void UpdateReceiveItemLabel()
		{
			if (this.receiveItemLabel == null)
			{
				return;
			}
			List<ReceiveItemDataModel> receiveItemDataModelList = this.m_kData.ReceiveItemDataModelList;
			if (receiveItemDataModelList == null || receiveItemDataModelList.Count <= 0)
			{
				return;
			}
			string text = string.Empty;
			for (int i = 0; i < receiveItemDataModelList.Count; i++)
			{
				ReceiveItemDataModel receiveItemDataModel = receiveItemDataModelList[i];
				if (receiveItemDataModel != null)
				{
					if (receiveItemDataModel.MinNumber <= 0 || receiveItemDataModel.MaxNumber <= 0)
					{
						return;
					}
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(receiveItemDataModel.ItemId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (i != 0)
						{
							text += TR.Value("Common_Format_Split_Flag");
						}
						string itemColorName = CommonUtility.GetItemColorName(tableItem);
						string str = string.Empty;
						if (receiveItemDataModel.MinNumber == receiveItemDataModel.MaxNumber)
						{
							str = TR.Value("Budo_Reward_Receive_One_Item_Format", receiveItemDataModel.MinNumber, itemColorName);
						}
						else
						{
							str = TR.Value("Budo_Reward_Receive_Two_Item_Format", receiveItemDataModel.MinNumber, receiveItemDataModel.MaxNumber, itemColorName);
						}
						text += str;
					}
				}
			}
			string text2 = TR.Value("Budo_Reward_Must_Received_Format", text);
			this.receiveItemLabel.text = text2;
		}

		// Token: 0x0600CD38 RID: 52536 RVA: 0x003274EC File Offset: 0x003258EC
		private void UpdatePreviewTipLabel()
		{
			if (this.previewTipLabel == null)
			{
				return;
			}
			this.previewTipLabel.text = TR.Value("Budo_Reward_Preview_TipLabel");
		}

		// Token: 0x04007797 RID: 30615
		private CachedObjectDicManager<ulong, BudoRewardsFrame.BudoAwardItem> m_akAwardItems = new CachedObjectDicManager<ulong, BudoRewardsFrame.BudoAwardItem>();

		// Token: 0x04007798 RID: 30616
		private BudoRewardsFrameData m_kData;

		// Token: 0x04007799 RID: 30617
		private GameObject goComItemsParent;

		// Token: 0x0400779A RID: 30618
		private GameObject goPrefab;

		// Token: 0x0400779B RID: 30619
		private Text receiveItemLabel;

		// Token: 0x0400779C RID: 30620
		private Text previewTipLabel;

		// Token: 0x0400779D RID: 30621
		private BudoRewardsFrame.CreateData m_kTempData = new BudoRewardsFrame.CreateData();

		// Token: 0x020014B0 RID: 5296
		private class BudoAwardItem : CachedObject
		{
			// Token: 0x17001BF0 RID: 7152
			// (get) Token: 0x0600CD3A RID: 52538 RVA: 0x0032751D File Offset: 0x0032591D
			public ItemData ItemData
			{
				get
				{
					return this.itemData;
				}
			}

			// Token: 0x0600CD3B RID: 52539 RVA: 0x00327528 File Offset: 0x00325928
			public override void OnDestroy()
			{
				InvokeMethod.RemoveInvokeCall(this);
				this.comItem.Setup(null, null);
				this.comItem = null;
				this.itemData = null;
				this.frame = null;
				this.tween = null;
				this.goPrefab = null;
				this.goParent = null;
				this.goLocal = null;
				this.name = null;
				this.comEffect.Stop("Light");
				this.comEffect = null;
			}

			// Token: 0x0600CD3C RID: 52540 RVA: 0x00327598 File Offset: 0x00325998
			public override void OnCreate(object[] param)
			{
				BudoRewardsFrame.CreateData createData = param[0] as BudoRewardsFrame.CreateData;
				this.goParent = createData.goParent;
				this.goPrefab = createData.goPrefab;
				this.itemData = createData.itemData;
				this.frame = createData.frame;
				this.bPreView = createData.bPreView;
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.name = Utility.FindComponent<Text>(this.goLocal, "Name", true);
					this.comItem = this.frame.CreateComItem(this.goLocal);
					this.comEffect = this.goLocal.GetComponent<ComEffect>();
					this.comEffect.Stop("Light");
					this.tween = this.goLocal.GetComponent<DOTweenAnimation>();
				}
				this.Enable();
				this._Update();
				if (!this.bPreView)
				{
					InvokeMethod.Invoke(this, 0.2f, delegate()
					{
						if (this.comEffect != null)
						{
							this.comEffect.Play("Light");
						}
					});
				}
			}

			// Token: 0x0600CD3D RID: 52541 RVA: 0x003276AC File Offset: 0x00325AAC
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
				InvokeMethod.RemoveInvokeCall(this);
			}

			// Token: 0x0600CD3E RID: 52542 RVA: 0x003276D1 File Offset: 0x00325AD1
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600CD3F RID: 52543 RVA: 0x003276DA File Offset: 0x00325ADA
			public override void OnRefresh(object[] param)
			{
				this.itemData = (param[0] as ItemData);
				this._Update();
			}

			// Token: 0x0600CD40 RID: 52544 RVA: 0x003276F0 File Offset: 0x00325AF0
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600CD41 RID: 52545 RVA: 0x0032770F File Offset: 0x00325B0F
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x0600CD42 RID: 52546 RVA: 0x00327732 File Offset: 0x00325B32
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
				InvokeMethod.RemoveInvokeCall(this);
			}

			// Token: 0x0600CD43 RID: 52547 RVA: 0x00327757 File Offset: 0x00325B57
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600CD44 RID: 52548 RVA: 0x0032775A File Offset: 0x00325B5A
			private void OnItemClicked(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				}
			}

			// Token: 0x0600CD45 RID: 52549 RVA: 0x00327772 File Offset: 0x00325B72
			private void _Update()
			{
				this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				this.name.text = this.itemData.GetColorName(string.Empty, false);
			}

			// Token: 0x0400779E RID: 30622
			private GameObject goLocal;

			// Token: 0x0400779F RID: 30623
			private GameObject goPrefab;

			// Token: 0x040077A0 RID: 30624
			private GameObject goParent;

			// Token: 0x040077A1 RID: 30625
			private ItemData itemData;

			// Token: 0x040077A2 RID: 30626
			private BudoRewardsFrame frame;

			// Token: 0x040077A3 RID: 30627
			private DOTweenAnimation tween;

			// Token: 0x040077A4 RID: 30628
			private Text name;

			// Token: 0x040077A5 RID: 30629
			private ComItem comItem;

			// Token: 0x040077A6 RID: 30630
			private ComEffect comEffect;

			// Token: 0x040077A7 RID: 30631
			private bool bPreView;
		}

		// Token: 0x020014B1 RID: 5297
		public class CreateData
		{
			// Token: 0x0600CD48 RID: 52552 RVA: 0x003277D8 File Offset: 0x00325BD8
			public void Clear()
			{
				this.goParent = null;
				this.goPrefab = null;
				this.itemData = null;
				this.frame = null;
				this.bPreView = false;
			}

			// Token: 0x040077A8 RID: 30632
			public GameObject goParent;

			// Token: 0x040077A9 RID: 30633
			public GameObject goPrefab;

			// Token: 0x040077AA RID: 30634
			public ItemData itemData;

			// Token: 0x040077AB RID: 30635
			public BudoRewardsFrame frame;

			// Token: 0x040077AC RID: 30636
			public bool bPreView;
		}
	}
}
