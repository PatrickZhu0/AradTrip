using System;

namespace behaviac
{
	// Token: 0x02003217 RID: 12823
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node1 : Condition
	{
		// Token: 0x06014CB7 RID: 85175 RVA: 0x0064400B File Offset: 0x0064240B
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570256;
		}

		// Token: 0x06014CB8 RID: 85176 RVA: 0x0064402C File Offset: 0x0064242C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5FC RID: 58876
		private BE_Target opl_p0;

		// Token: 0x0400E5FD RID: 58877
		private BE_Equal opl_p1;

		// Token: 0x0400E5FE RID: 58878
		private int opl_p2;
	}
}
