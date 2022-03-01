using System;

namespace behaviac
{
	// Token: 0x020036A3 RID: 13987
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node26 : Condition
	{
		// Token: 0x06015562 RID: 87394 RVA: 0x0066F8F5 File Offset: 0x0066DCF5
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node26()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521232;
		}

		// Token: 0x06015563 RID: 87395 RVA: 0x0066F918 File Offset: 0x0066DD18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF32 RID: 61234
		private BE_Target opl_p0;

		// Token: 0x0400EF33 RID: 61235
		private BE_Equal opl_p1;

		// Token: 0x0400EF34 RID: 61236
		private int opl_p2;
	}
}
