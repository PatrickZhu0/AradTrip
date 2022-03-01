using System;

namespace behaviac
{
	// Token: 0x020027CB RID: 10187
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node27 : Condition
	{
		// Token: 0x060138D5 RID: 80085 RVA: 0x005D4A7E File Offset: 0x005D2E7E
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node27()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060138D6 RID: 80086 RVA: 0x005D4AB4 File Offset: 0x005D2EB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D333 RID: 54067
		private int opl_p0;

		// Token: 0x0400D334 RID: 54068
		private int opl_p1;

		// Token: 0x0400D335 RID: 54069
		private int opl_p2;

		// Token: 0x0400D336 RID: 54070
		private int opl_p3;
	}
}
