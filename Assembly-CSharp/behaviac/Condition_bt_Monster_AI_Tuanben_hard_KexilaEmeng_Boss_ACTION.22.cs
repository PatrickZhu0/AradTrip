using System;

namespace behaviac
{
	// Token: 0x02003BA9 RID: 15273
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node29 : Condition
	{
		// Token: 0x06015F02 RID: 89858 RVA: 0x006A0A3A File Offset: 0x0069EE3A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node29()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06015F03 RID: 89859 RVA: 0x006A0A5C File Offset: 0x0069EE5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7A7 RID: 63399
		private HMType opl_p0;

		// Token: 0x0400F7A8 RID: 63400
		private BE_Operation opl_p1;

		// Token: 0x0400F7A9 RID: 63401
		private float opl_p2;
	}
}
