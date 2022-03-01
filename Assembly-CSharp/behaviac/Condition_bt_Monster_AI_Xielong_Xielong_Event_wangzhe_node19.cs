using System;

namespace behaviac
{
	// Token: 0x02003E4E RID: 15950
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node19 : Condition
	{
		// Token: 0x06016420 RID: 91168 RVA: 0x006BAECB File Offset: 0x006B92CB
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node19()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06016421 RID: 91169 RVA: 0x006BAEEC File Offset: 0x006B92EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC71 RID: 64625
		private HMType opl_p0;

		// Token: 0x0400FC72 RID: 64626
		private BE_Operation opl_p1;

		// Token: 0x0400FC73 RID: 64627
		private float opl_p2;
	}
}
