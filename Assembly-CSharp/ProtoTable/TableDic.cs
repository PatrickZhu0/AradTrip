using System;
using System.Collections.Generic;

namespace ProtoTable
{
	// Token: 0x0200025A RID: 602
	public class TableDic<T> : TableData
	{
		// Token: 0x06001385 RID: 4997 RVA: 0x00068B0E File Offset: 0x00066F0E
		public override void Init()
		{
			this.InstanceDic = this;
			if (this.InstanceDic != null)
			{
				this.InitInternal();
			}
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x00068B30 File Offset: 0x00066F30
		public override void BuildData(object[] data)
		{
			this.data = new T[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				T t = (T)((object)data[i]);
				this.data[i] = t;
			}
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x00068B78 File Offset: 0x00066F78
		public override IEnumerable<object> GetData()
		{
			if (this.InstanceDic.data == null)
			{
				yield break;
			}
			foreach (T obj in this.InstanceDic.data)
			{
				yield return obj;
			}
			yield break;
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x00068B9B File Offset: 0x00066F9B
		public new T[] GetAll()
		{
			return this.data;
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x00068BA3 File Offset: 0x00066FA3
		public override Dictionary<int, object> GetMap()
		{
			return this.InstanceDic.dataMap;
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x00068BB0 File Offset: 0x00066FB0
		public override bool IsEmpty()
		{
			return this.InstanceDic.data == null || this.InstanceDic.data.Length == 0;
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x00068BD8 File Offset: 0x00066FD8
		private bool InitInternal()
		{
			this.InstanceDic.dataMap.Clear();
			int num = 0;
			foreach (T obj in this.InstanceDic.data)
			{
				num++;
				int key = ((ITable)obj).GetKey();
				if (this.InstanceDic.dataMap.ContainsKey(key))
				{
				}
				this.InstanceDic.dataMap.Add(key, obj);
			}
			this.OnInitComplete();
			return true;
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x00068C66 File Offset: 0x00067066
		protected virtual void OnInitComplete()
		{
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x00068C68 File Offset: 0x00067068
		public bool HasItem(int entry)
		{
			return this.dataMap.ContainsKey(entry);
		}

		// Token: 0x04000D3E RID: 3390
		public T[] data;

		// Token: 0x04000D3F RID: 3391
		private Dictionary<int, object> dataMap = new Dictionary<int, object>();

		// Token: 0x04000D40 RID: 3392
		protected TableDic<T> InstanceDic;
	}
}
