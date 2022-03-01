using System;

namespace behaviac
{
	// Token: 0x020030F5 RID: 12533
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Fangshenghua_Event_node2 : Condition
	{
		// Token: 0x06014A99 RID: 84633 RVA: 0x00638EDC File Offset: 0x006372DC
		public Condition_bt_Monster_AI_Chapter10_Fangshenghua_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522987;
		}

		// Token: 0x06014A9A RID: 84634 RVA: 0x00638F00 File Offset: 0x00637300
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E40D RID: 58381
		private BE_Target opl_p0;

		// Token: 0x0400E40E RID: 58382
		private BE_Equal opl_p1;

		// Token: 0x0400E40F RID: 58383
		private int opl_p2;
	}
}
