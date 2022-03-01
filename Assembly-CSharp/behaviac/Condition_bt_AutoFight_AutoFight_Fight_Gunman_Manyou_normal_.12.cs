using System;

namespace behaviac
{
	// Token: 0x0200218F RID: 8591
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node28 : Condition
	{
		// Token: 0x06012CAE RID: 76974 RVA: 0x00586D4B File Offset: 0x0058514B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06012CAF RID: 76975 RVA: 0x00586D80 File Offset: 0x00585180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6A0 RID: 50848
		private int opl_p0;

		// Token: 0x0400C6A1 RID: 50849
		private int opl_p1;

		// Token: 0x0400C6A2 RID: 50850
		private int opl_p2;

		// Token: 0x0400C6A3 RID: 50851
		private int opl_p3;
	}
}
