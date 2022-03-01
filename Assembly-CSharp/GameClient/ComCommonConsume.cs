using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F72 RID: 3954
	[RequireComponent(typeof(HorizontalLayoutGroup))]
	public class ComCommonConsume : MonoBehaviour
	{
		// Token: 0x060098F9 RID: 39161 RVA: 0x001D6654 File Offset: 0x001D4A54
		private void _preSetting()
		{
			HorizontalLayoutGroup component = base.GetComponent<HorizontalLayoutGroup>();
			component.childForceExpandWidth = false;
			component.childForceExpandHeight = false;
			if (null != this.mBind)
			{
				this.mIcon = this.mBind.GetCom<Image>("icon");
				this.mCount = this.mBind.GetCom<Text>("cnt");
				this.mSumCount = this.mBind.GetCom<Text>("sumcnt");
				this.mAdd = this.mBind.GetCom<Button>("addbutton");
				this.mTipsButton = this.mBind.GetCom<Button>("tipsButton");
			}
			if (this.mIsGetParentComFrameBinder)
			{
				this.comFrameBinder = base.GetComponentInParent<ClientFrameBinder>();
			}
		}

		// Token: 0x060098FA RID: 39162 RVA: 0x001D670C File Offset: 0x001D4B0C
		private void Start()
		{
			if (!this.m_bInitialize)
			{
				this._preSetting();
				this._init();
				this._bindEvent();
				this._loadButton();
				this.m_bInitialize = true;
			}
		}

		// Token: 0x060098FB RID: 39163 RVA: 0x001D6738 File Offset: 0x001D4B38
		private void _init()
		{
			ComCommonConsume.eType eType = this.mType;
			if (eType != ComCommonConsume.eType.Item)
			{
				if (eType == ComCommonConsume.eType.Count)
				{
					this.mConsume = ConsumeFactory.CreateByCountType(this.mCountType, this.mDungeonID, this.comFrameBinder);
				}
			}
			else
			{
				ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(this.mItemID, string.Empty, string.Empty);
				if (tableItem != null && null != this.mIcon)
				{
					ETCImageLoader.LoadSprite(ref this.mIcon, tableItem.Icon, true);
				}
				this.mConsume = ConsumeFactory.CreateByItemID(this.mItemID, this.comFrameBinder);
			}
		}

		// Token: 0x060098FC RID: 39164 RVA: 0x001D67E6 File Offset: 0x001D4BE6
		private void OnDestroy()
		{
			this._unbindEvent();
			this._unloadButton();
			this._uninit();
		}

		// Token: 0x060098FD RID: 39165 RVA: 0x001D67FA File Offset: 0x001D4BFA
		private void _uninit()
		{
			this.comFrameBinder = null;
			this.mConsume = null;
			this.mIcon = null;
			this.mBorad = null;
			this.mAdd = null;
			this.mCount = null;
			this.mSumCount = null;
			this.mTipsButton = null;
		}

		// Token: 0x060098FE RID: 39166 RVA: 0x001D6834 File Offset: 0x001D4C34
		public void SetData(ComCommonConsume.eType type, ComCommonConsume.eCountType countType, int id)
		{
			this._unbindEvent();
			this.mType = type;
			this.mCountType = countType;
			ComCommonConsume.eType eType = this.mType;
			if (eType != ComCommonConsume.eType.Item)
			{
				if (eType == ComCommonConsume.eType.Count)
				{
					this.mDungeonID = id;
				}
			}
			else
			{
				this.mItemID = id;
			}
			this._init();
			this._bindEvent();
		}

		// Token: 0x060098FF RID: 39167 RVA: 0x001D6894 File Offset: 0x001D4C94
		private void _bindEvent()
		{
			if (this.mConsume != null)
			{
				EUIEventID[] array = this.mConsume.WatchEvents();
				if (array == null)
				{
					return;
				}
				for (int i = 0; i < array.Length; i++)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(array[i], new ClientEventSystem.UIEventHandler(this._onUpdate));
				}
				PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
				instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._onMoneyChanged));
				this._onUpdate(null);
			}
		}

		// Token: 0x06009900 RID: 39168 RVA: 0x001D691C File Offset: 0x001D4D1C
		private void _unbindEvent()
		{
			if (this.mConsume != null)
			{
				PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
				instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._onMoneyChanged));
				EUIEventID[] array = this.mConsume.WatchEvents();
				if (array == null)
				{
					return;
				}
				for (int i = 0; i < array.Length; i++)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(array[i], new ClientEventSystem.UIEventHandler(this._onUpdate));
				}
			}
		}

		// Token: 0x06009901 RID: 39169 RVA: 0x001D699C File Offset: 0x001D4D9C
		private void _onUpdate(UIEvent ui)
		{
			if (this.mConsume != null)
			{
				this.mConsume.OnChange();
				if (null != this.mCount)
				{
					this.mCount.text = Utility.ToThousandsSeparator(this.mConsume.GetCount());
				}
				if (null != this.mSumCount)
				{
					this.mSumCount.text = this.mConsume.GetSumCount().ToString();
				}
			}
		}

		// Token: 0x06009902 RID: 39170 RVA: 0x001D6A20 File Offset: 0x001D4E20
		private void _onMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._onUpdate(null);
		}

		// Token: 0x06009903 RID: 39171 RVA: 0x001D6A29 File Offset: 0x001D4E29
		private void _onAddClick()
		{
			if (this.mConsume != null)
			{
				this.mConsume.OnAdd();
			}
		}

		// Token: 0x06009904 RID: 39172 RVA: 0x001D6A44 File Offset: 0x001D4E44
		private void _onPopTips()
		{
			if (this.mType == ComCommonConsume.eType.Item)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mItemID);
				if (commonItemTableDataByID != null)
				{
					DataManager<ItemTipManager>.GetInstance().CloseAll();
					DataManager<ItemTipManager>.GetInstance().ShowTip(commonItemTableDataByID, null, 4, true, false, true);
				}
			}
		}

		// Token: 0x06009905 RID: 39173 RVA: 0x001D6A90 File Offset: 0x001D4E90
		private void _loadButton()
		{
			this._unloadButton();
			if (null != this.mAdd)
			{
				this.mAdd.onClick.AddListener(new UnityAction(this._onAddClick));
				GameObject gameObject = new GameObject("bigOpen", new Type[]
				{
					typeof(RectTransform)
				});
				gameObject.transform.SetParent(this.mAdd.gameObject.transform);
				RectTransform component = gameObject.GetComponent<RectTransform>();
				component.anchorMax = Vector2.one * 0.5f;
				component.anchorMin = Vector2.one * 0.5f;
				component.localScale = Vector3.one;
				component.offsetMax = new Vector2(50f, 50f);
				component.offsetMin = new Vector2(-50f, -50f);
				Image image = gameObject.AddComponent<Image>();
				image.color = Color.clear;
			}
			if (null != this.mTipsButton)
			{
				this.mTipsButton.onClick.AddListener(new UnityAction(this._onPopTips));
			}
		}

		// Token: 0x06009906 RID: 39174 RVA: 0x001D6BB0 File Offset: 0x001D4FB0
		private void _unloadButton()
		{
			if (null != this.mAdd)
			{
				this.mAdd.onClick.RemoveListener(new UnityAction(this._onAddClick));
			}
			if (null != this.mTipsButton)
			{
				this.mTipsButton.onClick.RemoveListener(new UnityAction(this._onPopTips));
			}
		}

		// Token: 0x04004EB9 RID: 20153
		public ComCommonConsume.eType mType;

		// Token: 0x04004EBA RID: 20154
		public ComCommonConsume.eCountType mCountType;

		// Token: 0x04004EBB RID: 20155
		public int mItemID;

		// Token: 0x04004EBC RID: 20156
		public int mDungeonID;

		// Token: 0x04004EBD RID: 20157
		public bool mIsGetParentComFrameBinder = true;

		// Token: 0x04004EBE RID: 20158
		public ComCommonBind mBind;

		// Token: 0x04004EBF RID: 20159
		private Image mIcon;

		// Token: 0x04004EC0 RID: 20160
		private Image mBorad;

		// Token: 0x04004EC1 RID: 20161
		private Button mAdd;

		// Token: 0x04004EC2 RID: 20162
		private Text mCount;

		// Token: 0x04004EC3 RID: 20163
		private Text mSumCount;

		// Token: 0x04004EC4 RID: 20164
		private Button mTipsButton;

		// Token: 0x04004EC5 RID: 20165
		private ICommonConsume mConsume;

		// Token: 0x04004EC6 RID: 20166
		private ClientFrameBinder comFrameBinder;

		// Token: 0x04004EC7 RID: 20167
		private bool m_bInitialize;

		// Token: 0x02000F73 RID: 3955
		public enum eType
		{
			// Token: 0x04004EC9 RID: 20169
			Item,
			// Token: 0x04004ECA RID: 20170
			Count
		}

		// Token: 0x02000F74 RID: 3956
		public enum eCountType
		{
			// Token: 0x04004ECC RID: 20172
			Fatigue,
			// Token: 0x04004ECD RID: 20173
			MouCount,
			// Token: 0x04004ECE RID: 20174
			NorthCount,
			// Token: 0x04004ECF RID: 20175
			HellTiketCount,
			// Token: 0x04004ED0 RID: 20176
			DeadTower,
			// Token: 0x04004ED1 RID: 20177
			Final_Test
		}
	}
}
