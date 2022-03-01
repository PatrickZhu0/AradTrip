using System;
using ProtoTable;

// Token: 0x020042E3 RID: 17123
public class Mechanism1176 : BeMechanism
{
	// Token: 0x06017B1B RID: 97051 RVA: 0x0074D467 File Offset: 0x0074B867
	public Mechanism1176(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B1C RID: 97052 RVA: 0x0074D474 File Offset: 0x0074B874
	public override void OnInit()
	{
		base.OnInit();
		this.m_BuffInfoIdList = new int[this.data.ValueALength];
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.m_BuffInfoIdList[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.m_CDBuffId = 0;
		this.m_CDBuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(this.m_CDBuffInfoId, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.m_CDBuffId = tableItem.BuffID;
		}
	}

	// Token: 0x06017B1D RID: 97053 RVA: 0x0074D544 File Offset: 0x0074B944
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.OnChangeWeapon, new BeEventHandle.Del(this.OnChangeWeapon));
	}

	// Token: 0x06017B1E RID: 97054 RVA: 0x0074D56C File Offset: 0x0074B96C
	public override void OnFinish()
	{
		base.OnFinish();
		for (int i = 0; i < this.m_BuffInfoIdList.Length; i++)
		{
			base.owner.buffController.RemoveBuffByBuffInfoID(this.m_BuffInfoIdList[i]);
		}
	}

	// Token: 0x06017B1F RID: 97055 RVA: 0x0074D5B0 File Offset: 0x0074B9B0
	private void OnChangeWeapon(object[] args)
	{
		if (this.m_CDBuffId > 0)
		{
			if (base.owner.buffController.HasBuffByID(this.m_CDBuffId) != null)
			{
				return;
			}
			base.owner.buffController.TryAddBuffInfo(this.m_CDBuffInfoId, base.owner, this.level);
		}
		for (int i = 0; i < this.m_BuffInfoIdList.Length; i++)
		{
			base.owner.buffController.TryAddBuffInfo(this.m_BuffInfoIdList[i], base.owner, this.level);
		}
	}

	// Token: 0x04011066 RID: 69734
	private int[] m_BuffInfoIdList;

	// Token: 0x04011067 RID: 69735
	private int m_CDBuffInfoId;

	// Token: 0x04011068 RID: 69736
	private int m_CDBuffId;
}
