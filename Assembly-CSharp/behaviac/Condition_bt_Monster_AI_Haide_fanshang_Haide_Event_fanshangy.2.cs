using System;

namespace behaviac
{
	// Token: 0x020033E5 RID: 13285
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node4 : Condition
	{
		// Token: 0x0601501E RID: 86046 RVA: 0x0065464F File Offset: 0x00652A4F
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2503;
		}

		// Token: 0x0601501F RID: 86047 RVA: 0x00654670 File Offset: 0x00652A70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E90A RID: 59658
		private BE_Target opl_p0;

		// Token: 0x0400E90B RID: 59659
		private BE_Equal opl_p1;

		// Token: 0x0400E90C RID: 59660
		private int opl_p2;
	}
}
