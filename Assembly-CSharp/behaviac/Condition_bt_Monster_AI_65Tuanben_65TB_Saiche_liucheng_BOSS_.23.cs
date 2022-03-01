using System;

namespace behaviac
{
	// Token: 0x02002C0E RID: 11278
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node116 : Condition
	{
		// Token: 0x0601411B RID: 82203 RVA: 0x00605ED2 File Offset: 0x006042D2
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node116()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522200;
		}

		// Token: 0x0601411C RID: 82204 RVA: 0x00605EF4 File Offset: 0x006042F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAF3 RID: 56051
		private BE_Target opl_p0;

		// Token: 0x0400DAF4 RID: 56052
		private BE_Equal opl_p1;

		// Token: 0x0400DAF5 RID: 56053
		private int opl_p2;
	}
}
