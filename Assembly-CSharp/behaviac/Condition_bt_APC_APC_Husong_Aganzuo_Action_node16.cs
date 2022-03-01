using System;

namespace behaviac
{
	// Token: 0x02001D58 RID: 7512
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node16 : Condition
	{
		// Token: 0x0601246F RID: 74863 RVA: 0x00554F66 File Offset: 0x00553366
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node16()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06012470 RID: 74864 RVA: 0x00554F9C File Offset: 0x0055339C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE5E RID: 48734
		private int opl_p0;

		// Token: 0x0400BE5F RID: 48735
		private int opl_p1;

		// Token: 0x0400BE60 RID: 48736
		private int opl_p2;

		// Token: 0x0400BE61 RID: 48737
		private int opl_p3;
	}
}
