using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001131 RID: 4401
	public class SelectOccupationFrame : ClientFrame
	{
		// Token: 0x0600A748 RID: 42824 RVA: 0x0022E23B File Offset: 0x0022C63B
		protected sealed override void _bindExUI()
		{
			this.mSelectOccupationView = this.mBind.GetCom<SelectOccupationView>("SelectOccupationView");
		}

		// Token: 0x0600A749 RID: 42825 RVA: 0x0022E253 File Offset: 0x0022C653
		protected sealed override void _unbindExUI()
		{
			this.mSelectOccupationView = null;
		}

		// Token: 0x0600A74A RID: 42826 RVA: 0x0022E25C File Offset: 0x0022C65C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/SelectOccupationFrame";
		}

		// Token: 0x0600A74B RID: 42827 RVA: 0x0022E264 File Offset: 0x0022C664
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				uint[] array = this.userData as uint[];
				if (array != null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						this.selectOccuIDs.Add((int)array[i]);
					}
				}
				else
				{
					Logger.LogError("吃鸡选择职业界面报错，occuList == null");
				}
			}
			else
			{
				Logger.LogError("吃鸡选择职业界面报错，userData == null");
			}
			if (this.mSelectOccupationView != null)
			{
				this.mSelectOccupationView.InitView(this.selectOccuIDs, new OnSelectJobClick(this._OnSelectJobClick));
			}
		}

		// Token: 0x0600A74C RID: 42828 RVA: 0x0022E2FC File Offset: 0x0022C6FC
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SelectMapAreaFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A74D RID: 42829 RVA: 0x0022E318 File Offset: 0x0022C718
		private void InitJobList()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.JobType != 0)
			{
				this.selectOccuIDs.Add(tableItem.ID);
			}
			List<int> list = new List<int>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					JobTable jobTable = keyValuePair.Value as JobTable;
					if (jobTable != null)
					{
						if (tableItem.JobType == 0 || jobTable.ID != DataManager<PlayerBaseData>.GetInstance().JobTableID)
						{
							if (jobTable.ID != 16)
							{
								if (jobTable.Open != 0)
								{
									if (jobTable.JobType != 0)
									{
										list.Add(jobTable.ID);
									}
								}
							}
						}
					}
				}
			}
			if (tableItem.JobType != 0)
			{
				int index = this.RandomNumber(0, list.Count / 2);
				this.Add(list[index]);
				int index2 = this.RandomNumber(list.Count / 2, list.Count);
				this.Add(list[index2]);
			}
			else
			{
				int index3 = this.RandomNumber(0, list.Count / 3);
				this.Add(list[index3]);
				int index4 = this.RandomNumber(list.Count / 3, 2 * list.Count / 3);
				this.Add(list[index4]);
				int index5 = this.RandomNumber(2 * list.Count / 3, list.Count);
				this.Add(list[index5]);
			}
		}

		// Token: 0x0600A74E RID: 42830 RVA: 0x0022E4E0 File Offset: 0x0022C8E0
		private int RandomNumber(int min, int max)
		{
			return Random.Range(min, max);
		}

		// Token: 0x0600A74F RID: 42831 RVA: 0x0022E4E9 File Offset: 0x0022C8E9
		private void Add(int jobId)
		{
			if (!this.selectOccuIDs.Contains(jobId))
			{
				this.selectOccuIDs.Add(jobId);
			}
		}

		// Token: 0x0600A750 RID: 42832 RVA: 0x0022E508 File Offset: 0x0022C908
		private void _ClearData()
		{
			if (this.selectOccuIDs != null)
			{
				this.selectOccuIDs.Clear();
			}
		}

		// Token: 0x0600A751 RID: 42833 RVA: 0x0022E520 File Offset: 0x0022C920
		protected void _OnSelectJobClick(int jobId)
		{
			DataManager<ChijiDataManager>.GetInstance().SendSelectJobId(jobId);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SelectOccupationFrame>(null, false);
		}

		// Token: 0x04005D9C RID: 23964
		private SelectOccupationView mSelectOccupationView;

		// Token: 0x04005D9D RID: 23965
		private List<int> selectOccuIDs = new List<int>();
	}
}
