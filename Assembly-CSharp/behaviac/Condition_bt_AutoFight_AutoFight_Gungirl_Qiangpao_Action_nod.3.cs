using System;

namespace behaviac
{
	// Token: 0x02002516 RID: 9494
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node28 : Condition
	{
		// Token: 0x06013375 RID: 78709 RVA: 0x005B5C6B File Offset: 0x005B406B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node28()
		{
			this.opl_p0 = 2606;
		}

		// Token: 0x06013376 RID: 78710 RVA: 0x005B5C80 File Offset: 0x005B4080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD98 RID: 52632
		private int opl_p0;
	}
}
