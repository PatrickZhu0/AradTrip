using System;

namespace behaviac
{
	// Token: 0x02002C89 RID: 11401
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node30 : Condition
	{
		// Token: 0x06014209 RID: 82441 RVA: 0x0060B8CE File Offset: 0x00609CCE
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Action_node30()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601420A RID: 82442 RVA: 0x0060B904 File Offset: 0x00609D04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBC6 RID: 56262
		private int opl_p0;

		// Token: 0x0400DBC7 RID: 56263
		private int opl_p1;

		// Token: 0x0400DBC8 RID: 56264
		private int opl_p2;

		// Token: 0x0400DBC9 RID: 56265
		private int opl_p3;
	}
}
