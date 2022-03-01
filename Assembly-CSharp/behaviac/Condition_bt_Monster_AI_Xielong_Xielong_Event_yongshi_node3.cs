using System;

namespace behaviac
{
	// Token: 0x02003E5F RID: 15967
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node3 : Condition
	{
		// Token: 0x06016441 RID: 91201 RVA: 0x006BB916 File Offset: 0x006B9D16
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.75f;
		}

		// Token: 0x06016442 RID: 91202 RVA: 0x006BB938 File Offset: 0x006B9D38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC86 RID: 64646
		private HMType opl_p0;

		// Token: 0x0400FC87 RID: 64647
		private BE_Operation opl_p1;

		// Token: 0x0400FC88 RID: 64648
		private float opl_p2;
	}
}
