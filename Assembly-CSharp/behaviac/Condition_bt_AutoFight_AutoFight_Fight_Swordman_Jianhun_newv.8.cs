using System;

namespace behaviac
{
	// Token: 0x020022B8 RID: 8888
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node24 : Condition
	{
		// Token: 0x06012EEB RID: 77547 RVA: 0x005963DB File Offset: 0x005947DB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node24()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012EEC RID: 77548 RVA: 0x00596410 File Offset: 0x00594810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8FC RID: 51452
		private int opl_p0;

		// Token: 0x0400C8FD RID: 51453
		private int opl_p1;

		// Token: 0x0400C8FE RID: 51454
		private int opl_p2;

		// Token: 0x0400C8FF RID: 51455
		private int opl_p3;
	}
}
