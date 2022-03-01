using System;

namespace behaviac
{
	// Token: 0x02003218 RID: 12824
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node3 : Condition
	{
		// Token: 0x06014CB9 RID: 85177 RVA: 0x0064406B File Offset: 0x0064246B
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014CBA RID: 85178 RVA: 0x0064408C File Offset: 0x0064248C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5FF RID: 58879
		private HMType opl_p0;

		// Token: 0x0400E600 RID: 58880
		private BE_Operation opl_p1;

		// Token: 0x0400E601 RID: 58881
		private float opl_p2;
	}
}
