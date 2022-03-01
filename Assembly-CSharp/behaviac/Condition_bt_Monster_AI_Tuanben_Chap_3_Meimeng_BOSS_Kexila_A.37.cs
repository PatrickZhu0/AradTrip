using System;

namespace behaviac
{
	// Token: 0x02003909 RID: 14601
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node77 : Condition
	{
		// Token: 0x060159ED RID: 88557 RVA: 0x0068749F File Offset: 0x0068589F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node77()
		{
			this.opl_p0 = 21201;
		}

		// Token: 0x060159EE RID: 88558 RVA: 0x006874B4 File Offset: 0x006858B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F388 RID: 62344
		private int opl_p0;
	}
}
