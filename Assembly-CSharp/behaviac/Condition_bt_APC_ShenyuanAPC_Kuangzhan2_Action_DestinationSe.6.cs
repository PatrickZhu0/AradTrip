using System;

namespace behaviac
{
	// Token: 0x02001E7A RID: 7802
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node15 : Condition
	{
		// Token: 0x0601269F RID: 75423 RVA: 0x005625C6 File Offset: 0x005609C6
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060126A0 RID: 75424 RVA: 0x005625FC File Offset: 0x005609FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C086 RID: 49286
		private int opl_p0;

		// Token: 0x0400C087 RID: 49287
		private int opl_p1;

		// Token: 0x0400C088 RID: 49288
		private int opl_p2;

		// Token: 0x0400C089 RID: 49289
		private int opl_p3;
	}
}
