using System;

namespace behaviac
{
	// Token: 0x02002027 RID: 8231
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node28 : Condition
	{
		// Token: 0x060129E9 RID: 76265 RVA: 0x00575A87 File Offset: 0x00573E87
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x060129EA RID: 76266 RVA: 0x00575ABC File Offset: 0x00573EBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3DB RID: 50139
		private int opl_p0;

		// Token: 0x0400C3DC RID: 50140
		private int opl_p1;

		// Token: 0x0400C3DD RID: 50141
		private int opl_p2;

		// Token: 0x0400C3DE RID: 50142
		private int opl_p3;
	}
}
