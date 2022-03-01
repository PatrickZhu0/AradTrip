using System;

namespace behaviac
{
	// Token: 0x020021B3 RID: 8627
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node23 : Condition
	{
		// Token: 0x06012CF5 RID: 77045 RVA: 0x0058891B File Offset: 0x00586D1B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node23()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012CF6 RID: 77046 RVA: 0x00588950 File Offset: 0x00586D50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6E7 RID: 50919
		private int opl_p0;

		// Token: 0x0400C6E8 RID: 50920
		private int opl_p1;

		// Token: 0x0400C6E9 RID: 50921
		private int opl_p2;

		// Token: 0x0400C6EA RID: 50922
		private int opl_p3;
	}
}
