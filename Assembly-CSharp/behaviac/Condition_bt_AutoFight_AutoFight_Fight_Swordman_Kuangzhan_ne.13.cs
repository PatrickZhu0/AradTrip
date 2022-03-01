using System;

namespace behaviac
{
	// Token: 0x020023A2 RID: 9122
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node35 : Condition
	{
		// Token: 0x060130AA RID: 77994 RVA: 0x005A2B9B File Offset: 0x005A0F9B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node35()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060130AB RID: 77995 RVA: 0x005A2BD0 File Offset: 0x005A0FD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CACE RID: 51918
		private int opl_p0;

		// Token: 0x0400CACF RID: 51919
		private int opl_p1;

		// Token: 0x0400CAD0 RID: 51920
		private int opl_p2;

		// Token: 0x0400CAD1 RID: 51921
		private int opl_p3;
	}
}
