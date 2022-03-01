using System;

namespace behaviac
{
	// Token: 0x02002763 RID: 10083
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node27 : Condition
	{
		// Token: 0x06013807 RID: 79879 RVA: 0x005CFEB2 File Offset: 0x005CE2B2
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node27()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013808 RID: 79880 RVA: 0x005CFEE8 File Offset: 0x005CE2E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D267 RID: 53863
		private int opl_p0;

		// Token: 0x0400D268 RID: 53864
		private int opl_p1;

		// Token: 0x0400D269 RID: 53865
		private int opl_p2;

		// Token: 0x0400D26A RID: 53866
		private int opl_p3;
	}
}
