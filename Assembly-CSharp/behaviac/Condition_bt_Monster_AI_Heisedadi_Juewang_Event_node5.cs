using System;

namespace behaviac
{
	// Token: 0x02003480 RID: 13440
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node5 : Condition
	{
		// Token: 0x06015149 RID: 86345 RVA: 0x0065A1E7 File Offset: 0x006585E7
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node5()
		{
			this.opl_p0 = 6213;
		}

		// Token: 0x0601514A RID: 86346 RVA: 0x0065A1FC File Offset: 0x006585FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA4B RID: 59979
		private int opl_p0;
	}
}
