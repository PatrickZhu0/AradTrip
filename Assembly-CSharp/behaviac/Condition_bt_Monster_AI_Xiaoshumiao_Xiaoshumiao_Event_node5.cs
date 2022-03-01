using System;

namespace behaviac
{
	// Token: 0x02003E25 RID: 15909
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node5 : Condition
	{
		// Token: 0x060163D1 RID: 91089 RVA: 0x006B95A6 File Offset: 0x006B79A6
		public Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao_Event_node5()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x060163D2 RID: 91090 RVA: 0x006B95C8 File Offset: 0x006B79C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC38 RID: 64568
		private HMType opl_p0;

		// Token: 0x0400FC39 RID: 64569
		private BE_Operation opl_p1;

		// Token: 0x0400FC3A RID: 64570
		private float opl_p2;
	}
}
