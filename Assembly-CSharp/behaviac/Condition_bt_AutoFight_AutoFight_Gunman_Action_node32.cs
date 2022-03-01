using System;

namespace behaviac
{
	// Token: 0x0200257F RID: 9599
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node32 : Condition
	{
		// Token: 0x06013446 RID: 78918 RVA: 0x005BA433 File Offset: 0x005B8833
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node32()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013447 RID: 78919 RVA: 0x005BA468 File Offset: 0x005B8868
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE6E RID: 52846
		private int opl_p0;

		// Token: 0x0400CE6F RID: 52847
		private int opl_p1;

		// Token: 0x0400CE70 RID: 52848
		private int opl_p2;

		// Token: 0x0400CE71 RID: 52849
		private int opl_p3;
	}
}
