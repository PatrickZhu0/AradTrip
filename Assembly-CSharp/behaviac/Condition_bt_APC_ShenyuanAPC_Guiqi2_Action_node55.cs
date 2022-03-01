using System;

namespace behaviac
{
	// Token: 0x02001E55 RID: 7765
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node55 : Condition
	{
		// Token: 0x06012657 RID: 75351 RVA: 0x00560492 File Offset: 0x0055E892
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node55()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012658 RID: 75352 RVA: 0x005604C8 File Offset: 0x0055E8C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C03E RID: 49214
		private int opl_p0;

		// Token: 0x0400C03F RID: 49215
		private int opl_p1;

		// Token: 0x0400C040 RID: 49216
		private int opl_p2;

		// Token: 0x0400C041 RID: 49217
		private int opl_p3;
	}
}
