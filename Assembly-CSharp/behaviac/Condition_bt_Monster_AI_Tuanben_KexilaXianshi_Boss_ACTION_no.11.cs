using System;

namespace behaviac
{
	// Token: 0x02003A44 RID: 14916
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node2 : Condition
	{
		// Token: 0x06015C51 RID: 89169 RVA: 0x00693662 File Offset: 0x00691A62
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570108;
		}

		// Token: 0x06015C52 RID: 89170 RVA: 0x00693684 File Offset: 0x00691A84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F570 RID: 62832
		private BE_Target opl_p0;

		// Token: 0x0400F571 RID: 62833
		private BE_Equal opl_p1;

		// Token: 0x0400F572 RID: 62834
		private int opl_p2;
	}
}
