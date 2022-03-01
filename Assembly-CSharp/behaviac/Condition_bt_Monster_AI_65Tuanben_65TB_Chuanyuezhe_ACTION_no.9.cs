using System;

namespace behaviac
{
	// Token: 0x02002B45 RID: 11077
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node31 : Condition
	{
		// Token: 0x06013F98 RID: 81816 RVA: 0x005FF0F2 File Offset: 0x005FD4F2
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node31()
		{
			this.opl_p0 = 21844;
		}

		// Token: 0x06013F99 RID: 81817 RVA: 0x005FF108 File Offset: 0x005FD508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9BD RID: 55741
		private int opl_p0;
	}
}
