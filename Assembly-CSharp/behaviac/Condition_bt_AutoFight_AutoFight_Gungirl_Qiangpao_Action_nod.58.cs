using System;

namespace behaviac
{
	// Token: 0x02002560 RID: 9568
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node104 : Condition
	{
		// Token: 0x06013409 RID: 78857 RVA: 0x005B7C66 File Offset: 0x005B6066
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node104()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601340A RID: 78858 RVA: 0x005B7C9C File Offset: 0x005B609C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE2F RID: 52783
		private int opl_p0;

		// Token: 0x0400CE30 RID: 52784
		private int opl_p1;

		// Token: 0x0400CE31 RID: 52785
		private int opl_p2;

		// Token: 0x0400CE32 RID: 52786
		private int opl_p3;
	}
}
