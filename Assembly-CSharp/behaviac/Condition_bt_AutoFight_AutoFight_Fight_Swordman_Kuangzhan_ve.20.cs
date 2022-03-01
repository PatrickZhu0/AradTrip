using System;

namespace behaviac
{
	// Token: 0x0200242A RID: 9258
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node38 : Condition
	{
		// Token: 0x060131AC RID: 78252 RVA: 0x005AA413 File Offset: 0x005A8813
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060131AD RID: 78253 RVA: 0x005AA448 File Offset: 0x005A8848
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBD2 RID: 52178
		private int opl_p0;

		// Token: 0x0400CBD3 RID: 52179
		private int opl_p1;

		// Token: 0x0400CBD4 RID: 52180
		private int opl_p2;

		// Token: 0x0400CBD5 RID: 52181
		private int opl_p3;
	}
}
