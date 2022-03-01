using System;

namespace behaviac
{
	// Token: 0x0200378C RID: 14220
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node2 : Condition
	{
		// Token: 0x0601571D RID: 87837 RVA: 0x00678F6C File Offset: 0x0067736C
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521627;
		}

		// Token: 0x0601571E RID: 87838 RVA: 0x00678F90 File Offset: 0x00677390
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0D2 RID: 61650
		private BE_Target opl_p0;

		// Token: 0x0400F0D3 RID: 61651
		private BE_Equal opl_p1;

		// Token: 0x0400F0D4 RID: 61652
		private int opl_p2;
	}
}
