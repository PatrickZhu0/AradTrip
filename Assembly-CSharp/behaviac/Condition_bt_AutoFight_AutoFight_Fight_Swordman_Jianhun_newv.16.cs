using System;

namespace behaviac
{
	// Token: 0x020022C3 RID: 8899
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node33 : Condition
	{
		// Token: 0x06012F01 RID: 77569 RVA: 0x005970E7 File Offset: 0x005954E7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node33()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012F02 RID: 77570 RVA: 0x0059711C File Offset: 0x0059551C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C913 RID: 51475
		private int opl_p0;

		// Token: 0x0400C914 RID: 51476
		private int opl_p1;

		// Token: 0x0400C915 RID: 51477
		private int opl_p2;

		// Token: 0x0400C916 RID: 51478
		private int opl_p3;
	}
}
