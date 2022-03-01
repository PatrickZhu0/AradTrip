using System;

namespace behaviac
{
	// Token: 0x02002EE6 RID: 12006
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node40 : Condition
	{
		// Token: 0x060146A6 RID: 83622 RVA: 0x006232C2 File Offset: 0x006216C2
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node40()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570297;
		}

		// Token: 0x060146A7 RID: 83623 RVA: 0x006232E4 File Offset: 0x006216E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E01E RID: 57374
		private BE_Target opl_p0;

		// Token: 0x0400E01F RID: 57375
		private BE_Equal opl_p1;

		// Token: 0x0400E020 RID: 57376
		private int opl_p2;
	}
}
