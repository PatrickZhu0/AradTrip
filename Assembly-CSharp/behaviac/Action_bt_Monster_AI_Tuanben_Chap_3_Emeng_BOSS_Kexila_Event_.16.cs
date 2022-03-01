using System;

namespace behaviac
{
	// Token: 0x020038B5 RID: 14517
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node53 : Action
	{
		// Token: 0x06015949 RID: 88393 RVA: 0x00683CAD File Offset: 0x006820AD
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node53()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570215;
		}

		// Token: 0x0601594A RID: 88394 RVA: 0x00683CCE File Offset: 0x006820CE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2F0 RID: 62192
		private BE_Target method_p0;

		// Token: 0x0400F2F1 RID: 62193
		private int method_p1;
	}
}
