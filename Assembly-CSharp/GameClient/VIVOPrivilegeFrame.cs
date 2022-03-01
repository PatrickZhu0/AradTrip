using System;
using System.Collections.Generic;
using System.ComponentModel;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013BB RID: 5051
	public class VIVOPrivilegeFrame : ClientFrame
	{
		// Token: 0x0600C408 RID: 50184 RVA: 0x002F0831 File Offset: 0x002EEC31
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/VIVOPrivilegeFrame";
		}

		// Token: 0x0600C409 RID: 50185 RVA: 0x002F0838 File Offset: 0x002EEC38
		protected sealed override void _OnOpenFrame()
		{
			this._InitOPPOTABTabs();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			Singleton<GameStatisticManager>.GetInstance().DoStartVIVO(StartVIVOType.VIVOOPEN);
		}

		// Token: 0x0600C40A RID: 50186 RVA: 0x002F0874 File Offset: 0x002EEC74
		protected sealed override void _OnCloseFrame()
		{
			for (int i = 0; i < this.m_kFunctionObject.Length; i++)
			{
				this.m_kFunctionObject[i].Clear();
			}
			Array.Clear(this.m_acPrefabInits, 0, this.m_acPrefabInits.Length);
			this.m_akOPPOTABTabs.DestroyAllObjects();
			this.myprivilegeActivityList.Clear();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600C40B RID: 50187 RVA: 0x002F08F7 File Offset: 0x002EECF7
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			this.fTime += timeElapsed;
			if (this.fTime > 1f)
			{
				this.IsUpdate = false;
				this.RefreshPriviPickUpBtn();
			}
		}

		// Token: 0x0600C40C RID: 50188 RVA: 0x002F0924 File Offset: 0x002EED24
		public sealed override bool IsNeedUpdate()
		{
			return this.IsUpdate;
		}

		// Token: 0x0600C40D RID: 50189 RVA: 0x002F092C File Offset: 0x002EED2C
		private void _InitOPPOTABTabs()
		{
			this.m_eFunctionType = VIVOPrivilegeFrame.VIVOTABType.OTT_PRIVILRGR;
			GameObject gameObject = Utility.FindChild(this.frame, "VerticalFilter");
			GameObject gameObject2 = Utility.FindChild(gameObject, "Filter");
			gameObject2.CustomActive(false);
			Delegate @delegate = Delegate.CreateDelegate(typeof(VIVOPrivilegeFrame.VIVOTABTab.OnFunctionLoad), this, "_OnFunctionLoad");
			for (int i = 0; i < 1; i++)
			{
				this.m_akOPPOTABTabs.Create((VIVOPrivilegeFrame.VIVOTABType)i, new object[]
				{
					gameObject,
					gameObject2,
					i,
					this,
					@delegate
				});
				this.m_kFunctionObject[i].Clear();
				this.m_aInits[i] = false;
			}
			this.m_akOPPOTABTabs.Filter(null);
			this.m_akOPPOTABTabs.GetObject(this.m_eFunctionType).toggle.isOn = true;
		}

		// Token: 0x0600C40E RID: 50190 RVA: 0x002F09F8 File Offset: 0x002EEDF8
		private void _OnFunctionLoad(VIVOPrivilegeFrame.VIVOTABType eVIVOTABType)
		{
			if (eVIVOTABType == VIVOPrivilegeFrame.VIVOTABType.OTT_PRIVILRGR)
			{
				if (this.m_acPrefabInits[0] == '\0')
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadRes(this.m_Prefabs[0], typeof(GameObject), true, 0U).obj as GameObject;
					gameObject.name = "Privilege";
					Utility.AttachTo(gameObject, this.goChildFrame, false);
					this.m_kFunctionObject[0].Add(gameObject);
					this.m_acPrefabInits[0] = '\u0001';
				}
			}
		}

		// Token: 0x0600C40F RID: 50191 RVA: 0x002F0A7C File Offset: 0x002EEE7C
		private void OnFunctionChanged(VIVOPrivilegeFrame.VIVOTABType eVIVOTABType)
		{
			this.m_eFunctionType = eVIVOTABType;
			for (int i = 0; i < this.m_kFunctionObject.Length; i++)
			{
				if (this.m_eFunctionType != (VIVOPrivilegeFrame.VIVOTABType)i)
				{
					for (int j = 0; j < this.m_kFunctionObject[i].Count; j++)
					{
						this.m_kFunctionObject[i][j].CustomActive(false);
					}
				}
			}
			for (int k = 0; k < this.m_kFunctionObject[(int)eVIVOTABType].Count; k++)
			{
				this.m_kFunctionObject[(int)eVIVOTABType][k].CustomActive(true);
			}
			if (!this.m_aInits[(int)this.m_eFunctionType] && this.m_eFunctionType == VIVOPrivilegeFrame.VIVOTABType.OTT_PRIVILRGR)
			{
				this.m_comRewardItemList = Utility.FindComponent<ComUIListScript>(this.frame, "ChildFrame/Privilege/Items", true);
				this.gray = Utility.FindComponent<UIGray>(this.frame, "ChildFrame/Privilege/OK", true);
				this.OKText = Utility.FindComponent<Text>(this.frame, "ChildFrame/Privilege/OK/Text", true);
				this._InitRewardItemList();
				this.GetPriviItemData();
				base._AddButton("ChildFrame/Privilege/OK", new UnityAction(this.OnOKButtonClick));
			}
		}

		// Token: 0x0600C410 RID: 50192 RVA: 0x002F0B9E File Offset: 0x002EEF9E
		private void RefreshPriviPickUpBtn()
		{
			if (!this._CheckPrivilrge())
			{
				return;
			}
			this.IsStartGameFromCenter();
		}

		// Token: 0x0600C411 RID: 50193 RVA: 0x002F0BB4 File Offset: 0x002EEFB4
		public bool _CheckPrivilrge()
		{
			int num = 0;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(23000);
			if (activeData == null)
			{
				return false;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				if (activeData.akChildItems[i].status == 2)
				{
					num++;
				}
			}
			return num > 0;
		}

		// Token: 0x0600C412 RID: 50194 RVA: 0x002F0C1C File Offset: 0x002EF01C
		private void IsStartGameFromCenter()
		{
			if (SDKInterface.instance.IsStartFromGameCenter())
			{
				this.gray.enabled = false;
				this.OKText.text = "领取";
			}
			else
			{
				this.gray.enabled = false;
				this.OKText.text = "前往游戏中心";
			}
		}

		// Token: 0x0600C413 RID: 50195 RVA: 0x002F0C78 File Offset: 0x002EF078
		private void OnOKButtonClick()
		{
			if (SDKInterface.instance.IsStartFromGameCenter())
			{
				DataManager<ActiveManager>.GetInstance().SendSubmitActivity(23001, 0U);
				Singleton<GameStatisticManager>.GetInstance().DoStartVIVO(StartVIVOType.VIVOPRIVILEGE);
			}
			else
			{
				this.IsUpdate = true;
				SDKInterface.instance.OpenGameCenter();
				Singleton<GameStatisticManager>.GetInstance().DoStartVIVO(StartVIVOType.VIVOJUMPGAMECENTER);
			}
		}

		// Token: 0x0600C414 RID: 50196 RVA: 0x002F0CD0 File Offset: 0x002EF0D0
		private void GetPriviItemData()
		{
			this.myprivilegeActivityList.Clear();
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(23000);
			if (activeData == null)
			{
				Logger.LogErrorFormat("activeData is null", new object[0]);
				return;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				this.myprivilegeActivityList.Add(activeData.akChildItems[i]);
			}
			this.UpdataPrivileState();
		}

		// Token: 0x0600C415 RID: 50197 RVA: 0x002F0D48 File Offset: 0x002EF148
		private void UpdataPrivileState()
		{
			for (int i = 0; i < this.myprivilegeActivityList.Count; i++)
			{
				if (this.myprivilegeActivityList[i].status == 5)
				{
					this.gray.enabled = true;
					this.OKText.text = "已领取";
				}
				else if (this.myprivilegeActivityList[i].status == 2)
				{
					this.IsStartGameFromCenter();
				}
				else if (this.myprivilegeActivityList[i].status == 1)
				{
					this.gray.enabled = false;
					this.OKText.text = "领取";
				}
			}
		}

		// Token: 0x0600C416 RID: 50198 RVA: 0x002F0E00 File Offset: 0x002EF200
		private void _InitRewardItemList()
		{
			List<AwardItemData> items = DataManager<ActiveManager>.GetInstance().GetActiveAwards(23001);
			if (items == null)
			{
				Logger.LogErrorFormat("PrivilegeItems is null ...", new object[0]);
				return;
			}
			this.m_comRewardItemList.Initialize();
			this.m_comRewardItemList.onBindItem = ((GameObject var) => this.CreateComItem(Utility.FindGameObject(var, "itemPos", true)));
			this.m_comRewardItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (items != null && var.m_index >= 0 && var.m_index < items.Count)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(items[var.m_index].ID);
					commonItemTableDataByID.Count = items[var.m_index].Num;
					ComItem comItem = var.gameObjectBindScript as ComItem;
					comItem.Setup(commonItemTableDataByID, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = commonItemTableDataByID.GetColorName(string.Empty, false);
				}
			};
			this.m_comRewardItemList.SetElementAmount(items.Count);
		}

		// Token: 0x0600C417 RID: 50199 RVA: 0x002F0E9A File Offset: 0x002EF29A
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this.GetPriviItemData();
		}

		// Token: 0x0600C418 RID: 50200 RVA: 0x002F0EA2 File Offset: 0x002EF2A2
		[UIEventHandle("close")]
		private void OnCloseClick()
		{
			this.frameMgr.CloseFrame<VIVOPrivilegeFrame>(this, false);
		}

		// Token: 0x04006F8F RID: 28559
		private VIVOPrivilegeFrame.VIVOTABType m_eFunctionType;

		// Token: 0x04006F90 RID: 28560
		private const int m_iConfigPrefabCount = 1;

		// Token: 0x04006F91 RID: 28561
		private string[] m_Prefabs = new string[]
		{
			"UIFlatten/Prefabs/Activity/VIVOPrivilege"
		};

		// Token: 0x04006F92 RID: 28562
		private char[] m_acPrefabInits = new char[1];

		// Token: 0x04006F93 RID: 28563
		private List<GameObject>[] m_kFunctionObject = new List<GameObject>[]
		{
			new List<GameObject>()
		};

		// Token: 0x04006F94 RID: 28564
		private bool[] m_aInits = new bool[1];

		// Token: 0x04006F95 RID: 28565
		[UIObject("ChildFrame")]
		private GameObject goChildFrame;

		// Token: 0x04006F96 RID: 28566
		private CachedObjectDicManager<VIVOPrivilegeFrame.VIVOTABType, VIVOPrivilegeFrame.VIVOTABTab> m_akOPPOTABTabs = new CachedObjectDicManager<VIVOPrivilegeFrame.VIVOTABType, VIVOPrivilegeFrame.VIVOTABTab>();

		// Token: 0x04006F97 RID: 28567
		public const int privilegeRwerdID = 23001;

		// Token: 0x04006F98 RID: 28568
		public const int privilegeID = 23000;

		// Token: 0x04006F99 RID: 28569
		private bool IsUpdate;

		// Token: 0x04006F9A RID: 28570
		private float fTime;

		// Token: 0x04006F9B RID: 28571
		private ComUIListScript m_comRewardItemList;

		// Token: 0x04006F9C RID: 28572
		private UIGray gray;

		// Token: 0x04006F9D RID: 28573
		private Text OKText;

		// Token: 0x04006F9E RID: 28574
		private List<ActiveManager.ActivityData> myprivilegeActivityList = new List<ActiveManager.ActivityData>();

		// Token: 0x020013BC RID: 5052
		public enum VIVOTABType
		{
			// Token: 0x04006FA0 RID: 28576
			[Description("启动特权")]
			OTT_PRIVILRGR,
			// Token: 0x04006FA1 RID: 28577
			OTT_COUNT
		}

		// Token: 0x020013BD RID: 5053
		private class VIVOTABTab : CachedObject
		{
			// Token: 0x17001BDE RID: 7134
			// (get) Token: 0x0600C41A RID: 50202 RVA: 0x002F0EB9 File Offset: 0x002EF2B9
			public VIVOPrivilegeFrame.VIVOTABType VIVOTABType
			{
				get
				{
					return this.eVIVOTABType;
				}
			}

			// Token: 0x0600C41B RID: 50203 RVA: 0x002F0EC4 File Offset: 0x002EF2C4
			public sealed override void OnDestroy()
			{
				this.goLocal = null;
				this.goPrefab = null;
				this.goParent = null;
				this.frame = null;
				this.labelMark = null;
				this.labelCheckMark = null;
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle = null;
				this.onFunctionLoad = null;
				this.functionRedBinder = null;
			}

			// Token: 0x0600C41C RID: 50204 RVA: 0x002F0F20 File Offset: 0x002EF320
			public sealed override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.eVIVOTABType = (VIVOPrivilegeFrame.VIVOTABType)param[2];
				this.frame = (VIVOPrivilegeFrame)param[3];
				this.onFunctionLoad = (param[4] as VIVOPrivilegeFrame.VIVOTABTab.OnFunctionLoad);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.toggle = this.goLocal.GetComponent<Toggle>();
					this.toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this._OnSelected();
						}
					});
					string enumDescription = Utility.GetEnumDescription<VIVOPrivilegeFrame.VIVOTABType>(this.eVIVOTABType);
					this.labelMark = Utility.FindComponent<Text>(this.goLocal, "Text", true);
					this.labelMark.text = enumDescription;
					this.labelCheckMark = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
					this.labelCheckMark.text = enumDescription;
					this.functionRedBinder = this.goLocal.GetComponent<OPPOFunctionRedBinder>();
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x0600C41D RID: 50205 RVA: 0x002F1043 File Offset: 0x002EF443
			public sealed override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C41E RID: 50206 RVA: 0x002F1062 File Offset: 0x002EF462
			public sealed override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C41F RID: 50207 RVA: 0x002F106B File Offset: 0x002EF46B
			public sealed override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600C420 RID: 50208 RVA: 0x002F108A File Offset: 0x002EF48A
			public sealed override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x0600C421 RID: 50209 RVA: 0x002F1092 File Offset: 0x002EF492
			public sealed override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C422 RID: 50210 RVA: 0x002F10B1 File Offset: 0x002EF4B1
			private void _Update()
			{
				if (this.eVIVOTABType == VIVOPrivilegeFrame.VIVOTABType.OTT_PRIVILRGR)
				{
					this.functionRedBinder.AddCheckFunction(OPPOFunctionRedBinder.OPPOFunctionType.OFT_PRIVILRGR);
				}
				else
				{
					this.functionRedBinder.ClearCheckFunctions();
				}
			}

			// Token: 0x0600C423 RID: 50211 RVA: 0x002F10DA File Offset: 0x002EF4DA
			private void _OnSelected()
			{
				if (this.onFunctionLoad != null)
				{
					this.onFunctionLoad(this.eVIVOTABType);
					this.onFunctionLoad = null;
				}
				this.frame.OnFunctionChanged(this.eVIVOTABType);
			}

			// Token: 0x04006FA2 RID: 28578
			private GameObject goLocal;

			// Token: 0x04006FA3 RID: 28579
			private GameObject goPrefab;

			// Token: 0x04006FA4 RID: 28580
			private GameObject goParent;

			// Token: 0x04006FA5 RID: 28581
			private VIVOPrivilegeFrame.VIVOTABType eVIVOTABType;

			// Token: 0x04006FA6 RID: 28582
			private VIVOPrivilegeFrame frame;

			// Token: 0x04006FA7 RID: 28583
			public Toggle toggle;

			// Token: 0x04006FA8 RID: 28584
			private Text labelMark;

			// Token: 0x04006FA9 RID: 28585
			private Text labelCheckMark;

			// Token: 0x04006FAA RID: 28586
			public VIVOPrivilegeFrame.VIVOTABTab.OnFunctionLoad onFunctionLoad;

			// Token: 0x04006FAB RID: 28587
			private OPPOFunctionRedBinder functionRedBinder;

			// Token: 0x020013BE RID: 5054
			// (Invoke) Token: 0x0600C426 RID: 50214
			public delegate void OnFunctionLoad(VIVOPrivilegeFrame.VIVOTABType eOPPOTABType);
		}
	}
}
