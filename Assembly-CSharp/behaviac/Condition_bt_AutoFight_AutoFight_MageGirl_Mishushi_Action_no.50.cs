using System;

namespace behaviac
{
	// Token: 0x020026F2 RID: 9970
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node69 : Condition
	{
		// Token: 0x06013727 RID: 79655 RVA: 0x005CA22E File Offset: 0x005C862E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node69()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013728 RID: 79656 RVA: 0x005CA264 File Offset: 0x005C8664
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D17D RID: 53629
		private int opl_p0;

		// Token: 0x0400D17E RID: 53630
		private int opl_p1;

		// Token: 0x0400D17F RID: 53631
		private int opl_p2;

		// Token: 0x0400D180 RID: 53632
		private int opl_p3;
	}
}
