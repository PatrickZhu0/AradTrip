using System;

namespace behaviac
{
	// Token: 0x02002197 RID: 8599
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node38 : Condition
	{
		// Token: 0x06012CBE RID: 76990 RVA: 0x00587083 File Offset: 0x00585483
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012CBF RID: 76991 RVA: 0x005870B8 File Offset: 0x005854B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6B0 RID: 50864
		private int opl_p0;

		// Token: 0x0400C6B1 RID: 50865
		private int opl_p1;

		// Token: 0x0400C6B2 RID: 50866
		private int opl_p2;

		// Token: 0x0400C6B3 RID: 50867
		private int opl_p3;
	}
}
