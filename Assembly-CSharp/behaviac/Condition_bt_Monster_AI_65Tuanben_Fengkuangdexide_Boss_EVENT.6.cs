using System;

namespace behaviac
{
	// Token: 0x02002EFD RID: 12029
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node25 : Condition
	{
		// Token: 0x060146D2 RID: 83666 RVA: 0x00624D9C File Offset: 0x0062319C
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node25()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570303;
		}

		// Token: 0x060146D3 RID: 83667 RVA: 0x00624DC0 File Offset: 0x006231C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E049 RID: 57417
		private BE_Target opl_p0;

		// Token: 0x0400E04A RID: 57418
		private BE_Equal opl_p1;

		// Token: 0x0400E04B RID: 57419
		private int opl_p2;
	}
}
