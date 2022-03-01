using System;

namespace behaviac
{
	// Token: 0x020040B8 RID: 16568
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node6 : Condition
	{
		// Token: 0x060168C8 RID: 92360 RVA: 0x006D4133 File Offset: 0x006D2533
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060168C9 RID: 92361 RVA: 0x006D4168 File Offset: 0x006D2568
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401010E RID: 65806
		private int opl_p0;

		// Token: 0x0401010F RID: 65807
		private int opl_p1;

		// Token: 0x04010110 RID: 65808
		private int opl_p2;

		// Token: 0x04010111 RID: 65809
		private int opl_p3;
	}
}
