using System;

namespace behaviac
{
	// Token: 0x02003C6B RID: 15467
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node97 : Condition
	{
		// Token: 0x0601607D RID: 90237 RVA: 0x006A89BB File Offset: 0x006A6DBB
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node97()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570034;
		}

		// Token: 0x0601607E RID: 90238 RVA: 0x006A89DC File Offset: 0x006A6DDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F901 RID: 63745
		private BE_Target opl_p0;

		// Token: 0x0400F902 RID: 63746
		private BE_Equal opl_p1;

		// Token: 0x0400F903 RID: 63747
		private int opl_p2;
	}
}
