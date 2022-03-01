using System;

namespace behaviac
{
	// Token: 0x0200359A RID: 13722
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node11 : Condition
	{
		// Token: 0x06015364 RID: 86884 RVA: 0x00664A36 File Offset: 0x00662E36
		public Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node11()
		{
			this.opl_p0 = EventType.OnBackHit;
		}

		// Token: 0x06015365 RID: 86885 RVA: 0x00664A48 File Offset: 0x00662E48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED2C RID: 60716
		private EventType opl_p0;
	}
}
