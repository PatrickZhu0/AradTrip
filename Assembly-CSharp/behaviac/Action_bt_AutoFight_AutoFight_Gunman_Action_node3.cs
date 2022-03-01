using System;

namespace behaviac
{
	// Token: 0x02002569 RID: 9577
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Action_node3 : Action
	{
		// Token: 0x0601341A RID: 78874 RVA: 0x005B9827 File Offset: 0x005B7C27
		public Action_bt_AutoFight_AutoFight_Gunman_Action_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1500;
			this.method_p1 = 500;
			this.method_p2 = 1000;
			this.method_p3 = 1000;
		}

		// Token: 0x0601341B RID: 78875 RVA: 0x005B9862 File Offset: 0x005B7C62
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE3F RID: 52799
		private int method_p0;

		// Token: 0x0400CE40 RID: 52800
		private int method_p1;

		// Token: 0x0400CE41 RID: 52801
		private int method_p2;

		// Token: 0x0400CE42 RID: 52802
		private int method_p3;
	}
}
