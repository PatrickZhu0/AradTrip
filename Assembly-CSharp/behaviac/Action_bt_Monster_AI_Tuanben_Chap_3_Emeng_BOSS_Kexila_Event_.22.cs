using System;

namespace behaviac
{
	// Token: 0x020038BF RID: 14527
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node44 : Action
	{
		// Token: 0x0601595D RID: 88413 RVA: 0x00683F8B File Offset: 0x0068238B
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_Hard_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570218;
		}

		// Token: 0x0601595E RID: 88414 RVA: 0x00683FAC File Offset: 0x006823AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F306 RID: 62214
		private BE_Target method_p0;

		// Token: 0x0400F307 RID: 62215
		private int method_p1;
	}
}
