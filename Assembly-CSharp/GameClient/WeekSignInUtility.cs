using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020012E7 RID: 4839
	public static class WeekSignInUtility
	{
		// Token: 0x0600BBB0 RID: 48048 RVA: 0x002B996C File Offset: 0x002B7D6C
		public static void OpenBoxOpenFrame(WeekSignInType weekSignInType, int awardItemId, int awardItemNumber)
		{
			BoxDataModel boxDataModel = new BoxDataModel();
			List<WeekSignInPreviewAwardDataModel> previewAwardItemDataModelListByWeekSignInType;
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				boxDataModel.BoxModelPath = "UIFlatten/Prefabs/Jar/EffUI_xiuzhenguan02";
				previewAwardItemDataModelListByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetPreviewAwardItemDataModelListByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn);
			}
			else
			{
				boxDataModel.BoxModelPath = "UIFlatten/Prefabs/Jar/EffUI_xiuzhenguan06";
				previewAwardItemDataModelListByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetPreviewAwardItemDataModelListByWeekSignInType(WeekSignInType.ActivityWeekSignIn);
			}
			for (int i = 0; i < previewAwardItemDataModelListByWeekSignInType.Count; i++)
			{
				CommonNewItemDataModel item = new CommonNewItemDataModel
				{
					ItemId = previewAwardItemDataModelListByWeekSignInType[i].ItemId,
					ItemCount = previewAwardItemDataModelListByWeekSignInType[i].ItemNumber
				};
				boxDataModel.CommonNewItemDataModelList.Add(item);
				if (previewAwardItemDataModelListByWeekSignInType[i].IsSpecialAward && previewAwardItemDataModelListByWeekSignInType[i].ItemId == awardItemId)
				{
					boxDataModel.IsSpecialAward = true;
				}
			}
			boxDataModel.AwardItemData = new CommonNewItemDataModel
			{
				ItemId = awardItemId,
				ItemCount = awardItemNumber
			};
			WeekSignInUtility.OpenBoxOpenFrame(boxDataModel);
		}

		// Token: 0x0600BBB1 RID: 48049 RVA: 0x002B9A5D File Offset: 0x002B7E5D
		public static void OpenBoxOpenFrame(BoxDataModel boxDataModel)
		{
			WeekSignInUtility.CloseBoxOpenFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<OpenBoxFrame>(FrameLayer.Middle, boxDataModel, string.Empty);
		}

		// Token: 0x0600BBB2 RID: 48050 RVA: 0x002B9A76 File Offset: 0x002B7E76
		public static void CloseBoxOpenFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OpenBoxFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<OpenBoxFrame>(null, false);
			}
		}

		// Token: 0x0600BBB3 RID: 48051 RVA: 0x002B9A94 File Offset: 0x002B7E94
		public static void OpenActiveFrameByNewPlayerWeekSignIn()
		{
			WeekSignInUtility.OpenActiveFrameByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn);
		}

		// Token: 0x0600BBB4 RID: 48052 RVA: 0x002B9A9C File Offset: 0x002B7E9C
		public static void OpenActiveFrameByActivityWeekSignIn()
		{
			WeekSignInUtility.OpenActiveFrameByWeekSignInType(WeekSignInType.ActivityWeekSignIn);
		}

		// Token: 0x0600BBB5 RID: 48053 RVA: 0x002B9AA4 File Offset: 0x002B7EA4
		private static void OpenActiveFrameByWeekSignInType(WeekSignInType weekSignInType)
		{
			if (weekSignInType != WeekSignInType.ActivityWeekSignIn && weekSignInType != WeekSignInType.NewPlayerWeekSignIn)
			{
				return;
			}
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 5400);
			}
			else
			{
				DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 5500);
			}
		}

		// Token: 0x0600BBB6 RID: 48054 RVA: 0x002B9AF4 File Offset: 0x002B7EF4
		public static void OnCloseWeekSignInAwardRecordFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<WeekSignInAwardRecordFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<WeekSignInAwardRecordFrame>(null, false);
			}
		}

		// Token: 0x0600BBB7 RID: 48055 RVA: 0x002B9B12 File Offset: 0x002B7F12
		public static void OnOpenWeekSignInAwardRecordFrame(int weekSignInType)
		{
			WeekSignInUtility.OnCloseWeekSignInAwardRecordFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<WeekSignInAwardRecordFrame>(FrameLayer.Middle, weekSignInType, string.Empty);
		}

		// Token: 0x0600BBB8 RID: 48056 RVA: 0x002B9B30 File Offset: 0x002B7F30
		public static List<WeekSignSumTable> GetWeekSignSumTableListByWeekSignSumTablesInType(WeekSignInType weekSignInType)
		{
			List<WeekSignSumTable> list = new List<WeekSignSumTable>();
			uint opActTypeByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetOpActTypeByWeekSignInType(weekSignInType);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<WeekSignSumTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				WeekSignSumTable weekSignSumTable = keyValuePair.Value as WeekSignSumTable;
				if (weekSignSumTable != null && (long)weekSignSumTable.opActType == (long)((ulong)opActTypeByWeekSignInType))
				{
					list.Add(weekSignSumTable);
				}
			}
			list.Sort((WeekSignSumTable x, WeekSignSumTable y) => x.weekSum.CompareTo(y.weekSum));
			return list;
		}

		// Token: 0x0600BBB9 RID: 48057 RVA: 0x002B9BCC File Offset: 0x002B7FCC
		public static int GetFirstTotalAwardItemIndex(WeekSignInType weekSignInType)
		{
			if (weekSignInType != WeekSignInType.ActivityWeekSignIn && weekSignInType != WeekSignInType.NewPlayerWeekSignIn)
			{
				return 0;
			}
			WeekSignInAwardDataModel weekSignInAwardDataModelByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInAwardDataModelByWeekSignInType(weekSignInType);
			if (weekSignInAwardDataModelByWeekSignInType == null || weekSignInAwardDataModelByWeekSignInType.AlreadyReceiveWeekList == null || weekSignInAwardDataModelByWeekSignInType.AlreadyReceiveWeekList.Count <= 0 || weekSignInAwardDataModelByWeekSignInType.AlreadySignInWeek <= 1U)
			{
				return 0;
			}
			for (int i = 0; i < weekSignInAwardDataModelByWeekSignInType.WeekSignSumTableList.Count; i++)
			{
				WeekSignSumTable weekSignSumTable = weekSignInAwardDataModelByWeekSignInType.WeekSignSumTableList[i];
				if (weekSignSumTable != null)
				{
					if ((ulong)weekSignInAwardDataModelByWeekSignInType.AlreadySignInWeek >= (ulong)((long)weekSignSumTable.weekSum))
					{
						bool flag = false;
						for (int j = 0; j < weekSignInAwardDataModelByWeekSignInType.AlreadyReceiveWeekList.Count; j++)
						{
							if ((ulong)weekSignInAwardDataModelByWeekSignInType.AlreadyReceiveWeekList[j] == (ulong)((long)weekSignSumTable.weekSum))
							{
								flag = true;
							}
						}
						if (!flag)
						{
							return i;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600BBBA RID: 48058 RVA: 0x002B9CB4 File Offset: 0x002B80B4
		public static WeekSignInAwardState GetWeekSignInTotalAwardState(WeekSignInType weekSignInType, WeekSignSumTable sumTable)
		{
			if (weekSignInType != WeekSignInType.ActivityWeekSignIn && weekSignInType != WeekSignInType.NewPlayerWeekSignIn)
			{
				return WeekSignInAwardState.UnFinished;
			}
			if (sumTable == null)
			{
				return WeekSignInAwardState.UnFinished;
			}
			WeekSignInAwardDataModel weekSignInAwardDataModelByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInAwardDataModelByWeekSignInType(weekSignInType);
			if (weekSignInAwardDataModelByWeekSignInType.AlreadyReceiveWeekList != null)
			{
				for (int i = 0; i < weekSignInAwardDataModelByWeekSignInType.AlreadyReceiveWeekList.Count; i++)
				{
					if ((ulong)weekSignInAwardDataModelByWeekSignInType.AlreadyReceiveWeekList[i] == (ulong)((long)sumTable.weekSum))
					{
						return WeekSignInAwardState.Received;
					}
				}
			}
			if ((ulong)weekSignInAwardDataModelByWeekSignInType.AlreadySignInWeek >= (ulong)((long)sumTable.weekSum))
			{
				return WeekSignInAwardState.Finished;
			}
			return WeekSignInAwardState.UnFinished;
		}

		// Token: 0x0600BBBB RID: 48059 RVA: 0x002B9D40 File Offset: 0x002B8140
		public static bool IsWeekSignInOpenByWeekSignInType(WeekSignInType weekSignInType)
		{
			OpActivityData weekSignInOpActivityDataByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInOpActivityDataByWeekSignInType(weekSignInType);
			return weekSignInOpActivityDataByWeekSignInType != null && weekSignInOpActivityDataByWeekSignInType.state == 1 && DataManager<TimeManager>.GetInstance().GetServerTime() <= weekSignInOpActivityDataByWeekSignInType.endTime;
		}

		// Token: 0x0600BBBC RID: 48060 RVA: 0x002B9D87 File Offset: 0x002B8187
		public static bool IsWeekSignInRedPointVisibleByWeekSignInType(WeekSignInType weekSignInType)
		{
			return WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(weekSignInType) && (WeekSignInUtility.IsWeekSignInShowRedPointByDailyLogin(weekSignInType) || WeekSignInUtility.IsWeekSignInTaskAwardCanReceived(weekSignInType) || WeekSignInUtility.IsWeekSignInTotalAwardCanReceived(weekSignInType));
		}

		// Token: 0x0600BBBD RID: 48061 RVA: 0x002B9DBE File Offset: 0x002B81BE
		public static bool IsWeekSignInVisibleByWeekSignInType(WeekSignInType weekSignInType)
		{
			return WeekSignInUtility.IsWeekSignInOpenByWeekSignInType(weekSignInType) && (WeekSignInUtility.IsWeekSignInTaskAwardCanDoOrReceived(weekSignInType) || WeekSignInUtility.IsWeekSignInTotalAwardCanReceived(weekSignInType));
		}

		// Token: 0x0600BBBE RID: 48062 RVA: 0x002B9DE8 File Offset: 0x002B81E8
		public static bool IsWeekSignInTaskAwardCanDoOrReceived(WeekSignInType weekSignInType)
		{
			OpActivityData weekSignInOpActivityDataByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInOpActivityDataByWeekSignInType(weekSignInType);
			if (weekSignInOpActivityDataByWeekSignInType == null || weekSignInOpActivityDataByWeekSignInType.tasks == null || weekSignInOpActivityDataByWeekSignInType.tasks.Length <= 0)
			{
				return false;
			}
			for (int i = 0; i < weekSignInOpActivityDataByWeekSignInType.tasks.Length; i++)
			{
				OpActTaskData opActTaskData = weekSignInOpActivityDataByWeekSignInType.tasks[i];
				if (opActTaskData != null)
				{
					OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(opActTaskData.dataid);
					if (limitTimeTaskData != null)
					{
						if (limitTimeTaskData.state == 1)
						{
							return true;
						}
						if (limitTimeTaskData.state == 2)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600BBBF RID: 48063 RVA: 0x002B9E88 File Offset: 0x002B8288
		public static bool IsWeekSignInTaskAwardCanReceived(WeekSignInType weekSignInType)
		{
			OpActivityData weekSignInOpActivityDataByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInOpActivityDataByWeekSignInType(weekSignInType);
			if (weekSignInOpActivityDataByWeekSignInType == null || weekSignInOpActivityDataByWeekSignInType.tasks == null || weekSignInOpActivityDataByWeekSignInType.tasks.Length <= 0)
			{
				return false;
			}
			for (int i = 0; i < weekSignInOpActivityDataByWeekSignInType.tasks.Length; i++)
			{
				OpActTaskData opActTaskData = weekSignInOpActivityDataByWeekSignInType.tasks[i];
				if (opActTaskData != null)
				{
					OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(opActTaskData.dataid);
					if (limitTimeTaskData != null)
					{
						if (limitTimeTaskData.state == 2)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600BBC0 RID: 48064 RVA: 0x002B9F1C File Offset: 0x002B831C
		public static bool IsWeekSignInTotalAwardCanReceived(WeekSignInType weekSignInType)
		{
			WeekSignInAwardDataModel weekSignInAwardDataModelByWeekSignInType = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInAwardDataModelByWeekSignInType(weekSignInType);
			return weekSignInAwardDataModelByWeekSignInType != null && weekSignInType == weekSignInAwardDataModelByWeekSignInType.WeekSignInType && weekSignInAwardDataModelByWeekSignInType.IsTotalAwardCanReceived();
		}

		// Token: 0x0600BBC1 RID: 48065 RVA: 0x002B9F5C File Offset: 0x002B835C
		public static bool IsWeekSignInShowRedPointByDailyLogin(WeekSignInType weekSignInType)
		{
			string arg = "ActivityWeekSignIn";
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				arg = "NewPlayerWeekSignIn";
			}
			string text = DataManager<PlayerBaseData>.GetInstance().RoleID + arg;
			if (!PlayerPrefs.HasKey(text))
			{
				return true;
			}
			string @string = PlayerPrefs.GetString(text);
			if (string.IsNullOrEmpty(@string))
			{
				return true;
			}
			ulong beginTime = ulong.Parse(@string);
			return !TimeUtility.IsSameDayOfTwoTime(beginTime, (ulong)DataManager<TimeManager>.GetInstance().GetServerTime());
		}

		// Token: 0x0600BBC2 RID: 48066 RVA: 0x002B9FD4 File Offset: 0x002B83D4
		public static void SetWeekSignInShowRedPointTimeByDailyLogin(WeekSignInType weekSignInType)
		{
			string arg = "ActivityWeekSignIn";
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				arg = "NewPlayerWeekSignIn";
			}
			string text = DataManager<TimeManager>.GetInstance().GetServerTime().ToString();
			string text2 = DataManager<PlayerBaseData>.GetInstance().RoleID + arg;
			if (!PlayerPrefs.HasKey(text2))
			{
				PlayerPrefs.SetString(text2, text);
				WeekSignInUtility.SendRedPointUpdateByChangeDailyLoginTime(weekSignInType);
				return;
			}
			string @string = PlayerPrefs.GetString(text2);
			if (string.IsNullOrEmpty(@string))
			{
				PlayerPrefs.SetString(text2, text);
				WeekSignInUtility.SendRedPointUpdateByChangeDailyLoginTime(weekSignInType);
				return;
			}
			ulong beginTime = ulong.Parse(@string);
			if (!TimeUtility.IsSameDayOfTwoTime(beginTime, (ulong)DataManager<TimeManager>.GetInstance().GetServerTime()))
			{
				PlayerPrefs.SetString(text2, text);
				WeekSignInUtility.SendRedPointUpdateByChangeDailyLoginTime(weekSignInType);
				return;
			}
		}

		// Token: 0x0600BBC3 RID: 48067 RVA: 0x002BA08C File Offset: 0x002B848C
		private static void SendRedPointUpdateByChangeDailyLoginTime(WeekSignInType weekSignInType)
		{
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, null, null, null, null);
			}
			else if (weekSignInType == WeekSignInType.ActivityWeekSignIn)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnActivityWeekSignInRedPointChanged, null, null, null, null);
			}
		}
	}
}
