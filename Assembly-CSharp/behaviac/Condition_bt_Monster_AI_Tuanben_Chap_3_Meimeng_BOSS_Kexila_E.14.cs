using System;

namespace behaviac
{
	// Token: 0x02003970 RID: 14704
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node3 : Condition
	{
		// Token: 0x06015AB7 RID: 88759 RVA: 0x0068B583 File Offset: 0x00689983
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x06015AB8 RID: 88760 RVA: 0x0068B5A4 File Offset: 0x006899A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F45E RID: 62558
		private HMType opl_p0;

		// Token: 0x0400F45F RID: 62559
		private BE_Operation opl_p1;

		// Token: 0x0400F460 RID: 62560
		private float opl_p2;
	}
}
