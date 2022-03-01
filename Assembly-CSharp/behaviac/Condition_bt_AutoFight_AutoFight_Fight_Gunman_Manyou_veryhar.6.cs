using System;

namespace behaviac
{
	// Token: 0x020021AB RID: 8619
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node13 : Condition
	{
		// Token: 0x06012CE5 RID: 77029 RVA: 0x00588533 File Offset: 0x00586933
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012CE6 RID: 77030 RVA: 0x00588568 File Offset: 0x00586968
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6D7 RID: 50903
		private int opl_p0;

		// Token: 0x0400C6D8 RID: 50904
		private int opl_p1;

		// Token: 0x0400C6D9 RID: 50905
		private int opl_p2;

		// Token: 0x0400C6DA RID: 50906
		private int opl_p3;
	}
}
