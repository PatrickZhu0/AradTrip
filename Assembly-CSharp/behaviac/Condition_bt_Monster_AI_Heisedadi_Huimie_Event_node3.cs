using System;

namespace behaviac
{
	// Token: 0x02003420 RID: 13344
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node3 : Condition
	{
		// Token: 0x0601508F RID: 86159 RVA: 0x006567A2 File Offset: 0x00654BA2
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node3()
		{
			this.opl_p0 = 6218;
		}

		// Token: 0x06015090 RID: 86160 RVA: 0x006567B8 File Offset: 0x00654BB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E961 RID: 59745
		private int opl_p0;
	}
}
