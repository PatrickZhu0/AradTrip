using System;

namespace behaviac
{
	// Token: 0x02002B58 RID: 11096
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node28 : Condition
	{
		// Token: 0x06013FBE RID: 81854 RVA: 0x005FFB55 File Offset: 0x005FDF55
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node28()
		{
			this.opl_p0 = 21850;
		}

		// Token: 0x06013FBF RID: 81855 RVA: 0x005FFB68 File Offset: 0x005FDF68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9DC RID: 55772
		private int opl_p0;
	}
}
