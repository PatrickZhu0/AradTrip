using System;

namespace behaviac
{
	// Token: 0x02003896 RID: 14486
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node61 : Condition
	{
		// Token: 0x06015910 RID: 88336 RVA: 0x00681F4E File Offset: 0x0068034E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node61()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015911 RID: 88337 RVA: 0x00681F64 File Offset: 0x00680364
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F2A1 RID: 62113
		private float opl_p0;
	}
}
