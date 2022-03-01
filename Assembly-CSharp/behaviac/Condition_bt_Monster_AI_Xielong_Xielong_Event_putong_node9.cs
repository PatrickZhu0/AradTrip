using System;

namespace behaviac
{
	// Token: 0x02003E43 RID: 15939
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9 : Condition
	{
		// Token: 0x0601640B RID: 91147 RVA: 0x006BA693 File Offset: 0x006B8A93
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node9()
		{
			this.opl_p0 = 7082;
		}

		// Token: 0x0601640C RID: 91148 RVA: 0x006BA6A8 File Offset: 0x006B8AA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC65 RID: 64613
		private int opl_p0;
	}
}
