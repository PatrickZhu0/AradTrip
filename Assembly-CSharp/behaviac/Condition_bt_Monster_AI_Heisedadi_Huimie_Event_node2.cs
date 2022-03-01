using System;

namespace behaviac
{
	// Token: 0x0200341F RID: 13343
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node2 : Condition
	{
		// Token: 0x0601508D RID: 86157 RVA: 0x00656757 File Offset: 0x00654B57
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node2()
		{
			this.opl_p0 = 6217;
		}

		// Token: 0x0601508E RID: 86158 RVA: 0x0065676C File Offset: 0x00654B6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E960 RID: 59744
		private int opl_p0;
	}
}
