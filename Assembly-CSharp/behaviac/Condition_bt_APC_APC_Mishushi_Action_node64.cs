using System;

namespace behaviac
{
	// Token: 0x02001DC3 RID: 7619
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node64 : Condition
	{
		// Token: 0x0601253E RID: 75070 RVA: 0x00559F4E File Offset: 0x0055834E
		public Condition_bt_APC_APC_Mishushi_Action_node64()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1500;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x0601253F RID: 75071 RVA: 0x00559F84 File Offset: 0x00558384
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF32 RID: 48946
		private int opl_p0;

		// Token: 0x0400BF33 RID: 48947
		private int opl_p1;

		// Token: 0x0400BF34 RID: 48948
		private int opl_p2;

		// Token: 0x0400BF35 RID: 48949
		private int opl_p3;
	}
}
