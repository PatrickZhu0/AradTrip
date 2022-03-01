using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013F9 RID: 5113
	internal class ActorShowMenu : ClientFrame
	{
		// Token: 0x0600C623 RID: 50723 RVA: 0x002FD010 File Offset: 0x002FB410
		protected override void _bindExUI()
		{
			this.mLevel = this.mBind.GetCom<Text>("level");
			this.mPortrait = this.mBind.GetCom<Image>("portrait");
			this.mName = this.mBind.GetCom<Text>("name");
			this.mGuildName = this.mBind.GetCom<Text>("guildName");
			this.mVip = this.mBind.GetCom<Text>("vip");
			this.mJobName = this.mBind.GetCom<Text>("jobName");
			this.mPkLevel = this.mBind.GetCom<Text>("pkLevel");
			this.mPkLevelImg = this.mBind.GetCom<Image>("pkLevelImg");
			this.mPkLevelNum = this.mBind.GetCom<Image>("pkLevelNum");
			this.mVipLv = this.mBind.GetCom<UINumber>("vipLv");
			this.mMenuitem = this.mBind.GetGameObject("menuitem");
			this.mMenuArray = this.mBind.GetGameObject("menuArray");
			this.mVipParent = this.mBind.GetGameObject("vipParent");
			this.mMenuitem.CustomActive(false);
		}

		// Token: 0x0600C624 RID: 50724 RVA: 0x002FD148 File Offset: 0x002FB548
		protected override void _unbindExUI()
		{
			this.mLevel = null;
			this.mPortrait = null;
			this.mName = null;
			this.mGuildName = null;
			this.mVip = null;
			this.mJobName = null;
			this.mPkLevel = null;
			this.mPkLevelImg = null;
			this.mPkLevelNum = null;
			this.mVipLv = null;
			this.mMenuitem = null;
			this.mMenuArray = null;
			this.mVipParent = null;
		}

		// Token: 0x17001BEB RID: 7147
		// (get) Token: 0x0600C625 RID: 50725 RVA: 0x002FD1B0 File Offset: 0x002FB5B0
		// (set) Token: 0x0600C626 RID: 50726 RVA: 0x002FD1B8 File Offset: 0x002FB5B8
		public MenuData MenuParams { get; set; }

		// Token: 0x0600C627 RID: 50727 RVA: 0x002FD1C1 File Offset: 0x002FB5C1
		public static void CloseMenu()
		{
			ActorShowMenu.ms_menuParams = null;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActorShowMenu>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActorShowMenu>(null, false);
			}
		}

		// Token: 0x0600C628 RID: 50728 RVA: 0x002FD1E8 File Offset: 0x002FB5E8
		public static void Open(MenuData menuData)
		{
			if (menuData != null)
			{
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActorShowMenu>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActorShowMenu>(FrameLayer.Middle, menuData, string.Empty);
				}
				else
				{
					ActorShowMenu.ms_menuParams = menuData;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateActorShowMenu, null, null, null, null);
				}
			}
		}

		// Token: 0x0600C629 RID: 50729 RVA: 0x002FD23B File Offset: 0x002FB63B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CheckInfo/ActorShowMenu";
		}

		// Token: 0x0600C62A RID: 50730 RVA: 0x002FD244 File Offset: 0x002FB644
		protected override void _OnOpenFrame()
		{
			this.m_kMenuData = (this.userData as MenuData);
			this.m_akCachedItemObjects.Clear();
			this.m_goUIRoot = GameObject.Find("UIRoot");
			this.m_kCanvas = Utility.FindComponent<Canvas>(this.m_goUIRoot, "UI2DRoot", true);
			Button button = Utility.FindComponent<Button>(this.frame, "Close", true);
			button.onClick.AddListener(delegate()
			{
				ActorShowMenu.CloseMenu();
				this.frameMgr.CloseFrame<ActorShowMenu>(this, false);
			});
			this._InitMenuItems();
		}

		// Token: 0x0600C62B RID: 50731 RVA: 0x002FD2C3 File Offset: 0x002FB6C3
		protected override void _OnCloseFrame()
		{
			this.m_akCachedItemObjects.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateActorShowMenu, new ClientEventSystem.UIEventHandler(this.OnUpdateMenu));
		}

		// Token: 0x0600C62C RID: 50732 RVA: 0x002FD2EB File Offset: 0x002FB6EB
		private void _InitMenuItems()
		{
			this._CreateMenuItemsFromData();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateActorShowMenu, new ClientEventSystem.UIEventHandler(this.OnUpdateMenu));
		}

		// Token: 0x0600C62D RID: 50733 RVA: 0x002FD30E File Offset: 0x002FB70E
		private void OnUpdateMenu(UIEvent uiEvent)
		{
			this._UpdateMenuItems();
		}

		// Token: 0x0600C62E RID: 50734 RVA: 0x002FD318 File Offset: 0x002FB718
		private void _UpdateMenuItems()
		{
			this.m_kMenuData = ActorShowMenu.ms_menuParams;
			if (this.m_kMenuData == null || this.m_kMenuData.items == null || this.m_kMenuData.items.Count <= 0)
			{
				this.frameMgr.CloseFrame<ActorShowMenu>(this, false);
				return;
			}
			this.m_akCachedItemObjects.RecycleAllObject();
			this._CreateMenuItemsFromData();
		}

		// Token: 0x0600C62F RID: 50735 RVA: 0x002FD380 File Offset: 0x002FB780
		private void _CreateMenuItemsFromData()
		{
			if (this.m_kMenuData != null)
			{
				this.mLevel.text = "Lv." + this.m_kMenuData.level;
				string path = string.Empty;
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.m_kMenuData.jobID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (this.mJobName)
					{
						this.mJobName.text = tableItem.Name;
					}
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						path = tableItem2.IconPath;
					}
				}
				ETCImageLoader.LoadSprite(ref this.mPortrait, path, true);
				this.mName.text = this.m_kMenuData.name;
				if (this.m_kMenuData.HasGuild())
				{
					this.mGuildName.text = "公会 " + this.m_kMenuData.guildName;
				}
				else
				{
					this.mGuildName.text = string.Empty;
				}
				if (this.m_kMenuData.HasVip())
				{
					this.mVipParent.CustomActive(true);
					if (this.mVipLv)
					{
						this.mVipLv.Value = this.m_kMenuData.vip;
					}
				}
				else
				{
					this.mVipParent.CustomActive(false);
				}
				if (this.mPkLevel)
				{
					this.mPkLevel.text = DataManager<SeasonDataManager>.GetInstance().GetRankName(this.m_kMenuData.pkLevel, true);
				}
				if (this.mPkLevelImg)
				{
					ETCImageLoader.LoadSprite(ref this.mPkLevelImg, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon(this.m_kMenuData.pkLevel), true);
				}
				if (this.mPkLevelNum)
				{
					ETCImageLoader.LoadSprite(ref this.mPkLevelNum, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon(this.m_kMenuData.pkLevel), true);
				}
				for (int i = 0; i < this.m_kMenuData.items.Count; i++)
				{
					ActorShowMenu.MenuItemObject menuItemObject = this.m_akCachedItemObjects.Create(new object[]
					{
						this.mMenuArray,
						this.mMenuitem,
						this.m_kMenuData.items[i],
						this
					});
					if (i > 1 && menuItemObject != null && this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
					{
						menuItemObject.Disable();
					}
				}
				GameObject gameObject = this.mBind.GetGameObject("BG1");
				GameObject gameObject2 = this.mBind.GetGameObject("BG2");
				if (gameObject != null && gameObject2 != null)
				{
					if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
					{
						gameObject.CustomActive(false);
						gameObject2.CustomActive(true);
					}
					else
					{
						gameObject.CustomActive(true);
						gameObject2.CustomActive(false);
					}
				}
			}
		}

		// Token: 0x0600C630 RID: 50736 RVA: 0x002FD67C File Offset: 0x002FBA7C
		private void UpdatePosition()
		{
			if (this.m_kMenuData != null && this.m_kCanvas != null)
			{
				Vector2 anchoredPosition;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(this.m_kCanvas.transform as RectTransform, Camera.main.WorldToScreenPoint(this.m_kMenuData.kWorldPos), this.m_kCanvas.worldCamera, ref anchoredPosition);
				RectTransform rectTransform = this.frame.transform as RectTransform;
				rectTransform.anchoredPosition = anchoredPosition;
			}
		}

		// Token: 0x0400719D RID: 29085
		private Text mLevel;

		// Token: 0x0400719E RID: 29086
		private Image mPortrait;

		// Token: 0x0400719F RID: 29087
		private Text mName;

		// Token: 0x040071A0 RID: 29088
		private Text mGuildName;

		// Token: 0x040071A1 RID: 29089
		private Text mVip;

		// Token: 0x040071A2 RID: 29090
		private Text mJobName;

		// Token: 0x040071A3 RID: 29091
		private Text mPkLevel;

		// Token: 0x040071A4 RID: 29092
		private Image mPkLevelImg;

		// Token: 0x040071A5 RID: 29093
		private Image mPkLevelNum;

		// Token: 0x040071A6 RID: 29094
		private UINumber mVipLv;

		// Token: 0x040071A7 RID: 29095
		private GameObject mMenuitem;

		// Token: 0x040071A8 RID: 29096
		private GameObject mMenuArray;

		// Token: 0x040071A9 RID: 29097
		private GameObject mVipParent;

		// Token: 0x040071AA RID: 29098
		private static MenuData ms_menuParams;

		// Token: 0x040071AC RID: 29100
		private MenuData m_kMenuData;

		// Token: 0x040071AD RID: 29101
		private GameObject m_goUIRoot;

		// Token: 0x040071AE RID: 29102
		private Canvas m_kCanvas;

		// Token: 0x040071AF RID: 29103
		private CachedObjectListManager<ActorShowMenu.MenuItemObject> m_akCachedItemObjects = new CachedObjectListManager<ActorShowMenu.MenuItemObject>();

		// Token: 0x020013FA RID: 5114
		public class MenuItemObject : CachedObject
		{
			// Token: 0x0600C633 RID: 50739 RVA: 0x002FD718 File Offset: 0x002FBB18
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.menuItem = (param[2] as MenuItem);
				this.THIS = (param[3] as ActorShowMenu);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.button = this.goLocal.GetComponent<Button>();
					this.text = Utility.FindComponent<Text>(this.goLocal, "Text", true);
					this.button.onClick.RemoveAllListeners();
					this.button.onClick.AddListener(delegate()
					{
						this.OnClickMenu();
					});
				}
				this.Enable();
				this._UpdateItem();
				if (this.button != null)
				{
					this.button.interactable = true;
					UIGray component = this.button.gameObject.GetComponent<UIGray>();
					if (component != null)
					{
						component.enabled = false;
					}
				}
			}

			// Token: 0x0600C634 RID: 50740 RVA: 0x002FD832 File Offset: 0x002FBC32
			private void OnClickMenu()
			{
				if (this.menuItem != null && this.menuItem.callback != null)
				{
					this.menuItem.callback();
				}
				this.THIS.Close(false);
			}

			// Token: 0x0600C635 RID: 50741 RVA: 0x002FD86B File Offset: 0x002FBC6B
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600C636 RID: 50742 RVA: 0x002FD873 File Offset: 0x002FBC73
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600C637 RID: 50743 RVA: 0x002FD892 File Offset: 0x002FBC92
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C638 RID: 50744 RVA: 0x002FD8B1 File Offset: 0x002FBCB1
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C639 RID: 50745 RVA: 0x002FD8BA File Offset: 0x002FBCBA
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C63A RID: 50746 RVA: 0x002FD8C3 File Offset: 0x002FBCC3
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600C63B RID: 50747 RVA: 0x002FD8C6 File Offset: 0x002FBCC6
			private void _UpdateItem()
			{
				if (this.menuItem != null)
				{
					this.text.text = this.menuItem.name;
				}
			}

			// Token: 0x0600C63C RID: 50748 RVA: 0x002FD8EC File Offset: 0x002FBCEC
			public void BtnDisable()
			{
				if (this.button != null)
				{
					this.button.onClick.RemoveAllListeners();
					this.button.interactable = false;
					UIGray uigray = this.button.gameObject.SafeAddComponent(true);
					if (uigray != null)
					{
						uigray.enabled = true;
					}
				}
			}

			// Token: 0x040071B0 RID: 29104
			protected GameObject goLocal;

			// Token: 0x040071B1 RID: 29105
			protected GameObject goParent;

			// Token: 0x040071B2 RID: 29106
			protected GameObject goPrefab;

			// Token: 0x040071B3 RID: 29107
			protected MenuItem menuItem;

			// Token: 0x040071B4 RID: 29108
			protected ActorShowMenu THIS;

			// Token: 0x040071B5 RID: 29109
			private Button button;

			// Token: 0x040071B6 RID: 29110
			private Text text;
		}
	}
}
