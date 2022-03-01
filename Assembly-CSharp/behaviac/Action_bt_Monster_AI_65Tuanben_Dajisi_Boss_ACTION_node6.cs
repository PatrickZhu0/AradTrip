using System;

namespace behaviac
{
	// Token: 0x02002D67 RID: 11623
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node6 : Action
	{
		// Token: 0x060143B0 RID: 82864 RVA: 0x00613ED6 File Offset: 0x006122D6
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x060143B1 RID: 82865 RVA: 0x00613EEC File Offset: 0x006122EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD7A RID: 56698
		private int method_p0;
	}
}
