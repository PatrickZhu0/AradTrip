using System;

namespace behaviac
{
	// Token: 0x0200201B RID: 8219
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node13 : Condition
	{
		// Token: 0x060129D1 RID: 76241 RVA: 0x00575453 File Offset: 0x00573853
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060129D2 RID: 76242 RVA: 0x00575488 File Offset: 0x00573888
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3C3 RID: 50115
		private int opl_p0;

		// Token: 0x0400C3C4 RID: 50116
		private int opl_p1;

		// Token: 0x0400C3C5 RID: 50117
		private int opl_p2;

		// Token: 0x0400C3C6 RID: 50118
		private int opl_p3;
	}
}
