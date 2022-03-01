using System;

namespace behaviac
{
	// Token: 0x020033D9 RID: 13273
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node3 : Condition
	{
		// Token: 0x06015007 RID: 86023 RVA: 0x00653FE4 File Offset: 0x006523E4
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2404;
		}

		// Token: 0x06015008 RID: 86024 RVA: 0x00654008 File Offset: 0x00652408
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8F1 RID: 59633
		private BE_Target opl_p0;

		// Token: 0x0400E8F2 RID: 59634
		private BE_Equal opl_p1;

		// Token: 0x0400E8F3 RID: 59635
		private int opl_p2;
	}
}
