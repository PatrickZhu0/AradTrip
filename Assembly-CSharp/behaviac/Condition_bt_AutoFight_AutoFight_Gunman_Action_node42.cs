using System;

namespace behaviac
{
	// Token: 0x02002587 RID: 9607
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node42 : Condition
	{
		// Token: 0x06013456 RID: 78934 RVA: 0x005BA7A3 File Offset: 0x005B8BA3
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node42()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013457 RID: 78935 RVA: 0x005BA7D8 File Offset: 0x005B8BD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE7E RID: 52862
		private int opl_p0;

		// Token: 0x0400CE7F RID: 52863
		private int opl_p1;

		// Token: 0x0400CE80 RID: 52864
		private int opl_p2;

		// Token: 0x0400CE81 RID: 52865
		private int opl_p3;
	}
}
