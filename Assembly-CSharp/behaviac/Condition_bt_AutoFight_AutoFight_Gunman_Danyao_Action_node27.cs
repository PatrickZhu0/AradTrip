using System;

namespace behaviac
{
	// Token: 0x020025D5 RID: 9685
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node27 : Condition
	{
		// Token: 0x060134F1 RID: 79089 RVA: 0x005BD69E File Offset: 0x005BBA9E
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node27()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060134F2 RID: 79090 RVA: 0x005BD6D4 File Offset: 0x005BBAD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF35 RID: 53045
		private int opl_p0;

		// Token: 0x0400CF36 RID: 53046
		private int opl_p1;

		// Token: 0x0400CF37 RID: 53047
		private int opl_p2;

		// Token: 0x0400CF38 RID: 53048
		private int opl_p3;
	}
}
