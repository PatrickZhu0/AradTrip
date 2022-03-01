using System;

namespace behaviac
{
	// Token: 0x020023AA RID: 9130
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node57 : Condition
	{
		// Token: 0x060130BA RID: 78010 RVA: 0x005A3753 File Offset: 0x005A1B53
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node57()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060130BB RID: 78011 RVA: 0x005A3788 File Offset: 0x005A1B88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAE2 RID: 51938
		private int opl_p0;

		// Token: 0x0400CAE3 RID: 51939
		private int opl_p1;

		// Token: 0x0400CAE4 RID: 51940
		private int opl_p2;

		// Token: 0x0400CAE5 RID: 51941
		private int opl_p3;
	}
}
