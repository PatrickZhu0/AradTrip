using System;

namespace behaviac
{
	// Token: 0x02003845 RID: 14405
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node20 : Condition
	{
		// Token: 0x06015870 RID: 88176 RVA: 0x0067F1DE File Offset: 0x0067D5DE
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node20()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06015871 RID: 88177 RVA: 0x0067F1F4 File Offset: 0x0067D5F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F230 RID: 62000
		private float opl_p0;
	}
}
