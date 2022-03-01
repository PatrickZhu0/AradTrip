using System;

namespace behaviac
{
	// Token: 0x0200264A RID: 9802
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node104 : Condition
	{
		// Token: 0x060135D9 RID: 79321 RVA: 0x005C3A53 File Offset: 0x005C1E53
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node104()
		{
			this.opl_p0 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p1 = 2;
		}

		// Token: 0x060135DA RID: 79322 RVA: 0x005C3A6C File Offset: 0x005C1E6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckLastResult(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D029 RID: 53289
		private BE_Operation opl_p0;

		// Token: 0x0400D02A RID: 53290
		private int opl_p1;
	}
}
