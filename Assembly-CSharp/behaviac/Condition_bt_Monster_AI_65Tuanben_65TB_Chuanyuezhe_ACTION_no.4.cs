using System;

namespace behaviac
{
	// Token: 0x02002B3E RID: 11070
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node33 : Condition
	{
		// Token: 0x06013F8A RID: 81802 RVA: 0x005FEDE6 File Offset: 0x005FD1E6
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node33()
		{
			this.opl_p0 = 21853;
		}

		// Token: 0x06013F8B RID: 81803 RVA: 0x005FEDFC File Offset: 0x005FD1FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9AF RID: 55727
		private int opl_p0;
	}
}
