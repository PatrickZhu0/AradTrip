using System;

namespace behaviac
{
	// Token: 0x0200384E RID: 14414
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node32 : Condition
	{
		// Token: 0x06015882 RID: 88194 RVA: 0x0067F592 File Offset: 0x0067D992
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node32()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015883 RID: 88195 RVA: 0x0067F5A8 File Offset: 0x0067D9A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F23C RID: 62012
		private float opl_p0;
	}
}
