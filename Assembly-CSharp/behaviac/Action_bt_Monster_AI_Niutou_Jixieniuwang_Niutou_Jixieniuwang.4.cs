using System;

namespace behaviac
{
	// Token: 0x02003702 RID: 14082
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node16 : Action
	{
		// Token: 0x06015613 RID: 87571 RVA: 0x00673292 File Offset: 0x00671692
		public Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2;
		}

		// Token: 0x06015614 RID: 87572 RVA: 0x006732AF File Offset: 0x006716AF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFDB RID: 61403
		private BE_Target method_p0;

		// Token: 0x0400EFDC RID: 61404
		private int method_p1;
	}
}
