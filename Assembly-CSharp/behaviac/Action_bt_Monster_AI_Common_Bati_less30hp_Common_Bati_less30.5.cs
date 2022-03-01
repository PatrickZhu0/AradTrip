using System;

namespace behaviac
{
	// Token: 0x02003236 RID: 12854
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node5 : Action
	{
		// Token: 0x06014CEF RID: 85231 RVA: 0x00644FCF File Offset: 0x006433CF
		public Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 30;
			this.method_p2 = -1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014CF0 RID: 85232 RVA: 0x00645002 File Offset: 0x00643402
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E648 RID: 58952
		private BE_Target method_p0;

		// Token: 0x0400E649 RID: 58953
		private int method_p1;

		// Token: 0x0400E64A RID: 58954
		private int method_p2;

		// Token: 0x0400E64B RID: 58955
		private int method_p3;

		// Token: 0x0400E64C RID: 58956
		private int method_p4;
	}
}
