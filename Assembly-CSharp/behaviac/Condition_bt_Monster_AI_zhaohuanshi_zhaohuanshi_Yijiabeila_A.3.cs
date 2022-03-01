using System;

namespace behaviac
{
	// Token: 0x02004000 RID: 16384
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4 : Condition
	{
		// Token: 0x06016764 RID: 92004 RVA: 0x006CC4AD File Offset: 0x006CA8AD
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4()
		{
			this.opl_p0 = 5092;
		}

		// Token: 0x06016765 RID: 92005 RVA: 0x006CC4C0 File Offset: 0x006CA8C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFB4 RID: 65460
		private int opl_p0;
	}
}
