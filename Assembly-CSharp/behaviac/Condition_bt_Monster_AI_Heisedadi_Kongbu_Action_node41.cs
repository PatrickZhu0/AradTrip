using System;

namespace behaviac
{
	// Token: 0x020034A4 RID: 13476
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node41 : Condition
	{
		// Token: 0x06015190 RID: 86416 RVA: 0x0065B875 File Offset: 0x00659C75
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node41()
		{
			this.opl_p0 = 6204;
		}

		// Token: 0x06015191 RID: 86417 RVA: 0x0065B888 File Offset: 0x00659C88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA93 RID: 60051
		private int opl_p0;
	}
}
