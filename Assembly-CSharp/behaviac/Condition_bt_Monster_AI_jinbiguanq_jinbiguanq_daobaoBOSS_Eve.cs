using System;

namespace behaviac
{
	// Token: 0x02003579 RID: 13689
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaoBOSS_Event_node3 : Condition
	{
		// Token: 0x06015325 RID: 86821 RVA: 0x006637BE File Offset: 0x00661BBE
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaoBOSS_Event_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06015326 RID: 86822 RVA: 0x006637DC File Offset: 0x00661BDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECE4 RID: 60644
		private BE_Target opl_p0;

		// Token: 0x0400ECE5 RID: 60645
		private BE_Equal opl_p1;

		// Token: 0x0400ECE6 RID: 60646
		private BE_State opl_p2;
	}
}
