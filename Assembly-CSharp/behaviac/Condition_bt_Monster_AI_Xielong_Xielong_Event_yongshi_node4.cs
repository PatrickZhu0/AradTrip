using System;

namespace behaviac
{
	// Token: 0x02003E61 RID: 15969
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node4 : Condition
	{
		// Token: 0x06016445 RID: 91205 RVA: 0x006BB9D7 File Offset: 0x006B9DD7
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node4()
		{
			this.opl_p0 = 7227;
		}

		// Token: 0x06016446 RID: 91206 RVA: 0x006BB9EC File Offset: 0x006B9DEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC8C RID: 64652
		private int opl_p0;
	}
}
