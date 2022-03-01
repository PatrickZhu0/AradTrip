using System;

namespace behaviac
{
	// Token: 0x02003B5A RID: 15194
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node30 : Condition
	{
		// Token: 0x06015E69 RID: 89705 RVA: 0x0069DAFB File Offset: 0x0069BEFB
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node30()
		{
			this.opl_p0 = 21081;
		}

		// Token: 0x06015E6A RID: 89706 RVA: 0x0069DB10 File Offset: 0x0069BF10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F734 RID: 63284
		private int opl_p0;
	}
}
