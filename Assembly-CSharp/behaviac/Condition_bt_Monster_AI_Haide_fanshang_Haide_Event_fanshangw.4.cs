using System;

namespace behaviac
{
	// Token: 0x020033DE RID: 13278
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node9 : Condition
	{
		// Token: 0x06015011 RID: 86033 RVA: 0x0065416A File Offset: 0x0065256A
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2504;
		}

		// Token: 0x06015012 RID: 86034 RVA: 0x0065418C File Offset: 0x0065258C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8FC RID: 59644
		private BE_Target opl_p0;

		// Token: 0x0400E8FD RID: 59645
		private BE_Equal opl_p1;

		// Token: 0x0400E8FE RID: 59646
		private int opl_p2;
	}
}
