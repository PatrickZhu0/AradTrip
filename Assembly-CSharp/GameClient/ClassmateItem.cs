using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BCD RID: 7117
	internal class ClassmateItem
	{
		// Token: 0x060116C2 RID: 71362 RVA: 0x0050D1C8 File Offset: 0x0050B5C8
		public ClassmateItem(ClassmateRelationData relationData)
		{
			this.CreateGo(relationData);
		}

		// Token: 0x17001DAF RID: 7599
		// (get) Token: 0x060116C3 RID: 71363 RVA: 0x0050D1D7 File Offset: 0x0050B5D7
		// (set) Token: 0x060116C4 RID: 71364 RVA: 0x0050D1DF File Offset: 0x0050B5DF
		public GameObject ThisGameObject
		{
			get
			{
				return this.thisGameObject;
			}
			set
			{
				this.thisGameObject = value;
			}
		}

		// Token: 0x060116C5 RID: 71365 RVA: 0x0050D1E8 File Offset: 0x0050B5E8
		private void CreateGo(ClassmateRelationData relationData)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/TAP/ClassmateItem", true, 0U);
			if (gameObject == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			this.mName = component.GetCom<Text>("Name");
			this.mIcon = component.GetCom<Image>("Icon");
			this.mOnline = component.GetCom<Text>("Online");
			this.mLevel = component.GetCom<Text>("Level");
			this.mMenu = component.GetCom<Button>("Menu");
			this.mGray = component.GetCom<UIGray>("Gray");
			this.mName.text = relationData.name;
			this.mLevel.text = relationData.level.ToString();
			this.mMenu.onClick.RemoveAllListeners();
			this.mMenu.onClick.AddListener(delegate()
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				relationMenuData.m_data = new RelationData
				{
					uid = relationData.uid,
					name = relationData.name,
					level = relationData.level,
					occu = relationData.occu,
					type = 3,
					vipLv = relationData.vipLv,
					status = relationData.status
				};
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_CLASSMATE;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowPupilRealMenu, relationMenuData, null, null, null);
			});
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)relationData.occu, string.Empty, string.Empty);
			if (null != this.mIcon)
			{
				string path = string.Empty;
				if (tableItem != null)
				{
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						path = tableItem2.IconPath;
					}
				}
				ETCImageLoader.LoadSprite(ref this.mIcon, path, true);
			}
			this.ThisGameObject = gameObject;
			this.mOnline.CustomActive(true);
			if (relationData.status == 0)
			{
				this.mOnline.text = "<color=#11EE11FF>在线</color>";
				this.mGray.SetEnable(false);
			}
			else if (relationData.status == 1)
			{
				this.mOnline.text = "<color=#E95137FF>战斗中</color>";
				this.mGray.SetEnable(false);
			}
			else if (relationData.status == 2)
			{
				this.mOnline.text = "<color=#99AABBFF>离线</color>";
				this.mGray.SetEnable(true);
			}
			else
			{
				this.mOnline.CustomActive(false);
				this.mGray.SetEnable(true);
			}
		}

		// Token: 0x060116C6 RID: 71366 RVA: 0x0050D437 File Offset: 0x0050B837
		public void DestoryGo()
		{
			Object.Destroy(this.ThisGameObject);
		}

		// Token: 0x0400B4C5 RID: 46277
		private const string ClassmateItemPath = "UIFlatten/Prefabs/TAP/ClassmateItem";

		// Token: 0x0400B4C6 RID: 46278
		private Image mIcon;

		// Token: 0x0400B4C7 RID: 46279
		private Text mName;

		// Token: 0x0400B4C8 RID: 46280
		private Text mOnline;

		// Token: 0x0400B4C9 RID: 46281
		private Text mLevel;

		// Token: 0x0400B4CA RID: 46282
		private Button mMenu;

		// Token: 0x0400B4CB RID: 46283
		private GameObject thisGameObject;

		// Token: 0x0400B4CC RID: 46284
		private UIGray mGray;
	}
}
