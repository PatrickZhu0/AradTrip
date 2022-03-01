using System;

namespace behaviac
{
	// Token: 0x0200262B RID: 9771
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node82 : Condition
	{
		// Token: 0x0601359C RID: 79260 RVA: 0x005C1835 File Offset: 0x005BFC35
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node82()
		{
			this.opl_p0 = 1011;
		}

		// Token: 0x0601359D RID: 79261 RVA: 0x005C1848 File Offset: 0x005BFC48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFEB RID: 53227
		private int opl_p0;
	}
}
