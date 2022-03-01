using System;

namespace behaviac
{
	// Token: 0x02002183 RID: 8579
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node13 : Condition
	{
		// Token: 0x06012C96 RID: 76950 RVA: 0x00586717 File Offset: 0x00584B17
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012C97 RID: 76951 RVA: 0x0058674C File Offset: 0x00584B4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C688 RID: 50824
		private int opl_p0;

		// Token: 0x0400C689 RID: 50825
		private int opl_p1;

		// Token: 0x0400C68A RID: 50826
		private int opl_p2;

		// Token: 0x0400C68B RID: 50827
		private int opl_p3;
	}
}
