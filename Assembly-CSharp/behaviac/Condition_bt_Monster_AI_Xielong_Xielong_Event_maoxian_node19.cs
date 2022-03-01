using System;

namespace behaviac
{
	// Token: 0x02003E2A RID: 15914
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node19 : Condition
	{
		// Token: 0x060163DA RID: 91098 RVA: 0x006B9973 File Offset: 0x006B7D73
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_maoxian_node19()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060163DB RID: 91099 RVA: 0x006B9994 File Offset: 0x006B7D94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC41 RID: 64577
		private HMType opl_p0;

		// Token: 0x0400FC42 RID: 64578
		private BE_Operation opl_p1;

		// Token: 0x0400FC43 RID: 64579
		private float opl_p2;
	}
}
