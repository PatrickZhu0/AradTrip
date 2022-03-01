using System;

namespace behaviac
{
	// Token: 0x02002797 RID: 10135
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node12 : Condition
	{
		// Token: 0x0601386E RID: 79982 RVA: 0x005D2712 File Offset: 0x005D0B12
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node12()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601386F RID: 79983 RVA: 0x005D2748 File Offset: 0x005D0B48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2CD RID: 53965
		private int opl_p0;

		// Token: 0x0400D2CE RID: 53966
		private int opl_p1;

		// Token: 0x0400D2CF RID: 53967
		private int opl_p2;

		// Token: 0x0400D2D0 RID: 53968
		private int opl_p3;
	}
}
