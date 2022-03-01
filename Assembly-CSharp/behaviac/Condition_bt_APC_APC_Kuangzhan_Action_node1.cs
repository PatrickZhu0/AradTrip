using System;

namespace behaviac
{
	// Token: 0x02001DB0 RID: 7600
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node1 : Condition
	{
		// Token: 0x06012519 RID: 75033 RVA: 0x00559148 File Offset: 0x00557548
		public Condition_bt_APC_APC_Kuangzhan_Action_node1()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601251A RID: 75034 RVA: 0x0055917C File Offset: 0x0055757C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF08 RID: 48904
		private int opl_p0;

		// Token: 0x0400BF09 RID: 48905
		private int opl_p1;

		// Token: 0x0400BF0A RID: 48906
		private int opl_p2;

		// Token: 0x0400BF0B RID: 48907
		private int opl_p3;
	}
}
