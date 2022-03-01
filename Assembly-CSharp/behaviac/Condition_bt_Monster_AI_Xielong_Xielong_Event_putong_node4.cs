using System;

namespace behaviac
{
	// Token: 0x02003E3D RID: 15933
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4 : Condition
	{
		// Token: 0x060163FF RID: 91135 RVA: 0x006BA47F File Offset: 0x006B887F
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node4()
		{
			this.opl_p0 = 7082;
		}

		// Token: 0x06016400 RID: 91136 RVA: 0x006BA494 File Offset: 0x006B8894
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC5C RID: 64604
		private int opl_p0;
	}
}
