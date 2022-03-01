using System;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001360 RID: 4960
	public class FairDuelPlaneSkillView : MonoBehaviour
	{
		// Token: 0x0600C05D RID: 49245 RVA: 0x002D585C File Offset: 0x002D3C5C
		public void Show(FairDuelSkillFrame fairDuelHelpFrame)
		{
			if (this.mAni != null)
			{
				base.gameObject.CustomActive(true);
				this.mAni.autoKill = false;
				this.mAni.DORestart(false);
			}
			if (!this.mIsInited)
			{
				this.BindUIEvent();
			}
			this._UpdateSkillBar();
			this.mIsInited = true;
			this.mFairDuelSkillFrame = fairDuelHelpFrame;
		}

		// Token: 0x0600C05E RID: 49246 RVA: 0x002D58C3 File Offset: 0x002D3CC3
		public void Hide()
		{
			base.gameObject.CustomActive(false);
		}

		// Token: 0x0600C05F RID: 49247 RVA: 0x002D58D1 File Offset: 0x002D3CD1
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this._OnSkillBarChanged));
		}

		// Token: 0x0600C060 RID: 49248 RVA: 0x002D58EE File Offset: 0x002D3CEE
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this._OnSkillBarChanged));
		}

		// Token: 0x0600C061 RID: 49249 RVA: 0x002D590B File Offset: 0x002D3D0B
		private void _OnSkillBarChanged(UIEvent uiEvent)
		{
			this._UpdateSkillBar();
		}

		// Token: 0x0600C062 RID: 49250 RVA: 0x002D5914 File Offset: 0x002D3D14
		private void _UpdateSkillBar()
		{
			for (int i = 0; i < this.mSkillBarPosBind.Length; i++)
			{
				Toggle com = this.mSkillBarPosBind[i].GetCom<Toggle>("SkillBarElement");
				Image com2 = this.mSkillBarPosBind[i].GetCom<Image>("Icon");
				Image com3 = this.mSkillBarPosBind[i].GetCom<Image>("plus");
				Drag_Me com4 = this.mSkillBarPosBind[i].GetCom<Drag_Me>("dragme");
				Drop_Me com5 = this.mSkillBarPosBind[i].GetCom<Drop_Me>("dropme");
				int num = 0;
				for (int j = 0; j < DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count; j++)
				{
					SkillBarGrid skillBarGrid = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j];
					if (i + 1 == (int)skillBarGrid.slot)
					{
						num = (int)skillBarGrid.id;
						break;
					}
				}
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
				com4.Id = (ushort)num;
				if (com3 != null)
				{
					com3.CustomActive(tableItem == null);
				}
				if (com2 != null)
				{
					if (tableItem == null)
					{
						com2.color = new Color(1f, 1f, 1f, 0f);
					}
					else
					{
						com2.color = new Color(1f, 1f, 1f, 1f);
					}
				}
				if (!this.mIsInited)
				{
					if (com4 != null)
					{
						com4.index = i;
						com4.ResponseDrag = new Drag_Me.OnResDrag(this.DealSkillBarDrag);
					}
					if (com5 != null)
					{
						com5.slot = i;
						com5.ResponseDrop = new Drop_Me.OnResDrop(this._DealSkillBarDrop);
						com5.SetAutoReplace(false);
					}
				}
				if (tableItem != null)
				{
					if (com2 != null)
					{
						ETCImageLoader.LoadSprite(ref com2, tableItem.Icon, true);
					}
				}
			}
		}

		// Token: 0x0600C063 RID: 49251 RVA: 0x002D5B0C File Offset: 0x002D3F0C
		public void InitGiveUpDrog()
		{
			if (!this.mIsInited && this.mGiveUpDropMe != null)
			{
				for (int i = 0; i < this.mGiveUpDropMe.Length; i++)
				{
					this.mGiveUpDropMe[i].ResponseDrop = new Drop_Me.OnResDrop(this._DealSkillBarDrop);
					this.mGiveUpDropMe[i].SetAutoReplace(false);
					this.mGiveUpDropMe[i].SetHighLight(false);
				}
			}
		}

		// Token: 0x0600C064 RID: 49252 RVA: 0x002D5B80 File Offset: 0x002D3F80
		public bool DealSkillBarDrag(PointerEventData eventData, bool bIsDrag)
		{
			GameObject lastPress = eventData.lastPress;
			if (lastPress == null)
			{
				return false;
			}
			Drag_Me componentInChildren = lastPress.GetComponentInChildren<Drag_Me>();
			if (componentInChildren == null)
			{
				return false;
			}
			int i = 0;
			while (i < DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count)
			{
				if (componentInChildren.index + 1 == (int)DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].slot)
				{
					if (DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].id == 0)
					{
						return false;
					}
					break;
				}
				else
				{
					i++;
				}
			}
			if (componentInChildren.DragGroup == EDragGroup.SkillTree)
			{
				int id = (int)componentInChildren.Id;
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", id));
					return false;
				}
				if (this.mFairDuelSkillFrame != null)
				{
					byte b = this.mFairDuelSkillFrame.CalFinalShowLv((ushort)id);
					if (b <= 0)
					{
						SystemNotifyManager.SystemNotify(1015, string.Empty);
						return false;
					}
				}
				if (tableItem.TopLevelLimit <= 0 && bIsDrag)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("该技能为学习", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return false;
				}
				if (tableItem.SkillType == SkillTable.eSkillType.PASSIVE)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("被动技能无法配置到技能栏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return false;
				}
				if (tableItem.IsBuff == 1)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("Buff技能无法配置到技能栏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return false;
				}
				if (tableItem.SkillCategory == 4)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("觉醒技能不需要配置到技能栏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return false;
				}
				if (tableItem.CanUseInPVP == 3)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("skill_pvpforbid"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return false;
				}
			}
			else if (componentInChildren.DragGroup == EDragGroup.SkillPlane && DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count == 0)
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600C065 RID: 49253 RVA: 0x002D5D68 File Offset: 0x002D4168
		private void _DealSkillBarDrop(PointerEventData dragData, GameObject beDropedImgParent)
		{
			GameObject lastPress = dragData.lastPress;
			if (!this.DealSkillBarDrag(dragData, false))
			{
				return;
			}
			if (lastPress == null)
			{
				return;
			}
			Drag_Me componentInChildren = lastPress.GetComponentInChildren<Drag_Me>();
			if (componentInChildren == null)
			{
				return;
			}
			GameObject gameObject = beDropedImgParent.transform.parent.gameObject;
			if (gameObject == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Drop_Me com = component.GetCom<Drop_Me>("dropme");
			if (com == null)
			{
				return;
			}
			if (componentInChildren.index == com.slot)
			{
				return;
			}
			SkillBarGrid skillBarGrid = new SkillBarGrid();
			SkillBarGrid skillBarGrid2 = new SkillBarGrid();
			skillBarGrid.slot = (byte)(componentInChildren.index + 1);
			skillBarGrid2.slot = (byte)(com.slot + 1);
			for (int i = 0; i < DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count; i++)
			{
				if (skillBarGrid.slot == DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].slot && DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].id != 0)
				{
					skillBarGrid.id = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].id;
				}
				if (skillBarGrid2.slot == DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].slot)
				{
					skillBarGrid2.id = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[i].id;
				}
			}
			SceneExchangeSkillBarReq sceneExchangeSkillBarReq = new SceneExchangeSkillBarReq();
			if (componentInChildren.DragGroup == EDragGroup.SkillPlane && com.DropGroup == EDropGroup.SkillPlane)
			{
				if (skillBarGrid.id == 0)
				{
					return;
				}
				ushort id = skillBarGrid.id;
				skillBarGrid.id = skillBarGrid2.id;
				skillBarGrid2.id = id;
				sceneExchangeSkillBarReq.skillBars.index = 1;
				sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
				sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
				sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[2];
				sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
				sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid2;
				sceneExchangeSkillBarReq.skillBars.bar[0].grids[1] = skillBarGrid;
				sceneExchangeSkillBarReq.configType = 3;
			}
			else if (componentInChildren.DragGroup == EDragGroup.SkillPlane && com.DropGroup == EDropGroup.GiveUp)
			{
				if (skillBarGrid.id == 0)
				{
					return;
				}
				SkillBarGrid skillBarGrid3 = skillBarGrid;
				skillBarGrid3.id = 0;
				skillBarGrid3.slot = skillBarGrid.slot;
				sceneExchangeSkillBarReq.skillBars.index = 1;
				sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
				sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
				sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[1];
				sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
				sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid3;
				sceneExchangeSkillBarReq.configType = 3;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnEquipOrDropSkill, componentInChildren.Id, false, null, null);
			}
			else if (componentInChildren.DragGroup == EDragGroup.SkillTree && com.DropGroup == EDropGroup.SkillPlane)
			{
				SkillBarGrid skillBarGrid4 = new SkillBarGrid();
				skillBarGrid4.id = componentInChildren.Id;
				skillBarGrid4.slot = (byte)(com.slot + 1);
				sceneExchangeSkillBarReq.skillBars.index = 1;
				sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
				sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
				if (DataManager<SkillDataManager>.GetInstance().IsEquipFairDuelSKill((int)componentInChildren.Id))
				{
					SkillBarGrid skillBarGrid5 = new SkillBarGrid();
					for (int j = 0; j < DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar.Count; j++)
					{
						if (componentInChildren.Id == DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j].id && DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j].slot != 0)
						{
							skillBarGrid5.slot = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j].slot;
						}
						if (com.slot + 1 == (int)DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j].slot)
						{
							skillBarGrid5.id = DataManager<SkillDataManager>.GetInstance().FairDuelSkillBar[j].id;
						}
					}
					sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[2];
					sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
					sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid4;
					sceneExchangeSkillBarReq.skillBars.bar[0].grids[1] = skillBarGrid5;
					sceneExchangeSkillBarReq.configType = 3;
				}
				else
				{
					sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[1];
					sceneExchangeSkillBarReq.skillBars.bar[0].index = 1;
					sceneExchangeSkillBarReq.skillBars.bar[0].grids[0] = skillBarGrid4;
					sceneExchangeSkillBarReq.configType = 3;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnEquipOrDropSkill, componentInChildren.Id, true, null, null);
				if (!DataManager<SkillDataManager>.GetInstance().IsHaveSetFairDueSkillBar)
				{
					DataManager<SkillDataManager>.GetInstance().SendSetSkillConfigReq(1);
				}
			}
			NetManager.Instance().SendCommand<SceneExchangeSkillBarReq>(ServerType.GATE_SERVER, sceneExchangeSkillBarReq);
		}

		// Token: 0x0600C066 RID: 49254 RVA: 0x002D630C File Offset: 0x002D470C
		private void OnDestroy()
		{
			if (this.mSkillBarPosBind != null)
			{
				for (int i = 0; i < this.mSkillBarPosBind.Length; i++)
				{
					this.mSkillBarPosBind[i] = null;
				}
				this.mSkillBarPosBind = null;
			}
			if (this.mGiveUpDropMe != null)
			{
				for (int j = 0; j < this.mGiveUpDropMe.Length; j++)
				{
					this.mGiveUpDropMe[j] = null;
				}
				this.mGiveUpDropMe = null;
			}
			this.UnBindUIEvent();
			this.mAni = null;
		}

		// Token: 0x04006C9B RID: 27803
		[SerializeField]
		private ComCommonBind[] mSkillBarPosBind = new ComCommonBind[12];

		// Token: 0x04006C9C RID: 27804
		[SerializeField]
		private Drop_Me[] mGiveUpDropMe = new Drop_Me[2];

		// Token: 0x04006C9D RID: 27805
		[SerializeField]
		private DOTweenAnimation mAni;

		// Token: 0x04006C9E RID: 27806
		private bool mIsInited;

		// Token: 0x04006C9F RID: 27807
		private FairDuelSkillFrame mFairDuelSkillFrame;
	}
}
