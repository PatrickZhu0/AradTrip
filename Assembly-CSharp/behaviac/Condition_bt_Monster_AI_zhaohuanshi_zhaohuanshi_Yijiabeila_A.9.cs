using System;

namespace behaviac
{
	// Token: 0x02004008 RID: 16392
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9 : Condition
	{
		// Token: 0x06016774 RID: 92020 RVA: 0x006CC815 File Offset: 0x006CAC15
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9()
		{
			this.opl_p0 = 5093;
		}

		// Token: 0x06016775 RID: 92021 RVA: 0x006CC828 File Offset: 0x006CAC28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFC4 RID: 65476
		private int opl_p0;
	}
}
