using System;
using System.Collections;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001ADF RID: 6879
	internal class ComLinkFrame : ClientFrame
	{
		// Token: 0x06010E39 RID: 69177 RVA: 0x004D27DC File Offset: 0x004D0BDC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/ComLinkFrame";
		}

		// Token: 0x06010E3A RID: 69178 RVA: 0x004D27E3 File Offset: 0x004D0BE3
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as ComLinkFrame.ComLinkFrameData);
			this._Initialize();
		}

		// Token: 0x06010E3B RID: 69179 RVA: 0x004D27FC File Offset: 0x004D0BFC
		private void _Initialize()
		{
			this.m_kDesc = Utility.FindComponent<Text>(this.frame, "back/BlankDesc/Desc", true);
			Utility.FindComponent<Button>(this.frame, "backclose", true).onClick.AddListener(delegate()
			{
				this.frameMgr.CloseFrame<ComLinkFrame>(this, false);
			});
			this.comItem = base.CreateComItem(Utility.FindChild(this.frame, "back/BlankTitle/ItemParent"));
			if (this.data != null)
			{
				this.m_kDesc.CustomActive(this.data.bNotEnough);
				this.goParent = Utility.FindChild(this.frame, "back/Scrollview/ViewPort/Content");
				this.goPrefab = Utility.FindChild(this.goParent, "Item");
				GameObject gameObject = Utility.FindChild(this.goParent, "EquipItem");
				this.goPrefab.CustomActive(false);
				gameObject.CustomActive(false);
				this.m_akLinkItemObjects.RecycleAllObject();
				this.m_akEquipLinkItemObjects.RecycleAllObject();
				this.desc = Utility.FindComponent<Text>(this.frame, "back/Name", true);
				if (this.data.item != null)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.data.item.ID);
					this.comItem.Setup(commonItemTableDataByID, null);
					if (commonItemTableDataByID != null)
					{
						this.comItemName.text = commonItemTableDataByID.GetColorName(string.Empty, false);
					}
				}
				else
				{
					this.comItem.Setup(null, null);
					this.comItemName.text = string.Empty;
					if (this.data.linkItem != null)
					{
						ItemData commonItemTableDataByID2 = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.data.linkItem.ItemId);
						if (commonItemTableDataByID2 != null)
						{
							this.comItem.Setup(commonItemTableDataByID2, null);
							this.comItemName.text = commonItemTableDataByID2.GetColorName(string.Empty, false);
						}
					}
				}
				if (this.data.item != null)
				{
					bool flag = DataManager<EquipHandbookDataManager>.GetInstance().EquipHandbookAttachedTableIsFindItemID(this.data.item.ID);
					if (flag)
					{
						int num = 0;
						IEnumerator sourceInfos = DataManager<ItemSourceInfoTableManager>.GetInstance().GetSourceInfos(this.data.item.ID);
						while (sourceInfos.MoveNext())
						{
							object obj = sourceInfos.Current;
							ISourceInfo sourceInfo = obj as ISourceInfo;
							if (sourceInfo != null)
							{
								this.m_akEquipLinkItemObjects.Create(num, new object[]
								{
									this.goParent,
									gameObject,
									sourceInfo,
									this
								});
								num++;
							}
						}
					}
					else
					{
						this.CreatLinkItemObj();
					}
				}
				else
				{
					this.CreatLinkItemObj();
				}
				if (!string.IsNullOrEmpty(this.data.titleContent))
				{
					this.mTitleTxt.SafeSetText(this.data.titleContent);
				}
			}
			else
			{
				int num2 = 1;
				float num3 = (float)(num2 - 1) * 14f + (float)num2 * 150f;
			}
		}

		// Token: 0x06010E3C RID: 69180 RVA: 0x004D2AD8 File Offset: 0x004D0ED8
		private void CreatLinkItemObj()
		{
			List<object> list = ListPool<object>.Get();
			try
			{
				if (this.data.bOrgLink && this.data.item != null)
				{
					this.desc.text = this.data.title;
					for (int i = 0; i < this.data.item.ComeLink.Count; i++)
					{
						AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(this.data.item.ComeLink[i], string.Empty, string.Empty);
						if (tableItem != null)
						{
							list.Add(tableItem);
						}
						else
						{
							Logger.LogErrorFormat("can not find linkItem with id = {0} in table AcquiredMethodTable , to HXL !!!", new object[]
							{
								this.data.item.ComeLink[i]
							});
						}
					}
				}
				else if (!this.data.bOrgLink && this.data.linkItem != null)
				{
					this.desc.text = this.data.title;
					for (int j = 0; j < this.data.linkItem.ReLinks.Count; j++)
					{
						AcquiredMethodTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(this.data.linkItem.ReLinks[j], string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							list.Add(tableItem2);
						}
						else
						{
							Logger.LogErrorFormat("relinkerror id = {0} belong to id is {1}", new object[]
							{
								this.data.linkItem.ReLinks[j],
								this.data.linkItem.ID
							});
						}
					}
				}
				int num = IntMath.Min(list.Count, 4);
				if (num == 0)
				{
					num = 1;
				}
				if (num != 4)
				{
					float num2 = (float)(num - 1) * 14f + (float)num * 150f;
				}
				for (int k = 0; k < list.Count; k++)
				{
					AcquiredMethodTable acquiredMethodTable = list[k] as AcquiredMethodTable;
					this.m_akLinkItemObjects.Create(acquiredMethodTable.ID, new object[]
					{
						this.goParent,
						this.goPrefab,
						acquiredMethodTable,
						this,
						this.data.onClick
					});
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat(ex.ToString(), new object[0]);
			}
			ListPool<object>.Release(list);
		}

		// Token: 0x06010E3D RID: 69181 RVA: 0x004D2D84 File Offset: 0x004D1184
		protected sealed override void _OnCloseFrame()
		{
			if (this.data.onClick != null)
			{
				this.data.onClick = null;
			}
			this.data = null;
			this.m_akLinkItemObjects.DestroyAllObjects();
			this.m_akEquipLinkItemObjects.DestroyAllObjects();
		}

		// Token: 0x0400AD79 RID: 44409
		private ComLinkFrame.ComLinkFrameData data;

		// Token: 0x0400AD7A RID: 44410
		private Text m_kDesc;

		// Token: 0x0400AD7B RID: 44411
		private ComItem comItem;

		// Token: 0x0400AD7C RID: 44412
		private GameObject goParent;

		// Token: 0x0400AD7D RID: 44413
		private GameObject goPrefab;

		// Token: 0x0400AD7E RID: 44414
		private Text desc;

		// Token: 0x0400AD7F RID: 44415
		[UIControl("back/BlankTitle/Name", typeof(Text), 0)]
		private Text comItemName;

		// Token: 0x0400AD80 RID: 44416
		[UIControl("back/Scrollview/ViewPort", typeof(LayoutElement), 0)]
		private LayoutElement comViewPortLayoutElement;

		// Token: 0x0400AD81 RID: 44417
		[UIControl("back/FixTitle", typeof(Text), 0)]
		private Text mTitleTxt;

		// Token: 0x0400AD82 RID: 44418
		private CachedObjectDicManager<int, ComLinkFrame.LinkItemObject> m_akLinkItemObjects = new CachedObjectDicManager<int, ComLinkFrame.LinkItemObject>();

		// Token: 0x0400AD83 RID: 44419
		private CachedObjectDicManager<int, ComLinkFrame.EquipLinkItemObject> m_akEquipLinkItemObjects = new CachedObjectDicManager<int, ComLinkFrame.EquipLinkItemObject>();

		// Token: 0x02001AE0 RID: 6880
		// (Invoke) Token: 0x06010E40 RID: 69184
		public delegate void OnClick();

		// Token: 0x02001AE1 RID: 6881
		public class ComLinkFrameData
		{
			// Token: 0x0400AD84 RID: 44420
			public ItemTable item;

			// Token: 0x0400AD85 RID: 44421
			public bool bOrgLink;

			// Token: 0x0400AD86 RID: 44422
			public AcquiredMethodTable linkItem;

			// Token: 0x0400AD87 RID: 44423
			public string title;

			// Token: 0x0400AD88 RID: 44424
			public ComLinkFrame.OnClick onClick;

			// Token: 0x0400AD89 RID: 44425
			public bool bNotEnough;

			// Token: 0x0400AD8A RID: 44426
			public string titleContent;
		}

		// Token: 0x02001AE2 RID: 6882
		private class EquipLinkItemObject : CachedObject
		{
			// Token: 0x06010E45 RID: 69189 RVA: 0x004D2DDE File Offset: 0x004D11DE
			public sealed override void OnDestroy()
			{
				this.Button.onClick.RemoveAllListeners();
				this.Button = null;
				this.THIS = null;
				this.info = null;
			}

			// Token: 0x06010E46 RID: 69190 RVA: 0x004D2E08 File Offset: 0x004D1208
			public sealed override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.info = (param[2] as ISourceInfo);
				this.THIS = (param[3] as ComLinkFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					ComCommonBind component = this.goLocal.GetComponent<ComCommonBind>();
					if (component != null)
					{
						this.Name = component.GetCom<Text>("Name");
						this.Button = component.GetCom<Button>("Button");
						this.Button.onClick.RemoveAllListeners();
						this.Button.onClick.AddListener(delegate()
						{
							if (ItemSourceInfoUtility.IsLinkFunctionOpen(this.info))
							{
								DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(this.linkString, null, false);
								this.THIS.frameMgr.CloseFrame<ComLinkFrame>(this.THIS, false);
							}
							else
							{
								SystemNotifyManager.SystemNotify(1013, string.Empty);
							}
						});
					}
					this.linkInfo = DataManager<ItemSourceInfoTableManager>.GetInstance().GetSourceInfoName(this.info);
					this.linkString = DataManager<ItemSourceInfoTableManager>.GetInstance().GetSourceInfoLink(this.info);
				}
				this.Enable();
				this.SetAsLastSibling();
				this._Update();
			}

			// Token: 0x06010E47 RID: 69191 RVA: 0x004D2F25 File Offset: 0x004D1325
			public sealed override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x06010E48 RID: 69192 RVA: 0x004D2F48 File Offset: 0x004D1348
			public sealed override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06010E49 RID: 69193 RVA: 0x004D2F67 File Offset: 0x004D1367
			public sealed override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06010E4A RID: 69194 RVA: 0x004D2F70 File Offset: 0x004D1370
			public sealed override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x06010E4B RID: 69195 RVA: 0x004D2F78 File Offset: 0x004D1378
			public sealed override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x06010E4C RID: 69196 RVA: 0x004D2F97 File Offset: 0x004D1397
			public sealed override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06010E4D RID: 69197 RVA: 0x004D2FB6 File Offset: 0x004D13B6
			public sealed override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x06010E4E RID: 69198 RVA: 0x004D2FB9 File Offset: 0x004D13B9
			private void _Update()
			{
				this.Name.text = this.linkInfo;
			}

			// Token: 0x0400AD8B RID: 44427
			private GameObject goLocal;

			// Token: 0x0400AD8C RID: 44428
			private GameObject goPrefab;

			// Token: 0x0400AD8D RID: 44429
			private GameObject goParent;

			// Token: 0x0400AD8E RID: 44430
			private ISourceInfo info;

			// Token: 0x0400AD8F RID: 44431
			private ComLinkFrame THIS;

			// Token: 0x0400AD90 RID: 44432
			private Text Name;

			// Token: 0x0400AD91 RID: 44433
			private Button Button;

			// Token: 0x0400AD92 RID: 44434
			private string linkInfo;

			// Token: 0x0400AD93 RID: 44435
			private string linkString;
		}

		// Token: 0x02001AE3 RID: 6883
		private class LinkItemObject : CachedObject
		{
			// Token: 0x06010E51 RID: 69201 RVA: 0x004D302E File Offset: 0x004D142E
			public sealed override void OnDestroy()
			{
				this.Button.onClick.RemoveAllListeners();
				this.Button = null;
				this.onClick = null;
				this.linkItem = null;
				this.THIS = null;
			}

			// Token: 0x06010E52 RID: 69202 RVA: 0x004D305C File Offset: 0x004D145C
			public sealed override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.linkItem = (param[2] as AcquiredMethodTable);
				this.THIS = (param[3] as ComLinkFrame);
				this.onClick = (param[4] as ComLinkFrame.OnClick);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.Name = Utility.FindComponent<Text>(this.goLocal, "Name", true);
					this.LinkZone = Utility.FindComponent<Text>(this.goLocal, "LinkZone", true);
					this.Button = Utility.FindComponent<Button>(this.goLocal, "Button", true);
					this.Desc = Utility.FindComponent<Text>(this.goLocal, "Button/Text", true);
					this.Button.onClick.RemoveAllListeners();
					this.Button.CustomActive(true);
					this.Button.onClick.RemoveAllListeners();
					this.Button.onClick.AddListener(new UnityAction(this.OnClick));
					this.gray = Utility.FindComponent<UIGray>(this.goLocal, "Button", true);
				}
				this.Enable();
				this.SetAsLastSibling();
				this._Update();
			}

			// Token: 0x06010E53 RID: 69203 RVA: 0x004D31B0 File Offset: 0x004D15B0
			public sealed override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x06010E54 RID: 69204 RVA: 0x004D31D3 File Offset: 0x004D15D3
			public sealed override void OnRecycle()
			{
				if (this.onClick != null)
				{
					this.onClick = null;
				}
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06010E55 RID: 69205 RVA: 0x004D3204 File Offset: 0x004D1604
			public sealed override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06010E56 RID: 69206 RVA: 0x004D320D File Offset: 0x004D160D
			public sealed override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x06010E57 RID: 69207 RVA: 0x004D3215 File Offset: 0x004D1615
			public sealed override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x06010E58 RID: 69208 RVA: 0x004D3234 File Offset: 0x004D1634
			public sealed override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06010E59 RID: 69209 RVA: 0x004D3253 File Offset: 0x004D1653
			public sealed override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x06010E5A RID: 69210 RVA: 0x004D3256 File Offset: 0x004D1656
			public bool IsOpened()
			{
				return this.linkItem != null && Utility.IsFunctionCanUnlock((FunctionUnLock.eFuncType)this.linkItem.FuncitonID);
			}

			// Token: 0x06010E5B RID: 69211 RVA: 0x004D3280 File Offset: 0x004D1680
			private void _Update()
			{
				if (this.linkItem != null)
				{
					bool flag = this.IsOpened();
					this.Name.text = this.linkItem.Name;
					this.Desc.text = this.linkItem.ActionDesc;
					this.LinkZone.text = this.linkItem.LinkZone;
					this.Button.enabled = (this.linkItem.IsLink != 0 && flag);
					this.Button.CustomActive(this.linkItem.IsLink != 0 && flag);
					this.gray.enabled = !flag;
				}
			}

			// Token: 0x06010E5C RID: 69212 RVA: 0x004D3330 File Offset: 0x004D1730
			private void OnClick()
			{
				if (this.linkItem != null && this.linkItem.IsLink != 0)
				{
					if (this.linkItem.FuncitonID == 93 && DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv == 0U)
					{
						bool flag = false;
						bool flag2 = false;
						if (DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID > 0U)
						{
							flag = true;
						}
						else
						{
							flag2 = true;
						}
						if (flag)
						{
							FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(93, string.Empty, string.Empty);
							if (tableItem != null)
							{
								SystemNotifyManager.SystemNotify(tableItem.CommDescID, string.Empty);
							}
						}
						else if (flag2)
						{
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_not_open_tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						}
						return;
					}
					if (this.linkItem.ID == 283)
					{
						DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(this.linkItem.LinkInfo, null, true);
					}
					else
					{
						DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(this.linkItem.LinkInfo, null, false);
					}
					this.THIS.frameMgr.CloseFrame<ComLinkFrame>(this.THIS, false);
					if (this.onClick != null)
					{
						this.onClick();
					}
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
					}
				}
			}

			// Token: 0x0400AD94 RID: 44436
			private GameObject goLocal;

			// Token: 0x0400AD95 RID: 44437
			private GameObject goPrefab;

			// Token: 0x0400AD96 RID: 44438
			private GameObject goParent;

			// Token: 0x0400AD97 RID: 44439
			private AcquiredMethodTable linkItem;

			// Token: 0x0400AD98 RID: 44440
			private ComLinkFrame THIS;

			// Token: 0x0400AD99 RID: 44441
			private ComLinkFrame.OnClick onClick;

			// Token: 0x0400AD9A RID: 44442
			private Text Name;

			// Token: 0x0400AD9B RID: 44443
			private Text LinkZone;

			// Token: 0x0400AD9C RID: 44444
			private Button Button;

			// Token: 0x0400AD9D RID: 44445
			private UIGray gray;

			// Token: 0x0400AD9E RID: 44446
			private Text Desc;

			// Token: 0x0400AD9F RID: 44447
			private Text Probility;

			// Token: 0x0400ADA0 RID: 44448
			private Text UnLockHint;

			// Token: 0x0400ADA1 RID: 44449
			private GameObject goContent;
		}
	}
}
