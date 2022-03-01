using System;

namespace behaviac
{
	// Token: 0x0200385E RID: 14430
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node45 : Condition
	{
		// Token: 0x060158A2 RID: 88226 RVA: 0x0067FBBE File Offset: 0x0067DFBE
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node45()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x060158A3 RID: 88227 RVA: 0x0067FBD4 File Offset: 0x0067DFD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F253 RID: 62035
		private float opl_p0;
	}
}
