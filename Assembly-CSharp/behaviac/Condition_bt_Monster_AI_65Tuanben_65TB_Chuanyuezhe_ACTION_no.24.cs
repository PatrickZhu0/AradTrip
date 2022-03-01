using System;

namespace behaviac
{
	// Token: 0x02002B65 RID: 11109
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node61 : Condition
	{
		// Token: 0x06013FD8 RID: 81880 RVA: 0x00600022 File Offset: 0x005FE422
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node61()
		{
			this.opl_p0 = 21852;
		}

		// Token: 0x06013FD9 RID: 81881 RVA: 0x00600038 File Offset: 0x005FE438
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9ED RID: 55789
		private int opl_p0;
	}
}
