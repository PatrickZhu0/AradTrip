using System;

namespace behaviac
{
	// Token: 0x020027C3 RID: 10179
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node66 : Condition
	{
		// Token: 0x060138C5 RID: 80069 RVA: 0x005D4716 File Offset: 0x005D2B16
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node66()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060138C6 RID: 80070 RVA: 0x005D474C File Offset: 0x005D2B4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D323 RID: 54051
		private int opl_p0;

		// Token: 0x0400D324 RID: 54052
		private int opl_p1;

		// Token: 0x0400D325 RID: 54053
		private int opl_p2;

		// Token: 0x0400D326 RID: 54054
		private int opl_p3;
	}
}
