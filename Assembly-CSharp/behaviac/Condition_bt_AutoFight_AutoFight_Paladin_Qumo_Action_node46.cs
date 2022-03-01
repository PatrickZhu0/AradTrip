using System;

namespace behaviac
{
	// Token: 0x020027E7 RID: 10215
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node46 : Condition
	{
		// Token: 0x0601390D RID: 80141 RVA: 0x005D566A File Offset: 0x005D3A6A
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node46()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x0601390E RID: 80142 RVA: 0x005D56A0 File Offset: 0x005D3AA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D36B RID: 54123
		private int opl_p0;

		// Token: 0x0400D36C RID: 54124
		private int opl_p1;

		// Token: 0x0400D36D RID: 54125
		private int opl_p2;

		// Token: 0x0400D36E RID: 54126
		private int opl_p3;
	}
}
