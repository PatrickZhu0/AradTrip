using System;

namespace behaviac
{
	// Token: 0x02002017 RID: 8215
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node8 : Condition
	{
		// Token: 0x060129C9 RID: 76233 RVA: 0x005752B7 File Offset: 0x005736B7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060129CA RID: 76234 RVA: 0x005752EC File Offset: 0x005736EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3BB RID: 50107
		private int opl_p0;

		// Token: 0x0400C3BC RID: 50108
		private int opl_p1;

		// Token: 0x0400C3BD RID: 50109
		private int opl_p2;

		// Token: 0x0400C3BE RID: 50110
		private int opl_p3;
	}
}
