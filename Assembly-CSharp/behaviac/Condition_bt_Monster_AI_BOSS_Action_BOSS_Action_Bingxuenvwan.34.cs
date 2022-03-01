using System;

namespace behaviac
{
	// Token: 0x02002F98 RID: 12184
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node45 : Condition
	{
		// Token: 0x060147FE RID: 83966 RVA: 0x0062ADE9 File Offset: 0x006291E9
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node45()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060147FF RID: 83967 RVA: 0x0062ADFC File Offset: 0x006291FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E163 RID: 57699
		private float opl_p0;
	}
}
