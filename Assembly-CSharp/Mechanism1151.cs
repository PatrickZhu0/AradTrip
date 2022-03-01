using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x020042C7 RID: 17095
public class Mechanism1151 : BeMechanism
{
	// Token: 0x06017A75 RID: 96885 RVA: 0x0074A008 File Offset: 0x00748408
	public Mechanism1151(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017A76 RID: 96886 RVA: 0x0074A020 File Offset: 0x00748420
	public override void OnInit()
	{
		this.mHasBuffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017A77 RID: 96887 RVA: 0x0074A080 File Offset: 0x00748480
	public override void OnStart()
	{
		BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(this.mBuffInfoID, string.Empty, string.Empty);
		if (tableItem != null && tableItem.BuffID == this.mHasBuffID)
		{
			return;
		}
		this.RemoveAllBuffInfo();
		if (base.owner != null && base.owner.buffController != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onAddBuff, new BeEventHandle.Del(this.OnAddBuffEvent));
			this.handleB = base.owner.RegisterEvent(BeEventType.onRemoveBuff, new BeEventHandle.Del(this.OnRemoveBuffEvent));
			this.InitBuffInfo();
		}
	}

	// Token: 0x06017A78 RID: 96888 RVA: 0x0074A125 File Offset: 0x00748525
	public override void OnFinish()
	{
		this.RemoveAllBuffInfo();
	}

	// Token: 0x06017A79 RID: 96889 RVA: 0x0074A130 File Offset: 0x00748530
	private void InitBuffInfo()
	{
		int buffCountByID = base.owner.buffController.GetBuffCountByID(this.mHasBuffID);
		if (buffCountByID > 0)
		{
			this.AddBuffInfoByCount(buffCountByID);
		}
	}

	// Token: 0x06017A7A RID: 96890 RVA: 0x0074A164 File Offset: 0x00748564
	private void OnAddBuffEvent(object[] args)
	{
		BeBuff beBuff = args[0] as BeBuff;
		if (beBuff != null && beBuff.buffID == this.mHasBuffID)
		{
			this.AddBuffInfoByCount(1);
		}
	}

	// Token: 0x06017A7B RID: 96891 RVA: 0x0074A198 File Offset: 0x00748598
	private void OnRemoveBuffEvent(object[] args)
	{
		int num = (int)args[0];
		if (num == this.mHasBuffID)
		{
			this.RemoveOneBuffInfo();
		}
	}

	// Token: 0x06017A7C RID: 96892 RVA: 0x0074A1C0 File Offset: 0x007485C0
	private void AddBuffInfoByCount(int count = 1)
	{
		for (int i = 0; i < count; i++)
		{
			this.mBuffInfoList.Add(base.owner.buffController.TryAddBuff(this.mBuffInfoID, base.owner, false, null, 0));
		}
	}

	// Token: 0x06017A7D RID: 96893 RVA: 0x0074A20C File Offset: 0x0074860C
	private void RemoveAllBuffInfo()
	{
		if (this.mBuffInfoList != null && base.owner != null && base.owner.buffController != null)
		{
			for (int i = 0; i < this.mBuffInfoList.Count; i++)
			{
				if (this.mBuffInfoList[i] != null)
				{
					base.owner.buffController.RemoveBuff(this.mBuffInfoList[i]);
				}
			}
			this.mBuffInfoList.Clear();
		}
	}

	// Token: 0x06017A7E RID: 96894 RVA: 0x0074A294 File Offset: 0x00748694
	private void RemoveOneBuffInfo()
	{
		if (this.mBuffInfoList != null && base.owner != null && base.owner.buffController != null && this.mBuffInfoList.Count > 0)
		{
			BeBuff buff = this.mBuffInfoList[this.mBuffInfoList.Count - 1];
			this.mBuffInfoList.RemoveAt(this.mBuffInfoList.Count - 1);
			base.owner.buffController.RemoveBuff(buff);
		}
	}

	// Token: 0x04010FFD RID: 69629
	private int mHasBuffID;

	// Token: 0x04010FFE RID: 69630
	private int mBuffInfoID;

	// Token: 0x04010FFF RID: 69631
	private List<BeBuff> mBuffInfoList = new List<BeBuff>();
}
