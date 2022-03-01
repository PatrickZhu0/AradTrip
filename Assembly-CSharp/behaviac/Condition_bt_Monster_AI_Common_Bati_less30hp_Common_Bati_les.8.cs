using System;

namespace behaviac
{
	// Token: 0x02003231 RID: 12849
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS04_Event_node2 : Condition
	{
		// Token: 0x06014CE7 RID: 85223 RVA: 0x00644DB7 File Offset: 0x006431B7
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS04_Event_node2()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06014CE8 RID: 85224 RVA: 0x00644DCC File Offset: 0x006431CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E63F RID: 58943
		private float opl_p0;
	}
}
