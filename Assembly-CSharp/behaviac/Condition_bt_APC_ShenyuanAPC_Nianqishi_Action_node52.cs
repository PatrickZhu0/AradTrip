using System;

namespace behaviac
{
	// Token: 0x02001EAF RID: 7855
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node52 : Condition
	{
		// Token: 0x06012706 RID: 75526 RVA: 0x00564AAF File Offset: 0x00562EAF
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012707 RID: 75527 RVA: 0x00564ACC File Offset: 0x00562ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0F3 RID: 49395
		private BE_Target opl_p0;

		// Token: 0x0400C0F4 RID: 49396
		private BE_Equal opl_p1;

		// Token: 0x0400C0F5 RID: 49397
		private BE_State opl_p2;
	}
}
