using System;

namespace behaviac
{
	// Token: 0x02002FA7 RID: 12199
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node60 : Condition
	{
		// Token: 0x0601481C RID: 83996 RVA: 0x0062B3DD File Offset: 0x006297DD
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node60()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601481D RID: 83997 RVA: 0x0062B3F0 File Offset: 0x006297F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E17E RID: 57726
		private float opl_p0;
	}
}
