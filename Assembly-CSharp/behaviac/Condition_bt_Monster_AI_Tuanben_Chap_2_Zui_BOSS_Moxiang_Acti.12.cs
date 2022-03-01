using System;

namespace behaviac
{
	// Token: 0x0200375A RID: 14170
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node13 : Condition
	{
		// Token: 0x060156BB RID: 87739 RVA: 0x00676642 File Offset: 0x00674A42
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node13()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521625;
		}

		// Token: 0x060156BC RID: 87740 RVA: 0x00676664 File Offset: 0x00674A64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F08D RID: 61581
		private BE_Target opl_p0;

		// Token: 0x0400F08E RID: 61582
		private BE_Equal opl_p1;

		// Token: 0x0400F08F RID: 61583
		private int opl_p2;
	}
}
