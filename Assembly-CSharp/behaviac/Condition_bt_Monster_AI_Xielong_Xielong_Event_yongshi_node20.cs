using System;

namespace behaviac
{
	// Token: 0x02003E66 RID: 15974
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node20 : Condition
	{
		// Token: 0x0601644F RID: 91215 RVA: 0x006BBB8B File Offset: 0x006B9F8B
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x06016450 RID: 91216 RVA: 0x006BBBAC File Offset: 0x006B9FAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC92 RID: 64658
		private HMType opl_p0;

		// Token: 0x0400FC93 RID: 64659
		private BE_Operation opl_p1;

		// Token: 0x0400FC94 RID: 64660
		private float opl_p2;
	}
}
