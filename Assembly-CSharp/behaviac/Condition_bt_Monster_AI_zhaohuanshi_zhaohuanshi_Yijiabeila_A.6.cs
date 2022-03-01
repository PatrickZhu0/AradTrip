using System;

namespace behaviac
{
	// Token: 0x02004004 RID: 16388
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node24 : Condition
	{
		// Token: 0x0601676C RID: 92012 RVA: 0x006CC661 File Offset: 0x006CAA61
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node24()
		{
			this.opl_p0 = 5094;
		}

		// Token: 0x0601676D RID: 92013 RVA: 0x006CC674 File Offset: 0x006CAA74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFBC RID: 65468
		private int opl_p0;
	}
}
