using System;

namespace behaviac
{
	// Token: 0x02003919 RID: 14617
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node3 : Condition
	{
		// Token: 0x06015A0D RID: 88589 RVA: 0x00687BAF File Offset: 0x00685FAF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015A0E RID: 88590 RVA: 0x00687BD0 File Offset: 0x00685FD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3A6 RID: 62374
		private HMType opl_p0;

		// Token: 0x0400F3A7 RID: 62375
		private BE_Operation opl_p1;

		// Token: 0x0400F3A8 RID: 62376
		private float opl_p2;
	}
}
