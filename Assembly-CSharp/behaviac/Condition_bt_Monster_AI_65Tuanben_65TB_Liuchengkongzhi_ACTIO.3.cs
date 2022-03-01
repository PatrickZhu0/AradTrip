using System;

namespace behaviac
{
	// Token: 0x02002BBC RID: 11196
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node1 : Condition
	{
		// Token: 0x0601407C RID: 82044 RVA: 0x0060424F File Offset: 0x0060264F
		public Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570292;
		}

		// Token: 0x0601407D RID: 82045 RVA: 0x00604270 File Offset: 0x00602670
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA72 RID: 55922
		private BE_Target opl_p0;

		// Token: 0x0400DA73 RID: 55923
		private BE_Equal opl_p1;

		// Token: 0x0400DA74 RID: 55924
		private int opl_p2;
	}
}
