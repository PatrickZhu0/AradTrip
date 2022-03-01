using System;

namespace behaviac
{
	// Token: 0x02002637 RID: 9783
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node34 : Condition
	{
		// Token: 0x060135B4 RID: 79284 RVA: 0x005C1D51 File Offset: 0x005C0151
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node34()
		{
			this.opl_p0 = 1013;
		}

		// Token: 0x060135B5 RID: 79285 RVA: 0x005C1D64 File Offset: 0x005C0164
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D003 RID: 53251
		private int opl_p0;
	}
}
