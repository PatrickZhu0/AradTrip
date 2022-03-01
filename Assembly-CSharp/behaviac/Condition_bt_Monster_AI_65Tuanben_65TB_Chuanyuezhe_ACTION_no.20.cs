using System;

namespace behaviac
{
	// Token: 0x02002B5B RID: 11099
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node2 : Condition
	{
		// Token: 0x06013FC4 RID: 81860 RVA: 0x005FFCC1 File Offset: 0x005FE0C1
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node2()
		{
			this.opl_p0 = 21846;
		}

		// Token: 0x06013FC5 RID: 81861 RVA: 0x005FFCD4 File Offset: 0x005FE0D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9E3 RID: 55779
		private int opl_p0;
	}
}
