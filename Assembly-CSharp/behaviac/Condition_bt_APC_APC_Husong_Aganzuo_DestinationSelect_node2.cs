using System;

namespace behaviac
{
	// Token: 0x02001D5D RID: 7517
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2 : Condition
	{
		// Token: 0x06012478 RID: 74872 RVA: 0x005555B2 File Offset: 0x005539B2
		public Condition_bt_APC_APC_Husong_Aganzuo_DestinationSelect_node2()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x06012479 RID: 74873 RVA: 0x005555E8 File Offset: 0x005539E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE66 RID: 48742
		private int opl_p0;

		// Token: 0x0400BE67 RID: 48743
		private int opl_p1;

		// Token: 0x0400BE68 RID: 48744
		private int opl_p2;

		// Token: 0x0400BE69 RID: 48745
		private int opl_p3;
	}
}
