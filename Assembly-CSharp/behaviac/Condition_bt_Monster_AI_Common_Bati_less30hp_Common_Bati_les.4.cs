using System;

namespace behaviac
{
	// Token: 0x02003229 RID: 12841
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS02_Event_node2 : Condition
	{
		// Token: 0x06014CD9 RID: 85209 RVA: 0x006449AF File Offset: 0x00642DAF
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS02_Event_node2()
		{
			this.opl_p0 = 0.025f;
		}

		// Token: 0x06014CDA RID: 85210 RVA: 0x006449C4 File Offset: 0x00642DC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E62D RID: 58925
		private float opl_p0;
	}
}
