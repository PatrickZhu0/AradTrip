using System;

namespace behaviac
{
	// Token: 0x02003E67 RID: 15975
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node9 : Condition
	{
		// Token: 0x06016451 RID: 91217 RVA: 0x006BBBEB File Offset: 0x006B9FEB
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node9()
		{
			this.opl_p0 = 7227;
		}

		// Token: 0x06016452 RID: 91218 RVA: 0x006BBC00 File Offset: 0x006BA000
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC95 RID: 64661
		private int opl_p0;
	}
}
