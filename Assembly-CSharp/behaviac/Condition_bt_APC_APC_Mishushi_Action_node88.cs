using System;

namespace behaviac
{
	// Token: 0x02001DC7 RID: 7623
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node88 : Condition
	{
		// Token: 0x06012546 RID: 75078 RVA: 0x0055A102 File Offset: 0x00558502
		public Condition_bt_APC_APC_Mishushi_Action_node88()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06012547 RID: 75079 RVA: 0x0055A138 File Offset: 0x00558538
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF3A RID: 48954
		private int opl_p0;

		// Token: 0x0400BF3B RID: 48955
		private int opl_p1;

		// Token: 0x0400BF3C RID: 48956
		private int opl_p2;

		// Token: 0x0400BF3D RID: 48957
		private int opl_p3;
	}
}
