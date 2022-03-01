using System;

namespace behaviac
{
	// Token: 0x0200383B RID: 14395
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node49 : Condition
	{
		// Token: 0x0601585C RID: 88156 RVA: 0x0067EDDF File Offset: 0x0067D1DF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node49()
		{
			this.opl_p0 = 21216;
		}

		// Token: 0x0601585D RID: 88157 RVA: 0x0067EDF4 File Offset: 0x0067D1F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F223 RID: 61987
		private int opl_p0;
	}
}
