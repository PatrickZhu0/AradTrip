using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A8F RID: 6799
	public class MonthlySignInFrameView : MonoBehaviour
	{
		// Token: 0x06010B03 RID: 68355 RVA: 0x004BB6B0 File Offset: 0x004B9AB0
		private void Start()
		{
			this.itemDataList = null;
			this.InitItems();
			this.UpdateMonthlySignInItems();
			this.UpdateMonthlySignInCountInfo();
			this.UpdateAccumulativeSignInItemInfo();
			this.BindUIEvent();
			DataManager<ActivityDataManager>.GetInstance().SendMonthlySignInQuery();
			DateTime d = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
			DateTime d2 = default(DateTime);
			if (d.Hour < 6)
			{
				d2 = new DateTime(d.Year, d.Month, d.Day, 6, 0, 1);
			}
			else
			{
				DateTime dateTime = d.AddDays(1.0);
				d2 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 6, 0, 1);
			}
			float fDelyTime = (float)(d2 - d).TotalSeconds;
			InvokeMethod.Invoke(this, fDelyTime, delegate()
			{
				this.bInitScrollBarPos = false;
				DataManager<ActivityDataManager>.GetInstance().SendMonthlySignInQuery();
			});
		}

		// Token: 0x06010B04 RID: 68356 RVA: 0x004BB790 File Offset: 0x004B9B90
		private void OnDestroy()
		{
			this.itemDataList = null;
			this.UnBindUIEvent();
			InvokeMethod.RemoveInvokeCall(this);
			this.bInitScrollBarPos = false;
		}

		// Token: 0x06010B05 RID: 68357 RVA: 0x004BB7AC File Offset: 0x004B9BAC
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateMonthlySignInCountInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateMonthlySignInCountInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateMonthlySignInItemInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateMonthlySignInItemInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateAccumulativeSignInItemInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateAccumulativeSignInItemInfo));
		}

		// Token: 0x06010B06 RID: 68358 RVA: 0x004BB80C File Offset: 0x004B9C0C
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateMonthlySignInCountInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateMonthlySignInCountInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateMonthlySignInItemInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateMonthlySignInItemInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateAccumulativeSignInItemInfo, new ClientEventSystem.UIEventHandler(this._OnUpdateAccumulativeSignInItemInfo));
		}

		// Token: 0x06010B07 RID: 68359 RVA: 0x004BB86C File Offset: 0x004B9C6C
		private void InitItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.itemList.Initialize();
			this.itemList.onBindItem = delegate(GameObject go)
			{
				MonthlySignInItem result = null;
				if (go)
				{
					result = go.GetComponent<MonthlySignInItem>();
				}
				return result;
			};
			this.itemList.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				this.UpdateSignInItem(var1);
			};
		}

		// Token: 0x06010B08 RID: 68360 RVA: 0x004BB8D8 File Offset: 0x004B9CD8
		private void UpdateSignInItem(ComUIListElementScript var1)
		{
			if (var1 == null)
			{
				return;
			}
			int index = var1.m_index;
			if (index >= 0 && this.itemDataList != null && index < this.itemDataList.Count)
			{
				MonthlySignInItem monthlySignInItem = var1.gameObjectBindScript as MonthlySignInItem;
				if (monthlySignInItem != null)
				{
					monthlySignInItem.SetUp(this.itemDataList[index]);
				}
			}
		}

		// Token: 0x06010B09 RID: 68361 RVA: 0x004BB946 File Offset: 0x004B9D46
		private void CalItemDataList()
		{
			this.itemDataList = null;
			this.itemDataList = DataManager<ActivityDataManager>.GetInstance().GetMonthlySignInItemDatas();
		}

		// Token: 0x06010B0A RID: 68362 RVA: 0x004BB960 File Offset: 0x004B9D60
		private void UpdateMonthlySignInItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.CalItemDataList();
			if (this.itemDataList != null)
			{
				this.itemList.SetElementAmount(0);
				this.itemList.SetElementAmount(this.itemDataList.Count);
			}
		}

		// Token: 0x06010B0B RID: 68363 RVA: 0x004BB9B4 File Offset: 0x004B9DB4
		private void UpdateMonthlySignInCountInfo()
		{
			ActivityDataManager.MonthlySignInCountInfo monthlySignInCountInfo = DataManager<ActivityDataManager>.GetInstance().GetMonthlySignInCountInfo();
			if (monthlySignInCountInfo == null)
			{
				return;
			}
			DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
			if (dateTime.Hour < 6)
			{
				dateTime = dateTime.AddDays(-1.0);
			}
			int monthDayNum = ActivityDataManager.GetMonthDayNum(dateTime.Year, dateTime.Month);
			this.totalSign.SafeSetText(TR.Value("total_sign", DataManager<ActivityDataManager>.GetInstance().GetHasSignInCount(), monthDayNum));
			this.livenessCount.SafeSetText(TR.Value("liveness_count", monthlySignInCountInfo.activite));
			this.leftCount.SafeSetText(TR.Value("left_count2", (int)(monthlySignInCountInfo.noFree + monthlySignInCountInfo.free)));
			this.liveness.SafeSetText(TR.Value("liveness", DataManager<MissionManager>.GetInstance().Score));
			this.liveness2.SafeSetText(TR.Value("liveness2", Utility.GetSystemValueFromTable(SystemValueTable.eType2.SVT_SIGN_NEW_ACTIVITE), Utility.GetSystemValueFromTable(SystemValueTable.eType2.SVT_SIGN_NEW_ACTIVITE) - (int)monthlySignInCountInfo.accumulatedActivite));
		}

		// Token: 0x06010B0C RID: 68364 RVA: 0x004BBAE4 File Offset: 0x004B9EE4
		private void UpdateAccumulativeSignInItemInfo()
		{
			List<AccumulativeSignInItem> list = new List<AccumulativeSignInItem>();
			if (list == null)
			{
				return;
			}
			list.Add(this.accumulativeSignIn1);
			list.Add(this.accumulativeSignIn2);
			list.Add(this.accumulativeSignIn3);
			list.Add(this.accumulativeSignIn4);
			List<ActivityDataManager.AccumulativeSignInItemData> accumulativeSignInItemDatas = DataManager<ActivityDataManager>.GetInstance().GetAccumulativeSignInItemDatas();
			if (accumulativeSignInItemDatas == null)
			{
				return;
			}
			int num = 0;
			while (num < list.Count && num < accumulativeSignInItemDatas.Count)
			{
				list[num].SetUp(accumulativeSignInItemDatas[num]);
				num++;
			}
			float[,] array = new float[,]
			{
				{
					0.135f,
					0.292f
				},
				{
					0.427f,
					0.575f
				},
				{
					0.71f,
					0.875f
				}
			};
			if (this.accumulativeProcess != null)
			{
				this.accumulativeProcess.value = 0f;
				int num2 = -1;
				int hasSignInCount = DataManager<ActivityDataManager>.GetInstance().GetHasSignInCount();
				for (int i = 0; i < accumulativeSignInItemDatas.Count; i++)
				{
					ActivityDataManager.AccumulativeSignInItemData accumulativeSignInItemData = accumulativeSignInItemDatas[i];
					if (accumulativeSignInItemData != null)
					{
						if (hasSignInCount >= accumulativeSignInItemData.accumulativeDay)
						{
							num2++;
						}
					}
				}
				if (num2 < 0)
				{
					this.accumulativeProcess.value = 0f;
				}
				else if (num2 >= array.GetLength(0))
				{
					this.accumulativeProcess.value = array[2, 1];
				}
				else
				{
					float num3 = array[num2, 0];
					float num4 = array[num2, 1];
					this.accumulativeProcess.value = num3 + (num4 - num3) * ((float)(hasSignInCount - accumulativeSignInItemDatas[num2].accumulativeDay) / (float)(accumulativeSignInItemDatas[num2 + 1].accumulativeDay - accumulativeSignInItemDatas[num2].accumulativeDay));
				}
			}
		}

		// Token: 0x06010B0D RID: 68365 RVA: 0x004BBC9C File Offset: 0x004BA09C
		private void _OnUpdateMonthlySignInItemInfo(UIEvent uiEvent)
		{
			this.UpdateMonthlySignInItems();
			if (!this.bInitScrollBarPos)
			{
				this.bInitScrollBarPos = true;
				if (this.itemList != null)
				{
					DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
					if (dateTime.Hour < 6)
					{
						dateTime = dateTime.AddDays(-1.0);
					}
					if (dateTime.Day > 21)
					{
						this.itemList.m_scrollRect.verticalNormalizedPosition = 0f;
					}
					else
					{
						this.itemList.m_scrollRect.verticalNormalizedPosition = 1f;
					}
				}
			}
		}

		// Token: 0x06010B0E RID: 68366 RVA: 0x004BBD3D File Offset: 0x004BA13D
		private void _OnUpdateMonthlySignInCountInfo(UIEvent uiEvent)
		{
			this.UpdateMonthlySignInCountInfo();
		}

		// Token: 0x06010B0F RID: 68367 RVA: 0x004BBD45 File Offset: 0x004BA145
		private void _OnUpdateAccumulativeSignInItemInfo(UIEvent uiEvent)
		{
			this.UpdateAccumulativeSignInItemInfo();
		}

		// Token: 0x0400AAA9 RID: 43689
		private List<ActivityDataManager.MonthlySignInItemData> itemDataList;

		// Token: 0x0400AAAA RID: 43690
		private bool bInitScrollBarPos;

		// Token: 0x0400AAAB RID: 43691
		[SerializeField]
		private ComUIListScript itemList;

		// Token: 0x0400AAAC RID: 43692
		[SerializeField]
		private AccumulativeSignInItem accumulativeSignIn1;

		// Token: 0x0400AAAD RID: 43693
		[SerializeField]
		private AccumulativeSignInItem accumulativeSignIn2;

		// Token: 0x0400AAAE RID: 43694
		[SerializeField]
		private AccumulativeSignInItem accumulativeSignIn3;

		// Token: 0x0400AAAF RID: 43695
		[SerializeField]
		private AccumulativeSignInItem accumulativeSignIn4;

		// Token: 0x0400AAB0 RID: 43696
		[SerializeField]
		private Text totalSign;

		// Token: 0x0400AAB1 RID: 43697
		[SerializeField]
		private Text livenessCount;

		// Token: 0x0400AAB2 RID: 43698
		[SerializeField]
		private Text leftCount;

		// Token: 0x0400AAB3 RID: 43699
		[SerializeField]
		private Text liveness;

		// Token: 0x0400AAB4 RID: 43700
		[SerializeField]
		private Text liveness2;

		// Token: 0x0400AAB5 RID: 43701
		[SerializeField]
		private Slider accumulativeProcess;
	}
}
