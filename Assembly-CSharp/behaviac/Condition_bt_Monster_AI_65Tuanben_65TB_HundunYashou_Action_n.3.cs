using System;

namespace behaviac
{
	// Token: 0x02002B82 RID: 11138
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node13 : Condition
	{
		// Token: 0x06014010 RID: 81936 RVA: 0x00601D76 File Offset: 0x00600176
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node13()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522099;
		}

		// Token: 0x06014011 RID: 81937 RVA: 0x00601D98 File Offset: 0x00600198
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA0E RID: 55822
		private BE_Target opl_p0;

		// Token: 0x0400DA0F RID: 55823
		private BE_Equal opl_p1;

		// Token: 0x0400DA10 RID: 55824
		private int opl_p2;
	}
}
