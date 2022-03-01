using System;

namespace behaviac
{
	// Token: 0x02001D42 RID: 7490
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Gunman_test_Action_node6 : Action
	{
		// Token: 0x06012445 RID: 74821 RVA: 0x005542B2 File Offset: 0x005526B2
		public Action_bt_APC_APC_Gunman_test_Action_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1;
		}

		// Token: 0x06012446 RID: 74822 RVA: 0x005542CF File Offset: 0x005526CF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE37 RID: 48695
		private BE_Target method_p0;

		// Token: 0x0400BE38 RID: 48696
		private int method_p1;
	}
}
