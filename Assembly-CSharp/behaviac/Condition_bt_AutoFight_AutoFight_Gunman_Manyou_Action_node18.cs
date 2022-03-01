using System;

namespace behaviac
{
	// Token: 0x02002601 RID: 9729
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node18 : Condition
	{
		// Token: 0x06013548 RID: 79176 RVA: 0x005C053D File Offset: 0x005BE93D
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node18()
		{
			this.opl_p0 = 1101;
		}

		// Token: 0x06013549 RID: 79177 RVA: 0x005C0550 File Offset: 0x005BE950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF95 RID: 53141
		private int opl_p0;
	}
}
