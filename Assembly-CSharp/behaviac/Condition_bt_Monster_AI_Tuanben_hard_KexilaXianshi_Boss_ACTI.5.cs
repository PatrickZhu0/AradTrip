using System;

namespace behaviac
{
	// Token: 0x02003C6D RID: 15469
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node99 : Condition
	{
		// Token: 0x06016081 RID: 90241 RVA: 0x006A8A7B File Offset: 0x006A6E7B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node99()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570036;
		}

		// Token: 0x06016082 RID: 90242 RVA: 0x006A8A9C File Offset: 0x006A6E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F907 RID: 63751
		private BE_Target opl_p0;

		// Token: 0x0400F908 RID: 63752
		private BE_Equal opl_p1;

		// Token: 0x0400F909 RID: 63753
		private int opl_p2;
	}
}
