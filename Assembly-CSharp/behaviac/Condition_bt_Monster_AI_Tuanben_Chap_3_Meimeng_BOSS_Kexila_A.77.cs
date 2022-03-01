using System;

namespace behaviac
{
	// Token: 0x02003944 RID: 14660
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node60 : Condition
	{
		// Token: 0x06015A63 RID: 88675 RVA: 0x00688DA6 File Offset: 0x006871A6
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node60()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015A64 RID: 88676 RVA: 0x00688DBC File Offset: 0x006871BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3ED RID: 62445
		private float opl_p0;
	}
}
