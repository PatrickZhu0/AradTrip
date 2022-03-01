using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000035 RID: 53
	internal class ComGuildItem : MonoBehaviour
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000D07C File Offset: 0x0000B47C
		// (set) Token: 0x0600015F RID: 351 RVA: 0x0000D084 File Offset: 0x0000B484
		public ComGuildItemData Value
		{
			get
			{
				return this.data;
			}
			private set
			{
				this.data = this.Value;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000D092 File Offset: 0x0000B492
		public static void ClearPools()
		{
			ComGuildItem.pools.Clear();
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000161 RID: 353 RVA: 0x0000D09E File Offset: 0x0000B49E
		public static List<ComGuildItem> PoolItems
		{
			get
			{
				return ComGuildItem.pools;
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000D0A8 File Offset: 0x0000B4A8
		public static void CancelSelectedItems()
		{
			List<object> list = ListPool<object>.Get();
			try
			{
				for (int i = 0; i < ComGuildItem.pools.Count; i++)
				{
					list.Add(ComGuildItem.pools[i]);
				}
				for (int j = 0; j < list.Count; j++)
				{
					ComGuildItem comGuildItem = list[j] as ComGuildItem;
					if (null != comGuildItem)
					{
						comGuildItem.OnItemSelected(false);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat(ex.ToString(), new object[0]);
			}
			ListPool<object>.Release(list);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000D154 File Offset: 0x0000B554
		public void OnItemSelected(bool bSelected)
		{
			if (null != this.comState)
			{
				if (bSelected)
				{
					if (!this.Value.bClear)
					{
						int num = DataManager<GuildDataManager>.GetInstance().storeDatas.Count + ComGuildItem.PoolItems.Count;
						if (num >= DataManager<GuildDataManager>.GetInstance().storeageCapacity)
						{
							if (null != this.toggle)
							{
								this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnItemSelected));
							}
							this.toggle.isOn = false;
							if (null != this.toggle)
							{
								this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnItemSelected));
							}
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_store_house_is_full"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
					}
					if (!ComGuildItem.pools.Contains(this))
					{
						ComGuildItem.pools.Add(this);
					}
					if (this.Value.itemData != null)
					{
						this.Value.iSelectedCount = this.Value.itemData.Count;
					}
					this._RefreshData();
					if (this.Value.itemData != null && this.Value.itemData.Count > 1)
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildStoreConfirmFrame>(FrameLayer.High, new GuildStoreConfirmFrameData
						{
							title = ((!this.Value.bClear) ? TR.Value("guild_op_title_0") : TR.Value("guild_op_title_1")),
							iCurCount = this.Value.itemData.Count,
							iMax = this.Value.itemData.Count,
							onOk = delegate(int iCount)
							{
								this.Value.iSelectedCount = iCount;
								this._RefreshData();
							}
						}, string.Empty);
					}
				}
				else
				{
					ComGuildItem.pools.Remove(this);
					this.Value.iSelectedCount = 0;
					this._RefreshData();
					if (this.toggle.isOn)
					{
						if (null != this.toggle)
						{
							this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnItemSelected));
						}
						this.toggle.isOn = false;
						if (null != this.toggle)
						{
							this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnItemSelected));
						}
					}
				}
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000D3BA File Offset: 0x0000B7BA
		public void InitComGuildItem(ComItem.OnItemClicked onItemClicked, bool bAsSelector, bool bClear)
		{
			this.onItemClicked = onItemClicked;
			this.Value.bAsSelector = bAsSelector;
			this.Value.bClear = bClear;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000D3DC File Offset: 0x0000B7DC
		private void _RefreshData()
		{
			if (this.Value.itemData == null)
			{
				if (null != this.comState)
				{
					this.comState.Key = ComGuildItem.ms_static_descs[0];
				}
				if (null != this.toggle)
				{
					this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnItemSelected));
				}
			}
			else
			{
				if (null == this.comItem)
				{
					this.comItem = ComItemManager.Create(this.goItemParent);
				}
				if (this.Value.bAsSelector)
				{
					if (!ComGuildItem.PoolItems.Contains(this))
					{
						this.comState.Key = ComGuildItem.ms_static_descs[2];
					}
					else
					{
						this.comState.Key = ComGuildItem.ms_static_descs[3];
					}
					if (null != this.toggle)
					{
						this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnItemSelected));
						this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnItemSelected));
					}
				}
				else
				{
					this.comState.Key = ComGuildItem.ms_static_descs[1];
					if (null != this.toggle)
					{
						this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnItemSelected));
					}
				}
			}
			if (null != this.comItem)
			{
				if (!ComGuildItem.PoolItems.Contains(this))
				{
					this.comItem.SetCountFormatter(null);
					if (this.Value == null || this.Value.itemData == null)
					{
						this.comItem.Setup(null, null);
					}
					else
					{
						this.comItem.Setup(this.Value.itemData, this.onItemClicked);
					}
				}
				else if (this.Value == null || this.Value.itemData == null)
				{
					this.comItem.SetCountFormatter(null);
					this.comItem.Setup(null, null);
				}
				else
				{
					if (this.Value.itemData.Count <= 1)
					{
						this.comItem.SetCountFormatter(null);
					}
					else
					{
						this.comItem.SetCountFormatter(new ComItem.CountFormatter(this._CountFormatter));
					}
					this.comItem.Setup(this.Value.itemData, this.onItemClicked);
				}
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000D654 File Offset: 0x0000BA54
		public void SetItemData(ItemData data)
		{
			this.data.itemData = data;
			this._RefreshData();
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000D668 File Offset: 0x0000BA68
		private string _CountFormatter(ComItem a_comItem)
		{
			if (null != a_comItem && this.data.itemData.Count > 0 && this.Value != null && this.Value.itemData != null)
			{
				return string.Format("{0}/{1}", this.Value.iSelectedCount, this.data.itemData.Count);
			}
			return string.Empty;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000D6E8 File Offset: 0x0000BAE8
		public void OnDestroy()
		{
			if (null != this.comItem)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
			if (null != this.toggle)
			{
				this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnItemSelected));
				this.toggle = null;
			}
			this.goItemParent = null;
			this.comState = null;
			this.data = null;
			this.onItemClicked = null;
		}

		// Token: 0x0400013E RID: 318
		private static string[] ms_static_descs = new string[]
		{
			"Blank",
			"ItemNormal",
			"ItemUnSelected",
			"ItemSelected"
		};

		// Token: 0x0400013F RID: 319
		public static ComGuildItem ms_selected = null;

		// Token: 0x04000140 RID: 320
		public GameObject goItemParent;

		// Token: 0x04000141 RID: 321
		public StateController comState;

		// Token: 0x04000142 RID: 322
		public Toggle toggle;

		// Token: 0x04000143 RID: 323
		private ComItem comItem;

		// Token: 0x04000144 RID: 324
		private ComGuildItemData data = new ComGuildItemData();

		// Token: 0x04000145 RID: 325
		private ComItem.OnItemClicked onItemClicked;

		// Token: 0x04000146 RID: 326
		private static List<ComGuildItem> pools = new List<ComGuildItem>();
	}
}
