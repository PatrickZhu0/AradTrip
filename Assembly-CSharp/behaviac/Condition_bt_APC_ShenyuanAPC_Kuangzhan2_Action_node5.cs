using System;

namespace behaviac
{
	// Token: 0x02001E63 RID: 7779
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node5 : Condition
	{
		// Token: 0x06012672 RID: 75378 RVA: 0x00561565 File Offset: 0x0055F965
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012673 RID: 75379 RVA: 0x0056159C File Offset: 0x0055F99C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C059 RID: 49241
		private int opl_p0;

		// Token: 0x0400C05A RID: 49242
		private int opl_p1;

		// Token: 0x0400C05B RID: 49243
		private int opl_p2;

		// Token: 0x0400C05C RID: 49244
		private int opl_p3;
	}
}
