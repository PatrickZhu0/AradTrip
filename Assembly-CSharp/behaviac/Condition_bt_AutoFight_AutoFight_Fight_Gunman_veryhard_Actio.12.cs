using System;

namespace behaviac
{
	// Token: 0x020021F7 RID: 8695
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node28 : Condition
	{
		// Token: 0x06012D7B RID: 77179 RVA: 0x0058BD4B File Offset: 0x0058A14B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node28()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D7C RID: 77180 RVA: 0x0058BD80 File Offset: 0x0058A180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C76D RID: 51053
		private int opl_p0;

		// Token: 0x0400C76E RID: 51054
		private int opl_p1;

		// Token: 0x0400C76F RID: 51055
		private int opl_p2;

		// Token: 0x0400C770 RID: 51056
		private int opl_p3;
	}
}
