using System;

namespace behaviac
{
	// Token: 0x02003703 RID: 14083
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node17 : Action
	{
		// Token: 0x06015615 RID: 87573 RVA: 0x006732C9 File Offset: 0x006716C9
		public Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 540103;
		}

		// Token: 0x06015616 RID: 87574 RVA: 0x006732EA File Offset: 0x006716EA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFDD RID: 61405
		private BE_Target method_p0;

		// Token: 0x0400EFDE RID: 61406
		private int method_p1;
	}
}
