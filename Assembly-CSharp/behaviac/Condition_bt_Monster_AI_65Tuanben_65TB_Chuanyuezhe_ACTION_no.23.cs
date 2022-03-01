using System;

namespace behaviac
{
	// Token: 0x02002B63 RID: 11107
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node58 : Condition
	{
		// Token: 0x06013FD4 RID: 81876 RVA: 0x005FFF31 File Offset: 0x005FE331
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node58()
		{
			this.opl_p0 = 21849;
		}

		// Token: 0x06013FD5 RID: 81877 RVA: 0x005FFF44 File Offset: 0x005FE344
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9EA RID: 55786
		private int opl_p0;
	}
}
