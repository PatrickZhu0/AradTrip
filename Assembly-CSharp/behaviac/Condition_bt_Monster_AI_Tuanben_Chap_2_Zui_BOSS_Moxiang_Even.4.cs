using System;

namespace behaviac
{
	// Token: 0x02003792 RID: 14226
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node8 : Condition
	{
		// Token: 0x06015729 RID: 87849 RVA: 0x00679135 File Offset: 0x00677535
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521627;
		}

		// Token: 0x0601572A RID: 87850 RVA: 0x00679158 File Offset: 0x00677558
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0DE RID: 61662
		private BE_Target opl_p0;

		// Token: 0x0400F0DF RID: 61663
		private BE_Equal opl_p1;

		// Token: 0x0400F0E0 RID: 61664
		private int opl_p2;
	}
}
