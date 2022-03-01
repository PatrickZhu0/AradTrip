using System;

namespace behaviac
{
	// Token: 0x020033DF RID: 13279
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node8 : Condition
	{
		// Token: 0x06015013 RID: 86035 RVA: 0x006541CB File Offset: 0x006525CB
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2404;
		}

		// Token: 0x06015014 RID: 86036 RVA: 0x006541EC File Offset: 0x006525EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8FF RID: 59647
		private BE_Target opl_p0;

		// Token: 0x0400E900 RID: 59648
		private BE_Equal opl_p1;

		// Token: 0x0400E901 RID: 59649
		private int opl_p2;
	}
}
