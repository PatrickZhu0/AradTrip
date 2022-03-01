using System;

namespace behaviac
{
	// Token: 0x02003949 RID: 14665
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node1 : Condition
	{
		// Token: 0x06015A6C RID: 88684 RVA: 0x0068A66B File Offset: 0x00688A6B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521645;
		}

		// Token: 0x06015A6D RID: 88685 RVA: 0x0068A68C File Offset: 0x00688A8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3F9 RID: 62457
		private BE_Target opl_p0;

		// Token: 0x0400F3FA RID: 62458
		private BE_Equal opl_p1;

		// Token: 0x0400F3FB RID: 62459
		private int opl_p2;
	}
}
