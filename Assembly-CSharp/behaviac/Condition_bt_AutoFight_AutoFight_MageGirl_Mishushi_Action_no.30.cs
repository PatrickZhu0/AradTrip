using System;

namespace behaviac
{
	// Token: 0x020026D7 RID: 9943
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node101 : Condition
	{
		// Token: 0x060136F1 RID: 79601 RVA: 0x005C96B3 File Offset: 0x005C7AB3
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node101()
		{
			this.opl_p0 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p1 = 2;
		}

		// Token: 0x060136F2 RID: 79602 RVA: 0x005C96CC File Offset: 0x005C7ACC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckLastResult(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D148 RID: 53576
		private BE_Operation opl_p0;

		// Token: 0x0400D149 RID: 53577
		private int opl_p1;
	}
}
