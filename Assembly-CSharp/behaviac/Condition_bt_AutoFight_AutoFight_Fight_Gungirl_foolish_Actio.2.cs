using System;

namespace behaviac
{
	// Token: 0x02001F90 RID: 8080
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node3 : Condition
	{
		// Token: 0x060128BF RID: 75967 RVA: 0x0056ECB3 File Offset: 0x0056D0B3
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128C0 RID: 75968 RVA: 0x0056ECE8 File Offset: 0x0056D0E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2B0 RID: 49840
		private int opl_p0;

		// Token: 0x0400C2B1 RID: 49841
		private int opl_p1;

		// Token: 0x0400C2B2 RID: 49842
		private int opl_p2;

		// Token: 0x0400C2B3 RID: 49843
		private int opl_p3;
	}
}
