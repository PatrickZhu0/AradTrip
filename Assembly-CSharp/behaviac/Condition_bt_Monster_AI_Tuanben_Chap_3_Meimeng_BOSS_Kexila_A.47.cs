using System;

namespace behaviac
{
	// Token: 0x02003918 RID: 14616
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node95 : Condition
	{
		// Token: 0x06015A0B RID: 88587 RVA: 0x00687B4E File Offset: 0x00685F4E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node95()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.85f;
		}

		// Token: 0x06015A0C RID: 88588 RVA: 0x00687B70 File Offset: 0x00685F70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3A3 RID: 62371
		private HMType opl_p0;

		// Token: 0x0400F3A4 RID: 62372
		private BE_Operation opl_p1;

		// Token: 0x0400F3A5 RID: 62373
		private float opl_p2;
	}
}
