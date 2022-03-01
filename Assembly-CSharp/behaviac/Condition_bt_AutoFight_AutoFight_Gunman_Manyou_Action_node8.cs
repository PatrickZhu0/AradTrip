using System;

namespace behaviac
{
	// Token: 0x020025F8 RID: 9720
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node8 : Condition
	{
		// Token: 0x06013536 RID: 79158 RVA: 0x005C010B File Offset: 0x005BE50B
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node8()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013537 RID: 79159 RVA: 0x005C0140 File Offset: 0x005BE540
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF7D RID: 53117
		private int opl_p0;

		// Token: 0x0400CF7E RID: 53118
		private int opl_p1;

		// Token: 0x0400CF7F RID: 53119
		private int opl_p2;

		// Token: 0x0400CF80 RID: 53120
		private int opl_p3;
	}
}
