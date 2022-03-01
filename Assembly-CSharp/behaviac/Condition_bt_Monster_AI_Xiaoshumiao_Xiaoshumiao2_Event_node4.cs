using System;

namespace behaviac
{
	// Token: 0x02003E1C RID: 15900
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node4 : Condition
	{
		// Token: 0x060163C0 RID: 91072 RVA: 0x006B8FDD File Offset: 0x006B73DD
		public Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node4()
		{
			this.opl_p0 = 9757;
		}

		// Token: 0x060163C1 RID: 91073 RVA: 0x006B8FF0 File Offset: 0x006B73F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC28 RID: 64552
		private int opl_p0;
	}
}
