using System;

namespace behaviac
{
	// Token: 0x02003478 RID: 13432
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node17 : Condition
	{
		// Token: 0x06015139 RID: 86329 RVA: 0x00659F1F File Offset: 0x0065831F
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node17()
		{
			this.opl_p0 = 6215;
		}

		// Token: 0x0601513A RID: 86330 RVA: 0x00659F34 File Offset: 0x00658334
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA39 RID: 59961
		private int opl_p0;
	}
}
