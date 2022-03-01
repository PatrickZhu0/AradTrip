using System;

namespace behaviac
{
	// Token: 0x02002D01 RID: 11521
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node60 : Condition
	{
		// Token: 0x060142F2 RID: 82674 RVA: 0x0060F6BD File Offset: 0x0060DABD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node60()
		{
			this.opl_p0 = 20746;
		}

		// Token: 0x060142F3 RID: 82675 RVA: 0x0060F6D0 File Offset: 0x0060DAD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC9A RID: 56474
		private int opl_p0;
	}
}
