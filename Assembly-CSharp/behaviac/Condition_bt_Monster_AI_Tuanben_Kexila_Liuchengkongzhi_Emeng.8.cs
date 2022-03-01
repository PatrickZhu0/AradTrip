using System;

namespace behaviac
{
	// Token: 0x02003AB1 RID: 15025
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3 : Condition
	{
		// Token: 0x06015D24 RID: 89380 RVA: 0x00697CA8 File Offset: 0x006960A8
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570154;
		}

		// Token: 0x06015D25 RID: 89381 RVA: 0x00697CCC File Offset: 0x006960CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F643 RID: 63043
		private BE_Target opl_p0;

		// Token: 0x0400F644 RID: 63044
		private BE_Equal opl_p1;

		// Token: 0x0400F645 RID: 63045
		private int opl_p2;
	}
}
