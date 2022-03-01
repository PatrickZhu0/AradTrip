using System;

namespace behaviac
{
	// Token: 0x02002803 RID: 10243
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node106 : Condition
	{
		// Token: 0x06013945 RID: 80197 RVA: 0x005D6256 File Offset: 0x005D4656
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node106()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013946 RID: 80198 RVA: 0x005D628C File Offset: 0x005D468C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3A3 RID: 54179
		private int opl_p0;

		// Token: 0x0400D3A4 RID: 54180
		private int opl_p1;

		// Token: 0x0400D3A5 RID: 54181
		private int opl_p2;

		// Token: 0x0400D3A6 RID: 54182
		private int opl_p3;
	}
}
