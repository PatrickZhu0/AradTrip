using System;

namespace behaviac
{
	// Token: 0x020033C9 RID: 13257
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node8 : Condition
	{
		// Token: 0x06014FE9 RID: 85993 RVA: 0x006535BB File Offset: 0x006519BB
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2402;
		}

		// Token: 0x06014FEA RID: 85994 RVA: 0x006535DC File Offset: 0x006519DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8D3 RID: 59603
		private BE_Target opl_p0;

		// Token: 0x0400E8D4 RID: 59604
		private BE_Equal opl_p1;

		// Token: 0x0400E8D5 RID: 59605
		private int opl_p2;
	}
}
