using System;

// Token: 0x020042A1 RID: 17057
public class Mechanism1095 : BeMechanism
{
	// Token: 0x06017999 RID: 96665 RVA: 0x00744FB0 File Offset: 0x007433B0
	public Mechanism1095(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601799A RID: 96666 RVA: 0x00744FBC File Offset: 0x007433BC
	public override void OnInit()
	{
		this.mTagBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.mAddBuffInfo = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x0601799B RID: 96667 RVA: 0x00745019 File Offset: 0x00743419
	public override void OnStart()
	{
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onAddTriggerBuff, new BeEventHandle.Del(this.OnAddTriggerBuffEvent));
		}
	}

	// Token: 0x0601799C RID: 96668 RVA: 0x00745048 File Offset: 0x00743448
	private void OnAddTriggerBuffEvent(object[] args)
	{
		if (args != null && args.Length > 0)
		{
			BuffInfoData buffInfoData = args[0] as BuffInfoData;
			if (buffInfoData != null && buffInfoData.buffInfoID == this.mTagBuffInfoID)
			{
				base.owner.buffController.TryAddBuffInfo(this.mAddBuffInfo, base.owner, buffInfoData.level);
			}
		}
	}

	// Token: 0x04010F5D RID: 69469
	private int mTagBuffInfoID;

	// Token: 0x04010F5E RID: 69470
	private int mAddBuffInfo;
}
