using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x020042CF RID: 17103
public class Mechanism1158 : BeMechanism
{
	// Token: 0x06017AA9 RID: 96937 RVA: 0x0074B2C4 File Offset: 0x007496C4
	public Mechanism1158(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017AAA RID: 96938 RVA: 0x0074B2DC File Offset: 0x007496DC
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			Mechanism1158.ChaserDamageChangeData item = default(Mechanism1158.ChaserDamageChangeData);
			item.Size = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			item.Type = TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true);
			item.BuffId = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
			item.BuffTime = TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true);
			this._chaserDamageList.Add(item);
		}
	}

	// Token: 0x06017AAB RID: 96939 RVA: 0x0074B3C8 File Offset: 0x007497C8
	public override void OnStart()
	{
		base.OnStart();
		this._RegisterEvent();
	}

	// Token: 0x06017AAC RID: 96940 RVA: 0x0074B3D6 File Offset: 0x007497D6
	private void _RegisterEvent()
	{
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onChaserUse, new BeEvent.BeEventHandleNew.Function(this._OnChaserUse));
	}

	// Token: 0x06017AAD RID: 96941 RVA: 0x0074B3F8 File Offset: 0x007497F8
	private void _OnChaserUse(BeEvent.BeEventParam param)
	{
		for (int i = 0; i < this._chaserDamageList.Count; i++)
		{
			Mechanism1158.ChaserDamageChangeData chaserDamageChangeData = this._chaserDamageList[i];
			if (chaserDamageChangeData.Size == param.m_Int)
			{
				if (chaserDamageChangeData.Type == param.m_Int2)
				{
					base.owner.buffController.TryAddBuff(chaserDamageChangeData.BuffId, chaserDamageChangeData.BuffTime, this.level);
				}
			}
		}
	}

	// Token: 0x0401101B RID: 69659
	private List<Mechanism1158.ChaserDamageChangeData> _chaserDamageList = new List<Mechanism1158.ChaserDamageChangeData>();

	// Token: 0x020042D0 RID: 17104
	private struct ChaserDamageChangeData
	{
		// Token: 0x0401101C RID: 69660
		public int Size;

		// Token: 0x0401101D RID: 69661
		public int Type;

		// Token: 0x0401101E RID: 69662
		public int BuffId;

		// Token: 0x0401101F RID: 69663
		public int BuffTime;
	}
}
