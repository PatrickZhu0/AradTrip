using System;

namespace behaviac
{
	// Token: 0x020021EF RID: 8687
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node18 : Condition
	{
		// Token: 0x06012D6B RID: 77163 RVA: 0x0058B963 File Offset: 0x00589D63
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node18()
		{
			this.opl_p0 = 1000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D6C RID: 77164 RVA: 0x0058B998 File Offset: 0x00589D98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C75D RID: 51037
		private int opl_p0;

		// Token: 0x0400C75E RID: 51038
		private int opl_p1;

		// Token: 0x0400C75F RID: 51039
		private int opl_p2;

		// Token: 0x0400C760 RID: 51040
		private int opl_p3;
	}
}
