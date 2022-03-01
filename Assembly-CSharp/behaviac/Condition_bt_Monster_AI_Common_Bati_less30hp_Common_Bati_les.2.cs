using System;

namespace behaviac
{
	// Token: 0x02003225 RID: 12837
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS01_Event_node2 : Condition
	{
		// Token: 0x06014CD2 RID: 85202 RVA: 0x006447AB File Offset: 0x00642BAB
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS01_Event_node2()
		{
			this.opl_p0 = 0.015f;
		}

		// Token: 0x06014CD3 RID: 85203 RVA: 0x006447C0 File Offset: 0x00642BC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E624 RID: 58916
		private float opl_p0;
	}
}
