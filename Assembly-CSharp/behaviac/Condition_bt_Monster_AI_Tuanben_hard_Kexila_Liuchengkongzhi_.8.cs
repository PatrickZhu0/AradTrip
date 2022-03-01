using System;

namespace behaviac
{
	// Token: 0x02003CFB RID: 15611
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node3 : Condition
	{
		// Token: 0x06016195 RID: 90517 RVA: 0x006AE238 File Offset: 0x006AC638
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570154;
		}

		// Token: 0x06016196 RID: 90518 RVA: 0x006AE25C File Offset: 0x006AC65C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA2E RID: 64046
		private BE_Target opl_p0;

		// Token: 0x0400FA2F RID: 64047
		private BE_Equal opl_p1;

		// Token: 0x0400FA30 RID: 64048
		private int opl_p2;
	}
}
