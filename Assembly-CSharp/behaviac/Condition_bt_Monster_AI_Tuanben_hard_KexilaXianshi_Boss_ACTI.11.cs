using System;

namespace behaviac
{
	// Token: 0x02003C76 RID: 15478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node2 : Condition
	{
		// Token: 0x06016093 RID: 90259 RVA: 0x006A8E4A File Offset: 0x006A724A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570108;
		}

		// Token: 0x06016094 RID: 90260 RVA: 0x006A8E6C File Offset: 0x006A726C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F91E RID: 63774
		private BE_Target opl_p0;

		// Token: 0x0400F91F RID: 63775
		private BE_Equal opl_p1;

		// Token: 0x0400F920 RID: 63776
		private int opl_p2;
	}
}
