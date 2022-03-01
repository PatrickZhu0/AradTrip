using System;

namespace behaviac
{
	// Token: 0x0200256D RID: 9581
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node10 : Condition
	{
		// Token: 0x06013422 RID: 78882 RVA: 0x005B9A73 File Offset: 0x005B7E73
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node10()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013423 RID: 78883 RVA: 0x005B9AA8 File Offset: 0x005B7EA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE47 RID: 52807
		private int opl_p0;

		// Token: 0x0400CE48 RID: 52808
		private int opl_p1;

		// Token: 0x0400CE49 RID: 52809
		private int opl_p2;

		// Token: 0x0400CE4A RID: 52810
		private int opl_p3;
	}
}
