using System;

namespace behaviac
{
	// Token: 0x02003977 RID: 14711
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node15 : Condition
	{
		// Token: 0x06015AC5 RID: 88773 RVA: 0x0068B7D5 File Offset: 0x00689BD5
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node15()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015AC6 RID: 88774 RVA: 0x0068B7F8 File Offset: 0x00689BF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F46B RID: 62571
		private HMType opl_p0;

		// Token: 0x0400F46C RID: 62572
		private BE_Operation opl_p1;

		// Token: 0x0400F46D RID: 62573
		private float opl_p2;
	}
}
