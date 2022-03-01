using System;

namespace behaviac
{
	// Token: 0x0200379A RID: 14234
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node26 : Action
	{
		// Token: 0x06015739 RID: 87865 RVA: 0x00679439 File Offset: 0x00677839
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521666;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601573A RID: 87866 RVA: 0x00679470 File Offset: 0x00677870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0E8 RID: 61672
		private BE_Target method_p0;

		// Token: 0x0400F0E9 RID: 61673
		private int method_p1;

		// Token: 0x0400F0EA RID: 61674
		private int method_p2;

		// Token: 0x0400F0EB RID: 61675
		private int method_p3;

		// Token: 0x0400F0EC RID: 61676
		private int method_p4;
	}
}
