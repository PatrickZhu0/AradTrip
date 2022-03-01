using System;

namespace behaviac
{
	// Token: 0x02003C78 RID: 15480
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node72 : Condition
	{
		// Token: 0x06016097 RID: 90263 RVA: 0x006A8F0B File Offset: 0x006A730B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node72()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570033;
		}

		// Token: 0x06016098 RID: 90264 RVA: 0x006A8F2C File Offset: 0x006A732C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F924 RID: 63780
		private BE_Target opl_p0;

		// Token: 0x0400F925 RID: 63781
		private BE_Equal opl_p1;

		// Token: 0x0400F926 RID: 63782
		private int opl_p2;
	}
}
