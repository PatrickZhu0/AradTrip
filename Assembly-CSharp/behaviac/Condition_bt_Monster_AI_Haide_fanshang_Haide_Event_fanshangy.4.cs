using System;

namespace behaviac
{
	// Token: 0x020033E9 RID: 13289
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node9 : Condition
	{
		// Token: 0x06015026 RID: 86054 RVA: 0x00654772 File Offset: 0x00652B72
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangyongshi_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2503;
		}

		// Token: 0x06015027 RID: 86055 RVA: 0x00654794 File Offset: 0x00652B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E912 RID: 59666
		private BE_Target opl_p0;

		// Token: 0x0400E913 RID: 59667
		private BE_Equal opl_p1;

		// Token: 0x0400E914 RID: 59668
		private int opl_p2;
	}
}
