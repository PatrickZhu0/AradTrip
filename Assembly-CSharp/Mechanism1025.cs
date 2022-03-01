using System;

// Token: 0x02004261 RID: 16993
public class Mechanism1025 : BeMechanism
{
	// Token: 0x06017834 RID: 96308 RVA: 0x0073BDE2 File Offset: 0x0073A1E2
	public Mechanism1025(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017835 RID: 96309 RVA: 0x0073BDEC File Offset: 0x0073A1EC
	public override void OnInit()
	{
		base.OnInit();
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skillIDs = new int[this.data.ValueB.Count];
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.skillIDs[i] = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
		}
	}

	// Token: 0x06017836 RID: 96310 RVA: 0x0073BE8D File Offset: 0x0073A28D
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onCastSkill, delegate(object[] args)
		{
			int value = (int)args[0];
			if (Array.IndexOf<int>(this.skillIDs, value) != -1)
			{
				base.owner.buffController.TryAddBuffInfo(this.buffInfoID, base.owner, this.level);
			}
		});
	}

	// Token: 0x04010E5B RID: 69211
	private int buffInfoID;

	// Token: 0x04010E5C RID: 69212
	private int[] skillIDs;
}
