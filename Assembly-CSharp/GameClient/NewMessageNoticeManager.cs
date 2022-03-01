using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012B5 RID: 4789
	public class NewMessageNoticeManager : DataManager<NewMessageNoticeManager>
	{
		// Token: 0x0600B8B0 RID: 47280 RVA: 0x002A50C2 File Offset: 0x002A34C2
		public override void Initialize()
		{
			this.mDataVersion = ulong.MaxValue;
			if (this.newMessageNoticesList == null)
			{
				this.newMessageNoticesList = new List<NewMessageNoticeData>();
			}
			this.SetDataDirty();
		}

		// Token: 0x0600B8B1 RID: 47281 RVA: 0x002A50E8 File Offset: 0x002A34E8
		public override void Clear()
		{
			this.ClearNewMessageNotice();
			this.SetDataDirty();
		}

		// Token: 0x17001B3D RID: 6973
		// (get) Token: 0x0600B8B2 RID: 47282 RVA: 0x002A50F6 File Offset: 0x002A34F6
		public ulong DataVersion
		{
			get
			{
				return this.mDataVersion;
			}
		}

		// Token: 0x17001B3E RID: 6974
		// (get) Token: 0x0600B8B3 RID: 47283 RVA: 0x002A50FE File Offset: 0x002A34FE
		public bool DataDirty
		{
			get
			{
				return this.mDataDirty;
			}
		}

		// Token: 0x0600B8B4 RID: 47284 RVA: 0x002A5106 File Offset: 0x002A3506
		public void SetDataDirty()
		{
			this.mDataVersion += 1UL;
			this.mDataDirty = true;
		}

		// Token: 0x0600B8B5 RID: 47285 RVA: 0x002A5120 File Offset: 0x002A3520
		protected NewMessageNoticeData AddNewMessageNotice(string tag, string title, string message, object userdata, Action<NewMessageNoticeData> forwordAction, bool bUnique)
		{
			if (string.IsNullOrEmpty(tag))
			{
				Logger.LogError("[NewMessageNoticeManager] AddNewMessageNotice - Tag Can not be Null or Empty");
				return null;
			}
			if (bUnique)
			{
				this.RemoveNewMessageNoticeByTag(tag);
			}
			NewMessageNoticeData newMessageNoticeData = new NewMessageNoticeData(tag)
			{
				mTitle = title,
				mMessage = message,
				mUserdata = userdata,
				mForwardAction = forwordAction
			};
			this.newMessageNoticesList.Insert(0, newMessageNoticeData);
			this.SetDataDirty();
			return newMessageNoticeData;
		}

		// Token: 0x0600B8B6 RID: 47286 RVA: 0x002A518D File Offset: 0x002A358D
		public NewMessageNoticeData AddNewMessageNotice(string tag, object userdata, Action<NewMessageNoticeData> forwordAction, bool bUnique)
		{
			return this.AddNewMessageNotice(tag, TR.Value(tag + "_title"), TR.Value(tag + "_message"), userdata, forwordAction, bUnique);
		}

		// Token: 0x0600B8B7 RID: 47287 RVA: 0x002A51BA File Offset: 0x002A35BA
		public NewMessageNoticeData AddNewMessageNoticeWhenNoExist(string tag, object userdata, Action<NewMessageNoticeData> forwordAction)
		{
			if (this.IsNewMessageNoticeExsits(tag))
			{
				return null;
			}
			return this.AddNewMessageNotice(tag, userdata, forwordAction, true);
		}

		// Token: 0x0600B8B8 RID: 47288 RVA: 0x002A51D4 File Offset: 0x002A35D4
		public void MarkAllRead()
		{
			for (int i = 0; i < this.mNewMessageNoticeCount; i++)
			{
				NewMessageNoticeData newMessageNoticeByIndex = this.GetNewMessageNoticeByIndex(i);
				if (newMessageNoticeByIndex != null)
				{
					newMessageNoticeByIndex.bReaded = true;
				}
			}
			this.SetDataDirty();
		}

		// Token: 0x0600B8B9 RID: 47289 RVA: 0x002A5214 File Offset: 0x002A3614
		public int GetUnReadCount()
		{
			int num = 0;
			for (int i = 0; i < this.mNewMessageNoticeCount; i++)
			{
				NewMessageNoticeData newMessageNoticeByIndex = this.GetNewMessageNoticeByIndex(i);
				if (newMessageNoticeByIndex != null && !newMessageNoticeByIndex.bReaded)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600B8BA RID: 47290 RVA: 0x002A5258 File Offset: 0x002A3658
		public void RemoveNewMessageNotice(NewMessageNoticeData data)
		{
			this.SetDataDirty();
			this.newMessageNoticesList.Remove(data);
		}

		// Token: 0x0600B8BB RID: 47291 RVA: 0x002A5270 File Offset: 0x002A3670
		public void RemoveNewMessageNoticeByTag(string tag)
		{
			List<NewMessageNoticeData> list = this.newMessageNoticesList.FindAll((NewMessageNoticeData current) => current.mTag.Equals(tag));
			for (int i = 0; i < list.Count; i++)
			{
				this.newMessageNoticesList.Remove(list[i]);
				this.SetDataDirty();
			}
		}

		// Token: 0x0600B8BC RID: 47292 RVA: 0x002A52D2 File Offset: 0x002A36D2
		public void ClearNewMessageNotice()
		{
			this.newMessageNoticesList.Clear();
			this.SetDataDirty();
		}

		// Token: 0x17001B3F RID: 6975
		// (get) Token: 0x0600B8BD RID: 47293 RVA: 0x002A52E5 File Offset: 0x002A36E5
		public int mNewMessageNoticeCount
		{
			get
			{
				return this.newMessageNoticesList.Count;
			}
		}

		// Token: 0x0600B8BE RID: 47294 RVA: 0x002A52F2 File Offset: 0x002A36F2
		public NewMessageNoticeData GetNewMessageNoticeByIndex(int index)
		{
			if (index < 0 || index >= this.mNewMessageNoticeCount)
			{
				return null;
			}
			return this.newMessageNoticesList[index];
		}

		// Token: 0x0600B8BF RID: 47295 RVA: 0x002A5315 File Offset: 0x002A3715
		public void Update()
		{
			this.newMessageNoticesList.RemoveAll((NewMessageNoticeData item) => item.mNotUse);
		}

		// Token: 0x0600B8C0 RID: 47296 RVA: 0x002A5340 File Offset: 0x002A3740
		public List<NewMessageNoticeData> GetNewMessageNoticeByTag(string tag)
		{
			return this.newMessageNoticesList.FindAll((NewMessageNoticeData current) => current.mTag.Equals(tag));
		}

		// Token: 0x0600B8C1 RID: 47297 RVA: 0x002A5374 File Offset: 0x002A3774
		public bool IsNewMessageNoticeExsits(string tag)
		{
			return this.newMessageNoticesList.Exists((NewMessageNoticeData current) => current.mTag.Equals(tag));
		}

		// Token: 0x04006812 RID: 26642
		private ulong mDataVersion;

		// Token: 0x04006813 RID: 26643
		private bool mDataDirty;

		// Token: 0x04006814 RID: 26644
		protected List<NewMessageNoticeData> newMessageNoticesList = new List<NewMessageNoticeData>();
	}
}
