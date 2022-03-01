using System;

namespace behaviac
{
	// Token: 0x0200359C RID: 13724
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node12 : Action
	{
		// Token: 0x06015368 RID: 86888 RVA: 0x00664ADB File Offset: 0x00662EDB
		public Action_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x06015369 RID: 86889 RVA: 0x00664AFC File Offset: 0x00662EFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED30 RID: 60720
		private BE_Target method_p0;

		// Token: 0x0400ED31 RID: 60721
		private int method_p1;
	}
}
