using System;

namespace behaviac
{
	// Token: 0x020033DA RID: 13274
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node4 : Condition
	{
		// Token: 0x06015009 RID: 86025 RVA: 0x00654047 File Offset: 0x00652447
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2504;
		}

		// Token: 0x0601500A RID: 86026 RVA: 0x00654068 File Offset: 0x00652468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8F4 RID: 59636
		private BE_Target opl_p0;

		// Token: 0x0400E8F5 RID: 59637
		private BE_Equal opl_p1;

		// Token: 0x0400E8F6 RID: 59638
		private int opl_p2;
	}
}
