using System;

namespace behaviac
{
	// Token: 0x02003E1B RID: 15899
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node3 : Condition
	{
		// Token: 0x060163BE RID: 91070 RVA: 0x006B8F64 File Offset: 0x006B7364
		public Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node3()
		{
			this.opl_p0 = 500;
			this.opl_p1 = 500;
			this.opl_p2 = 500;
			this.opl_p3 = 500;
		}

		// Token: 0x060163BF RID: 91071 RVA: 0x006B8F98 File Offset: 0x006B7398
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC24 RID: 64548
		private int opl_p0;

		// Token: 0x0400FC25 RID: 64549
		private int opl_p1;

		// Token: 0x0400FC26 RID: 64550
		private int opl_p2;

		// Token: 0x0400FC27 RID: 64551
		private int opl_p3;
	}
}
