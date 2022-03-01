using System;

namespace behaviac
{
	// Token: 0x0200384B RID: 14411
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node28 : Condition
	{
		// Token: 0x0601587C RID: 88188 RVA: 0x0067F456 File Offset: 0x0067D856
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601587D RID: 88189 RVA: 0x0067F46C File Offset: 0x0067D86C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F238 RID: 62008
		private float opl_p0;
	}
}
