using System;

namespace behaviac
{
	// Token: 0x020033C8 RID: 13256
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node9 : Condition
	{
		// Token: 0x06014FE7 RID: 85991 RVA: 0x0065355A File Offset: 0x0065195A
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2502;
		}

		// Token: 0x06014FE8 RID: 85992 RVA: 0x0065357C File Offset: 0x0065197C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8D0 RID: 59600
		private BE_Target opl_p0;

		// Token: 0x0400E8D1 RID: 59601
		private BE_Equal opl_p1;

		// Token: 0x0400E8D2 RID: 59602
		private int opl_p2;
	}
}
