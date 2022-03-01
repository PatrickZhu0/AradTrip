using System;

namespace behaviac
{
	// Token: 0x02003EB6 RID: 16054
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node31 : Condition
	{
		// Token: 0x060164EA RID: 91370 RVA: 0x006BEEB9 File Offset: 0x006BD2B9
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node31()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060164EB RID: 91371 RVA: 0x006BEECC File Offset: 0x006BD2CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD1F RID: 64799
		private float opl_p0;
	}
}
