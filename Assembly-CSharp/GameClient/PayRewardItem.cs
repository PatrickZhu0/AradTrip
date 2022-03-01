using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200195C RID: 6492
	public class PayRewardItem : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		// Token: 0x0600FC65 RID: 64613 RVA: 0x00456218 File Offset: 0x00454618
		public void Initialize(ClientFrame dependFrame, ItemData data = null, bool bUsedComItem = true, bool bComItemHideCount = true)
		{
			if (this.m_ItemName == null)
			{
				this.m_ItemName = Utility.GetComponetInChild<Text>(base.gameObject, "Desc");
			}
			if (this.m_Count == null)
			{
				this.m_Count = Utility.GetComponetInChild<Text>(base.gameObject, "Bg/count");
			}
			if (this.m_Icon == null)
			{
				this.m_Icon = Utility.GetComponetInChild<Image>(base.gameObject, "Bg/icon");
			}
			if (this.m_RootObj == null)
			{
				this.m_RootObj = Utility.FindChild(base.gameObject, "Bg");
			}
			if (this.m_Icon != null && this.m_IconRoot == null)
			{
				this.m_IconRoot = this.m_Icon.gameObject;
			}
			if (this.m_ComItem == null && dependFrame != null && bUsedComItem)
			{
				this.m_ComItem = dependFrame.CreateComItem(this.m_IconRoot);
			}
			this.m_ItemData = data;
			this.m_bComItemHideCount = bComItemHideCount;
			this.m_bComItemUsed = bUsedComItem;
			this.m_ItemCountTextFormat = TR.Value("vip_month_card_first_buy_reward_item_count_format");
			this.m_ComItemCountTextFormat = TR.Value("vip_month_card_first_buy_first_comitem_count_format");
		}

		// Token: 0x0600FC66 RID: 64614 RVA: 0x0045635C File Offset: 0x0045475C
		public void Clear()
		{
			this.m_ItemName = null;
			this.m_Count = null;
			this.m_Icon = null;
			if (this.m_Effect_objs != null)
			{
				for (int i = 0; i < this.m_Effect_objs.Count; i++)
				{
					this.m_Effect_objs[i].CustomActive(false);
				}
				this.m_Effect_objs.Clear();
			}
			this.onPayItemClick = null;
			this.m_ComItem = null;
			this.m_IconRoot = null;
			this.m_RootObj = null;
			this.m_ItemData = null;
			this.m_bComItemUsed = false;
			this.m_bComItemHideCount = false;
			this.m_ItemCountTextFormat = string.Empty;
			this.m_ComItemCountTextFormat = string.Empty;
		}

		// Token: 0x0600FC67 RID: 64615 RVA: 0x0045640C File Offset: 0x0045480C
		public void RefreshView(bool bShowName = true, bool bShowCount = true)
		{
			if (this.m_ItemData == null)
			{
				return;
			}
			if (bShowName)
			{
				this.SetItemName(this.m_ItemData.GetColorName(string.Empty, false));
			}
			else
			{
				this.SetItemName(string.Empty);
			}
			if (bShowCount)
			{
				this.SetItemCount(string.Format(this.m_ItemCountTextFormat, this.m_ItemData.Count.ToString()));
			}
			else
			{
				this.SetItemCount(string.Empty);
			}
			if (this.m_bComItemUsed)
			{
				this.RefreshComItem(this.m_bComItemHideCount);
			}
		}

		// Token: 0x0600FC68 RID: 64616 RVA: 0x004564A6 File Offset: 0x004548A6
		public void EnableItemEffect()
		{
		}

		// Token: 0x0600FC69 RID: 64617 RVA: 0x004564A8 File Offset: 0x004548A8
		public void SetItemIcon(string spritePath)
		{
			if (this.m_Icon)
			{
				ETCImageLoader.LoadSprite(ref this.m_Icon, spritePath, true);
			}
		}

		// Token: 0x0600FC6A RID: 64618 RVA: 0x004564C8 File Offset: 0x004548C8
		public void SetItemName(string name)
		{
			if (this.m_ItemName)
			{
				this.m_ItemName.text = name;
			}
		}

		// Token: 0x0600FC6B RID: 64619 RVA: 0x004564E6 File Offset: 0x004548E6
		public void SetItemCount(string count)
		{
			if (this.m_Count)
			{
				this.m_Count.text = count;
			}
		}

		// Token: 0x0600FC6C RID: 64620 RVA: 0x00456504 File Offset: 0x00454904
		private void RefreshComItem(bool bItemHideCount)
		{
			if (this.m_ComItem != null)
			{
				this.m_ComItem.Reset();
				if (bItemHideCount)
				{
					this.m_ItemData.Count = 0;
				}
				else
				{
					int count = this.m_ItemData.Count;
					int length = Mathf.Abs(count).ToString().Length;
					if (length > 4)
					{
						int num = (int)Mathf.Pow(10f, 4f);
						int num2 = (int)Mathf.Pow(10f, 3f);
						int num3 = count / num;
						int num4 = count % num / num2;
						string formatCountStr = string.Empty;
						if (num4 == 0)
						{
							formatCountStr = string.Format("{0}", num3);
						}
						else
						{
							formatCountStr = string.Format("{0}.{1}", num3, num4);
						}
						this.m_ComItem.SetCountFormatter((ComItem var) => string.Format(this.m_ComItemCountTextFormat, formatCountStr));
					}
					else
					{
						this.m_ComItem.SetCountFormatter(null);
					}
				}
				this.m_ComItem.Setup(this.m_ItemData, delegate(GameObject obj, ItemData item1)
				{
					List<TipFuncButon> list = new List<TipFuncButon>();
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item1.TableID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Type == ItemTable.eType.EXPENDABLE && tableItem.SubType == ItemTable.eSubType.GiftPackage && tableItem.ThirdType == ItemTable.eThirdType.HaloGift)
					{
						list.Add(new TipFuncButonSpecial
						{
							text = TR.Value("tip_preview"),
							callback = new OnTipFuncClicked(this.OnPreviewItem)
						});
					}
					Utility.DoStartFrameOperation("SecondPayFrame", string.Format("ItemID/{0}", item1.TableID));
					DataManager<ItemTipManager>.GetInstance().ShowTip(item1, list, 4, true, false, true);
				});
			}
		}

		// Token: 0x0600FC6D RID: 64621 RVA: 0x00456642 File Offset: 0x00454A42
		private void OnPreviewItem(ItemData item, object data)
		{
			if (item != null)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, item.TableID, string.Empty);
			}
		}

		// Token: 0x0600FC6E RID: 64622 RVA: 0x00456666 File Offset: 0x00454A66
		public void OnPointerClick(PointerEventData eventData)
		{
			if (this.onPayItemClick != null)
			{
				this.onPayItemClick();
			}
		}

		// Token: 0x0600FC6F RID: 64623 RVA: 0x0045667E File Offset: 0x00454A7E
		public void OnPointerDown(PointerEventData eventData)
		{
		}

		// Token: 0x0600FC70 RID: 64624 RVA: 0x00456680 File Offset: 0x00454A80
		public void OnPointerUp(PointerEventData eventData)
		{
		}

		// Token: 0x04009E2C RID: 40492
		protected const string effect_obj_1 = "";

		// Token: 0x04009E2D RID: 40493
		private List<GameObject> m_Effect_objs = new List<GameObject>();

		// Token: 0x04009E2E RID: 40494
		private Text m_ItemName;

		// Token: 0x04009E2F RID: 40495
		private Text m_Count;

		// Token: 0x04009E30 RID: 40496
		private Image m_Icon;

		// Token: 0x04009E31 RID: 40497
		private GameObject m_RootObj;

		// Token: 0x04009E32 RID: 40498
		private GameObject m_IconRoot;

		// Token: 0x04009E33 RID: 40499
		private ComItem m_ComItem;

		// Token: 0x04009E34 RID: 40500
		private ItemData m_ItemData;

		// Token: 0x04009E35 RID: 40501
		private bool m_bComItemUsed;

		// Token: 0x04009E36 RID: 40502
		private bool m_bComItemHideCount;

		// Token: 0x04009E37 RID: 40503
		private string m_ItemCountTextFormat = "X{0}";

		// Token: 0x04009E38 RID: 40504
		private string m_ComItemCountTextFormat = "{0}.{1}万元";

		// Token: 0x04009E39 RID: 40505
		public PayRewardItem.OnPayItemClick onPayItemClick;

		// Token: 0x0200195D RID: 6493
		// (Invoke) Token: 0x0600FC73 RID: 64627
		public delegate void OnPayItemClick();
	}
}
