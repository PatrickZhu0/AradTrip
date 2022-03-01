using System;

namespace behaviac
{
	// Token: 0x02003875 RID: 14453
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node54 : Condition
	{
		// Token: 0x060158CE RID: 88270 RVA: 0x00681267 File Offset: 0x0067F667
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node54()
		{
			this.opl_p0 = 21219;
		}

		// Token: 0x060158CF RID: 88271 RVA: 0x0068127C File Offset: 0x0067F67C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F271 RID: 62065
		private int opl_p0;
	}
}
