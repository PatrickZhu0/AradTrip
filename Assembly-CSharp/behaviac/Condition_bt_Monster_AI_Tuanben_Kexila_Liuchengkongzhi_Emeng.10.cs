using System;

namespace behaviac
{
	// Token: 0x02003AB4 RID: 15028
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9 : Condition
	{
		// Token: 0x06015D2A RID: 89386 RVA: 0x00697DFE File Offset: 0x006961FE
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570155;
		}

		// Token: 0x06015D2B RID: 89387 RVA: 0x00697E20 File Offset: 0x00696220
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F649 RID: 63049
		private BE_Target opl_p0;

		// Token: 0x0400F64A RID: 63050
		private BE_Equal opl_p1;

		// Token: 0x0400F64B RID: 63051
		private int opl_p2;
	}
}
