using System;

namespace behaviac
{
	// Token: 0x02001DBC RID: 7612
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node10 : Condition
	{
		// Token: 0x06012530 RID: 75056 RVA: 0x00559C29 File Offset: 0x00558029
		public Condition_bt_APC_APC_Mishushi_Action_node10()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012531 RID: 75057 RVA: 0x00559C60 File Offset: 0x00558060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF23 RID: 48931
		private int opl_p0;

		// Token: 0x0400BF24 RID: 48932
		private int opl_p1;

		// Token: 0x0400BF25 RID: 48933
		private int opl_p2;

		// Token: 0x0400BF26 RID: 48934
		private int opl_p3;
	}
}
