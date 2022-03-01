using System;

namespace behaviac
{
	// Token: 0x02002740 RID: 10048
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node31 : Condition
	{
		// Token: 0x060137C2 RID: 79810 RVA: 0x005CDAA6 File Offset: 0x005CBEA6
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node31()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060137C3 RID: 79811 RVA: 0x005CDADC File Offset: 0x005CBEDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D21B RID: 53787
		private int opl_p0;

		// Token: 0x0400D21C RID: 53788
		private int opl_p1;

		// Token: 0x0400D21D RID: 53789
		private int opl_p2;

		// Token: 0x0400D21E RID: 53790
		private int opl_p3;
	}
}
