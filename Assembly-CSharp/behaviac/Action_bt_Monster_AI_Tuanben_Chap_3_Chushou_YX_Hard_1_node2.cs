using System;

namespace behaviac
{
	// Token: 0x02003836 RID: 14390
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_1_node2 : Action
	{
		// Token: 0x06015854 RID: 88148 RVA: 0x0067EBB2 File Offset: 0x0067CFB2
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_1_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521683;
			this.method_p2 = -1;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015855 RID: 88149 RVA: 0x0067EBE8 File Offset: 0x0067CFE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F219 RID: 61977
		private BE_Target method_p0;

		// Token: 0x0400F21A RID: 61978
		private int method_p1;

		// Token: 0x0400F21B RID: 61979
		private int method_p2;

		// Token: 0x0400F21C RID: 61980
		private int method_p3;

		// Token: 0x0400F21D RID: 61981
		private int method_p4;
	}
}
