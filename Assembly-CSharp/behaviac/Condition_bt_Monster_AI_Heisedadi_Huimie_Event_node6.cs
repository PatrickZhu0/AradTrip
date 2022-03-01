using System;

namespace behaviac
{
	// Token: 0x02003422 RID: 13346
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node6 : Condition
	{
		// Token: 0x06015093 RID: 86163 RVA: 0x0065683A File Offset: 0x00654C3A
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node6()
		{
			this.opl_p0 = 6220;
		}

		// Token: 0x06015094 RID: 86164 RVA: 0x00656850 File Offset: 0x00654C50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E963 RID: 59747
		private int opl_p0;
	}
}
