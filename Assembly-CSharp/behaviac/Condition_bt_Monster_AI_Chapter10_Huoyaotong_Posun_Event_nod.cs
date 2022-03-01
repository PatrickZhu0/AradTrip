using System;

namespace behaviac
{
	// Token: 0x0200311B RID: 12571
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Event_node1 : Condition
	{
		// Token: 0x06014ADD RID: 84701 RVA: 0x0063A39A File Offset: 0x0063879A
		public Condition_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522064;
		}

		// Token: 0x06014ADE RID: 84702 RVA: 0x0063A3BC File Offset: 0x006387BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E449 RID: 58441
		private BE_Target opl_p0;

		// Token: 0x0400E44A RID: 58442
		private BE_Equal opl_p1;

		// Token: 0x0400E44B RID: 58443
		private int opl_p2;
	}
}
