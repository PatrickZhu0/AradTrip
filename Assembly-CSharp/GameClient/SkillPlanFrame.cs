using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AAC RID: 6828
	public class SkillPlanFrame : ClientFrame
	{
		// Token: 0x06010C1D RID: 68637 RVA: 0x004C176C File Offset: 0x004BFB6C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Skill/SkillPlanFrame";
		}

		// Token: 0x06010C1E RID: 68638 RVA: 0x004C1774 File Offset: 0x004BFB74
		private void ClearData()
		{
			for (int i = 0; i < SkillPlanFrame.skillBarToggle.Length; i++)
			{
				SkillPlanFrame.skillBarToggle[i].onValueChanged.RemoveAllListeners();
			}
			SkillPlanFrame.bIsAddSkillBarState = false;
			SkillPlanFrame.CurSelUseBtnIdx = 0;
		}

		// Token: 0x06010C1F RID: 68639 RVA: 0x004C17B6 File Offset: 0x004BFBB6
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x06010C20 RID: 68640 RVA: 0x004C17C4 File Offset: 0x004BFBC4
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			SkillPlanFrame.UpdateSkillBar();
			this.UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillPlanClose, null, null, null, null);
		}

		// Token: 0x06010C21 RID: 68641 RVA: 0x004C17EA File Offset: 0x004BFBEA
		private void _CloseFrame()
		{
			this.frameMgr.CloseFrame<SkillPlanFrame>(this, false);
		}

		// Token: 0x06010C22 RID: 68642 RVA: 0x004C17F9 File Offset: 0x004BFBF9
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateCurUseSkillBar, new ClientEventSystem.UIEventHandler(this.OnUpdateCurUseSkillBar));
		}

		// Token: 0x06010C23 RID: 68643 RVA: 0x004C1816 File Offset: 0x004BFC16
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateCurUseSkillBar, new ClientEventSystem.UIEventHandler(this.OnUpdateCurUseSkillBar));
		}

		// Token: 0x06010C24 RID: 68644 RVA: 0x004C1833 File Offset: 0x004BFC33
		private void OnUpdateCurUseSkillBar(UIEvent iEvent)
		{
			this.TryUpdateSkillBarInterface();
		}

		// Token: 0x06010C25 RID: 68645 RVA: 0x004C183B File Offset: 0x004BFC3B
		private void OnUseSkill(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
		}

		// Token: 0x06010C26 RID: 68646 RVA: 0x004C184B File Offset: 0x004BFC4B
		private void DeleteSkillBarItem(int iIndex)
		{
			SkillPlanFrame.UpdateSkillBarChanged(SkillBarSource.FromGiveUpSelSkill, -1, (int)SkillPlanFrame.CurSelUseBtnIdx);
			SkillPlanFrame.skillBarToggle[(int)SkillPlanFrame.CurSelUseBtnIdx].isOn = false;
			SkillPlanFrame.bIsAddSkillBarState = false;
			SkillPlanFrame.SendSavePlan();
		}

		// Token: 0x06010C27 RID: 68647 RVA: 0x004C1878 File Offset: 0x004BFC78
		public static void SendSavePlan()
		{
			NetManager netManager = NetManager.Instance();
			SkillBarGrid[] array = SkillPlanFrame.CalSkillBarChange();
			if (array.Length > 0)
			{
				SceneExchangeSkillBarReq sceneExchangeSkillBarReq = new SceneExchangeSkillBarReq();
				byte index;
				byte configType;
				if (DataManager<SkillDataManager>.GetInstance().isPve())
				{
					index = (byte)(DataManager<SkillDataManager>.GetInstance().CurPVESKillPage + 1);
					configType = 1;
				}
				else
				{
					index = (byte)(DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage + 1);
					configType = 2;
				}
				sceneExchangeSkillBarReq.skillBars.index = index;
				sceneExchangeSkillBarReq.skillBars.bar = new SkillBar[1];
				sceneExchangeSkillBarReq.skillBars.bar[0] = new SkillBar();
				sceneExchangeSkillBarReq.skillBars.bar[0].grids = new SkillBarGrid[array.Length];
				sceneExchangeSkillBarReq.skillBars.bar[0].grids = array;
				sceneExchangeSkillBarReq.configType = configType;
				sceneExchangeSkillBarReq.skillBars.bar[0].index = index;
				netManager.SendCommand<SceneExchangeSkillBarReq>(ServerType.GATE_SERVER, sceneExchangeSkillBarReq);
			}
		}

		// Token: 0x06010C28 RID: 68648 RVA: 0x004C195C File Offset: 0x004BFD5C
		private void InitInterface()
		{
			this.CreateSkillTreePreFerb();
			this.TryUpdateSkillBarInterface();
			this.InitDropBind();
			if (this.mPassiveAwakeSkillItem != null)
			{
				this.mPassiveAwakeSkillItem.Show();
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.JobType == 0)
			{
				JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					this.mPreJob.text = tableItem2.Name;
					this.mPreJob.gameObject.CustomActive(true);
					this.mPreJobRoot.CustomActive(true);
				}
			}
		}

		// Token: 0x06010C29 RID: 68649 RVA: 0x004C1A1C File Offset: 0x004BFE1C
		private void CreateSkillTreePreFerb()
		{
			string path = "root";
			GameObject gameObject = Utility.FindGameObject(this.frame, path, true);
			if (gameObject == null)
			{
				Logger.LogError("can't find componnent : SkillPlanFrame/root");
				return;
			}
			RectTransform[] componentsInChildren = gameObject.GetComponentsInChildren<RectTransform>();
			int num = 0;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == string.Format("BarPos{0}", num + 1))
				{
					GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.SkillBarElementPath, true, 0U);
					if (gameObject2 == null)
					{
						Logger.LogError("can't create obj SkillTBarElement");
						return;
					}
					Utility.AttachTo(gameObject2, componentsInChildren[i].gameObject, false);
					SkillPlanFrame.skillBarToggle[num] = gameObject2.GetComponentInChildren<Toggle>();
					SkillPlanFrame.skillBarOpenLv[num] = gameObject2.GetComponentInChildren<Text>();
					Image[] componentsInChildren2 = gameObject2.GetComponentsInChildren<Image>();
					gameObject2.GetComponentInChildren<Toggle>().group = gameObject.GetComponentInChildren<ToggleGroup>();
					for (int j = 0; j < componentsInChildren2.Length; j++)
					{
						if (componentsInChildren2[j].name == "Icon")
						{
							SkillPlanFrame.skillBarImage[num] = componentsInChildren2[j];
						}
						else if (componentsInChildren2[j].name == "plus")
						{
							SkillPlanFrame.skillBarPlus[num] = componentsInChildren2[j];
						}
						else if (componentsInChildren2[j].name == "lock")
						{
							SkillPlanFrame.skillBarLock[num] = componentsInChildren2[j];
						}
					}
					num++;
				}
			}
			for (int k = 0; k < SkillPlanFrame.skillBarToggle.Length; k++)
			{
				SkillPlanFrame.skillBarToggle[k].onValueChanged.RemoveAllListeners();
				int index = k;
				SkillPlanFrame.skillBarToggle[k].onValueChanged.AddListener(delegate(bool value)
				{
					this.OnUseSkill(index, value);
				});
			}
		}

		// Token: 0x06010C2A RID: 68650 RVA: 0x004C1C0C File Offset: 0x004C000C
		private static void UpdateSkillBarInterface(List<SkillBarGrid> skillBar)
		{
			for (int i = 0; i < SkillPlanFrame.skillBarToggle.Length; i++)
			{
				if (i < SkillPlanFrame.UnLockSkillBarNum)
				{
					bool flag = false;
					for (int j = 0; j < skillBar.Count; j++)
					{
						SkillBarGrid skillBarGrid = skillBar[j];
						if ((int)skillBarGrid.slot == i + 1)
						{
							SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)skillBarGrid.id, string.Empty, string.Empty);
							if (tableItem != null)
							{
								ETCImageLoader.LoadSprite(ref SkillPlanFrame.skillBarImage[(int)(skillBarGrid.slot - 1)], tableItem.Icon, true);
								SkillPlanFrame.skillBarImage[i].color = new Color(1f, 1f, 1f, 1f);
								SkillPlanFrame.skillBarPlus[i].gameObject.SetActive(false);
								flag = true;
								break;
							}
							Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", skillBarGrid.id));
						}
					}
					if (!flag)
					{
						ETCImageLoader.LoadSprite(ref SkillPlanFrame.skillBarImage[i], SkillPlanFrame.defaultIconPath, true);
						SkillPlanFrame.skillBarImage[i].color = new Color(1f, 1f, 1f, 0f);
						SkillPlanFrame.skillBarPlus[i].gameObject.SetActive(true);
					}
					SkillPlanFrame.skillBarLock[i].gameObject.SetActive(false);
					SkillPlanFrame.skillBarOpenLv[i].gameObject.SetActive(false);
					SkillPlanFrame.skillBarImage[i].gameObject.SetActive(true);
					SkillPlanFrame.skillBarToggle[i].GetComponent<Toggle>().interactable = true;
				}
				else
				{
					SkillPlanFrame.skillBarImage[i].gameObject.SetActive(false);
					SkillPlanFrame.skillBarPlus[i].gameObject.SetActive(false);
					SkillPlanFrame.skillBarLock[i].gameObject.SetActive(true);
					if (i == 11)
					{
						SkillPlanFrame.skillBarOpenLv[i].text = TR.Value("skill_task_skill_des");
					}
					else
					{
						SkillPlanFrame.skillBarOpenLv[i].text = string.Format("{0}级开放", Singleton<TableManager>.GetInstance().GetLevelBySkillBarIndex(i + 1));
					}
					SkillPlanFrame.skillBarOpenLv[i].gameObject.SetActive(true);
					SkillPlanFrame.skillBarToggle[i].GetComponent<Toggle>().interactable = false;
				}
			}
		}

		// Token: 0x06010C2B RID: 68651 RVA: 0x004C1E54 File Offset: 0x004C0254
		public static bool UpdateSkillBarChanged(SkillBarSource fromSource, int iTargetIndex, int iSourceIndex)
		{
			List<SkillBarGrid> curSelSkillBar = SkillPlanFrame.GetCurSelSkillBar();
			if (curSelSkillBar == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("Skill Solution is null", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			for (int i = 0; i < curSelSkillBar.Count; i++)
			{
				Singleton<GameStatisticManager>.GetInstance().DoStatSkillPanel(StatSkillPanelType.SKILL_CONFIG, (int)curSelSkillBar[i].id, 0, (int)curSelSkillBar[i].slot);
			}
			if (fromSource == SkillBarSource.FromSkillTree)
			{
				int num = -1;
				if (!DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill.TryGetValue(iTargetIndex + 1, out num) || num == -1)
				{
					return false;
				}
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", num));
					return false;
				}
				if (tableItem.SkillType == SkillTable.eSkillType.PASSIVE || tableItem.IsQTE != 0)
				{
					SystemNotifyManager.SystemNotify(1014, string.Empty);
					return false;
				}
				if (tableItem.IsBuff == 1)
				{
					SystemNotifyManager.SystemNotify(1067, string.Empty);
					return false;
				}
				byte b = SkillTreeFrame.CalFinalShowLv((ushort)num);
				if (b <= 0)
				{
					SystemNotifyManager.SystemNotify(1015, string.Empty);
					return false;
				}
				int num2 = -1;
				for (int j = 0; j < curSelSkillBar.Count; j++)
				{
					if ((int)curSelSkillBar[j].id == num)
					{
						num2 = j;
						break;
					}
				}
				int id = 0;
				for (int k = 0; k < curSelSkillBar.Count; k++)
				{
					if (curSelSkillBar[k].slot == (byte)(iSourceIndex + 1))
					{
						id = (int)curSelSkillBar[k].id;
						break;
					}
				}
				SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.IsPreJob == 1)
				{
					JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
					if (tableItem3 == null)
					{
						return false;
					}
					if (tableItem3.JobType == 0)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("转职前无法配置预转职技能栏位", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return false;
					}
				}
				bool flag = false;
				int num3 = -1;
				int l = 0;
				while (l < curSelSkillBar.Count)
				{
					if (curSelSkillBar[l].slot == (byte)(iSourceIndex + 1))
					{
						if (curSelSkillBar[l].id != (ushort)num)
						{
							if (num2 >= 0)
							{
								curSelSkillBar[num2].id = curSelSkillBar[l].id;
							}
							num3 = (int)curSelSkillBar[l].id;
							curSelSkillBar[l].id = (ushort)num;
							flag = true;
							break;
						}
						return false;
					}
					else
					{
						l++;
					}
				}
				if (!flag)
				{
					if (num2 >= 0)
					{
						curSelSkillBar.RemoveAt(num2);
					}
					curSelSkillBar.Add(new SkillBarGrid
					{
						id = (ushort)num,
						slot = (byte)(iSourceIndex + 1)
					});
				}
				else if (num3 != -1)
				{
					SkillTreeFrame.UpdateSelSkillAllocate(num3);
				}
				SkillTreeFrame.UpdateSelSkillAllocate(num);
			}
			else if (fromSource == SkillBarSource.FromSkillBar)
			{
				int id2 = 0;
				for (int m = 0; m < curSelSkillBar.Count; m++)
				{
					if (curSelSkillBar[m].slot == (byte)(iTargetIndex + 1))
					{
						id2 = (int)curSelSkillBar[m].id;
						break;
					}
				}
				SkillTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id2, string.Empty, string.Empty);
				if (tableItem4 != null && tableItem4.IsPreJob == 1)
				{
					JobTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
					if (tableItem5 == null)
					{
						return false;
					}
					if (tableItem5.JobType == 0)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("转职前无法配置预转职技能栏位", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return false;
					}
				}
				int num4 = -1;
				int num5 = -1;
				for (int n = 0; n < curSelSkillBar.Count; n++)
				{
					if (curSelSkillBar[n].slot == (byte)(iSourceIndex + 1))
					{
						num4 = n;
					}
					if (curSelSkillBar[n].slot == (byte)(iTargetIndex + 1))
					{
						num5 = n;
					}
				}
				SkillBarGrid skillBarGrid = new SkillBarGrid();
				if (num4 >= 0 && num5 >= 0)
				{
					skillBarGrid.id = curSelSkillBar[num4].id;
					curSelSkillBar[num4].id = curSelSkillBar[num5].id;
					curSelSkillBar[num5].id = skillBarGrid.id;
				}
				else if (num4 >= 0 && num5 < 0)
				{
					skillBarGrid.slot = (byte)(iTargetIndex + 1);
					skillBarGrid.id = curSelSkillBar[num4].id;
					curSelSkillBar.RemoveAt(num4);
					curSelSkillBar.Add(skillBarGrid);
				}
				else
				{
					if (num4 >= 0 || num5 < 0)
					{
						return false;
					}
					skillBarGrid.slot = (byte)(iSourceIndex + 1);
					skillBarGrid.id = curSelSkillBar[num5].id;
					curSelSkillBar.RemoveAt(num5);
					curSelSkillBar.Add(skillBarGrid);
				}
			}
			else
			{
				for (int num6 = 0; num6 < curSelSkillBar.Count; num6++)
				{
					if (curSelSkillBar[num6].slot == (byte)(iSourceIndex + 1))
					{
						int id3 = (int)curSelSkillBar[num6].id;
						curSelSkillBar.RemoveAt(num6);
						SkillTreeFrame.UpdateSelSkillAllocate(id3);
						break;
					}
				}
			}
			SkillPlanFrame.UpdateSkillBarInterface(curSelSkillBar);
			return true;
		}

		// Token: 0x06010C2C RID: 68652 RVA: 0x004C23B4 File Offset: 0x004C07B4
		private void InitDropBind()
		{
			for (int i = 0; i < SkillPlanFrame.skillBarImage.Length; i++)
			{
				int num = i;
				Drag_Me component = SkillPlanFrame.skillBarImage[num].GetComponent<Drag_Me>();
				Drag_Me drag_Me = component;
				if (SkillPlanFrame.<>f__mg$cache0 == null)
				{
					SkillPlanFrame.<>f__mg$cache0 = new Drag_Me.OnResDrag(SkillPlanFrame.DealDrag);
				}
				drag_Me.ResponseDrag = SkillPlanFrame.<>f__mg$cache0;
				Drop_Me component2 = SkillPlanFrame.skillBarImage[num].GetComponent<Drop_Me>();
				Drop_Me drop_Me = component2;
				if (SkillPlanFrame.<>f__mg$cache1 == null)
				{
					SkillPlanFrame.<>f__mg$cache1 = new Drop_Me.OnResDrop(SkillPlanFrame.DealDrop);
				}
				drop_Me.ResponseDrop = SkillPlanFrame.<>f__mg$cache1;
				component2.SetAutoReplace(false);
			}
			Drop_Me component3 = this.back.GetComponent<Drop_Me>();
			Drop_Me drop_Me2 = component3;
			if (SkillPlanFrame.<>f__mg$cache2 == null)
			{
				SkillPlanFrame.<>f__mg$cache2 = new Drop_Me.OnResDrop(SkillPlanFrame.DealDrop);
			}
			drop_Me2.ResponseDrop = SkillPlanFrame.<>f__mg$cache2;
			component3.SetHighLight(false);
			component3.SetAutoReplace(false);
		}

		// Token: 0x06010C2D RID: 68653 RVA: 0x004C2484 File Offset: 0x004C0884
		[MessageHandle(501202U, false, 0)]
		private void OnSaveSkillBarChangeRet(MsgDATA msg)
		{
			SceneExchangeSkillBarRes sceneExchangeSkillBarRes = new SceneExchangeSkillBarRes();
			sceneExchangeSkillBarRes.decode(msg.bytes);
			if (sceneExchangeSkillBarRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneExchangeSkillBarRes.result, string.Empty);
			}
		}

		// Token: 0x06010C2E RID: 68654 RVA: 0x004C24C4 File Offset: 0x004C08C4
		public static bool DealDrag(PointerEventData DragData, bool bIsDrag = true)
		{
			GameObject lastPress = DragData.lastPress;
			GameObject gameObject = lastPress.transform.parent.gameObject;
			GameObject gameObject2 = gameObject.transform.parent.gameObject;
			int num = -1;
			bool flag = false;
			for (int i = 0; i < SkillPlanFrame.skillBarToggle.Length; i++)
			{
				if (!(SkillPlanFrame.skillBarToggle[i] == null))
				{
					GameObject gameObject3 = SkillPlanFrame.skillBarToggle[i].transform.parent.gameObject;
					GameObject gameObject4 = gameObject3.transform.parent.gameObject;
					if (gameObject2.name == gameObject4.name)
					{
						flag = true;
						num = i;
						break;
					}
				}
			}
			if (!flag)
			{
				return SkillPlanFrame.UpdateDragData(lastPress, SkillTreeFrame.uniqueSkillTransform, DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill, bIsDrag);
			}
			bool result = false;
			List<SkillBarGrid> curSelSkillBar = SkillPlanFrame.GetCurSelSkillBar();
			if (curSelSkillBar == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("Skill Solution is null", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return result;
			}
			for (int j = 0; j < curSelSkillBar.Count; j++)
			{
				if (curSelSkillBar[j].slot == (byte)(num + 1))
				{
					SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)curSelSkillBar[j].id, string.Empty, string.Empty);
					if (tableItem != null && tableItem.IsPreJob == 1)
					{
						JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
						if (tableItem2 != null && tableItem2.JobType == 0)
						{
							if (bIsDrag)
							{
								SystemNotifyManager.SystemNotify(800006, string.Empty);
							}
							return result;
						}
					}
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x06010C2F RID: 68655 RVA: 0x004C2684 File Offset: 0x004C0A84
		public static void DealDrop(PointerEventData DragData, GameObject BeDropedImgParent)
		{
			GameObject lastPress = DragData.lastPress;
			if (!SkillPlanFrame.DealDrag(DragData, false))
			{
				return;
			}
			SkillPlanFrame.UpdateDropData(lastPress, BeDropedImgParent, SkillTreeFrame.uniqueSkillTransform, DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill);
		}

		// Token: 0x06010C30 RID: 68656 RVA: 0x004C26BC File Offset: 0x004C0ABC
		public static bool UpdateDragData(GameObject DragObj, List<string> SkillRectTransform, Dictionary<int, int> ButtonBindSkill, bool bIsDrag)
		{
			bool result = false;
			GameObject gameObject = DragObj.transform.parent.gameObject;
			GameObject gameObject2 = gameObject.transform.parent.gameObject;
			bool flag = false;
			int num = -1;
			for (int i = 0; i < SkillRectTransform.Count; i++)
			{
				if (SkillRectTransform[i] == gameObject2.name)
				{
					num = i;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				int num2 = 0;
				if (!ButtonBindSkill.TryGetValue(num + 1, out num2))
				{
					return result;
				}
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num2, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", num2));
					return result;
				}
				if (tableItem.SkillType == SkillTable.eSkillType.PASSIVE)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("被动技能无法配置到技能栏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return result;
				}
				if (tableItem.IsBuff == 1)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("Buff技能无法配置到技能栏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return result;
				}
				if (tableItem.SkillCategory == 4)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("觉醒技能不需要配置到技能栏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return result;
				}
				if (tableItem.IsPreJob == 1)
				{
					JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
					if (tableItem2 != null && tableItem2.JobType == 0)
					{
						if (bIsDrag)
						{
							SystemNotifyManager.SystemNotify(800006, string.Empty);
						}
						return result;
					}
				}
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit && tableItem.IsPreJob == 0)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("角色等级不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return result;
				}
				if (DataManager<SkillDataManager>.GetInstance().CurSkillConfigType == SkillConfigType.SKILL_CONFIG_PVP && tableItem.CanUseInPVP == 3)
				{
					if (bIsDrag)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("skill_pvpforbid"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					return result;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06010C31 RID: 68657 RVA: 0x004C28AC File Offset: 0x004C0CAC
		public static void UpdateDropData(GameObject DragObj, GameObject beDropedObj, List<string> skillRectTransform, Dictionary<int, int> ButtonBindSkill)
		{
			SkillBarSource skillBarSource = SkillBarSource.SOURCE_NULL;
			int num = -1;
			GameObject gameObject = DragObj.transform.parent.gameObject;
			GameObject gameObject2 = gameObject.transform.parent.gameObject;
			GameObject gameObject3 = beDropedObj.transform.parent.gameObject;
			GameObject gameObject4 = gameObject3.transform.parent.gameObject;
			for (int i = 0; i < skillRectTransform.Count; i++)
			{
				if (gameObject2.name == skillRectTransform[i])
				{
					skillBarSource = SkillBarSource.FromSkillTree;
					num = i;
					break;
				}
			}
			if (skillBarSource != SkillBarSource.FromSkillTree)
			{
				for (int j = 0; j < SkillPlanFrame.skillBarToggle.Length; j++)
				{
					if (gameObject2.name == string.Format("BarPos{0}", j + 1))
					{
						skillBarSource = SkillBarSource.FromSkillBar;
						num = j;
						break;
					}
				}
			}
			if (skillBarSource != SkillBarSource.FromSkillTree && skillBarSource != SkillBarSource.FromSkillBar)
			{
				return;
			}
			bool flag = false;
			int iSourceIndex = -1;
			int num2 = -1;
			for (int k = 0; k < SkillPlanFrame.skillBarToggle.Length; k++)
			{
				if (gameObject4.name == string.Format("BarPos{0}", k + 1))
				{
					if (skillBarSource == SkillBarSource.FromSkillTree)
					{
						iSourceIndex = (int)((byte)k);
					}
					else if (skillBarSource == SkillBarSource.FromSkillBar)
					{
						iSourceIndex = num;
						num = k;
					}
					num2 = k;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				if (skillBarSource != SkillBarSource.FromSkillBar)
				{
					return;
				}
				skillBarSource = SkillBarSource.FromGiveUpSelSkill;
				iSourceIndex = (int)((byte)num);
				num = -1;
			}
			bool flag2 = SkillPlanFrame.UpdateSkillBarChanged(skillBarSource, num, iSourceIndex);
			if (flag2)
			{
				SkillPlanFrame.SendSavePlan();
				if (num2 != -1)
				{
					SkillPlanFrame.skillBarImage[num2].color = new Color(1f, 1f, 1f, 1f);
				}
				SkillPlanFrame.skillBarToggle[(int)SkillPlanFrame.CurSelUseBtnIdx].isOn = false;
				SkillPlanFrame.CurSelUseBtnIdx = 0;
				SkillPlanFrame.bIsAddSkillBarState = false;
			}
		}

		// Token: 0x06010C32 RID: 68658 RVA: 0x004C2A90 File Offset: 0x004C0E90
		public static SkillBarGrid[] CalSkillBarChange()
		{
			List<SkillBarGrid> curSelSkillBar = SkillPlanFrame.GetCurSelSkillBar();
			if (curSelSkillBar == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("Skill Solution is null", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return null;
			}
			List<SkillBarGrid> list = new List<SkillBarGrid>();
			for (int i = 0; i < curSelSkillBar.Count; i++)
			{
				if ((int)curSelSkillBar[i].slot > SkillPlanFrame.UnLockSkillBarNum)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("skillBar Slot Index = {0}, UnLockSkillBarNum = {1}, skillID = [2]", curSelSkillBar[i].slot, SkillPlanFrame.UnLockSkillBarNum, curSelSkillBar[i].id), null, string.Empty, false);
					break;
				}
				list.Add(new SkillBarGrid
				{
					id = curSelSkillBar[i].id,
					slot = curSelSkillBar[i].slot
				});
			}
			List<Skillbar> list2 = new List<Skillbar>();
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					list2 = SkillPlanFrame.OriginalSkillBar;
				}
				else
				{
					list2 = SkillPlanFrame.OriginalSkillBar2;
				}
				SkillPlanFrame.CurSelSolution = (byte)(DataManager<SkillDataManager>.GetInstance().CurPVESKillPage + 1);
			}
			else
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
				{
					list2 = SkillPlanFrame.pvpOriginalSkillBar;
				}
				else
				{
					list2 = SkillPlanFrame.pvpOriginalSkillBar2;
				}
				SkillPlanFrame.CurSelSolution = (byte)(DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage + 1);
			}
			for (int j = 0; j < list2.Count; j++)
			{
				if (list2[j].index == SkillPlanFrame.CurSelSolution)
				{
					List<SkillBarGrid> grids = list2[j].grids;
					for (int k = 0; k < grids.Count; k++)
					{
						bool flag = false;
						for (int l = 0; l < list.Count; l++)
						{
							if (grids[k].slot == list[l].slot)
							{
								if (grids[k].id == list[l].id)
								{
									list.RemoveAt(l);
								}
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							list.Add(new SkillBarGrid
							{
								id = 0,
								slot = grids[k].slot
							});
						}
					}
					list2[j].grids.Clear();
					for (int m = 0; m < curSelSkillBar.Count; m++)
					{
						SkillBarGrid skillBarGrid = new SkillBarGrid();
						skillBarGrid.id = curSelSkillBar[m].id;
						skillBarGrid.slot = curSelSkillBar[m].slot;
						list2[j].grids.Add(skillBarGrid);
					}
				}
			}
			SkillBarGrid[] array = new SkillBarGrid[list.Count];
			for (int n = 0; n < list.Count; n++)
			{
				array[n] = new SkillBarGrid
				{
					id = list[n].id,
					slot = list[n].slot
				};
			}
			return array;
		}

		// Token: 0x06010C33 RID: 68659 RVA: 0x004C2DBC File Offset: 0x004C11BC
		public static void UpdateSkillBar()
		{
			List<SkillBar> list = new List<SkillBar>();
			SkillPlanFrame.skillBarDirty.Clear();
			SkillPlanFrame.skillBarDirty2.Clear();
			SkillPlanFrame.OriginalSkillBar.Clear();
			SkillPlanFrame.OriginalSkillBar2.Clear();
			SkillPlanFrame.pvpSkillBarDirty.Clear();
			SkillPlanFrame.pvpSkillBarDirty2.Clear();
			SkillPlanFrame.pvpOriginalSkillBar.Clear();
			SkillPlanFrame.pvpOriginalSkillBar2.Clear();
			for (int i = 0; i < DataManager<SkillDataManager>.GetInstance().skillBarSolution.Count; i++)
			{
				SkillBar skillBar = DataManager<SkillDataManager>.GetInstance().skillBarSolution[i];
				Skillbar skillbar = new Skillbar();
				skillbar.index = skillBar.index;
				skillbar.grids = new List<SkillBarGrid>();
				Skillbar skillbar2 = new Skillbar();
				skillbar2.index = skillBar.index;
				skillbar2.grids = new List<SkillBarGrid>();
				for (int j = 0; j < skillBar.grids.Length; j++)
				{
					if ((int)skillBar.grids[j].slot > SkillPlanFrame.UnLockSkillBarNum)
					{
						SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("skillBar Slot Index = {0}, UnLockSkillBarNum = {1}, skillID = [2]", skillBar.grids[j].slot, SkillPlanFrame.UnLockSkillBarNum, skillBar.grids[j].id), null, string.Empty, false);
						break;
					}
					SkillBarGrid skillBarGrid = new SkillBarGrid();
					skillBarGrid.id = skillBar.grids[j].id;
					skillBarGrid.slot = skillBar.grids[j].slot;
					SkillBarGrid skillBarGrid2 = new SkillBarGrid();
					skillBarGrid2.id = skillBar.grids[j].id;
					skillBarGrid2.slot = skillBar.grids[j].slot;
					skillbar.grids.Add(skillBarGrid);
					skillbar2.grids.Add(skillBarGrid2);
				}
				SkillPlanFrame.skillBarDirty.Add(skillbar);
				SkillPlanFrame.OriginalSkillBar.Add(skillbar2);
			}
			for (int k = 0; k < DataManager<SkillDataManager>.GetInstance().skillBarSolution2.Count; k++)
			{
				SkillBar skillBar2 = DataManager<SkillDataManager>.GetInstance().skillBarSolution2[k];
				Skillbar skillbar3 = new Skillbar();
				skillbar3.index = skillBar2.index;
				skillbar3.grids = new List<SkillBarGrid>();
				Skillbar skillbar4 = new Skillbar();
				skillbar4.index = skillBar2.index;
				skillbar4.grids = new List<SkillBarGrid>();
				for (int l = 0; l < skillBar2.grids.Length; l++)
				{
					if ((int)skillBar2.grids[l].slot > SkillPlanFrame.UnLockSkillBarNum)
					{
						SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("skillBar Slot Index = {0}, UnLockSkillBarNum = {1}, skillID = [2]", skillBar2.grids[l].slot, SkillPlanFrame.UnLockSkillBarNum, skillBar2.grids[l].id), null, string.Empty, false);
						break;
					}
					SkillBarGrid skillBarGrid3 = new SkillBarGrid();
					skillBarGrid3.id = skillBar2.grids[l].id;
					skillBarGrid3.slot = skillBar2.grids[l].slot;
					SkillBarGrid skillBarGrid4 = new SkillBarGrid();
					skillBarGrid4.id = skillBar2.grids[l].id;
					skillBarGrid4.slot = skillBar2.grids[l].slot;
					skillbar3.grids.Add(skillBarGrid3);
					skillbar4.grids.Add(skillBarGrid4);
				}
				SkillPlanFrame.skillBarDirty2.Add(skillbar3);
				SkillPlanFrame.OriginalSkillBar2.Add(skillbar4);
			}
			for (int m = 0; m < DataManager<SkillDataManager>.GetInstance().pvpSkillBarSolution.Count; m++)
			{
				SkillBar skillBar3 = DataManager<SkillDataManager>.GetInstance().pvpSkillBarSolution[m];
				Skillbar skillbar5 = new Skillbar();
				skillbar5.index = skillBar3.index;
				skillbar5.grids = new List<SkillBarGrid>();
				Skillbar skillbar6 = new Skillbar();
				skillbar6.index = skillBar3.index;
				skillbar6.grids = new List<SkillBarGrid>();
				for (int n = 0; n < skillBar3.grids.Length; n++)
				{
					if ((int)skillBar3.grids[n].slot > SkillPlanFrame.UnLockSkillBarNum)
					{
						SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("skillBar Slot Index = {0}, UnLockSkillBarNum = {1}, skillID = [2]", skillBar3.grids[n].slot, SkillPlanFrame.UnLockSkillBarNum, skillBar3.grids[n].id), null, string.Empty, false);
						break;
					}
					SkillBarGrid skillBarGrid5 = new SkillBarGrid();
					skillBarGrid5.id = skillBar3.grids[n].id;
					skillBarGrid5.slot = skillBar3.grids[n].slot;
					SkillBarGrid skillBarGrid6 = new SkillBarGrid();
					skillBarGrid6.id = skillBar3.grids[n].id;
					skillBarGrid6.slot = skillBar3.grids[n].slot;
					skillbar5.grids.Add(skillBarGrid5);
					skillbar6.grids.Add(skillBarGrid6);
				}
				SkillPlanFrame.pvpSkillBarDirty.Add(skillbar5);
				SkillPlanFrame.pvpOriginalSkillBar.Add(skillbar6);
			}
			for (int num = 0; num < DataManager<SkillDataManager>.GetInstance().pvpSkillBarSolution2.Count; num++)
			{
				SkillBar skillBar4 = DataManager<SkillDataManager>.GetInstance().pvpSkillBarSolution2[num];
				Skillbar skillbar7 = new Skillbar();
				skillbar7.index = skillBar4.index;
				skillbar7.grids = new List<SkillBarGrid>();
				Skillbar skillbar8 = new Skillbar();
				skillbar8.index = skillBar4.index;
				skillbar8.grids = new List<SkillBarGrid>();
				for (int num2 = 0; num2 < skillBar4.grids.Length; num2++)
				{
					if ((int)skillBar4.grids[num2].slot > SkillPlanFrame.UnLockSkillBarNum)
					{
						SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("skillBar Slot Index = {0}, UnLockSkillBarNum = {1}, skillID = [2]", skillBar4.grids[num2].slot, SkillPlanFrame.UnLockSkillBarNum, skillBar4.grids[num2].id), null, string.Empty, false);
						break;
					}
					SkillBarGrid skillBarGrid7 = new SkillBarGrid();
					skillBarGrid7.id = skillBar4.grids[num2].id;
					skillBarGrid7.slot = skillBar4.grids[num2].slot;
					SkillBarGrid skillBarGrid8 = new SkillBarGrid();
					skillBarGrid8.id = skillBar4.grids[num2].id;
					skillBarGrid8.slot = skillBar4.grids[num2].slot;
					skillbar7.grids.Add(skillBarGrid7);
					skillbar8.grids.Add(skillBarGrid8);
				}
				SkillPlanFrame.pvpSkillBarDirty2.Add(skillbar7);
				SkillPlanFrame.pvpOriginalSkillBar2.Add(skillbar8);
			}
		}

		// Token: 0x06010C34 RID: 68660 RVA: 0x004C3468 File Offset: 0x004C1868
		public static List<SkillBarGrid> GetCurSelSkillBar()
		{
			List<Skillbar> list = new List<Skillbar>();
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					list = SkillPlanFrame.skillBarDirty;
				}
				else
				{
					list = SkillPlanFrame.skillBarDirty2;
				}
				SkillPlanFrame.CurSelSolution = (byte)(DataManager<SkillDataManager>.GetInstance().CurPVESKillPage + 1);
			}
			else
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
				{
					list = SkillPlanFrame.pvpSkillBarDirty;
				}
				else
				{
					list = SkillPlanFrame.pvpSkillBarDirty2;
				}
				SkillPlanFrame.CurSelSolution = (byte)(DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage + 1);
			}
			for (int i = 0; i < list.Count; i++)
			{
				Skillbar skillbar = list[i];
				if (skillbar.index == SkillPlanFrame.CurSelSolution)
				{
					return skillbar.grids;
				}
			}
			return null;
		}

		// Token: 0x06010C35 RID: 68661 RVA: 0x004C352C File Offset: 0x004C192C
		private void TryUpdateSkillBarInterface()
		{
			SkillPlanFrame.UpdateSkillBarInterface(DataManager<SkillDataManager>.GetInstance().GetCurSkillBar(!DataManager<SkillDataManager>.GetInstance().isPve(), SkillSystemSourceType.None));
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				this.mSkillTreeType.text = "地下城技能配置";
				this.SkillConfigBuriedPoint();
			}
			else
			{
				this.mSkillTreeType.text = "决斗场技能配置";
				this.SkillConfigBuriedPoint();
			}
		}

		// Token: 0x06010C36 RID: 68662 RVA: 0x004C3598 File Offset: 0x004C1998
		private void SkillConfigBuriedPoint()
		{
			bool flag = DataManager<SkillDataManager>.GetInstance().isPve();
			List<SkillBarGrid> curSkillBar = DataManager<SkillDataManager>.GetInstance().GetCurSkillBar(!flag, SkillSystemSourceType.None);
			for (int i = 0; i < curSkillBar.Count; i++)
			{
				SkillBarGrid skillBarGrid = curSkillBar[i];
				SkillConfigType skillConfigType;
				if (flag)
				{
					skillConfigType = SkillConfigType.SKILL_CONFIG_PVE;
				}
				else
				{
					skillConfigType = SkillConfigType.SKILL_CONFIG_PVP;
				}
				Singleton<GameStatisticManager>.GetInstance().DoStartSkillConfiguration(skillConfigType, (int)skillBarGrid.id, (int)skillBarGrid.slot);
			}
		}

		// Token: 0x06010C37 RID: 68663 RVA: 0x004C360C File Offset: 0x004C1A0C
		protected override void _bindExUI()
		{
			this.mPreJob = this.mBind.GetCom<Text>("PreJob");
			this.mSkillTreeType = this.mBind.GetCom<Text>("SkillTreeType");
			this.mPreJobRoot = this.mBind.GetGameObject("PreJobRoot");
			this.mPassiveAwakeSkillItem = this.mBind.GetCom<PassiveAwakeSkillItem>("BarPos_Awake");
		}

		// Token: 0x06010C38 RID: 68664 RVA: 0x004C3671 File Offset: 0x004C1A71
		protected override void _unbindExUI()
		{
			this.mPreJob = null;
			this.mSkillTreeType = null;
			this.mPreJobRoot = null;
			this.mPassiveAwakeSkillItem = null;
		}

		// Token: 0x0400AB79 RID: 43897
		private string SkillBarElementPath = "UIFlatten/Prefabs/Skill/SkillBarElement";

		// Token: 0x0400AB7A RID: 43898
		private const int MaxSolutionNum = 2;

		// Token: 0x0400AB7B RID: 43899
		private const int MaxSkillBarNum = 12;

		// Token: 0x0400AB7C RID: 43900
		private static string defaultIconPath = "UIPacked/p-Common-0.png:Common_iconSkill_n";

		// Token: 0x0400AB7D RID: 43901
		private static Image[] skillBarImage = new Image[12];

		// Token: 0x0400AB7E RID: 43902
		private static Image[] skillBarPlus = new Image[12];

		// Token: 0x0400AB7F RID: 43903
		private static Image[] skillBarLock = new Image[12];

		// Token: 0x0400AB80 RID: 43904
		private static Text[] skillBarOpenLv = new Text[12];

		// Token: 0x0400AB81 RID: 43905
		public static int UnLockSkillBarNum = 0;

		// Token: 0x0400AB82 RID: 43906
		public static bool bIsAddSkillBarState = false;

		// Token: 0x0400AB83 RID: 43907
		public static byte CurSelUseBtnIdx = 0;

		// Token: 0x0400AB84 RID: 43908
		public static byte CurSelSolution = 1;

		// Token: 0x0400AB85 RID: 43909
		public static List<Skillbar> OriginalSkillBar = new List<Skillbar>();

		// Token: 0x0400AB86 RID: 43910
		public static List<Skillbar> OriginalSkillBar2 = new List<Skillbar>();

		// Token: 0x0400AB87 RID: 43911
		public static List<Skillbar> skillBarDirty = new List<Skillbar>();

		// Token: 0x0400AB88 RID: 43912
		public static List<Skillbar> skillBarDirty2 = new List<Skillbar>();

		// Token: 0x0400AB89 RID: 43913
		public static List<Skillbar> pvpOriginalSkillBar = new List<Skillbar>();

		// Token: 0x0400AB8A RID: 43914
		public static List<Skillbar> pvpOriginalSkillBar2 = new List<Skillbar>();

		// Token: 0x0400AB8B RID: 43915
		public static List<Skillbar> pvpSkillBarDirty = new List<Skillbar>();

		// Token: 0x0400AB8C RID: 43916
		public static List<Skillbar> pvpSkillBarDirty2 = new List<Skillbar>();

		// Token: 0x0400AB8D RID: 43917
		public static Toggle[] skillBarToggle = new Toggle[12];

		// Token: 0x0400AB8E RID: 43918
		[UIControl("back", null, 0)]
		protected Image back;

		// Token: 0x0400AB8F RID: 43919
		private Text mPreJob;

		// Token: 0x0400AB90 RID: 43920
		private Text mSkillTreeType;

		// Token: 0x0400AB91 RID: 43921
		private GameObject mPreJobRoot;

		// Token: 0x0400AB92 RID: 43922
		private PassiveAwakeSkillItem mPassiveAwakeSkillItem;

		// Token: 0x0400AB93 RID: 43923
		[CompilerGenerated]
		private static Drag_Me.OnResDrag <>f__mg$cache0;

		// Token: 0x0400AB94 RID: 43924
		[CompilerGenerated]
		private static Drop_Me.OnResDrop <>f__mg$cache1;

		// Token: 0x0400AB95 RID: 43925
		[CompilerGenerated]
		private static Drop_Me.OnResDrop <>f__mg$cache2;
	}
}
