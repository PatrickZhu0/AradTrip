using System;

namespace behaviac
{
	// Token: 0x0200386A RID: 14442
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node16 : Condition
	{
		// Token: 0x060158B8 RID: 88248 RVA: 0x00680E22 File Offset: 0x0067F222
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node16()
		{
			this.opl_p0 = 0.14f;
		}

		// Token: 0x060158B9 RID: 88249 RVA: 0x00680E38 File Offset: 0x0067F238
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F262 RID: 62050
		private float opl_p0;
	}
}
