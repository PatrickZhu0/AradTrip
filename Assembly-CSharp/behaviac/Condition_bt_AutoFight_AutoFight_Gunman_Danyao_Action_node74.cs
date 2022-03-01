using System;

namespace behaviac
{
	// Token: 0x020025D9 RID: 9689
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node74 : Condition
	{
		// Token: 0x060134F9 RID: 79097 RVA: 0x005BD852 File Offset: 0x005BBC52
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node74()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060134FA RID: 79098 RVA: 0x005BD888 File Offset: 0x005BBC88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF3D RID: 53053
		private int opl_p0;

		// Token: 0x0400CF3E RID: 53054
		private int opl_p1;

		// Token: 0x0400CF3F RID: 53055
		private int opl_p2;

		// Token: 0x0400CF40 RID: 53056
		private int opl_p3;
	}
}
