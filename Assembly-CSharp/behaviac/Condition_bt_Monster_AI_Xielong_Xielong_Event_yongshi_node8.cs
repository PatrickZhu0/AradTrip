using System;

namespace behaviac
{
	// Token: 0x02003E65 RID: 15973
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node8 : Condition
	{
		// Token: 0x0601644D RID: 91213 RVA: 0x006BBB2A File Offset: 0x006B9F2A
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node8()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x0601644E RID: 91214 RVA: 0x006BBB4C File Offset: 0x006B9F4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC8F RID: 64655
		private HMType opl_p0;

		// Token: 0x0400FC90 RID: 64656
		private BE_Operation opl_p1;

		// Token: 0x0400FC91 RID: 64657
		private float opl_p2;
	}
}
