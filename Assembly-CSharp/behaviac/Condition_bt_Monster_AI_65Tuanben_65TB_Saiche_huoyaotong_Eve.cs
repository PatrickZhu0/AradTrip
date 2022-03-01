using System;

namespace behaviac
{
	// Token: 0x02002BC6 RID: 11206
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node0 : Condition
	{
		// Token: 0x0601408E RID: 82062 RVA: 0x00604868 File Offset: 0x00602C68
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node0()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522225;
		}

		// Token: 0x0601408F RID: 82063 RVA: 0x0060488C File Offset: 0x00602C8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA7C RID: 55932
		private BE_Target opl_p0;

		// Token: 0x0400DA7D RID: 55933
		private BE_Equal opl_p1;

		// Token: 0x0400DA7E RID: 55934
		private int opl_p2;
	}
}
