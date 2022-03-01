using System;

namespace behaviac
{
	// Token: 0x020027A3 RID: 10147
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node27 : Condition
	{
		// Token: 0x06013886 RID: 80006 RVA: 0x005D2C2E File Offset: 0x005D102E
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node27()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013887 RID: 80007 RVA: 0x005D2C64 File Offset: 0x005D1064
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2E5 RID: 53989
		private int opl_p0;

		// Token: 0x0400D2E6 RID: 53990
		private int opl_p1;

		// Token: 0x0400D2E7 RID: 53991
		private int opl_p2;

		// Token: 0x0400D2E8 RID: 53992
		private int opl_p3;
	}
}
