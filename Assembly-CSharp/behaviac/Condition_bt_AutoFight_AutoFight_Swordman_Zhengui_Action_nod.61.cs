using System;

namespace behaviac
{
	// Token: 0x020029CC RID: 10700
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node61 : Condition
	{
		// Token: 0x06013CCC RID: 81100 RVA: 0x005EB9FF File Offset: 0x005E9DFF
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node61()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06013CCD RID: 81101 RVA: 0x005EBA34 File Offset: 0x005E9E34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D73A RID: 55098
		private int opl_p0;

		// Token: 0x0400D73B RID: 55099
		private int opl_p1;

		// Token: 0x0400D73C RID: 55100
		private int opl_p2;

		// Token: 0x0400D73D RID: 55101
		private int opl_p3;
	}
}
