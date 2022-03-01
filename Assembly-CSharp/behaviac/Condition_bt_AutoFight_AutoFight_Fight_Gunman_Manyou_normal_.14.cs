using System;

namespace behaviac
{
	// Token: 0x02002193 RID: 8595
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node33 : Condition
	{
		// Token: 0x06012CB6 RID: 76982 RVA: 0x00586EE7 File Offset: 0x005852E7
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node33()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012CB7 RID: 76983 RVA: 0x00586F1C File Offset: 0x0058531C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6A8 RID: 50856
		private int opl_p0;

		// Token: 0x0400C6A9 RID: 50857
		private int opl_p1;

		// Token: 0x0400C6AA RID: 50858
		private int opl_p2;

		// Token: 0x0400C6AB RID: 50859
		private int opl_p3;
	}
}
