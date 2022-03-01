using System;

namespace behaviac
{
	// Token: 0x02003C7F RID: 15487
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node92 : Action
	{
		// Token: 0x060160A5 RID: 90277 RVA: 0x006A919A File Offset: 0x006A759A
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node92()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "你们都是坏人！";
			this.method_p1 = 4f;
			this.method_p2 = 0;
		}

		// Token: 0x060160A6 RID: 90278 RVA: 0x006A91C6 File Offset: 0x006A75C6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F939 RID: 63801
		private string method_p0;

		// Token: 0x0400F93A RID: 63802
		private float method_p1;

		// Token: 0x0400F93B RID: 63803
		private int method_p2;
	}
}
