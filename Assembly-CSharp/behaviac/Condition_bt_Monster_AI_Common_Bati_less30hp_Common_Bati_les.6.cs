using System;

namespace behaviac
{
	// Token: 0x0200322D RID: 12845
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2 : Condition
	{
		// Token: 0x06014CE0 RID: 85216 RVA: 0x00644BB3 File Offset: 0x00642FB3
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2()
		{
			this.opl_p0 = 0.35f;
		}

		// Token: 0x06014CE1 RID: 85217 RVA: 0x00644BC8 File Offset: 0x00642FC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E636 RID: 58934
		private float opl_p0;
	}
}
