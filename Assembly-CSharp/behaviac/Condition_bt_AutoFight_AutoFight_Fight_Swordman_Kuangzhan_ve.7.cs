using System;

namespace behaviac
{
	// Token: 0x02002415 RID: 9237
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node16 : Condition
	{
		// Token: 0x06013186 RID: 78214 RVA: 0x005A9C06 File Offset: 0x005A8006
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node16()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013187 RID: 78215 RVA: 0x005A9C3C File Offset: 0x005A803C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBB1 RID: 52145
		private int opl_p0;

		// Token: 0x0400CBB2 RID: 52146
		private int opl_p1;

		// Token: 0x0400CBB3 RID: 52147
		private int opl_p2;

		// Token: 0x0400CBB4 RID: 52148
		private int opl_p3;
	}
}
