using System;

namespace behaviac
{
	// Token: 0x02002F1D RID: 12061
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node32 : Action
	{
		// Token: 0x06014710 RID: 83728 RVA: 0x00626521 File Offset: 0x00624921
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node32()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570283;
		}

		// Token: 0x06014711 RID: 83729 RVA: 0x00626542 File Offset: 0x00624942
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E087 RID: 57479
		private BE_Target method_p0;

		// Token: 0x0400E088 RID: 57480
		private int method_p1;
	}
}
