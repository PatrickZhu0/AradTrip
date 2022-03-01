using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001009 RID: 4105
[LoggerModel("NewbieGuide")]
public class ComNewbieGuideControl : MonoBehaviour
{
	// Token: 0x06009C06 RID: 39942 RVA: 0x001E6728 File Offset: 0x001E4B28
	public ComNewbieGuideControl()
	{
		this.GuideTaskID = NewbieGuideTable.eNewbieGuideTask.None;
		this.mCurState = ComNewbieGuideControl.ControlState.None;
		this.currentIndex = 0;
		this.mCurGuideUnit = null;
	}

	// Token: 0x06009C07 RID: 39943 RVA: 0x001E674C File Offset: 0x001E4B4C
	public void ClearData()
	{
		this.mCurGuideTaskID = NewbieGuideTable.eNewbieGuideTask.None;
		this.mCurState = ComNewbieGuideControl.ControlState.None;
		this.mCurrentIndex = 0;
		if (this.mCurGuideUnit != null)
		{
			this.mCurGuideUnit.ClearData();
		}
		if (this.mCurrentCom != null)
		{
			this.mCurrentCom.ClearData();
		}
	}

	// Token: 0x06009C08 RID: 39944 RVA: 0x001E67A0 File Offset: 0x001E4BA0
	private void Start()
	{
		this._start();
	}

	// Token: 0x06009C09 RID: 39945 RVA: 0x001E67A8 File Offset: 0x001E4BA8
	private void _start()
	{
		if (this.mCurGuideUnit.newbieComList == null)
		{
			this._DealFinishProcess();
		}
		else
		{
			this.curState = ComNewbieGuideControl.ControlState.Guiding;
			this.currentIndex = this.mCurGuideUnit.savePoint;
			this._checkNext();
		}
	}

	// Token: 0x1700194D RID: 6477
	// (get) Token: 0x06009C0A RID: 39946 RVA: 0x001E67F1 File Offset: 0x001E4BF1
	// (set) Token: 0x06009C0B RID: 39947 RVA: 0x001E67F9 File Offset: 0x001E4BF9
	private bool needCheckNext
	{
		get
		{
			return this._bNeedCheckNext;
		}
		set
		{
			if (this._bNeedCheckNext != value)
			{
				this.fCheckTime = 0f;
			}
			this._bNeedCheckNext = value;
		}
	}

	// Token: 0x06009C0C RID: 39948 RVA: 0x001E681C File Offset: 0x001E4C1C
	private void PerformCheckNext()
	{
		if (this.needCheckNext)
		{
			this.fCheckTime += Time.deltaTime;
			if (this.fCheckTime <= 5f)
			{
				this._checkNext();
			}
			else
			{
				this.needCheckNext = false;
				this.ControlException();
			}
		}
	}

	// Token: 0x06009C0D RID: 39949 RVA: 0x001E6870 File Offset: 0x001E4C70
	private bool _checkNext()
	{
		List<ComNewbieData> newbieComList = this.mCurGuideUnit.newbieComList;
		if (newbieComList == null || this.currentIndex >= newbieComList.Count)
		{
			this._DealFinishProcess();
			return false;
		}
		ComNewbieData type = newbieComList[this.currentIndex];
		if (!this.CheckModifyData(ref type))
		{
			this.needCheckNext = true;
			return false;
		}
		this.needCheckNext = false;
		this._DealGuidingProcess(type);
		return true;
	}

	// Token: 0x06009C0E RID: 39950 RVA: 0x001E68DA File Offset: 0x001E4CDA
	public void ControlComplete()
	{
		this._deleteCom();
		this.fCheckTime = 0f;
		this.currentIndex++;
		this.mCurGuideUnit.savePoint = this.currentIndex;
		this._setUnitData();
		this._checkNext();
	}

	// Token: 0x06009C0F RID: 39951 RVA: 0x001E6919 File Offset: 0x001E4D19
	public void ControlWait()
	{
		this._deleteCom();
		this.mCurGuideUnit.savePoint = this.currentIndex;
		this._setUnitData();
		if (this.mGuideManager != null)
		{
			this.mGuideManager.ManagerWait();
		}
	}

	// Token: 0x06009C10 RID: 39952 RVA: 0x001E694E File Offset: 0x001E4D4E
	public void ControlException()
	{
		if (this.mGuideManager != null)
		{
			this.mGuideManager.ManagerException();
		}
		this._DealFinishProcess();
	}

	// Token: 0x06009C11 RID: 39953 RVA: 0x001E696C File Offset: 0x001E4D6C
	public void FinishCurGuideControl()
	{
		if (Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemBattle && BattleMain.instance != null)
		{
			BattleMain.instance.GetDungeonManager().ResumeFight(true, string.Empty, false);
		}
		this._deleteCom();
		this._setUnitData();
		this.curState = ComNewbieGuideControl.ControlState.Finish;
	}

	// Token: 0x06009C12 RID: 39954 RVA: 0x001E69C0 File Offset: 0x001E4DC0
	private void Update()
	{
		ComNewbieGuideControl.ControlState curState = this.curState;
		if (curState != ComNewbieGuideControl.ControlState.None)
		{
			if (curState != ComNewbieGuideControl.ControlState.Guiding)
			{
				if (curState != ComNewbieGuideControl.ControlState.Finish)
				{
				}
			}
		}
		this.PerformCheckNext();
	}

	// Token: 0x06009C13 RID: 39955 RVA: 0x001E6A04 File Offset: 0x001E4E04
	private void _setUnitData()
	{
		if (this.mGuideManager == null)
		{
			return;
		}
		NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>((int)this.mCurGuideUnit.taskId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		NewbieGuideDataUnit unit = this.mGuideManager.GetUnit(tableItem);
		if (unit == null)
		{
			return;
		}
		unit.manager.mGuideControl = this;
		unit.manager.mGuideControl.mCurState = this.mCurState;
		unit.savePoint = this.mCurGuideUnit.savePoint;
		unit.AlreadySend = this.mCurGuideUnit.AlreadySend;
	}

	// Token: 0x06009C14 RID: 39956 RVA: 0x001E6A9C File Offset: 0x001E4E9C
	private void _DealGuidingProcess(ComNewbieData type)
	{
		this.mCurrentCom = NewbieGuideComFactory.AddNewbieCom(base.gameObject, type);
		if (this.mCurrentCom == null)
		{
			this._DealFinishProcess();
			return;
		}
		this.mCurrentCom.SetTaskBaseNewbieGuideControl(this);
		if (this.mGuideManager != null && this.mCurGuideUnit != null && !this.mCurGuideUnit.AlreadySend && this.mCurrentCom != null && this.mCurrentCom.mSendSaveBoot && this.mCurGuideTaskID > NewbieGuideTable.eNewbieGuideTask.None)
		{
			this.mGuideManager.SendSaveBoot(this.mCurGuideTaskID);
			this.mCurGuideUnit.AlreadySend = true;
		}
		if (this.mCurrentCom != null && Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemBattle && BattleMain.instance != null)
		{
			if (this.mCurrentCom.mTryPauseBattle)
			{
				BattleMain.instance.GetDungeonManager().PauseFight(true, string.Empty, false);
			}
			else if (this.mCurrentCom.mTryResumeBattle)
			{
				BattleMain.instance.GetDungeonManager().ResumeFight(true, string.Empty, false);
			}
		}
		this.curState = ComNewbieGuideControl.ControlState.Guiding;
		NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>((int)this.mCurGuideTaskID, string.Empty, string.Empty);
		if (tableItem != null && this.currentIndex >= 0 && this.currentIndex < tableItem.AudioIDList.Count && tableItem.AudioIDList[this.currentIndex] > 0)
		{
			SoundTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SoundTable>(tableItem.AudioIDList[this.currentIndex], string.Empty, string.Empty);
			if (tableItem2 != null && tableItem2.Path.Count > 0 && tableItem2.Path[0] != string.Empty && tableItem2.Path[0] != "-")
			{
				MonoSingleton<AudioManager>.instance.PlayGuideAudio(tableItem2.Path[0], 1f, null, false, null, false);
			}
		}
		Singleton<GameStatisticManager>.GetInstance().DoStatNewBieGuide(this.GuideTaskID.ToString(), this.currentIndex);
	}

	// Token: 0x06009C15 RID: 39957 RVA: 0x001E6CE9 File Offset: 0x001E50E9
	private void _DealFinishProcess()
	{
		if (this.mGuideManager != null && this.mCurGuideTaskID > NewbieGuideTable.eNewbieGuideTask.None)
		{
			this.mGuideManager.ManagerFinishGuide(this.mCurGuideTaskID);
		}
	}

	// Token: 0x06009C16 RID: 39958 RVA: 0x001E6D13 File Offset: 0x001E5113
	private void _deleteCom()
	{
		if (this.mCurrentCom != null)
		{
			this.mCurrentCom.BaseComplete();
			this.mCurrentCom = null;
		}
	}

	// Token: 0x06009C17 RID: 39959 RVA: 0x001E6D38 File Offset: 0x001E5138
	public void ControlSave()
	{
		if (this.mGuideManager != null)
		{
			this.mGuideManager.Save();
		}
	}

	// Token: 0x1700194E RID: 6478
	// (get) Token: 0x06009C18 RID: 39960 RVA: 0x001E6D50 File Offset: 0x001E5150
	// (set) Token: 0x06009C19 RID: 39961 RVA: 0x001E6D58 File Offset: 0x001E5158
	public NewbieGuideTable.eNewbieGuideTask GuideTaskID
	{
		get
		{
			return this.mCurGuideTaskID;
		}
		set
		{
			if (this.mCurGuideTaskID != value)
			{
				this.mCurGuideTaskID = value;
			}
		}
	}

	// Token: 0x1700194F RID: 6479
	// (get) Token: 0x06009C1A RID: 39962 RVA: 0x001E6D6D File Offset: 0x001E516D
	// (set) Token: 0x06009C1B RID: 39963 RVA: 0x001E6D75 File Offset: 0x001E5175
	public ComNewbieGuideControl.ControlState curState
	{
		get
		{
			return this.mCurState;
		}
		set
		{
			if (this.mCurState != value)
			{
				this.mCurState = value;
			}
		}
	}

	// Token: 0x17001950 RID: 6480
	// (get) Token: 0x06009C1C RID: 39964 RVA: 0x001E6D8A File Offset: 0x001E518A
	// (set) Token: 0x06009C1D RID: 39965 RVA: 0x001E6D92 File Offset: 0x001E5192
	public int currentIndex
	{
		get
		{
			return this.mCurrentIndex;
		}
		set
		{
			if (value < 0)
			{
				this.mCurrentIndex = 0;
			}
			this.mCurrentIndex = value;
		}
	}

	// Token: 0x17001951 RID: 6481
	// (get) Token: 0x06009C1E RID: 39966 RVA: 0x001E6DA9 File Offset: 0x001E51A9
	// (set) Token: 0x06009C1F RID: 39967 RVA: 0x001E6DB1 File Offset: 0x001E51B1
	public NewbieGuideManager guideManager
	{
		get
		{
			return this.mGuideManager;
		}
		set
		{
			this.mGuideManager = value;
		}
	}

	// Token: 0x06009C20 RID: 39968 RVA: 0x001E6DBC File Offset: 0x001E51BC
	public void SetUnit(NewbieGuideDataUnit unit)
	{
		this.mCurGuideUnit = unit;
		this.mCurrentIndex = this.mCurGuideUnit.savePoint;
		if (this.mCurGuideUnit.manager.mGuideControl != null)
		{
			this.mCurState = this.mCurGuideUnit.manager.mGuideControl.mCurState;
		}
	}

	// Token: 0x06009C21 RID: 39969 RVA: 0x001E6E17 File Offset: 0x001E5217
	public ComNewbieGuideBase GetCurGuideCom()
	{
		return this.mCurrentCom;
	}

	// Token: 0x06009C22 RID: 39970 RVA: 0x001E6E1F File Offset: 0x001E521F
	public NewbieGuideDataUnit GetControlUnit()
	{
		return this.mCurGuideUnit;
	}

	// Token: 0x06009C23 RID: 39971 RVA: 0x001E6E28 File Offset: 0x001E5228
	private bool CheckModifyData(ref ComNewbieData type)
	{
		if (type.ModifyDataTypeList != null && type.ModifyDataTypeList.Count > 0)
		{
			for (int i = 0; i < type.ModifyDataTypeList.Count; i++)
			{
				NewbieModifyData modifyData = type.ModifyDataTypeList[i];
				int j = 0;
				while (j < type.args.Length)
				{
					if (j != modifyData.iIndex)
					{
						j++;
					}
					else
					{
						if (!this.SwitchDataForm(modifyData, ref type.args[j]))
						{
							return false;
						}
						break;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06009C24 RID: 39972 RVA: 0x001E6ECC File Offset: 0x001E52CC
	private bool SwitchDataForm(NewbieModifyData ModifyData, ref object obj)
	{
		object[] args = new object[3];
		bool modifyRealDataByType = this.GetModifyRealDataByType(ModifyData.ModifyDataType, ref args);
		if (modifyRealDataByType)
		{
			if (obj is string)
			{
				string format = obj as string;
				obj = string.Format(format, args);
			}
			else if (obj is int)
			{
			}
		}
		return modifyRealDataByType;
	}

	// Token: 0x06009C25 RID: 39973 RVA: 0x001E6F2C File Offset: 0x001E532C
	private bool GetModifyRealDataByType(NewBieModifyDataType ModifyDataType, ref object[] ReturnParamList)
	{
		bool result = false;
		if (ReturnParamList.Length < 3)
		{
			return result;
		}
		switch (ModifyDataType)
		{
		case NewBieModifyDataType.JobID:
			ReturnParamList[0] = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			result = true;
			break;
		case NewBieModifyDataType.EquipInPackagePos:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null)
			{
				Logger.LogErrorFormat("新手引导报错---[EquipInPackagePos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				IGameBind gameBind = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PackageNewFrame)) as IGameBind;
				if (gameBind == null)
				{
					Logger.LogErrorFormat("新手引导报错---[EquipInPackagePos]IGameBind为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					RectTransform component = gameBind.GetComponent<RectTransform>("Content/ItemListView/Viewport/Content");
					if (component == null)
					{
						Logger.LogErrorFormat("新手引导报错---[EquipInPackagePos]root为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
						{
							this.mCurGuideTaskID,
							this.mCurrentIndex,
							this.mCurState
						});
					}
					else
					{
						List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
						if (itemsByPackageType != null && itemsByPackageType.Count > 0)
						{
							List<ItemData> list = new List<ItemData>();
							for (int i = 0; i < itemsByPackageType.Count; i++)
							{
								ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
								if (item != null)
								{
									if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= item.LevelLimit)
									{
										if ((this.mCurGuideUnit.taskId != NewbieGuideTable.eNewbieGuideTask.ForgeGuide && this.mCurGuideUnit.taskId != NewbieGuideTable.eNewbieGuideTask.QuickEquipGuide) || item.EquipWearSlotType == EEquipWearSlotType.EquipWeapon)
										{
											if (item.IsOccupationFit())
											{
												if (item.Quality >= ItemTable.eColor.BLUE)
												{
													list.Add(item);
												}
											}
										}
									}
								}
							}
							for (int j = 0; j < list.Count; j++)
							{
								for (int k = j + 1; k < list.Count; k++)
								{
									if (list[k].Quality > list[j].Quality)
									{
										ItemData value = list[j];
										list[j] = list[k];
										list[k] = value;
									}
								}
							}
							if (list.Count > 0)
							{
								ComGridBindItem[] componentsInChildren = component.GetComponentsInChildren<ComGridBindItem>();
								for (int l = 0; l < componentsInChildren.Length; l++)
								{
									if (!(componentsInChildren[l] == null))
									{
										if (componentsInChildren[l].param1 != null && componentsInChildren[l].param2 != null)
										{
											if ((ulong)componentsInChildren[l].param2 == list[0].GUID)
											{
												string text = (string)componentsInChildren[l].param1;
												string[] array = text.Split(new char[]
												{
													'_'
												});
												if (array.Length >= 2)
												{
													int num = int.Parse(array[1]);
													ReturnParamList[0] = num;
													ReturnParamList[1] = list[0].GUID;
													this.mCurGuideUnit.NeedSaveParamsList.Add(list[0].GUID);
													result = true;
													break;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			break;
		case NewBieModifyDataType.PackageEquipTipsGuidePos:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count < 1)
			{
				Logger.LogErrorFormat("新手引导报错---[PackageEquipTipsGuidePos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem((ulong)this.mCurGuideUnit.NeedSaveParamsList[0]);
				if (item2 == null)
				{
					Logger.LogErrorFormat("新手引导报错---[PackageEquipTipsGuidePos]ItemData为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					ulong wearEquipBySlotType = DataManager<ItemDataManager>.GetInstance().GetWearEquipBySlotType(item2.EquipWearSlotType);
					if (wearEquipBySlotType != 0UL)
					{
						ReturnParamList[0] = 1;
						this.mCurGuideUnit.NeedSaveParamsList.Add(wearEquipBySlotType);
					}
					else
					{
						ReturnParamList[0] = 0;
					}
					result = true;
				}
			}
			break;
		case NewBieModifyDataType.ChangedEquipInPackagePos:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count < 2)
			{
				Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				IGameBind gameBind2 = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PackageNewFrame)) as IGameBind;
				if (gameBind2 == null)
				{
					Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]IGameBind为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					RectTransform component2 = gameBind2.GetComponent<RectTransform>("Content/ItemListView/Viewport/Content");
					if (component2 == null)
					{
						Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]root为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
						{
							this.mCurGuideTaskID,
							this.mCurrentIndex,
							this.mCurState
						});
					}
					else
					{
						ComGridBindItem[] componentsInChildren2 = component2.GetComponentsInChildren<ComGridBindItem>();
						for (int m = 0; m < componentsInChildren2.Length; m++)
						{
							if (!(componentsInChildren2[m] == null))
							{
								if (componentsInChildren2[m].param1 != null && componentsInChildren2[m].param2 != null)
								{
									if ((ulong)componentsInChildren2[m].param2 == (ulong)this.mCurGuideUnit.NeedSaveParamsList[1])
									{
										string text2 = (string)componentsInChildren2[m].param1;
										string[] array2 = text2.Split(new char[]
										{
											'_'
										});
										if (array2.Length >= 2)
										{
											int num2 = int.Parse(array2[1]);
											ReturnParamList[0] = num2;
											ReturnParamList[1] = this.mCurGuideUnit.NeedSaveParamsList[1];
											result = true;
											break;
										}
									}
								}
							}
						}
					}
				}
			}
			break;
		case NewBieModifyDataType.ActorShowEquipPos:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count < 1)
			{
				Logger.LogErrorFormat("新手引导报错---[ActorShowEquipPos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				IGameBind gameBind3 = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PackageNewFrame)) as IGameBind;
				if (gameBind3 == null)
				{
					Logger.LogErrorFormat("新手引导报错---[ActorShowEquipPos]IGameBind为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					RectTransform component3 = gameBind3.GetComponent<RectTransform>("Content/ActorShow/Equips/Right");
					if (component3 == null)
					{
						Logger.LogErrorFormat("新手引导报错---[ActorShowEquipPos]root为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
						{
							this.mCurGuideTaskID,
							this.mCurrentIndex,
							this.mCurState
						});
					}
					else
					{
						RectTransform[] componentsInChildren3 = component3.GetComponentsInChildren<RectTransform>();
						for (int n = 0; n < componentsInChildren3.Length; n++)
						{
							if (!(componentsInChildren3[n] == null))
							{
								if (!(componentsInChildren3[n].name != this.mCurGuideUnit.NeedSaveParamsList[0].ToString()))
								{
									RectTransform[] componentsInParent = componentsInChildren3[n].GetComponentsInParent<RectTransform>();
									if (componentsInParent.Length >= 2)
									{
										ReturnParamList[0] = componentsInParent[1].name;
										ReturnParamList[1] = this.mCurGuideUnit.NeedSaveParamsList[0];
										result = true;
										break;
									}
								}
							}
						}
					}
				}
			}
			break;
		case NewBieModifyDataType.WelfareID:
		{
			GameObject gameObject = Utility.FindGameObject("topright/activeFuli", true);
			if (gameObject == null)
			{
				Logger.LogErrorFormat("新手引导报错---[WelfareID][MainUIIconPath.activeFuli]路径错误, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				OnOpenActiveFrame component4 = gameObject.GetComponent<OnOpenActiveFrame>();
				if (component4 == null)
				{
					Logger.LogErrorFormat("新手引导报错---[WelfareID]OnOpenActiveFrame为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					ReturnParamList[0] = component4.iActiveTypeID;
					result = true;
				}
			}
			break;
		}
		case NewBieModifyDataType.SignInID:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count <= 0)
			{
				Logger.LogErrorFormat("新手引导报错---[SignInID]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				ReturnParamList[0] = this.mCurGuideUnit.NeedSaveParamsList[0];
				result = true;
			}
			break;
		case NewBieModifyDataType.EntourageID:
			if (DataManager<PlayerBaseData>.GetInstance().JobTableID == 50)
			{
				ReturnParamList[0] = 1001;
			}
			else
			{
				ReturnParamList[0] = 1000;
			}
			result = true;
			break;
		case NewBieModifyDataType.EnchantID:
		{
			GameObject gameObject2 = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.MiddleLayer, "Smithshop(Clone)/ScrollView/ViewPort/Content", true);
			if (gameObject2 == null)
			{
				Logger.LogErrorFormat("新手引导报错---[EnchantID]Smithshop路径错误, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				Toggle[] componentsInChildren4 = gameObject2.GetComponentsInChildren<Toggle>();
				if (componentsInChildren4 != null && componentsInChildren4.Length > 0)
				{
					ReturnParamList[0] = componentsInChildren4[0].gameObject.name;
					result = true;
				}
			}
			break;
		}
		case NewBieModifyDataType.EnchantMagicCardID:
		{
			GameObject gameObject3 = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.MiddleLayer, "Smithshop(Clone)/Magic/AddMagic/Right/ScrollView/ViewPort/Content", true);
			if (gameObject3 == null)
			{
				Logger.LogErrorFormat("新手引导报错---[EnchantMagicCardID]Smithshop路径错误, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				Toggle[] componentsInChildren5 = gameObject3.GetComponentsInChildren<Toggle>();
				if (componentsInChildren5 != null && componentsInChildren5.Length > 0)
				{
					ReturnParamList[0] = componentsInChildren5[0].gameObject.name;
					result = true;
				}
			}
			break;
		}
		case NewBieModifyDataType.AchievementPos:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count <= 0)
			{
				Logger.LogErrorFormat("新手引导报错---[AchievementPos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				ReturnParamList[0] = this.mCurGuideUnit.NeedSaveParamsList[0];
				result = true;
			}
			break;
		case NewBieModifyDataType.BranchMissionPos:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count <= 0)
			{
				Logger.LogErrorFormat("新手引导报错---[BranchMissionPos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				ReturnParamList[0] = this.mCurGuideUnit.NeedSaveParamsList[0];
				result = true;
			}
			break;
		case NewBieModifyDataType.DailyMissionPos:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count <= 0)
			{
				Logger.LogErrorFormat("新手引导报错---[DailyMissionPos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				ReturnParamList[0] = this.mCurGuideUnit.NeedSaveParamsList[0];
				result = true;
			}
			break;
		case NewBieModifyDataType.IconPath:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count <= 0)
			{
				Logger.LogErrorFormat("新手引导报错---[IconPath]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				int id = (int)this.mCurGuideUnit.NeedSaveParamsList[0];
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("新手引导报错---[IconPath]iSkillID错误, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					ReturnParamList[0] = tableItem.Icon;
					result = true;
				}
			}
			break;
		case NewBieModifyDataType.IconName:
			if (this.mCurGuideUnit == null || this.mCurGuideUnit.NeedSaveParamsList == null || this.mCurGuideUnit.NeedSaveParamsList.Count <= 0)
			{
				Logger.LogErrorFormat("新手引导报错---[IconName]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				int id2 = (int)this.mCurGuideUnit.NeedSaveParamsList[0];
				SkillTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(id2, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogErrorFormat("新手引导报错---[IconName]iSkillID错误, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					ReturnParamList[0] = tableItem2.Name;
					result = true;
				}
			}
			break;
		case NewBieModifyDataType.PreJobSkill:
			if (this.mCurGuideUnit == null)
			{
				Logger.LogErrorFormat("新手引导报错---[PreJobSkill]当前引导Unit为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
				if (tableItem3 == null)
				{
					Logger.LogErrorFormat("新手引导报错---预转职职业id不存在, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					SkillTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(tableItem3.ProJobSkills, string.Empty, string.Empty);
					if (tableItem4 == null)
					{
						Logger.LogErrorFormat("新手引导报错---预转职职业技能id不存在, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
						{
							this.mCurGuideTaskID,
							this.mCurrentIndex,
							this.mCurState
						});
					}
					else
					{
						ReturnParamList[0] = tableItem4.Icon;
						result = true;
					}
				}
			}
			break;
		case NewBieModifyDataType.PreJobName:
			if (this.mCurGuideUnit == null)
			{
				Logger.LogErrorFormat("新手引导报错---[PreJobSkill]当前引导Unit为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				JobTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
				if (tableItem5 == null)
				{
					Logger.LogErrorFormat("新手引导报错---预转职职业id不存在, PreChangeJobTableID = {0} CurGuideTaskID = {1}, mCurrentIndex = {2}, mCurState = {3}", new object[]
					{
						DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID,
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					ReturnParamList[0] = tableItem5.Name;
					ReturnParamList[1] = tableItem5.Name;
					result = true;
				}
			}
			break;
		case NewBieModifyDataType.MagicBoxPos:
			if (this.mCurGuideUnit == null)
			{
				Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				IGameBind gameBind4 = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PackageNewFrame)) as IGameBind;
				if (gameBind4 == null)
				{
					Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]IGameBind为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					RectTransform component5 = gameBind4.GetComponent<RectTransform>("Content/ItemListView/Viewport/Content");
					if (component5 == null)
					{
						Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]root为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
						{
							this.mCurGuideTaskID,
							this.mCurrentIndex,
							this.mCurState
						});
					}
					else
					{
						List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
						if (itemsByPackageType2 != null && itemsByPackageType2.Count > 0)
						{
							ulong num3 = 0UL;
							for (int num4 = 0; num4 < itemsByPackageType2.Count; num4++)
							{
								ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[num4]);
								if (item3 != null)
								{
									if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= item3.LevelLimit)
									{
										if (item3.SubType == 55)
										{
											num3 = item3.GUID;
											break;
										}
									}
								}
							}
							if (num3 == 0UL)
							{
								Logger.LogErrorFormat("Can not find MagicBox In Package", new object[0]);
							}
							else
							{
								ComGridBindItem[] componentsInChildren6 = component5.GetComponentsInChildren<ComGridBindItem>();
								for (int num5 = 0; num5 < componentsInChildren6.Length; num5++)
								{
									if (!(componentsInChildren6[num5] == null))
									{
										if (componentsInChildren6[num5].param1 != null && componentsInChildren6[num5].param2 != null)
										{
											if ((ulong)componentsInChildren6[num5].param2 == num3)
											{
												string text3 = (string)componentsInChildren6[num5].param1;
												string[] array3 = text3.Split(new char[]
												{
													'_'
												});
												if (array3.Length >= 2)
												{
													int num6 = int.Parse(array3[1]);
													ReturnParamList[0] = num6;
													ReturnParamList[1] = num3;
													result = true;
													break;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			break;
		case NewBieModifyDataType.FashionInPackagePos:
			if (this.mCurGuideUnit == null)
			{
				Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]所需数据为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
				{
					this.mCurGuideTaskID,
					this.mCurrentIndex,
					this.mCurState
				});
			}
			else
			{
				IGameBind gameBind5 = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PackageNewFrame)) as IGameBind;
				if (gameBind5 == null)
				{
					Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]IGameBind为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
					{
						this.mCurGuideTaskID,
						this.mCurrentIndex,
						this.mCurState
					});
				}
				else
				{
					RectTransform component6 = gameBind5.GetComponent<RectTransform>("Content/ItemListView/Viewport/Content");
					if (component6 == null)
					{
						Logger.LogErrorFormat("新手引导报错---[ChangedEquipInPackagePos]root为null, CurGuideTaskID = {0}, mCurrentIndex = {1}, mCurState = {2}", new object[]
						{
							this.mCurGuideTaskID,
							this.mCurrentIndex,
							this.mCurState
						});
					}
					else
					{
						List<ulong> itemsByPackageType3 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Fashion);
						if (itemsByPackageType3 != null && itemsByPackageType3.Count > 0)
						{
							ulong num7 = 0UL;
							for (int num8 = 0; num8 < itemsByPackageType3.Count; num8++)
							{
								ItemData item4 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType3[num8]);
								if (item4 != null)
								{
									if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= item4.LevelLimit)
									{
										if (item4.SubType == 12)
										{
											num7 = item4.GUID;
											break;
										}
									}
								}
							}
							if (num7 == 0UL)
							{
								Logger.LogErrorFormat("Can not find Fashion In Package", new object[0]);
							}
							else
							{
								ComGridBindItem[] componentsInChildren7 = component6.GetComponentsInChildren<ComGridBindItem>();
								for (int num9 = 0; num9 < componentsInChildren7.Length; num9++)
								{
									if (!(componentsInChildren7[num9] == null))
									{
										if (componentsInChildren7[num9].param1 != null && componentsInChildren7[num9].param2 != null)
										{
											if ((ulong)componentsInChildren7[num9].param2 == num7)
											{
												string text4 = (string)componentsInChildren7[num9].param1;
												string[] array4 = text4.Split(new char[]
												{
													'_'
												});
												if (array4.Length >= 2)
												{
													int num10 = int.Parse(array4[1]);
													ReturnParamList[0] = num10;
													ReturnParamList[1] = num7;
													result = true;
													break;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			break;
		}
		return result;
	}

	// Token: 0x04005585 RID: 21893
	private const int ParamNum = 3;

	// Token: 0x04005586 RID: 21894
	protected NewbieGuideManager mGuideManager;

	// Token: 0x04005587 RID: 21895
	private ComNewbieGuideBase mCurrentCom;

	// Token: 0x04005588 RID: 21896
	protected NewbieGuideTable.eNewbieGuideTask mCurGuideTaskID;

	// Token: 0x04005589 RID: 21897
	protected ComNewbieGuideControl.ControlState mCurState;

	// Token: 0x0400558A RID: 21898
	private int mCurrentIndex;

	// Token: 0x0400558B RID: 21899
	private NewbieGuideDataUnit mCurGuideUnit;

	// Token: 0x0400558C RID: 21900
	private bool _bNeedCheckNext;

	// Token: 0x0400558D RID: 21901
	private float fCheckTime;

	// Token: 0x0200100A RID: 4106
	public enum ControlState
	{
		// Token: 0x0400558F RID: 21903
		None,
		// Token: 0x04005590 RID: 21904
		Guiding,
		// Token: 0x04005591 RID: 21905
		Finish
	}
}
